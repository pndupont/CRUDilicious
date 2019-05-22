using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDILICIOUS.Models;
using Microsoft.EntityFrameworkCore;


namespace CRUDILICIOUS.Controllers
{
    public class HomeController : Controller
    {
        private MyContext DbContext;
        public HomeController(MyContext context)
        {
            DbContext = context;
        }


        [HttpGet("")]
        public IActionResult Index()
        {
            List<Dish> AllDishes = DbContext.Dishes.OrderByDescending( d => d.Name ).ToList();
            return View("Index", AllDishes);
        }
        
        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost("CreateDish")]
        public IActionResult CreateDish (Dish SubmittedDish)
        {
            //TODO connect submitted dish with user submitting dish
            if (ModelState.IsValid)
            {
                DbContext.Dishes.Add(SubmittedDish);
                DbContext.SaveChanges();
                return RedirectToAction ("Index");
            }
            else
            {
                return View("New");
            }
        }

        [HttpGet("/{DishIdx}")]
        public IActionResult ShowDish (int DishIdx)
        {   
            System.Console.WriteLine($"/////{DishIdx}");
            Dish ViewDish = DbContext.Dishes.FirstOrDefault(d => d.DishId == DishIdx);
            Console.WriteLine(ViewDish.Chef);
            return View("ShowDish", ViewDish);
        }

        [HttpGet("/edit/{DishIdx}")]
        public IActionResult EditDish (int DishIdx)
        {
            Dish Dish = DbContext.Dishes.FirstOrDefault(d => d.DishId == DishIdx);
            return View("EditDish", Dish);
        }

        [HttpPost("/edit/{DishIdx}")]
        public IActionResult UpdateDish(Dish DishSubmitted)
        {
            if (ModelState.IsValid)
            {
                Dish DishToUpdate = DbContext.Dishes.FirstOrDefault(d => d.DishId == DishSubmitted.DishId);
                DishToUpdate.Name = DishSubmitted.Name;
                DishToUpdate.Chef = DishSubmitted.Chef;
                DishToUpdate.Tastiness = DishSubmitted.Tastiness;
                DishToUpdate.Calories = DishSubmitted.Calories;
                DishToUpdate.UpdatedAt = DateTime.Now;
                DbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit/{DishSubmitted.DishId}", DishSubmitted);
            }
        }
        [HttpGet("Delete/{DishIdx}")]
        public IActionResult DeleteDish(int DishIdx)
        {
            Dish Dish = DbContext.Dishes.FirstOrDefault(d => d.DishId == DishIdx);
            DbContext.Dishes.Remove(Dish);
            DbContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}