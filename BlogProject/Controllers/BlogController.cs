using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class BlogController : Controller
    {
        BlogManager BlogManager = new BlogManager(new EfBlogRepository());

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Detail()
        {
            var baseUri = $"{Request.Scheme}://{Request.Host}/";
            Blog blog = BlogManager.GetByID(11);
            blog.MainImage = baseUri + blog.MainImage;
            return View(blog);
        }
    }
}
