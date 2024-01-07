using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace DataAccesLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> GetListWithCategory();
        List<Blog> GetListWithCategory(Expression<Func<Blog, bool>> filter);
        Blog GetBlogWithCategory(Expression<Func<Blog, bool>> filter);
    }
}
