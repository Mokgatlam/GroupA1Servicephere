using Servicesphere.DataAccess.Data;
using Servicesphere.DataAccess.Repository.IRepository;
using ServiceSphere.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Servicesphere.DataAccess.Repository
{
    public class ServiceProductRepository :Repository<ServiceProduct>, IServiceProductRepository 
    {

        //dependency injection
        private ApplicationDbContext _db;

        public ServiceProductRepository(ApplicationDbContext db): base(db)
        {
            _db= db;

        }

   

        public void Update(ServiceProduct obj)
        {
            // update query
            _db.Service_Products.Update(obj);
        }
    }
}
