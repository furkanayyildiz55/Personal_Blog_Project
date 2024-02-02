using BlogApplication.DTO;
using BlogProject.Helper;
using BlogProject.MailOperations;
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
        private readonly IMailService mailService;

        public SubscribeController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        #region Subscribe

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SubscribeMail(Subscribe subscribe)
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
                subscribe.SubscribeGuid = Util.Guid12();

                SubscribeManager.Add(subscribe);

                ajaxResultDTO.status = true;
                ResultMessage resultMessage = new ResultMessage("userMessage", "Aboneliğiniz alındı.");
                ajaxResultDTO.resultMessages.Add(resultMessage);

                
                MailData mailData = new MailData();
                mailData.ToEmail = "furkanayyildiz55@hotmail.com";
                mailData.ToEmailSubject = "Aboneliğin İçin Teşekkürler! İlk Haberler Seninle!";
                mailData.ToEmailBody = MailBodyCreator.Subsribe("furkanayyildiz55@hotmail.com");
                _ = Task.Run(() => mailService.SendMailAsync(mailData, 5));

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

        #endregion


        #region UnSubscribeMail

        public async Task<IActionResult> UnSubscribe(string Email , string Guid)
        {

            return View();
        }

        #endregion
    }
}
