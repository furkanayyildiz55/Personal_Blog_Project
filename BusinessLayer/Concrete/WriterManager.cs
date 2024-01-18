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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetByID(int id)
        {
            return _writerDal.GetByID(id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.GetListAll();
        }

		public void Add(Writer t)
		{
			_writerDal.Insert(t);
		}

		public void Delete(Writer t)
		{
			_writerDal.Delete(t);
		}

		public void Update(Writer t)
		{
			_writerDal.Update(t);

		}

        public List<Writer> GetWriterByID(int id)
        {
            throw new NotImplementedException();
        }

		public Writer Get(Expression<Func<Writer, bool>> filter)
		{
			return _writerDal.Get(filter);
		}

        public List<Writer> GetList(Expression<Func<Writer, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
