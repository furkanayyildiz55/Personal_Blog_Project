using BlogProject.DTO;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.PagePartialWidget
{
    public class BlogCommentWidget : ViewComponent
    {
        CommentManager CommentManager = new CommentManager(new EfCommentRepository());

        public IViewComponentResult Invoke(int BlogId)
        {
            List<Comment> comments = CommentManager.GetList(cm => cm.BlogId == BlogId);
            List<CommentListDTO> commentListDTOs = new List<CommentListDTO>();

            foreach (Comment comment in comments.Where(cm => cm.ReplyId == null))
            {
                CommentListDTO commentDTO = new CommentListDTO();
                commentDTO.MainComment = comment;
                commentDTO.ReplyComment= comments.Where(cm => cm.ReplyId == comment.ObjectId).ToList();

                commentListDTOs.Add(commentDTO);
            }
            return View(commentListDTOs);
        }
    }
}
