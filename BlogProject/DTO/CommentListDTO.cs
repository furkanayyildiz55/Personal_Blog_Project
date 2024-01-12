using EntityLayer.Concrete;

namespace BlogProject.DTO
{
    public class CommentListDTO
    {
        public Comment MainComment { get; set; }
        public List<Comment> ReplyComment { get; set; }
    }
}
