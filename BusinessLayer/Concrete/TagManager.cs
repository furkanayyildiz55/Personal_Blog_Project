using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class TagManager : ITagService
    {
        ITagDal _tagDal;

        public TagManager(ITagDal tagDal)
        {
            _tagDal = tagDal;
        }

        public void Add(Tag t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Tag t)
        {
            throw new NotImplementedException();
        }

		public Tag Get(Expression<Func<Tag, bool>> filter)
		{
			return _tagDal.Get(filter);
		}

		public Tag GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tag> GetList()
        {
          return  _tagDal.GetListAll();
        }

        public List<Tag> GetList(Expression<Func<Tag, bool>> filter)
        {
           return _tagDal.GetListAll(filter);
        }

        public void Update(Tag t)
        {
            throw new NotImplementedException();
        }
    }
}
