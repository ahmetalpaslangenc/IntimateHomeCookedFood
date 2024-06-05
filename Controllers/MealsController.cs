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

        [Route("Meals/Corbalar")]
        public IActionResult Soups()
        {
            var soups = _context.Meals.Where(m => m.Type == "Çorba").Take(6).ToList();
            return View("Corbalar", soups);
        }

        [Route("Meals/AnaYemekler")]
        public IActionResult MainDishes()
        {
            var mainDishes = _context.Meals.Where(m => m.Type == "Ana Yemek").Take(6).ToList();
            return View("AnaYemekler", mainDishes);
        }

        [Route("Meals/Salatalar")]
        public IActionResult Salads()
        {
            var salads = _context.Meals.Where(m => m.Type == "Salata").Take(6).ToList();
            return View("Salatalar", salads);
        }

        [Route("Meals/Tatlilar")]
        public IActionResult Desserts()
        {
            var desserts = _context.Meals.Where(m => m.Type == "Tatlı").Take(6).ToList();
            return View("Tatlilar", desserts);
        }

        [Route("Meals/Icecekler")]
        public IActionResult Drinks()
        {
            var drinks = _context.Meals.Where(m => m.Type == "İçecek").Take(6).ToList();
            return View("Icecekler", drinks);
        }

        [Route("Meals/Details/{id}")]
        public IActionResult Details(int id)
        {
            var meal = _context.Meals.FirstOrDefault(m => m.Id == id);
            var mothers = MothersController.Mothers.Where(m => m.Meals.Any(meal => meal.Id == id)).ToList();

            if (meal == null)
            {
                return NotFound();
            }

            var viewModel = new MealDetailsViewModel
            {
                Meal = meal,
                Mothers = mothers
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddToCart(int mealId)
        {
            var meal = _context.Meals.FirstOrDefault(m => m.Id == mealId);
            var mother = MothersController.Mothers.FirstOrDefault(m => m.Meals.Any(meal => meal.Id == mealId));

            if (meal != null && mother != null)
            {
                var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart") ?? new List<CartItem>();
                var cartItem = new CartItem { Meal = meal, Mother = mother };
                cart.Add(cartItem);

                HttpContext.Session.SetObjectAsJson("cart", cart);

                var cartCount = HttpContext.Session.GetInt32("cartCount") ?? 0;
                HttpContext.Session.SetInt32("cartCount", cartCount + 1);

                TempData["Message"] = "Ürün sepete eklendi.";
            }
            return RedirectToAction("Index", "Cart");
        }
    }
}
