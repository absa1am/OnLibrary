using Autofac;
using Microsoft.AspNetCore.Mvc;
using OnLibrary.Infrastructure;
using OnLibrary.Web.Areas.Admin.Models.Books;
using OnLibrary.Web.Models;
using System.Diagnostics;

namespace OnLibrary.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ILifetimeScope scope)
        {
            _scope = scope;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetBooks()
        {
            var dataTables = new DataAjaxRequest(Request);
            var model = _scope.Resolve<ViewBookModel>();
            var data = await model.GetPagedBooksAsync(dataTables);

            return Json(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}