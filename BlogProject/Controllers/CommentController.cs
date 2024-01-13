using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class CommentController : Controller
    {
        [HttpPost]
        public IActionResult AddComment(Comment comment )
        {
            return RedirectToAction("Blog");
        }
    }
}
