using Servicesphere.DataAccess.Data;
using Servicesphere.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicesphere.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        //dependency injection
        private ApplicationDbContext _db;
        public IServiceCategoryRepository ServiceCategory { get; private set; }
        public IServiceProductRepository ServiceProduct { get; private set; }



        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            ServiceCategory = new ServiceCategoryRepository(_db);
            ServiceProduct = new ServiceProductRepository(_db);
        }
        

        public void Save()
        {

            // save changes  query
            _db.SaveChanges();
        }
    }
}
