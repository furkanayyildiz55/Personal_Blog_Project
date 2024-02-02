using DataAccesLayer.Abstract;
using DataAccesLayer.Repositories;
using EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EfMailLogRepository : GenericRepository<MailLog> , IMailLogDal 
    {
    }
}
