using Microsoft.AspNetCore.Mvc;
using IntimateHomeCookedFood.Models;
using IntimateHomeCookedFood.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace IntimateHomeCookedFood.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart") ?? new List<CartItem>();
            return View(cart);
        }

        [HttpPost]
        public IActionResult UpdateQuantity(string mealId, string action)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart") ?? new List<CartItem>();
            var item = cart.FirstOrDefault(c => c.Meal.Id == mealId);

            if (item != null)
            {
                if (action == "increase")
                {
                    item.Quantity++;
                }
                else if (action == "decrease")
                {
                    item.Quantity--;
                    if (item.Quantity <= 0)
                    {
                        cart.Remove(item);
                    }
                }
            }

            HttpContext.Session.SetObjectAsJson("cart", cart);
            HttpContext.Session.SetInt32("cartCount", cart.Sum(x => x.Quantity));

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddMenuToCart(List<string> items)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart") ?? new List<CartItem>();

            foreach (var item in items)
            {
                var parts = item.Split('|');
                if (parts.Length < 3) continue;

                string id = parts[0];
                string name = parts[1];
                if (!decimal.TryParse(parts[2], out decimal price)) continue;

                var existing = cart.FirstOrDefault(x => x.Meal.Id == id);
                if (existing != null)
                {
                    existing.Quantity++;
                }
                else
                {
                    cart.Add(new CartItem
                    {
                        Meal = new Meal
                        {
                            Id = id,
                            Name = name,
                            Price = price
                        },
                        Quantity = 1
                    });
                }
            }

            HttpContext.Session.SetObjectAsJson("cart", cart);
            HttpContext.Session.SetInt32("cartCount", cart.Sum(x => x.Quantity));

            return RedirectToAction("Index");
        }

        // ✅ Yeni: Sipariş onay ekranı
            [HttpGet]
            public IActionResult OrderConfirmation()
            {
                var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart") ?? new List<CartItem>();

                if (cart.Any())
                {
                    var order = new Order
                    {
                        UserEmail = User.Identity.Name,
                        Items = cart
                    };

                    // Geçici siparişi session'a kaydet (İsteğe bağlı: istersen orders listesine de eklersin)
                    HttpContext.Session.SetObjectAsJson("lastOrder", cart);

                    HttpContext.Session.Remove("cart");
                    HttpContext.Session.SetInt32("cartCount", 0);
                }

                var lastOrder = HttpContext.Session.GetObjectFromJson<List<CartItem>>("lastOrder") ?? new List<CartItem>();
                return View(lastOrder);
            }

    }
}
