using BlogProject.ViewModels;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace BlogProject.Controllers
{
    public class AdminController : Controller
    {
        CategoryManager CategoryManager = new CategoryManager(new EfCategoryRepository());
        TagManager TagManager = new TagManager(new EfTagRepository());
        BlogTagManager BlogTagManager = new BlogTagManager(new EfBlogTagRepository());
        BlogManager BlogManager = new BlogManager(new EfBlogRepository());

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            return View(CreateAddBlogViewModel());
        }

        private AddBlogViewModel CreateAddBlogViewModel()
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

            AddBlogViewModel AddBlogViewModel = new AddBlogViewModel(CategoryItem, TagItem);
            return AddBlogViewModel;
        }

        [HttpPost]
        public async Task<IActionResult> AddBlogAsync(AddBlogViewModel addBlogViewModel)
        {
            IFormFile file = addBlogViewModel.FormFile;
            KeyValuePair<bool, string> fileStatus;
            if (file != null)
            {
                string FileExt = Path.GetExtension(file.FileName);
                long FileLength = file.Length;
                if (FileExt == ".png" || FileExt == ".jpg")
                {
                    if (FileLength <= 5242880)  //5 Mb dan küçük
                    {
                        var ImageNanme = Guid.NewGuid() + FileExt;
                        
                        var ImageLocation = "BlogImage/" + ImageNanme;
                        var ImageSaveLocation = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/" + ImageLocation);
                        using (var stream = new FileStream(ImageSaveLocation, FileMode.Create))
                        {
                            await addBlogViewModel.FormFile.CopyToAsync(stream);
                        }

                        addBlogViewModel.Blog.MainImage = ImageLocation;
                        addBlogViewModel.Blog.ThumbnailImage = ImageLocation;
                        fileStatus = new KeyValuePair<bool, string>(true, "");
                    }
                    else
                        fileStatus = new KeyValuePair<bool, string>(false, "Görsel Boyutu 5 Mb dan küçük olmalı !");
                }
                else
                    fileStatus = new KeyValuePair<bool, string>(false, "Lütfen PNG veya JPG biçiminde görsel yükleyin !");
            }
            else
                fileStatus = new KeyValuePair<bool, string>(false, "Lütfen görsel yükleyiniz !");


            BlogValidator validationRules = new BlogValidator();
            ValidationResult result = validationRules.Validate(addBlogViewModel.Blog);

            if (result.IsValid && fileStatus.Key)
            {
                //BLOG KAYIT 
                addBlogViewModel.Blog.WriterId = 3;

                BlogManager.Add(addBlogViewModel.Blog);

                foreach (int id in addBlogViewModel.TagItemIds)
                {
                    BlogTag blogTag = new BlogTag();
                    blogTag.TagId = id;
                    blogTag.BlogId = addBlogViewModel.Blog.ObjectId;
                    BlogTagManager.Add(blogTag);
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(CreateAddBlogViewModel());
            }

            return View(CreateAddBlogViewModel());
        }
    }
}
