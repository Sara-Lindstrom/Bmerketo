using Bmerketo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Bmerketo.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            var breadcrumb = new BreadcrumbViewModel
            {
                Title = "CONTACT",
                Crumbs = new List<string> { "HOME", "CONTACT" },
            };

            return View(breadcrumb);
        }
    }
}
