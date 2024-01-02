using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }




        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public Blog GetByID(int id)
        {
           return _blogDal.GetByID(id); 
        }



        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }


		public List<Blog> GetLast3Blog()
		{
            return _blogDal.GetListAll().Take(3).ToList();
		}


        public void Add(Blog t)
        {
            _blogDal.Insert(t);

        }

        public void Delete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void Update(Blog t)
        {
            _blogDal.Update(t);
        }

        public List<Blog> GetList(Blog t)
        {
           return _blogDal.GetListAll();
        }

		public int GetBlogCount(int id)
		{
            if(id >= 0)
            {
				return _blogDal.GetCount(f => f.ObjectId == id);

			}
            else
            {
				return _blogDal.GetCount();
			}

		}

		public Blog Get(Expression<Func<Blog, bool>> filter)
		{
            return _blogDal.Get(filter);
		}

        public List<Blog> GetList(Expression<Func<Blog, bool>> filter)
        {
           return _blogDal.GetListAll(filter);
        }
    }
}
