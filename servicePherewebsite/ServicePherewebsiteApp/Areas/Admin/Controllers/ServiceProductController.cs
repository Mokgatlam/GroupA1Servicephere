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

        private readonly IWebHostEnvironment _webHostEnvironment;
        public ServiceProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            //constructor
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        // index action to display all categories
        public IActionResult Index()
        {
            List<ServiceProduct> objServiceProductList = _unitOfWork.ServiceProduct.GetAll(includeProperties:"Category").ToList();
            
            return View(objServiceProductList);
        }


        //Get: create new Service List
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            var model = new ServiceProduct
            {
                CreatedAt = DateTime.Now ,// Set default value
                UpdatedAt= DateTime.Now// Set default
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

            if (id == null || id == 0)
            {
                //Create function
                return View(serviceProductVM);

            }
            else {
                //update function

                serviceProductVM.ServiceProduct = _unitOfWork.ServiceProduct.Get(u => u.SProductId == id);
                return View(serviceProductVM);

            
            }
            
        }


        //Post Create a new Service List

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(ServiceProductVM serviceProductVM,IFormFile? file)
        {


            if (ModelState.IsValid)
            {
                // Add the Service Product object to the database
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null) 
                { 
                    string fileName =Guid.NewGuid().ToString()+Path.GetExtension(file.FileName);
                    string serviceProductPath =Path.Combine(wwwRootPath, @"images\serviceListings");

                    if (!string.IsNullOrEmpty(serviceProductVM.ServiceProduct.ImageUrls))
                    {
                        //delete the old image
                        var oldImagePath =Path.Combine(wwwRootPath, serviceProductVM.ServiceProduct.ImageUrls.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        { 
                            System.IO.File.Delete(oldImagePath);

                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(serviceProductPath, fileName),FileMode.Create)) 
                    {
                        file.CopyTo(fileStream);
                    }

                    serviceProductVM.ServiceProduct.ImageUrls = @"\images\serviceListings\" + fileName;
                }

                if (serviceProductVM.ServiceProduct.SProductId == 0)
                {
                    _unitOfWork.ServiceProduct.Add(serviceProductVM.ServiceProduct);

                }
                else
                { 
                    _unitOfWork.ServiceProduct.Update(serviceProductVM.ServiceProduct);
                }


                
                _unitOfWork.Save();
                TempData["success"] = "Service List created successfully";
               // TempData["Error"] = "There was an issue creating the service listing.";
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

        ////Get: Edit Service category
        //[HttpGet]
        //public IActionResult Edit(int? id)
        //{

        //    var model = new ServiceProduct
        //    {

        //        CreatedAt = DateTime.Now // Set default value
        //    };

        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    ServiceProduct? serviceProductFromDb = _unitOfWork.ServiceProduct.Get(u => u.SProductId == id);
        //    //ServiceProduct? serviceProductFromDb=_db.Service_Categories.FirstOrDefault(u=>u.SProductId==id);
        //    //ServiceProduct? serviceProductFromDb=_db.Service_Categories.Where(u=>u.ProductId==id).FirstOrDefault(u=>u.SProductId==id);
        //    if (serviceProductFromDb == null)
        //    {
        //        return NotFound();

        //    }

        //    return View(serviceProductFromDb);
        //}


        ////Post:  Edit Service Listing

        //[HttpPost]

        //public IActionResult Edit(ServiceProduct obj)
        //{




        //    if (ModelState.IsValid)
        //    {
        //        // Add the Product object to the database

        //        _unitOfWork.ServiceProduct.Update(obj);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Service Listing updated successfully";
        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}


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

        //#region API CALLS
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    List<ServiceProduct> objServiceProductList = _unitOfWork.ServiceProduct.GetAll(includeProperties: "Category").ToList();
        //    return Json(new { data = objServiceProductList});
        //}
        //#endregion


    }
}
