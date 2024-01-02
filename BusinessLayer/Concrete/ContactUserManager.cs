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
    public class ContactUserManager : IContactUserService
    {
        IContactUserDal _contactUserDal;

        public ContactUserManager()
        {
        }

        public ContactUserManager(IContactUserDal contactUserDal)
        {
            _contactUserDal = contactUserDal;
        }

        public void Add(ContactUser t)
        {
            _contactUserDal.Insert(t);
        }

        public void Delete(ContactUser t)
        {
            throw new NotImplementedException();
        }

		public ContactUser Get(Expression<Func<ContactUser, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public ContactUser GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContactUser> GetList()
        {
            throw new NotImplementedException();
        }

        public List<ContactUser> GetList(Expression<Func<ContactUser, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(ContactUser t)
        {
            throw new NotImplementedException();
        }
    }
}
