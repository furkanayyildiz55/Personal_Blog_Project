using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.BoxWidget
{
    public class PopularTagsBoxWidget : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
