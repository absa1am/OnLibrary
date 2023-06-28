using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnLibrary.Web.Areas.Admin.Models.Books;

namespace OnLibrary.Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class BookController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<BookController> _logger;

        public BookController(ILifetimeScope scope, ILogger<BookController> logger)
        {
            _scope = scope;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = _scope.Resolve<CreateBookModel>();

            return View(model);
        }
    }
}
