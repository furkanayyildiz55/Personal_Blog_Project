using System.Linq.Expressions;


namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> 
    {
        void Add(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetList();
        List<T> GetList(Expression<Func<T, bool>> filter);
        T GetByID(int id);
        T Get(Expression<Func<T, bool>> filter);
    }
}
