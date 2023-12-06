using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.BoxWidget
{
    public class SocialMediaBoxWidget : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
