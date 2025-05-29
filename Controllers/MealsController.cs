using Microsoft.AspNetCore.Mvc;
using IntimateHomeCookedFood.Models;
using IntimateHomeCookedFood.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using IntimateHomeCookedFood.Extensions;

namespace IntimateHomeCookedFood.Controllers
{
    public class MealsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MealsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Soups()
        {
            var meals = _context.Meals.Where(m => m.Type == "Çorba").ToList();
            return View("Corbalar", meals);
        }

        public IActionResult MainDishes()
        {
            var meals = _context.Meals.Where(m => m.Type == "Ana Yemek").ToList();
            return View("AnaYemekler", meals);
        }

        public IActionResult Salads()
        {
            var meals = _context.Meals.Where(m => m.Type == "Salata").ToList();
            return View("Salatalar", meals);
        }

        public IActionResult Desserts()
        {
            var meals = _context.Meals.Where(m => m.Type == "Tatlı").ToList();
            return View("Tatlilar", meals);
        }

        public IActionResult Drinks()
        {
            var meals = _context.Meals.Where(m => m.Type == "İçecek").ToList();
            return View("icecekler", meals);
        }

        [HttpPost]
        public IActionResult AddToCart(string mealId, string returnUrl)
        {
            var meal = _context.Meals.FirstOrDefault(m => m.Id == mealId);

            if (meal != null)
            {
                var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart") ?? new List<CartItem>();

                var existing = cart.FirstOrDefault(x => x.Meal.Id == mealId);
                if (existing != null)
                {
                    existing.Quantity++;
                }
                else
                {
                    cart.Add(new CartItem
                    {
                        Meal = meal,
                        Mother = null,
                        Quantity = 1
                    });
                }

                HttpContext.Session.SetObjectAsJson("cart", cart);
                HttpContext.Session.SetInt32("cartCount", cart.Sum(x => x.Quantity));
            }

            return Redirect(returnUrl ?? Url.Action("Index", "Meals"));
        }
    }
}
