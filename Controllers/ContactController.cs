using Microsoft.AspNetCore.Mvc;

namespace IntimateHomeCookedFood.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
