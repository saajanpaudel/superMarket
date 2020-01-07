using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Data;
using SuperMarket.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperMarket.Controllers
{
    public class StockController : Controller
    {
        private superMarketDbContext dbContext;
        public StockController(superMarketDbContext _dbcontext)
        {
            dbContext = _dbcontext;
        }
        public IActionResult Index()
        {
            List<stockModel> stocks = dbContext.stocks.ToList();
            return View(stocks);
        }
        public IActionResult Details(int id)
        {
            stockModel stocks = dbContext.stocks.Find(id);
            return View(stocks);
        }
    }
}
