using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Servicesphere.DataAccess.Data;
using Servicesphere.DataAccess.Repository.IRepository;
using ServiceSphere.Models;


namespace ServicePherewebsiteApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceCategoryController(IUnitOfWork unitOfWork)
        {
            //constructor
            _unitOfWork = unitOfWork;
        }

        // index action to display all categories
        public IActionResult Index()
        {
            List<ServiceCategory> objServiceCategoryList = _unitOfWork.ServiceCategory.GetAll().ToList();
            return View(objServiceCategoryList);
        }


        //Get: create new category
        [HttpGet]
        public IActionResult Create()
        {
            var model = new ServiceCategory
            {
                CreatedAt = DateTime.Now // Set default value
            };

            return View(model);
        }


        //Post Create a new category

        [HttpPost]

        public IActionResult Create(ServiceCategory obj)
        {
            if (obj.Name == obj.Description.ToString())
            {
                ModelState.AddModelError("name", "The Name cannot not exactly match the Description.");
            }




            if (ModelState.IsValid)
            {
                // Add the Category object to the database

                _unitOfWork.ServiceCategory.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Service Category created successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        //Get: Edit Service category
        [HttpGet]
        public IActionResult Edit(int? id)
        {

            var model = new ServiceCategory
            {

                CreatedAt = DateTime.Now // Set default value
            };

            if (id == null || id == 0)
            {
                return NotFound();
            }

            ServiceCategory? serviceCategoryFromDb = _unitOfWork.ServiceCategory.Get(u => u.CategoryId == id);
            //ServiceCategory? serviceCategoryFromDb=_db.Service_Categories.FirstOrDefault(u=>u.CategoryId==id);
            //ServiceCategory? serviceCategoryFromDb=_db.Service_Categories.Where(u=>u.CategoryId==id).FirstOrDefault(u=>u.CategoryId==id);
            if (serviceCategoryFromDb == null)
            {
                return NotFound();

            }

            return View(serviceCategoryFromDb);
        }


        //Post:  Edit Service category

        [HttpPost]

        public IActionResult Edit(ServiceCategory obj)
        {




            if (ModelState.IsValid)
            {
                // Add the Category object to the database

                _unitOfWork.ServiceCategory.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Service Category updated successfully";
                return RedirectToAction("Index");
            }

            return View();
        }


        //Get: Delete Service category
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var model = new ServiceCategory
            {

                CreatedAt = DateTime.Now // Set default value
            };

            if (id == null || id == 0)
            {
                return NotFound();
            }

            ServiceCategory? serviceCategoryFromDb = _unitOfWork.ServiceCategory.Get(u => u.CategoryId == id);

            if (serviceCategoryFromDb == null)
            {
                return NotFound();

            }

            return View(serviceCategoryFromDb);
        }


        //Post:  Delete Service category

        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int? id)
        {
            // the Category object to the database
            ServiceCategory? obj = _unitOfWork.ServiceCategory.Get(u => u.CategoryId == id);

            if (obj == null)
            { return NotFound(); }
            _unitOfWork.ServiceCategory.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Service Category deleted successfully";
            return RedirectToAction("Index");

        }


    }
}
