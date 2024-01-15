using EntityLayer.Concrete;

namespace BlogProject.DTO
{
    public class CommentListDTO
    {
        public List<CommentList> CommentList { get; set; }
        public int BlogId { get; set; }
        public int CommentCount { get; set; }
        public CommentListDTO()
        {
            CommentList = new List<CommentList>();
        }

    }

    public class CommentList
    {
        public Comment MainComment { get; set; }
        public List<Comment> ReplyComment { get; set; }

        public CommentList()
        {
            MainComment = new Comment();
            ReplyComment = new List<Comment>();
        }
    }
}
