using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IntimateHomeCookedFood.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace IntimateHomeCookedFood.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.CartCount = HttpContext.Session.GetInt32("CartCount") ?? 0;
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.GetUserAsync(User);
                ViewBag.UserName = user.UserName;
                return View("LoggedIn");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View(); // Views/Home/About.cshtml sayfasına yönlendirir
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
