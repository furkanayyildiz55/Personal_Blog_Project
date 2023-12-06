using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.BoxWidget
{
    public class PopularResentBlogBoxWidget : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
