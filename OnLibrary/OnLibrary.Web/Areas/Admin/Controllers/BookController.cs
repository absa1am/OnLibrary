using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnLibrary.Infrastructure;
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
            var model = _scope.Resolve<ViewBookModel>();

            return View(model);
        }

        public async Task<JsonResult> GetBooks()
        {
            var dataTables = new DataAjaxRequest(Request);
            var model = _scope.Resolve<ViewBookModel>();
            var data = await model.GetPagedBooksAsync(dataTables);

            return Json(data);
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

                    return RedirectToAction("Index");
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


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id)
        {
            var model = _scope.Resolve<ViewBookModel>();

            if (ModelState.IsValid)
            {
                try
                {
                    model.DeleteBook(id);

                    TempData.Put<ResponseModel>("Message", new ResponseModel()
                    {
                        Message = "Book deleted from database.",
                        Type = ResponseType.Success
                    });
                }
                catch (Exception e)
                {
                    _logger.LogError(e, e.Message);

                    TempData.Put<ResponseModel>("Message", new ResponseModel()
                    {
                        Message = "Unable to delete book",
                        Type = ResponseType.Danger
                    });
                }
            }

            return RedirectToAction("Index");
        }
    }
}
