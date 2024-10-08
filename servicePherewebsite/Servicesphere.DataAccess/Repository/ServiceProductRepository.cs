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
            var objFromDb = _db.Service_Products.FirstOrDefault(u => u.SProductId == obj.SProductId);

            if (objFromDb != null)
            {
                objFromDb.Name= obj.Name;
                objFromDb.Description= obj.Description; 
                objFromDb.Price= obj.Price;
                objFromDb.CategoryId= obj.CategoryId;
                objFromDb.UpdatedAt= obj.UpdatedAt;
                objFromDb.Location= obj.Location;
                objFromDb.IsActive= obj.IsActive;
                objFromDb.CreatedAt= obj.CreatedAt;
                objFromDb.IsVerified= obj.IsVerified;
                if (obj.ImageUrls != null)
                {
                    objFromDb.ImageUrls = obj.ImageUrls;
                }
                


            
            }

        
        
        
        }
    }
}
