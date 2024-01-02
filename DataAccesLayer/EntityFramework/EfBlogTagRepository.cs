using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccesLayer.EntityFramework
{
    public class EfBlogTagRepository : GenericRepository<BlogTag>, IBlogTagDal
    {
        public List<BlogTag> GetListWithTag(Expression<Func<BlogTag, bool>> filter)
        {
            using (var c = new Context())
            {
                return c.BlogTag.Where(filter).Include(bt => bt.Tags).ToList();
            }
        }

        public List<BlogTag> GetListWithTag()
        {
            using (var c = new Context())
            {
                return c.BlogTag.Include(bt => bt.Tags).ToList();
            }
        }
    }
}
