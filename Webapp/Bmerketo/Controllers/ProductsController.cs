using Bmerketo.Models.ViewModels;
using Bmerketo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductServices _productServices;

        public ProductsController(ProductServices productServices)
        {
            _productServices = productServices;
        }


        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Products";

            var products = await _productServices.GetAllAsync();

            return View(products);
        }

        public IActionResult Register()
        {
            ViewData["Title"] = "Register Product";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(ProductRegistrationViewModel productRegistrationViewModel)
        {
            if (ModelState.IsValid)
            {
                if(await _productServices.RegisterNewProduct(productRegistrationViewModel))
                {
                    return RedirectToAction("Index", "Products");
                }

                ModelState.AddModelError("", "Something went wrong and your Product could not be added");
            }
            return View(productRegistrationViewModel);
        }

        public IActionResult Details()
        {
            ViewData["Title"] = "Product Details";

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
