using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnLibrary.Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class PublicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
