using BlogProject.ViewModels.ComponentViewModel;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.BoxWidget
{
    public class PopularTagsBoxWidget : ViewComponent
    {
        BlogTagManager BlogTagManager = new BlogTagManager(new EfBlogTagRepository());

        public IViewComponentResult Invoke()
        {
            List<PopularTagBoxViewModel> blogTags = BlogTagManager.GetListWithTag(bt => bt.ObjectStatus == 1)
                .GroupBy(p => p.TagId)
                .Select(group => new PopularTagBoxViewModel
                {
                    TagName = group.First().Tags.Name,
                    TagUsingCount = group.Count()
                }).Take(8).ToList();
            
            return View(blogTags);
        }
    }
}
