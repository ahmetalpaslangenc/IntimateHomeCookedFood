using Microsoft.AspNetCore.Mvc;
using IntimateHomeCookedFood.Models;
using System.Collections.Generic;
using System.Linq;

namespace IntimateHomeCookedFood.Controllers
{
    public class MothersController : Controller
    {
        public static List<Mother> Mothers = new List<Mother>
        {
            new Mother
            {
                Id = 1, 
                Name = "Anne 1", 
                Rating = 4.5, 
                Meals = new List<Meal> 
                { 
                    new Meal { Id = 1, Name = "Yemek 1", Description = "Lezzetli yemek", Price = 15.0M } 
                }
            },
            new Mother
            {
                Id = 2, 
                Name = "Anne 2", 
                Rating = 3.8, 
                Meals = new List<Meal> 
                { 
                    new Meal { Id = 2, Name = "Yemek 2", Description = "Lezzetli yemek", Price = 20.0M } 
                }
            }
            // Daha fazla örnek ekleyin
        };

        public IActionResult Index()
        {
            return View(Mothers);
        }

        public IActionResult Details(int id)
        {
            var mother = Mothers.FirstOrDefault(m => m.Id == id);
            if (mother == null)
            {
                return NotFound();
            }
            return View(mother);
        }
    }
}

