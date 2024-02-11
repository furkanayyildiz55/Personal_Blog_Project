using BlogProject.Helper;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.BoxWidget
{
    public class EditorsChoiceBoxWidget : ViewComponent
    {
        BlogManager BlogManager = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            var baseUri = Util.BaseUrl(Request);
            List<Blog> blogList = new List<Blog>();
            blogList = BlogManager.GetBlogListWithCategory(bl => bl.ObjectStatus == 1)
                .OrderByDescending(x => x.ObjectId)
                .Take(2)
                .ToList();
            foreach (var item in blogList)
            {
                item.ThumbnailImage = baseUri + item.ThumbnailImage;
                item.MainImage = baseUri + item.MainImage;
            }

            return View(blogList);
        }
    }
}
