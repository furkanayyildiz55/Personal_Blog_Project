using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.BoxWidget
{
    public class EditorsChoiceBoxWidget : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
