using Microsoft.AspNetCore.Mvc;

namespace IntimateHomeCookedFood.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(string name, string email, string message)
        {
            // Burada form verileri ile işlem yapılabilir (veritabanına kayıt, e-posta gönderimi olarak. Ancak şu anda sadece teşekkür sayfasına yönlendirme yapılacak.

            return RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}