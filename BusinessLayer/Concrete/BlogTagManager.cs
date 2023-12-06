using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class BlogTagManager : IBlogTagService
    {
        IBlogTagDal _blogTagDal;

        public BlogTagManager(IBlogTagDal blogTagDal)
        {
            this._blogTagDal = blogTagDal;
        }

        public void Add(BlogTag t)
        {
            _blogTagDal.Insert(t);
        }

        public void Delete(BlogTag t)
        {
            throw new NotImplementedException();
        }

        public BlogTag GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<BlogTag> GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(BlogTag t)
        {
            throw new NotImplementedException();
        }
    }
}
