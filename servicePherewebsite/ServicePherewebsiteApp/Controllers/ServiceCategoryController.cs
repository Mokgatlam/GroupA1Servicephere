using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ServicePherewebsiteApp.Data;
using ServicePherewebsiteApp.Models;

namespace ServicePherewebsiteApp.Controllers
{
    public class ServiceCategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ServiceCategoryController(ApplicationDbContext db)
        {
            //constructor
            _db = db;
        }

        // index action to display all categories
        public IActionResult Index()
        {
            List<ServiceCategory> objServiceCategoryList = _db.Service_Categories.ToList();
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

    public IActionResult Create(ServiceCategory obj) {
            if (obj.Name == obj.Description.ToString())
            {
                ModelState.AddModelError("name", "The Name cannot not exactly match the Description.");
            }

  


            if (ModelState.IsValid) {
                // Add the Category object to the database

                _db.Service_Categories.Add(obj);
                _db.SaveChanges();
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

            ServiceCategory serviceCategoryFromDb=_db.Service_Categories.Find(id);
            if (serviceCategoryFromDb == null) { 
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

                _db.Service_Categories.Update(obj);
                _db.SaveChanges();
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

            ServiceCategory serviceCategoryFromDb = _db.Service_Categories.Find(id);
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
            ServiceCategory? obj = _db.Service_Categories.Find(id);

            if (obj==null)
                { return NotFound(); }
            _db.Service_Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Service Category deleted successfully";
            return RedirectToAction("Index");
         
        }


    }
}
    