using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnLibrary.Web.Areas.Admin.Models.Authors;

namespace OnLibrary.Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class AuthorController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(ILifetimeScope scope, ILogger<AuthorController> logger)
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
            var model = _scope.Resolve<CreateAuthorModel>();

            return View(model);
        }
    }
}
