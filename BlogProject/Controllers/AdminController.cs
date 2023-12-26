using BlogProject.ViewModels;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogProject.Controllers
{
    public class AdminController : Controller
    {
        CategoryManager CategoryManager = new CategoryManager(new EfCategoryRepository());
        TagManager TagManager = new TagManager(new EfTagRepository());
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
        public async Task<IActionResult> AddBlogAsync(AddBlogViewModel  addBlogViewModel)
        {


            bool imageValid;
            if (addBlogViewModel.FormFile != null)
            {
                var extent = Path.GetExtension(addBlogViewModel.FormFile.FileName);
                var randomName = ($"{Guid.NewGuid()}{extent}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\BlogImage", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await addBlogViewModel.FormFile.CopyToAsync(stream);
                }
                imageValid = true;
                addBlogViewModel.Blog.MainImage = path;
                addBlogViewModel.Blog.ThumbnailImage = path;

            }
            else
            {
                imageValid = false;
            }

            BlogValidator validationRules = new BlogValidator();
            ValidationResult result = validationRules.Validate(addBlogViewModel.Blog);

            if (result.IsValid && imageValid)
            {
                //BLOG KAYIT 
                addBlogViewModel.Blog.WriterId = 3;
                BlogManager.Add(addBlogViewModel.Blog);



            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(CreateAddBlogViewModel());
            }




            return View();
        }
    }
}
