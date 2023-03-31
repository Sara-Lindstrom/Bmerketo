using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
