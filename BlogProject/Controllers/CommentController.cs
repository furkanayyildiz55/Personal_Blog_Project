using BlogApplication.DTO;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using static BlogProject.Constants.Enums;

namespace BlogProject.Controllers
{
    public class CommentController : Controller
    {
        CommentManager CommentManager = new CommentManager(new EfCommentRepository());
        [HttpPost]
        public IActionResult AddComment(Comment comment )
        {

            AjaxResultDTO ajaxResultDTO = new AjaxResultDTO();
            CommentValidator validationRules = new CommentValidator();
            ValidationResult validationResult = validationRules.Validate(comment);

            if(validationResult.IsValid)
            {
                CommentManager.Add(comment , (int)ObjectStatus.Passive);

                ajaxResultDTO.status = true;
                ResultMessage resultMessage = new ResultMessage("userMessage", "Yorumunuz yönetici onayından sonra yayınlanacak.");
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
