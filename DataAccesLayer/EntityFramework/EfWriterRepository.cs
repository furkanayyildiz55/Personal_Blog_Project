using DataAccesLayer.Abstract;
using DataAccesLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccesLayer.EntityFramework
{
    public class EfWriterRepository : GenericRepository<Writer> , IWriterDal
    {
    }
}
