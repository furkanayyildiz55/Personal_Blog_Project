using EntityLayer.Concrete;

namespace DataAccesLayer.Abstract
{
    public interface IBlogTagDal : IGenericDal<BlogTag>
    {
        List<Blog> GetListWithTag();
    }
}
