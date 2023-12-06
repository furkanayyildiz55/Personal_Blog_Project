using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;


namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this._categoryDal = categoryDal;
        }

        public void Add(Category t)
        {
            throw new NotImplementedException();
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public void Delete(Category t)
        {
            throw new NotImplementedException();
        }

        public Category GetByID(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetListAll();
        }

        public List<Category> GetList(Category category)
        {
            throw new NotImplementedException();
        }

        public void Update(Category t)
        {
            throw new NotImplementedException();
        }
    }
}
