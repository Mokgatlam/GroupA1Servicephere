using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicesphere.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {

        IServiceCategoryRepository ServiceCategory { get; }
        IServiceProductRepository ServiceProduct { get; }

        void Save();
    }
}
