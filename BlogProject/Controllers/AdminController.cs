using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddBlog()
        {
            return View();
        }
    }
}
