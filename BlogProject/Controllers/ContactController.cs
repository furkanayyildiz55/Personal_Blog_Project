using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using BlogApplication.DTO;
using Newtonsoft.Json;




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
			AjaxResultDTO ajaxResultDTO = new AjaxResultDTO();

			ContactUserValidator validationRules = new ContactUserValidator();
			ValidationResult validationResult = validationRules.Validate(contactUser);
			if (validationResult.IsValid)
			{
				contactUser.UserIp = "127.0.0.1";
				ContactUserManager.Add(contactUser);

				ajaxResultDTO.status = true;
				ResultMessage resultMessage = new ResultMessage("userMessage", "Mesajınız yönticiye iletildi.");
				ajaxResultDTO.resultMessages.Add(resultMessage);
				return Json(ajaxResultDTO );

			}
			else
			{
				ajaxResultDTO.status = false;

				foreach (var item in validationResult.Errors)
				{
					ResultMessage resultMessage = new ResultMessage(item.PropertyName, item.ErrorMessage);
					ajaxResultDTO.resultMessages.Add(resultMessage);
				}
				return Json(ajaxResultDTO);
			}
		}

		[HttpGet]
		public IActionResult Test()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Test(ContactUser contactUser)
		{
			AjaxResultDTO ajaxResultDTO = new AjaxResultDTO();

			ContactUserValidator validationRules = new ContactUserValidator();
			ValidationResult validationResult = validationRules.Validate(contactUser);
			if (validationResult.IsValid)
			{
				contactUser.UserIp = "127.0.0.1";
				ContactUserManager.Add(contactUser);

				ajaxResultDTO.status = true;
				ResultMessage resultMessage = new ResultMessage("userMessage", "Yorum eklendi. İlginiz için teşekkürler.");
				ajaxResultDTO.resultMessages.Add(resultMessage);
				return Json(ajaxResultDTO);

			}
			else
			{
				ajaxResultDTO.status = false;

				foreach (var item in validationResult.Errors)
				{
					ResultMessage resultMessage = new ResultMessage(item.PropertyName, item.ErrorMessage);
					ajaxResultDTO.resultMessages.Add(resultMessage);
				}

				return Json(ajaxResultDTO);
			}
		}


	}
}
