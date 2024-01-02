using EntityLayer.Concrete;

namespace BlogProject.DTO
{
    public class BlogListDTO
    {
        public Blog Blog { get; set; }
        public List<BlogTag> Tags { get; set; }
    }
}
