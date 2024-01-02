using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System.Linq.Expressions;

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

		public BlogTag Get(Expression<Func<BlogTag, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public BlogTag GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<BlogTag> GetList()
        {
            return _blogTagDal.GetListAll();
        }

        public List<BlogTag> GetList(Expression<Func<BlogTag, bool>> filter)
        {
            return _blogTagDal.GetListAll(filter);
        }

        public List<BlogTag> GetListWithTag(Expression<Func<BlogTag, bool>> filter)
        {
            return _blogTagDal.GetListWithTag(filter);
        }

        public List<BlogTag> GetListWithTag()
        {
            return _blogTagDal.GetListWithTag();
        }

        public void Update(BlogTag t)
        {
            throw new NotImplementedException();
        }
    }
}
