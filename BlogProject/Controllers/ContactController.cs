using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
