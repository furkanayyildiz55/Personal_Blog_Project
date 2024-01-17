using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index(int code)
        {
            ViewBag.ErrorCode = code;
            return View();
        }
    }
}
