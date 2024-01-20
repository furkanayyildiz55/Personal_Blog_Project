﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T t);
        void Insert(T t, int status);
        void Delete(T t);
        void Update(T t);
        
        T GetByID(int ID);
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetListAll();
        List<T> GetListAll(Expression<Func<T,bool>> filter);
        int GetCount();
        int GetCount(Expression<Func<T, bool>> filter);

	}
}
