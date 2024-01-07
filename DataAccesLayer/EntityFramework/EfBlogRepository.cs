using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccesLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        /// <summary>
        /// Liste içerisindeki her bir Blog nesnesine ilişkili Category nesnesi de dahil edilerek çağrılır.
        /// </summary>
        /// <returns></returns>
        public List<Blog> GetListWithCategory()
        {
            using (var c = new Context())
            {
                return c.Blog.Include(x => x.Category).ToList();
            }
        }

        public Blog GetBlogWithCategory(Expression<Func<Blog, bool>> filter)
        {
            using (var c = new Context())
            {
                return c.Blog.Where(filter)
                    .Include(x => x.Category)
                    .Include(x => x.Writer)
                    .FirstOrDefault();
            }
        }

        public List<Blog> GetListWithCategory(Expression<Func<Blog, bool>> filter)
        {
            using (var c = new Context())
            {
                return c.Blog.Where(filter)
                    .Include(x => x.Category)
                    .Include(x => x.Writer)
                    .ToList();
            }
        }
    }
}
