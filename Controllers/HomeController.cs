using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context {get;set;}
        public HomeController(MyContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Dish> Dishes = _context.Dishes.ToList();
            return View(Dishes);
        }

        [HttpGet("New")]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost("Create")]
        public IActionResult CreateDish(Dish newDish)
        {   if(ModelState.IsValid)
            {
                
                _context.Dishes.Add(newDish);
                _context.SaveChanges();
                List<Dish> Dishes = _context.Dishes.ToList();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New");
            }
        }
        [HttpGet("{DId}")]
        public IActionResult OneDish(int DId)
        {
            Dish show = _context.Dishes.FirstOrDefault(d => d.UserID == DId);
            return View(show);
            
        }

        [HttpGet("edit/{DId}")]
        public IActionResult Edit(int DId)
        {
            Dish edit = _context.Dishes.FirstOrDefault(d => d.UserID == DId);
            return View(edit);
        }

        [HttpPost("update/{DId}")]
        public IActionResult Update(int DId, Dish update)
        {
            Dish retrieved = _context.Dishes.FirstOrDefault(d => d.UserID == DId);
            if(ModelState.IsValid)
            {
                retrieved.Name = update.Name;
                retrieved.Chef = update.Chef;
                retrieved.Description = update.Description;
                retrieved.Tastiness = update.Tastiness;
                retrieved.Calories = update.Calories;
                _context.SaveChanges();
                return Redirect($"/{DId}");
            }
            else
            {
                return View("Edit", update);
            }
        }
        [HttpGet("delete/{DId}")]
        public IActionResult Delete(int DId)
        {
            Dish remove = _context.Dishes.FirstOrDefault(d => d.UserID == DId);
            _context.Dishes.Remove(remove);
            _context.SaveChanges();
            return Redirect("/");
        }

    }
}
