using System.Collections.Generic;
using System.Linq;
using SuperMarket.Data;
using SuperMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;

namespace SuperMarket.Controllers
{
    public class EmployeeController:Controller
    {
        private superMarketDbContext dbContext;
        IWebHostEnvironment _env;
        //IHostingEnvironment _env;

        public EmployeeController(superMarketDbContext _dbcontext, IWebHostEnvironment env)
        {
            dbContext = _dbcontext;
            _env = env;
        }
        public IActionResult Index()
        {
            //List<employeeModel> employees = dbContext.employee.Where(a=>a.name == "fdsaf" && a.address== "fdasf").ToList();
            //List<employeeModel> employees = dbContext.employee.OrderByDescending(a => a.name).ToList();
            List<employeeModel> employees = dbContext.employee.OrderBy(a => a.emp_id).ToList();
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
        public IActionResult Add([FromForm]employeeModel newemployee)
        {
            string rootPath = _env.WebRootPath;
            string uploadName = newemployee.UploadImage.FileName;
            string fileName = Guid.NewGuid().ToString()+uploadName;
            string uploadPath = rootPath + "/imgs/" + fileName;
            newemployee.photo = fileName;

            using (var filestream = new FileStream(uploadPath, FileMode.Create))
            {
                newemployee.UploadImage.CopyTo(filestream);
            }

            if (ModelState.IsValid)
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
        public IActionResult Edit([FromForm]employeeModel editemployee)
        {
            if (ModelState.IsValid)
            {
                dbContext.employee.Update(editemployee);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editemployee);
        }

        public IActionResult Delete(int id)
        {
            employeeModel employees = dbContext.employee.Find(id);
            dbContext.employee.Remove(employees);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
