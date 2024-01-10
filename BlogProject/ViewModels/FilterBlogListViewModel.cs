using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogProject.ViewModels
{
    public class FilterBlogListViewModel
    {
        public FilterBlogListViewModel(List<SelectListItem> categoryItem, List<SelectListItem> tagItem, List<Blog> blogList)
        {
            CategoryItem = categoryItem;
            TagItem = tagItem;
            Blogs = blogList;
        }

        public FilterBlogListViewModel(List<SelectListItem> categoryItem, List<SelectListItem> tagItem)
        {
            CategoryItem = categoryItem;
            TagItem = tagItem;
        }

        public string Title { get; set; }
        public int CategryId { get; set; }
        public int TagId { get; set; }
        public int OrderId { get; set; }

        public List<SelectListItem> CategoryItem { get; set; }
        public List<SelectListItem> TagItem { get; set; }
        public List<Blog> Blogs { get; set; }

    }
}
