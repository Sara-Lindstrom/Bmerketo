using Bmerketo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
                ImageUrl = "images/placeholders/1920x300.svg"
            };

            return View(breadcrumb);
        }
    }
}
