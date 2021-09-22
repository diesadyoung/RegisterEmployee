﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RegisterEmployee.Models;
using RegisterEmployee.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterEmployee.Controllers
{
    public class HomeController : Controller
    {
        EmployeeServices ems = new EmployeeServices();

        private EmployeeServices _empServices;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
