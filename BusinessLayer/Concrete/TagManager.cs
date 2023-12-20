using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Tag GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tag> GetList()
        {
          return  _tagDal.GetListAll();
        }

        public void Update(Tag t)
        {
            throw new NotImplementedException();
        }
    }
}
