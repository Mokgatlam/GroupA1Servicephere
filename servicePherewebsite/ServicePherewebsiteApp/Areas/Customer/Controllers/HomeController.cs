using Microsoft.AspNetCore.Mvc;
using Servicesphere.DataAccess.Repository.IRepository;
using ServiceSphere.Models;
using System.Diagnostics;

namespace ServicePherewebsiteApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
           
        }

        public IActionResult Index()
        {   
            IEnumerable<ServiceProduct> serviceProductList =_unitOfWork.ServiceProduct.GetAll(includeProperties:"Category");
            return View(serviceProductList);
        }

        public IActionResult Details(int serviceProductId)
        {
            ServiceProduct serviceProductList = _unitOfWork.ServiceProduct.Get(u=>u.SProductId==serviceProductId,includeProperties:"Category");
            return View(serviceProductList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
