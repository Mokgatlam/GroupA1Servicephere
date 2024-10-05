using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using Servicesphere.DataAccess.Data;
using Servicesphere.DataAccess.Repository.IRepository;
using ServiceSphere.Models;
using ServiceSphere.Models.ViewModels;
using static System.Net.Mime.MediaTypeNames;


namespace ServicePherewebsiteApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceProductController(IUnitOfWork unitOfWork)
        {
            //constructor
            _unitOfWork = unitOfWork;
        }

        // index action to display all categories
        public IActionResult Index()
        {
            List<ServiceProduct> objServiceProductList = _unitOfWork.ServiceProduct.GetAll().ToList();
            
            return View(objServiceProductList);
        }


        //Get: create new Service List
        [HttpGet]
        public IActionResult Create()
        {
            var model = new ServiceProduct
            {
                CreatedAt = DateTime.Now // Set default value
            };


            //IEnumerable<SelectListItem> CategoryList = _unitOfWork.ServiceCategory.GetAll().Select(u => new SelectListItem
          //  {
           //     Text = u.Name,
             //   Value = u.CategoryId.ToString()

          //  });

            //ViewBag.CategoryList = CategoryList;
            // ViewData["CategoryList"]= CategoryList;

            ServiceProductVM serviceProductVM = new()
            {
                ServiceCategoryList = _unitOfWork.ServiceCategory.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryId.ToString()

                }),
                ServiceProduct=new ServiceProduct()
           

            };


            return View(serviceProductVM);
        }


        //Post Create a new Service List

        [HttpPost]

        public IActionResult Create(ServiceProductVM serviceProductVM)
        {





            if (ModelState.IsValid)
            {
                // Add the Service Product object to the database

                _unitOfWork.ServiceProduct.Add(serviceProductVM.ServiceProduct);
                _unitOfWork.Save();
                TempData["success"] = "Service List created successfully";
                return RedirectToAction("Index");
            }
            else {


                serviceProductVM.ServiceCategoryList = _unitOfWork.ServiceCategory.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryId.ToString()

                });

                return View(serviceProductVM);

            }

            
        }

        //Get: Edit Service category
        [HttpGet]
        public IActionResult Edit(int? id)
        {

            var model = new ServiceProduct
            {

                CreatedAt = DateTime.Now // Set default value
            };

            if (id == null || id == 0)
            {
                return NotFound();
            }

            ServiceProduct? serviceProductFromDb = _unitOfWork.ServiceProduct.Get(u => u.SProductId == id);
            //ServiceProduct? serviceProductFromDb=_db.Service_Categories.FirstOrDefault(u=>u.SProductId==id);
            //ServiceProduct? serviceProductFromDb=_db.Service_Categories.Where(u=>u.ProductId==id).FirstOrDefault(u=>u.SProductId==id);
            if (serviceProductFromDb == null)
            {
                return NotFound();

            }

            return View(serviceProductFromDb);
        }


        //Post:  Edit Service Listing

        [HttpPost]

        public IActionResult Edit(ServiceProduct obj)
        {




            if (ModelState.IsValid)
            {
                // Add the Product object to the database

                _unitOfWork.ServiceProduct.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Service Listing updated successfully";
                return RedirectToAction("Index");
            }

            return View();
        }


        //Get: Delete Service category
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var model = new ServiceProduct
            {

                CreatedAt = DateTime.Now // Set default value
            };

            if (id == null || id == 0)
            {
                return NotFound();
            }

            ServiceProduct? serviceProductFromDb = _unitOfWork.ServiceProduct.Get(u => u.SProductId == id);

            if (serviceProductFromDb == null)
            {
                return NotFound();

            }

            return View(serviceProductFromDb);
        }


        //Post:  Delete Service category

        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int? id)
        {
            // the Product object to the database
            ServiceProduct? obj = _unitOfWork.ServiceProduct.Get(u => u.SProductId == id);

            if (obj == null)
            { return NotFound(); }
            _unitOfWork.ServiceProduct.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Service Listing deleted successfully";
            return RedirectToAction("Index");

        }


    }
}
