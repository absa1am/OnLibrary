using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnLibrary.Web.Areas.Admin.Models.Books;
using OnLibrary.Web.Models;
using OnLibrary.Web.TempData;

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

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookModel model)
        {
            model.ResolveDependency(_scope);

            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateBook();

                    TempData.Put<ResponseModel>("Message", new ResponseModel
                    {
                        Message = "Book created to the database.",
                        Type = ResponseType.Success
                    });

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Unable to create Book.");

                    TempData.Put<ResponseModel>("Message", new ResponseModel
                    {
                        Message = "Unable to create Book.",
                        Type = ResponseType.Danger
                    });
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var model = _scope.Resolve<UpdateBookModel>();

            model.Load(id);

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateBookModel model)
        {
            model.ResolveDependency(_scope);

            if (ModelState.IsValid)
            {
                try
                {
                    model.UpdateBook();

                    TempData.Put<ResponseModel>("Message", new ResponseModel
                    {
                        Message = "Book updated to the database.",
                        Type = ResponseType.Success
                    });
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Unable to update Book.");

                    TempData.Put<ResponseModel>("Message", new ResponseModel
                    {
                        Message = "Unable to update Book.",
                        Type = ResponseType.Danger
                    });
                }
            }

            return View(model);
        }
    }
}
