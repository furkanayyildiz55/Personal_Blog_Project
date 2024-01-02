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
    public class SubscribeManager : ISubscribeService
    {
        ISubscribeDal _subscribeDal;

        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }

        public void Add(Subscribe t)
        {
            _subscribeDal.Insert(t);
        }

        public void Delete(Subscribe t)
        {
            throw new NotImplementedException();
        }

		public Subscribe Get(Expression<Func<Subscribe, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public Subscribe GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Subscribe> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Subscribe> GetList(Expression<Func<Subscribe, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Subscribe t)
        {
            throw new NotImplementedException();
        }
    }
}
