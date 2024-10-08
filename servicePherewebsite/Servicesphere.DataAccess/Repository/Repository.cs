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
            _db.Service_Products.Include(u => u.Category).Include(u=>u.CategoryId);

            // _db.ServiceCategory.Add()
            // Now - dbSet.Add()

        }

        public void Add(T entity)
        {
            // _db.ServiceCategory.Add()
            // Now - dbSet.Add()
            dbSet.Add(entity);
           
        }

        //public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        //{
        //    // our query using a where condition
        //    //on our search we want the first or default  method
        //   // same =ServiceCategory? serviceCategoryFromDb=_db.Service_Categories.Where(u=>u.CategoryId==id).FirstOrDefault(u=>u.CategoryId==id);
        //    IQueryable<T> query = dbSet;
        //    query = query.Where(filter);
        //    if (!string.IsNullOrEmpty(includeProperties))
        //    {
        //        foreach (var includeProp in includeProperties.
        //           Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(includeProp);

        //        }

        //    }
        //    return query.FirstOrDefault();
        //}

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            // our query using a where condition
            //on our search we want the first or default  method
            // same =ServiceCategory? serviceCategoryFromDb=_db.Service_Categories.Where(u=>u.CategoryId==id).FirstOrDefault(u=>u.CategoryId==id);
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.
                   Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);

                }

            }
            return query.FirstOrDefault();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return dbSet.FirstOrDefault(filter);
        }





        //Category,Categorytype
        public IEnumerable<T> GetAll(string? includeProperties = null, int pageNumber = 1, int pageSize = 10)
        {

            // Select all condition /Query
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query=query.Include(includeProp);
                
                }  
            
            }
            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.AsNoTracking().ToList(); // Return
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
