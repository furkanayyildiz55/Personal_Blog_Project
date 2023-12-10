using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class ContactController : Controller
    {
        ContactUserManager ContactUserManager = new ContactUserManager(new EfContactUserRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
		public IActionResult Index(ContactUser contactUser)
		{
            contactUser.UserIp = "127.0.0.1";

            ContactUserManager.Add(contactUser);
            
			return View();
		}
	}
}
