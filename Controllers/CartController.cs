using Microsoft.AspNetCore.Mvc;
using IntimateHomeCookedFood.Models;
using IntimateHomeCookedFood.Extensions;
using IntimateHomeCookedFood.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace IntimateHomeCookedFood.Controllers
{
    public class CartController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;

        public CartController(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart") ?? new List<CartItem>();
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int mealId, string returnUrl)
        {
            var meal = _context.Meals.FirstOrDefault(m => m.Id == mealId);
            var mother = MothersController.Mothers.FirstOrDefault(m => m.Meals.Any(meal => meal.Id == mealId));

            if (meal != null && mother != null)
            {
                var cart = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart") ?? new List<CartItem>();
                var cartItem = new CartItem { Meal = meal, Mother = mother };
                cart.Add(cartItem);

                _httpContextAccessor.HttpContext.Session.SetObjectAsJson("cart", cart);

                var cartCount = _httpContextAccessor.HttpContext.Session.GetInt32("cartCount") ?? 0;
                _httpContextAccessor.HttpContext.Session.SetInt32("cartCount", cart.Count);

                TempData["Message"] = "Ürün sepete eklendi.";
            }

            returnUrl = string.IsNullOrEmpty(returnUrl) ? Url.Action("Index", "Meals") : returnUrl;
            return Redirect(returnUrl);
        }
    }
}
