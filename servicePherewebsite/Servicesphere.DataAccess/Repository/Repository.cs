using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Servicesphere.DataAccess.Data;
using Servicesphere.DataAccess.Repository.IRepository;

namespace Servicesphere.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //dependence injection
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db =db;
            this.dbSet = _db.Set<T>();
            //_db.ServiceCategory ==dbSet
            // _db.ServiceCategory.Add()
            // Now - dbSet.Add()

        }

        public void Add(T entity)
        {
            // _db.ServiceCategory.Add()
            // Now - dbSet.Add()
            dbSet.Add(entity);
           
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            // our query using a where condition
            //on our serch we want the first or default  method
           // same =ServiceCategory? serviceCategoryFromDb=_db.Service_Categories.Where(u=>u.CategoryId==id).FirstOrDefault(u=>u.CategoryId==id);
            IQueryable<T> query = dbSet;
            query =query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {

            // Select all condition /Query
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            // Remove query
            dbSet.Remove(entity);
            
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            // Remove range query
            //expects an IEnumerable
            dbSet.RemoveRange(entity);
        }
    }
}
