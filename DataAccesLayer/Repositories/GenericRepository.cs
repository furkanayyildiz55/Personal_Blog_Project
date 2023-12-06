using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using System.Linq.Expressions;

namespace DataAccesLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var context = new Context();
            context.Remove(t);
            context.SaveChanges();

        }

        public T GetByID(int ID)
        {
            using var context = new Context();
            return context.Set<T>().Find(ID);
        }

        public List<T> GetListAll()
        {
            using var context = new Context();
            return context.Set<T>().ToList();  
        }

        public void Insert(T t)
        {
            using var context = new Context();
            context.Add(t);
            context.SaveChanges();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            using var context = new Context();
            var result = context.Set<T>().Where(filter).ToList();
            return result; 
        }

        public void Update(T t)
        {
            using var context = new Context();
            context.Update(t);
            context.SaveChanges();
        }

        public int GetCount(Expression<Func<T, bool>> filter)
        {
			using var context = new Context();
			return context.Set<T>().Where(filter).Count();
		}

		public int GetCount()
		{
			using var context = new Context();
			return context.Set<T>().Count();
		}
	}
}
