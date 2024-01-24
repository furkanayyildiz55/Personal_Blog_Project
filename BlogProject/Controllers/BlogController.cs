using BlogProject.DTO;
using BlogProject.ViewModels;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Specialized;
using System;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using BlogProject.Constants;
using BlogProject.Helper;

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

            SelectListItem selectListItemDefault = new SelectListItem();
            selectListItemDefault.Text = "Seçiniz";
            selectListItemDefault.Value = "0";
            CategoryItem.Add(selectListItemDefault);
            TagItem.Add(selectListItemDefault);


            FilterBlogListViewModel filterBlogListViewModel = new FilterBlogListViewModel(CategoryItem, TagItem);
            return filterBlogListViewModel;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string Title = "";
            int Category = 0, Tag = 0, Order = 0;
            bool QueryStatus= Request.QueryString.HasValue;
            if (QueryStatus)
            {
                Title = Request.Query["Title"].ToString();
                Category = Request.Query["Category"].ToString() == "" ? 0 : int.Parse(Request.Query["Category"].ToString());
                Tag = Request.Query["Tag"].ToString() == "" ? 0 : int.Parse(Request.Query["Tag"].ToString());
                Order = Request.Query["Order"].ToString() == "" ? 0 : int.Parse(Request.Query["Order"].ToString());
            }
            FilterBlogListViewModel filterBlogListViewModel = FilterBlogListViewModel();

            List<Blog> blogList = BlogManager.GetBlogListWithCategory();


            if (QueryStatus)
            {
                if (Title != "")
                    blogList = blogList.Where(bl => bl.Title.Contains(Title)).ToList();
                if (Category != 0)
                    blogList = blogList.Where(bl => bl.CategoryId == Category).ToList();

                if (Tag != 0)
                {
                    List<int> TagIds = BlogTagManager.GetList(tg => tg.TagId == Tag).Select(tg => tg.BlogId).ToList();
                    blogList = blogList.Where(bl => TagIds.Contains(bl.ObjectId)).ToList();
                }

                if (Order != 0)
                {
                    if (Order == (int)Enums.Order.MostRead)
                        blogList = blogList.OrderByDescending(bl => bl.ViewsCount).ToList();
                    else if (Order == (int)Enums.Order.MostCommented)
                        blogList = blogList.OrderByDescending(bl => bl.CommnetCount).ToList();
                    else if (Order == (int)Enums.Order.NewestUploadDate)
                        blogList = blogList.OrderByDescending(bl => bl.ObjectIDate).ToList();
                    else if (Order == (int)Enums.Order.OldestUploadDate)
                        blogList = blogList.OrderBy(bl => bl.ObjectIDate).ToList();
                }

                filterBlogListViewModel.Title = Title;
                filterBlogListViewModel.CategryId = Category;
                filterBlogListViewModel.TagId = Tag;
                filterBlogListViewModel.OrderId = Order;
            }
            foreach (var blog in blogList)
            {
                blog.ThumbnailImage = Util.BaseUrl(Request) + blog.ThumbnailImage;
            }

            filterBlogListViewModel.Blogs = blogList;
            return View(filterBlogListViewModel);
        }


        #region BlogDetayı
        public  IActionResult Detail(string? title)
        {
            if(title == null)
            {
                return NotFound();
            }

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
            blogListDTO.Blog.MainImage = Util.BaseUrl(Request) + blogListDTO.Blog.MainImage;



            return View(blogListDTO);
        }
        #endregion
    }
}
