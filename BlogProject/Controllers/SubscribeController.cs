using BlogApplication.DTO;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{

    public class SubscribeController : Controller
    {
        SubscribeManager SubscribeManager = new SubscribeManager(new EfSubscribeRepository());

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SubscribeMail(Subscribe subscribe)
        {
            AjaxResultDTO ajaxResultDTO = new AjaxResultDTO();

            SubscribeValidator validationRules = new SubscribeValidator();
            ValidationResult validationResult = validationRules.Validate(subscribe);
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
                subscribe.UserIp = ip;

                SubscribeManager.Add(subscribe);

                ajaxResultDTO.status = true;
                ResultMessage resultMessage = new ResultMessage("userMessage", "Aboneliğiniz alındı.");
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
