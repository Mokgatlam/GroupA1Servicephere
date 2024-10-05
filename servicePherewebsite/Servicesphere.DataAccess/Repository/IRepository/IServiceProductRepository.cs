using ServiceSphere.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicesphere.DataAccess.Repository.IRepository
{
   public interface IServiceProductRepository: IRepository<ServiceProduct>
    {

        void Update(ServiceProduct obj);
       

    }
}
