using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MailLogManager : IMailLogService
    {
        IMailLogDal _mailLogDal;
        public MailLogManager(IMailLogDal mailLogDal)
        {
            _mailLogDal = mailLogDal;
        }

        public void Add(MailLog t)
        {
            _mailLogDal.Insert(t);
        }

        public void Delete(MailLog t)
        {
            throw new NotImplementedException();
        }

        public MailLog Get(Expression<Func<MailLog, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public MailLog GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<MailLog> GetList()
        {
            throw new NotImplementedException();
        }

        public List<MailLog> GetList(Expression<Func<MailLog, bool>> filter)
        {
           return _mailLogDal.GetListAll(filter);
        }

        public void Update(MailLog t)
        {
            throw new NotImplementedException();
        }
    }
}
