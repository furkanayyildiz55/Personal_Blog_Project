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
			return _subscribeDal.Get(filter);
		}

		public Subscribe GetByID(int id)
        {
            return _subscribeDal.GetByID(id);
        }

        public List<Subscribe> GetList()
        {
            return _subscribeDal.GetListAll();
        }

        public List<Subscribe> GetList(Expression<Func<Subscribe, bool>> filter)
        {
           return _subscribeDal.GetListAll(filter);
        }

        public void Update(Subscribe t)
        {
           _subscribeDal.Update(t);
        }
    }
}
