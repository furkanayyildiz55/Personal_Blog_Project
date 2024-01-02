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
    public class ReportManager : IReportService
    {
        IReportDal _reportDal;

        public ReportManager(IReportDal reportDal)
        {
            _reportDal = reportDal;
        }

        public void Add(Category t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category t)
        {
            throw new NotImplementedException();
        }

		public Category Get(Expression<Func<Category, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public Category GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Category> GetList(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category t)
        {
            throw new NotImplementedException();
        }
    }
}
