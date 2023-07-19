using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Text;

namespace OnLibrary.Infrastructure
{
    public class DataAjaxRequest
    {
        private HttpRequest _request;

        public DataAjaxRequest(HttpRequest request) => _request = request;

        private int Start
        {
            get => Convert.ToInt32(_request.Query["start"]);
        }

        private int Length
        {
            get => Convert.ToInt32(_request.Query["length"]);
        }

        public string SearchText
        {
            get => _request.Query["search[value]"];
        }

        public int PageIndex
        {
            get
            {
                if (Length > 0)
                    return (Start / Length) + 1;

                return 1;
            }
        }

        public int PageSize
        {
            get => (Length == 0) ? 10 : Length;
        }

        public static object EmptyResult
        {
            get
            {
                return new
                {
                    recordsTotal = 0,
                    recordsFiltered = 0,
                    data = (new string[] { }).ToArray()
                };
            }
        }

        private string ReadValues(IEnumerable<KeyValuePair<string, StringValues>> requestValues, string[] columnNames)
        {
            var sortText = new StringBuilder();

            for (int i = 0; i < columnNames.Length; i++)
            {
                if (requestValues.Any(x => x.Key == $"order[{i}][column]"))
                {
                    if (sortText.Length > 0)
                        sortText.Append(",");

                    var columnvalue = requestValues.Where(x => x.Key == $"order[{i}][column]").FirstOrDefault();
                    var column = int.Parse(columnvalue.Value.ToArray()[0]);

                    var directionvalue = requestValues.Where(x => x.Key == $"order[{i}][dir]").FirstOrDefault();
                    var direction = directionvalue.Value.ToArray()[0];
                    var sortDirection = $"{columnNames[column]} {(direction == "asc" ? "asc" : "desc")}";

                    sortText.Append(sortDirection);
                }
            }

            return sortText.ToString();
        }

        public string GetSortText(string[] columnNames)
        {
            var method = _request.Method.ToLower();

            if (method == "get")
                return ReadValues(_request.Query, columnNames);
            else if (method == "post")
                return ReadValues(_request.Form, columnNames);
            else throw new InvalidOperationException("Use get or post");
        }

    }
}
