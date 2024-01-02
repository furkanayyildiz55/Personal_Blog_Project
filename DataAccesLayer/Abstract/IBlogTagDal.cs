using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace DataAccesLayer.Abstract
{
    public interface IBlogTagDal : IGenericDal<BlogTag>
    {
        List<BlogTag> GetListWithTag(Expression<Func<BlogTag, bool>> filter);
        List<BlogTag> GetListWithTag();
    }
}
