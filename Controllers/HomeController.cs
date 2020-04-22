using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ChefNDish.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefNDish.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {   
            List<Chef> getAll = _context.Chefs.Include(c => c.Dishes).ToList();
            return View("Index",getAll);
        }
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View("AddChef");
        }
        [HttpPost("createchef")]
        public IActionResult CreateChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                _context.Chefs.Add(newChef);
                _context.SaveChanges();
                return Redirect("/");
            }
            else
            {
                return View("AddChef");
            }
        }


        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            ViewBag.AllChefs = _context.Chefs.ToList();
            List<Dish> getAll = _context.Dishes.ToList();
            return View("Dish",getAll);
        }
        [HttpGet("adddish")]
        public IActionResult AddDish()
        {
            ViewBag.AllChefs = _context.Chefs.ToList();
            return View("AddDish");
        }
        [HttpPost("upload")]
        public IActionResult CreateDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                _context.Dishes.Add(newDish);
                _context.SaveChanges();
                return Redirect("/dishes");
            }
            else
            {
                return Redirect("/adddish");
            }
        }

        [HttpGet("delete/{ID}")]
        public IActionResult Delete(int ID)
        {
            Dish get = _context.Dishes.FirstOrDefault(d => d.DishId == ID);
            _context.Remove(get);
            _context.SaveChanges();
            return Redirect("/dishes");
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
