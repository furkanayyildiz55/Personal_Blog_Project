using BlogProject.ViewModels;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogProject.Controllers
{
    public class AdminController : Controller
    {
        CategoryManager CategoryManager = new CategoryManager(new EfCategoryRepository());
        TagManager TagManager = new TagManager(new EfTagRepository());

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            List<Category> Category = CategoryManager.GetList();
            List<Tag> Tag = TagManager.GetList();

            List<SelectListItem> CategoryItem =new List<SelectListItem>();
            List<SelectListItem> TagItem = new List<SelectListItem>();

            foreach (var item in Category) {
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

            AddBlogViewModel AddBlogViewModel = new AddBlogViewModel(CategoryItem,TagItem);
            return View(AddBlogViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddBlogAsync(AddBlogViewModel  addBlogViewModel)
        {
            if (addBlogViewModel.FormFile != null)
            {
                var extent = Path.GetExtension(addBlogViewModel.FormFile.FileName);
                var randomName = ($"{Guid.NewGuid()}{extent}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await addBlogViewModel.FormFile.CopyToAsync(stream);
                }
            }

                return View();
        }
    }
}
