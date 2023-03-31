using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["title"] = "Home"; 
            return View();
        }
    }
}
