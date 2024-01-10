using BlogProject.DTO;
using BlogProject.ViewModels;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata;

namespace BlogProject.Controllers
{
    public class BlogController : Controller
    {
        BlogManager BlogManager = new BlogManager(new EfBlogRepository());
        BlogTagManager BlogTagManager = new BlogTagManager(new EfBlogTagRepository());
        CategoryManager CategoryManager = new CategoryManager(new EfCategoryRepository());
        TagManager TagManager = new TagManager(new EfTagRepository());

        private FilterBlogListViewModel FilterBlogListViewModel()
        {
            List<Category> Category = CategoryManager.GetList();
            List<Tag> Tag = TagManager.GetList();

            List<SelectListItem> CategoryItem = new List<SelectListItem>();
            List<SelectListItem> TagItem = new List<SelectListItem>();

            foreach (var item in Category)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = item.Name;
                selectListItem.Value = item.ObjectId.ToString();
                CategoryItem.Add(selectListItem);
            }

            foreach (var item in Tag)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = item.Name;
                selectListItem.Value = item.ObjectId.ToString();
                TagItem.Add(selectListItem);
            }

            FilterBlogListViewModel filterBlogListViewModel = new FilterBlogListViewModel(CategoryItem, TagItem);
            return filterBlogListViewModel;
        }

        [HttpGet]
        public IActionResult Index()
        {
            FilterBlogListViewModel filterBlogListViewModel = FilterBlogListViewModel();
            return View(filterBlogListViewModel);
        }

        [HttpPost]
        public IActionResult Index(string? parameters)
        {

            return View();
        }

        #region BlogDetayı

        public  IActionResult Detail(string? title)
        {
            if(title == null)
            {
                return NotFound();
            }

            var baseUri = $"{Request.Scheme}://{Request.Host}/";
            BlogListDTO blogListDTO = new BlogListDTO();
            blogListDTO.Blog = BlogManager.GetBlogWithCategory(b => b.UrlTitle == title);
            blogListDTO.Tags = BlogTagManager.GetListWithTag(bt => bt.BlogId == blogListDTO.Blog.ObjectId);
            if (blogListDTO.Blog == null)
            {
                return NotFound();
            }
            //TODO : Update metodu async olarak düzenlenecek
            blogListDTO.Blog.ViewsCount += 1;
            BlogManager.Update(blogListDTO.Blog);
            blogListDTO.Blog.MainImage = baseUri + blogListDTO.Blog.MainImage;



            return View(blogListDTO);
        }
        #endregion
    }
}
