using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RegisterEmployee.Models;
using RegisterEmployee.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeServices ems = new EmployeeServices();

        private EmployeeServices _empServices;


        public IActionResult List()
        {
            _empServices = new EmployeeServices();

            var model = _empServices.GetEmployeeList();

            return View(model);
        }

        public IActionResult AddEmployee()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employees model)
        {
            _empServices = new EmployeeServices();

            _empServices.InsertEmployee(model);

            return RedirectToAction("List");
        }

        public IActionResult EditEmployee(int Id)
        {
            _empServices = new EmployeeServices();

            var model = _empServices.GetEditById(Id);

            return View(model);
        }
        [HttpPost]
        public ActionResult EditEmployee(Employees model)
        {
            _empServices = new EmployeeServices();

            _empServices.UpdateEmployees(model);

            return RedirectToAction("List");
        }

        public IActionResult DeleteEmployee(int Id)
        {
            _empServices = new EmployeeServices();

            _empServices.DeleteEmployees(Id);

            return RedirectToAction("List");
        }
    }
}
