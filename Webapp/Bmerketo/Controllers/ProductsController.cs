using Bmerketo.Models.ViewModels;
using Bmerketo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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

        [Authorize(Roles = "admin")]
        public IActionResult Register()
        {
            ViewData["Title"] = "Register Product";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(ProductRegistrationViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                if(await _productServices.RegisterNewProduct(ViewModel))
                {
                    return RedirectToAction("Index", "Products");
                }

                ModelState.AddModelError("", "Something went wrong and your Product could not be added");
            }
            return View(ViewModel);
        }

        public async Task<IActionResult> Details(string id)
        {
            ViewData["Title"] = "Product Details";

            if(id is not "")
            {

                ProductDetailsViewModel model = new ProductDetailsViewModel
                {
                    Breadcrumb = new BreadcrumbViewModel
                    {
                        Title = "SHOP",
                        Crumbs = new List<string> { "PRODUCTS", "DETAILS" }
                    },
                    Product = await _productServices.GetByIdAsync(id)
                };

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Products");
            }
        }
    }
}
