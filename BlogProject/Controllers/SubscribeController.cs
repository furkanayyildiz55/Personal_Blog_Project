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
using Microsoft.IdentityModel.Tokens;
using static BlogProject.Constants.Enums;

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
                mailData.ToEmail = subscribe.SubscribeEmail;
                mailData.ToEmailSubject = "Aboneliğin İçin Teşekkürler! İlk Haberler Seninle!";
                mailData.ToEmailBody = MailBodyCreator.Subsribe(subscribe.SubscribeEmail, subscribe.SubscribeGuid , Util.BaseUrl(Request));
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

        public async Task<IActionResult> UnSubscribe(string Email="" , string Guid = "")
        {
            if (Email=="" || Email.Length > 100)
                return View(new KeyValuePair<bool, string>(false, "Geçersiz Email bilgisi")); 

            if(Guid=="" || Guid.Length != 12)
                return View(new KeyValuePair<bool, string>(false, "Geçersiz Guid bilgisi"));

            Subscribe subscribe = SubscribeManager.Get(s => s.SubscribeEmail == Email && s.SubscribeGuid == Guid);

            if (subscribe == null)
                return View(new KeyValuePair<bool, string>(false, "Geçersiz istek"));

            subscribe.ObjectStatus = (int)ObjectStatus.Passive; 
            SubscribeManager.Update(subscribe);
            return View(new KeyValuePair<bool, string>(true, Email));
        }

        #endregion
    }
}
