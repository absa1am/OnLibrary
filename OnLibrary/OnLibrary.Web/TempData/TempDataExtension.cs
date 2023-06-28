using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Json;

namespace OnLibrary.Web.TempData
{
    public static class TempDataExtension
    {
        public static void Put<T>(this ITempDataDictionary data, string key, T value) where T : class
        {
            data[key] = JsonSerializer.Serialize(value);
        }

        public static T Get<T>(this ITempDataDictionary data, string key) where T : class
        {
            data.TryGetValue(key, out object response);

            return response == null ? null : JsonSerializer.Deserialize<T>((string) response);
        }

        public static T Peek<T>(this ITempDataDictionary data, string key) where T : class
        {
            object response = data.Peek(key);

            return response == null ? null : JsonSerializer.Deserialize<T>((string) response);
        }
    }
}
