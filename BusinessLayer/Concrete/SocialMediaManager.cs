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
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void Add(SocialMedia t)
        {
            throw new NotImplementedException();
        }

        public void Delete(SocialMedia t)
        {
            throw new NotImplementedException();
        }

		public SocialMedia Get(Expression<Func<SocialMedia, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public SocialMedia GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<SocialMedia> GetList()
        {
            throw new NotImplementedException();
        }

        public List<SocialMedia> GetList(Expression<Func<SocialMedia, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(SocialMedia t)
        {
            throw new NotImplementedException();
        }
    }
}
