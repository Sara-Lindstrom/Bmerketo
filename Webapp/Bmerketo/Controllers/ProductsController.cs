using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var breadcrumb = new BreadcrumbViewModel
            {
                Title = "SHOP",
                Crumbs = new List<string> { "HOME", "PRODUCT", "DETAILS" },
                ImageUrl = "images/placeholders/1920x300.svg"
            };

            return View(breadcrumb);
        }
    }
}
