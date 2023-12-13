using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using BlogApplication.DTO;
using Newtonsoft.Json;
using System.Net;




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
				String? ip;
				try
				{
					ip = Response.HttpContext.Connection.RemoteIpAddress?.ToString();
				}
				catch (Exception)
				{
					ip = "0";
				}
				contactUser.UserIp = ip;

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
	}
}
