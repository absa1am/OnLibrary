using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnLibrary.Web.Areas.Admin.Models.Publications;
using OnLibrary.Web.Models;
using OnLibrary.Web.TempData;

namespace OnLibrary.Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class PublicationController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<PublicationController> _logger;

        public PublicationController(ILifetimeScope scope, ILogger<PublicationController> logger)
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
            var model = _scope.Resolve<CreatePublicationModel>();

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePublicationModel model)
        {
            model.ResolveDependency(_scope);

            if (ModelState.IsValid)
            {
                try
                {
                    model.CreatePublication();

                    TempData.Put<ResponseModel>("Message", new ResponseModel
                    {
                        Message = "Publication created to the database.",
                        Type = ResponseType.Success
                    });

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Unable to create publication.");

                    TempData.Put<ResponseModel>("Message", new ResponseModel
                    {
                        Message = "Unable to create publication.",
                        Type = ResponseType.Danger
                    });
                }
            }

            return View(model);
        }
    }
}
