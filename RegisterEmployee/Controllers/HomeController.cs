using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RegisterEmployee.Models;
using RegisterEmployee.Services;
using System.Diagnostics;

namespace RegisterEmployee.Controllers
{
    public class HomeController : Controller
    {
        EmployeeServices ems = new EmployeeServices();

        CompanyServices cms = new CompanyServices();

        private EmployeeServices _empServices;

        private CompanyServices _cmsServices;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult List()
        {
            _empServices = new EmployeeServices();
            


            var model = _empServices.GetEmployeeList();
            

            return View(model);

            
        }
        public IActionResult IList()
        {
            _cmsServices = new CompanyServices();

            var models = _cmsServices.GetCompanyList();

            return View(models);
        }
        public IActionResult AddEmployee()
        {

            return View();
        }

        public IActionResult AddCompany()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCompany(Companies models)
        {
            _cmsServices = new CompanyServices();

            _cmsServices.InsertCompany(models);

            return RedirectToAction("IList");
        }
        [HttpPost]
        public ActionResult AddEmployee(Employees model)
        {
            _empServices = new EmployeeServices();

            _empServices.InsertEmployee(model);

            return RedirectToAction("List");
        }

        public IActionResult EditCompany(int Id)
        {
            _cmsServices = new CompanyServices();

            var models = _cmsServices.GetCompanyById(Id);

            return View(models);
        }
        public IActionResult EditEmployee(int Id)
        {
            _empServices = new EmployeeServices();

            var model = _empServices.GetEditById(Id);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditCompany(Companies models)
        {
            _cmsServices = new CompanyServices();

            _cmsServices.UpdateCompany(models);

            return RedirectToAction("IList");
        }
        [HttpPost]
        public ActionResult EditEmployee(Employees model)
        {
            _empServices = new EmployeeServices();

            _empServices.UpdateEmployees(model);

            return RedirectToAction("List");
        }

        public IActionResult DeleteCompany(int Id)
        {
            _cmsServices = new CompanyServices();

            _cmsServices.DeleteCompany(Id);

            return RedirectToAction("IList");
        }

        public IActionResult DeleteEmployees(int Id)
        {
            _empServices = new EmployeeServices();

            _empServices.DeleteEmployees(Id);

            return RedirectToAction("List");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
