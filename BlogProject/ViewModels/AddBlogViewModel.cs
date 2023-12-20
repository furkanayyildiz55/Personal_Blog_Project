using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogProject.ViewModels
{
    public class AddBlogViewModel
    {
        public AddBlogViewModel(List<SelectListItem> categoryItem, List<SelectListItem> tagItem, Blog blog)
        {
            CategoryItem = categoryItem;
            TagItem = tagItem;
            Blog = blog;
        }

        public AddBlogViewModel(List<SelectListItem> categoryItem, List<SelectListItem> tagItem)
        {
            CategoryItem = categoryItem;
            TagItem = tagItem;
        }

        public List<SelectListItem> CategoryItem { get; set; }
        public List<SelectListItem> TagItem { get; set; }
        public Blog Blog { get; set; }
    }
}
