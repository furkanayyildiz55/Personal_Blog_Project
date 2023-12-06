using EntityLayer.Concrete;

namespace DataAccesLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> GetListWithCategory();
    }
}
