using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccesLayer.EntityFramework
{
    public class EfBlogTagRepository : GenericRepository<BlogTag>, IBlogTagDal
    {
        public List<Blog> GetListWithTag()
        {
            throw new NotImplementedException();
        }
    }
}
