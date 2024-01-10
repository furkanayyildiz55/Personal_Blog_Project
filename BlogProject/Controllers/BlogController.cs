using BlogProject.DTO;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace BlogProject.Controllers
{
    public class BlogController : Controller
    {
        BlogManager BlogManager = new BlogManager(new EfBlogRepository());
        BlogTagManager BlogTagManager = new BlogTagManager(new EfBlogTagRepository());


        public IActionResult Index()
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
