using BlogProject.Models;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogProject.Controllers
{
    public class HomeController : Controller
    {
        BlogManager BlogManager = new BlogManager(new EfBlogRepository());
        BlogTagManager BlogTagManager = new BlogTagManager(new EfBlogTagRepository());

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            var baseUri = $"{Request.Scheme}://{Request.Host}/";
            List<Blog> blogList = new List<Blog>();
            blogList = BlogManager.GetBlogListWithCategory(bl => bl.ObjectStatus == 1).OrderByDescending(x=>x.ObjectId).Take(7).ToList();
            foreach (var item in blogList)
            {
                item.ThumbnailImage = item.ThumbnailImage.Replace( @"\", @"/");
                item.ThumbnailImage = baseUri + item.ThumbnailImage;
                item.MainImage= baseUri + item.MainImage;
            }
            return View(blogList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
