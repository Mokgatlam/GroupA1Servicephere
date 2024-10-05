using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceSphere.Models.ViewModels
{
    public class ServiceProductVM
    {

        public ServiceProduct ServiceProduct { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ServiceCategoryList { get; set; }

    }
}
