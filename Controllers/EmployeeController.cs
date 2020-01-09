using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperMarket.Data;
using SuperMarket.Models;
using Microsoft.AspNetCore.Mvc;

namespace SuperMarket.Controllers
{
    public class EmployeeController:Controller
    {
        private superMarketDbContext dbContext;
        public EmployeeController(superMarketDbContext _dbcontext)
        {
            dbContext = _dbcontext;
        }
        public IActionResult Index()
        {
            List<employeeModel> employees = dbContext.employee.ToList();
            
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            employeeModel employees = dbContext.employee.Find(id);
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(employeeModel newemployee)
        {
            if(ModelState.IsValid)
            {
            dbContext.employee.Add(newemployee);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
            }
            return View(newemployee);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            employeeModel employees = dbContext.employee.Find(id);
            return View(employees);
        }

        [HttpPost]
        public IActionResult Edit(employeeModel editemployee)
        {
            if (ModelState.IsValid)
            {
                dbContext.employee.Update(editemployee);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editemployee);
        }
    }
}
