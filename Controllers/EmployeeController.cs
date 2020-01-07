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
        public IActionResult Add()
        {
            return View();
        }
    }
}
