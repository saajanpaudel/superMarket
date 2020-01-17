using System.Collections.Generic;
using System.Linq;
using SuperMarket.Data;
using SuperMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace SuperMarket.Controllers
{
    public class EmployeeController:Controller
    {
        private superMarketDbContext dbContext;
        IHostingEnvironment _env;

        public EmployeeController(superMarketDbContext _dbcontext, IHostingEnvironment env)
        {
            dbContext = _dbcontext;
            _env = env;
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
        public IActionResult Add([FromForm]employeeModel newemployee)
        {
            string rootPath = _env.WebRootPath;
            string fileName = newemployee.UploadImage.FileName;
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
