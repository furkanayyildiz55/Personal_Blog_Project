using BlogProject.DTO;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using static BlogProject.Constants.Enums;

namespace BlogProject.ViewComponents.PagePartialWidget
{
    public class BlogCommentWidget : ViewComponent
    {
        CommentManager CommentManager = new CommentManager(new EfCommentRepository());

        public IViewComponentResult Invoke(int BlogId)
        {
            List<Comment> comments = CommentManager.GetList(cm => cm.BlogId == BlogId && cm.ObjectStatus== (int)ObjectStatus.Active);
            CommentListDTO commentListDTO = new CommentListDTO();
            commentListDTO.BlogId = BlogId;

            foreach (Comment comment in comments.Where(cm => cm.ReplyId == null))
            {
                CommentList commentList = new CommentList();
                commentList.MainComment = comment;
                commentList.ReplyComment= comments.Where(cm => cm.ReplyId == comment.ObjectId).ToList();

                commentListDTO.CommentList.Add(commentList);
            }
            return View(commentListDTO);
        }
    }
}
