using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.BoxWidget
{
    public class BlogTitleSlider : ViewComponent
    {
        BlogManager BlogManager = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            List<Blog> blogList = BlogManager.GetList(bl => bl.ObjectStatus == 1)
                .OrderByDescending(bl => bl.ObjectIDate)
                .Take(3)
                .ToList();
            return View(blogList);
        }
    }
}
