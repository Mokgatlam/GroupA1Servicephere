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
    public class ServiceCategoryRepository :Repository<ServiceCategory>, IServiceCategoryRepository 
    {

        //dependency injection
        private ApplicationDbContext _db;

        public ServiceCategoryRepository(ApplicationDbContext db): base(db)
        {
            _db= db;

        }

        public void Save()
        {
            // save canges  query
            _db.SaveChanges();
        }

        public void Update(ServiceCategory obj)
        {
            // update quer
            _db.Service_Categories.Update(obj);
        }
    }
}
