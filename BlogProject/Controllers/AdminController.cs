using BlogProject.DTO;
using BlogProject.Helper;
using BlogProject.ViewModels;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mono.TextTemplating;
using System.IO;

namespace BlogProject.Controllers
{
    public class AdminController : Controller
    {
        CategoryManager CategoryManager = new CategoryManager(new EfCategoryRepository());
        TagManager TagManager = new TagManager(new EfTagRepository());
        BlogTagManager BlogTagManager = new BlogTagManager(new EfBlogTagRepository());
        BlogManager BlogManager = new BlogManager(new EfBlogRepository());

        #region YardımcıFonksiyonlar
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

        private  KeyValuePair<bool, string> FileUpload(IFormFile file, string folderName, bool continues = true)
        {
            KeyValuePair<bool, string> fileStatus = new KeyValuePair<bool, string>(false, ""); ;
            try
            {
                if (continues && file != null)
                {
                    string FileExt = Path.GetExtension(file.FileName);
                    string FileName = Path.GetFileNameWithoutExtension(file.FileName);
                    long FileLength = file.Length;


                    string time = DateTime.Now.ToString("dd-MM-yyyy");
                    var subfolderName = Path.Combine("BlogImage", folderName);

                    var ImageName = FileName + "-T-" + time + FileExt;
                    var ImageLocation = Path.Combine(subfolderName, ImageName);

                    var ImageSaveLocation = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", subfolderName, ImageName);

                    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", subfolderName)))
                    {
                        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", subfolderName));
                    }

                    using (var stream = new FileStream(ImageSaveLocation, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    fileStatus = new KeyValuePair<bool, string>(true, ImageLocation);

                }
                else
                    fileStatus = new KeyValuePair<bool, string>(false, "Lütfen görsel yükleyiniz !");

                return fileStatus;
            }
            catch (Exception ex)
            {
                return new KeyValuePair<bool, string>(false, $"Bir sorun oluştu ! {ex.Message} ");
            }
        }
        private KeyValuePair<bool, string> FileStatus(IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    string FileExt = Path.GetExtension(file.FileName);
                    long FileLength = file.Length;

                    if (FileExt == ".png" || FileExt == ".jpg")
                    {
                        if (FileLength <= 5242880) // 5 Mb dan 
                            return new KeyValuePair<bool, string>(true, "");
                        else
                            return new KeyValuePair<bool, string>(false, "Görsel Boyutu 5 Mb dan küçük olmalı !");
                    }
                    else
                        return new KeyValuePair<bool, string>(false, "Lütfen PNG veya JPG biçiminde görsel yükleyin !");
                }
                else
                    return new KeyValuePair<bool, string>(false, "Lütfen görsel yükleyiniz !");

            }
            catch (Exception ex)
            {
                return new KeyValuePair<bool, string>(false, $"Bir sorun oluştu ! {ex.Message} ");
            }
        }

        #endregion

        public IActionResult Index()
        {
            return View();
        }

        #region Add Blog

        [HttpGet]
        public IActionResult AddBlog()
        {
            return View(CreateAddBlogViewModel());
        }

        [HttpPost]
        public IActionResult AddBlogAsync(AddBlogViewModel addBlogViewModel)
        {
            addBlogViewModel.Blog.UrlTitle = Util.UrlFormating(addBlogViewModel.Blog.Title!);
            BlogValidator validationRules = new BlogValidator();
            ValidationResult result = validationRules.Validate(addBlogViewModel.Blog);

            var fileStatus = FileStatus(addBlogViewModel.FormFile);

            if (result.IsValid && fileStatus.Key)
            {
                //Blog Kayıt 
                addBlogViewModel.Blog.WriterId = 3;
                BlogManager.Add(addBlogViewModel.Blog);

                foreach (int id in addBlogViewModel.TagItemIds)
                {
                    BlogTag blogTag = new BlogTag();
                    blogTag.TagId = id;
                    blogTag.BlogId = addBlogViewModel.Blog.ObjectId;
                    BlogTagManager.Add(blogTag);
                }

                //Görsel Yüklenmesi
                var fileUpload = FileUpload(addBlogViewModel.FormFile, addBlogViewModel.Blog.ObjectId.ToString());
                if (fileUpload.Key)
                {
                    addBlogViewModel.Blog.MainImage = fileUpload.Value;
                    addBlogViewModel.Blog.ThumbnailImage = fileUpload.Value;
                    BlogManager.Update(addBlogViewModel.Blog);
                }

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                if (fileStatus.Key)
                    ModelState.AddModelError("BlogImage", fileStatus.Value.ToString());
                return View(CreateAddBlogViewModel());
            }
            return RedirectToAction("BlogList", "Admin");
        }

        #endregion


        #region UpdateBlog

        [HttpGet]
        public IActionResult UpdateBlog(string? title)
        {
            if (title == null)
            {
                return NotFound();
            }

            AddBlogViewModel viewModel = new AddBlogViewModel();
            viewModel = CreateAddBlogViewModel();
            viewModel.Blog = BlogManager.Get(b => b.UrlTitle == title);
            viewModel.TagItemIds = BlogTagManager.GetList(bt => bt.BlogId == viewModel.Blog.ObjectId).Select(bt => bt.TagId).ToArray();
            //TODO: Geçici olarak yazılan update blog controller düzenlenecek
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UpdateBlog(AddBlogViewModel addBlogViewModel)
        {
            Blog UpdatedBlog = BlogManager.Get(b => b.ObjectId == addBlogViewModel.Blog.ObjectId);

            UpdatedBlog.Title = addBlogViewModel.Blog.Title;
            UpdatedBlog.UrlTitle = Util.UrlFormating(addBlogViewModel.Blog.Title);
            UpdatedBlog.ObjectStatus = addBlogViewModel.Blog.ObjectStatus;
            UpdatedBlog.Content = addBlogViewModel.Blog.Content;
            UpdatedBlog.Category = addBlogViewModel.Blog.Category;

            //tag
            int[] oldTag = BlogTagManager.GetList(bt => bt.BlogId == UpdatedBlog.ObjectId).Select(bt => bt.TagId).ToArray();
            int[] newTag = addBlogViewModel.TagItemIds;

            foreach (int old in oldTag)
            {
                if (!newTag.Contains(old))
                {
                    BlogTag deleteTag= BlogTagManager.Get(bt => bt.TagId == old && bt.BlogId ==UpdatedBlog.ObjectId)  ;
                    BlogTagManager.Delete(deleteTag);
                }
                else
                {
                    newTag = newTag.Where(tg => tg != old).ToArray();
                }
            }
            if(newTag.Length > 0)
            {
                foreach (var tag in newTag)
                {
                    BlogTag blogTag = new BlogTag();
                    blogTag.BlogId = UpdatedBlog.ObjectId;
                    blogTag.TagId = tag;
                    BlogTagManager.Add(blogTag);
                }
            }

            //image
            var fileStatus = new KeyValuePair<bool, string>(true,"");
            var fileUpload = new KeyValuePair<bool, string>(true,"");
            if (addBlogViewModel.FormFile != null)
            {
                fileStatus = FileStatus(addBlogViewModel.FormFile);
                if (fileStatus.Key)
                {
                    fileUpload = FileUpload(addBlogViewModel.FormFile, UpdatedBlog.ObjectId.ToString());
                    if (fileUpload.Key)
                    {
                        UpdatedBlog.MainImage = fileUpload.Value;
                        UpdatedBlog.ThumbnailImage = fileUpload.Value;
                    }
                    else
                        ModelState.AddModelError("Image", fileUpload.Value);

                }
                else
                    ModelState.AddModelError("Image", fileStatus.Value);
            }

            BlogValidator validationRules = new BlogValidator();
            ValidationResult result = validationRules.Validate(UpdatedBlog);

            if (result.IsValid && fileStatus.Key && fileUpload.Key)
            {
                BlogManager.Update(UpdatedBlog);
                return RedirectToAction("BlogList", "Admin");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(CreateAddBlogViewModel());
            }

        }

        #endregion





        #region Blog Listele
        [HttpGet]
        public IActionResult BlogList()
        {


            List<BlogListDTO> blogListDTOs = new List<BlogListDTO>();
            List<Blog> blogs = BlogManager.GetBlogListWithCategory();

            foreach (Blog blog in blogs)
            {
                BlogListDTO blogListDTO = new BlogListDTO();
                blogListDTO.Blog = blog;
                blogListDTO.Tags = BlogTagManager.GetListWithTag(bt => bt.BlogId == blog.ObjectId);
                blogListDTOs.Add(blogListDTO);
            }

            return View(blogListDTOs);
        }

        [HttpPost]
        public IActionResult BlogList(Blog blog)
        {
            return View();
        }

        #endregion
    }
}
