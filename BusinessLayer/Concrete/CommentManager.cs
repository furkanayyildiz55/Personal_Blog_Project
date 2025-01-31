﻿using BusinessLayer.Abstract;
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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void Add(Comment t)
        {
            _commentDal.Insert(t);
        }

        public void Add(Comment t , int status)
        {
            _commentDal.Insert(t , status);
        }

        public void Delete(Comment t)
        {
            _commentDal.Delete(t);
        }

		public Comment Get(Expression<Func<Comment, bool>> filter)
		{
            return _commentDal.Get(filter);
        }

		public Comment GetByID(int id)
        {
            return _commentDal.GetByID(id);
        }

        public List<Comment> GetList(int id)
        {
            return _commentDal.GetListAll(f => f.ObjectId == id).ToList();
        }


		public List<Comment> GetList()
		{
			throw new NotImplementedException();
		}

        public List<Comment> GetList(Expression<Func<Comment, bool>> filter)
        {
           return _commentDal.GetListAll(filter).ToList() ;
        }

        public void Update(Comment t)
        {
            _commentDal.Update(t);
        }
    }
}
