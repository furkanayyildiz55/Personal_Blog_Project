using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.FormWidget
{
    public class SubscribeFormWidget : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
