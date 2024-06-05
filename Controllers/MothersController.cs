using Microsoft.AspNetCore.Mvc;
using IntimateHomeCookedFood.Models;
using System.Linq;

namespace IntimateHomeCookedFood.Controllers
{
    public class MothersController : Controller
    {
       private static List<Mother> _mothers = new List<Mother>
       {
            new Mother { Id = 1, Name = "Ayla Hanım", Rating = 4.5, Meals = new List<Meal> { new Meal { Name = "Musakka" } } },
            new Mother { Id = 2, Name = "Selma Hanım", Rating = 3.8, Meals = new List<Meal> { new Meal { Name = "Mantı" } } },
            new Mother { Id = 3, Name = "Gülsüm Hanım", Rating = 4.1, Meals = new List<Meal> { new Meal { Name = "Ayran" } } },
            new Mother { Id = 4, Name = "Sedef Hanım", Rating = 3.4, Meals = new List<Meal> { new Meal { Name = "Sütlaç" } } }
       };


        public static List<Mother> Mothers => _mothers;

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
