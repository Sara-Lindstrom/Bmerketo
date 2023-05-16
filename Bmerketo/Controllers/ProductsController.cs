
using Bmerketo.Models;
using Bmerketo.Models.Enums;
using Bmerketo.Models.ViewModels;
using Bmerketo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using static Bmerketo.Models.Enums.CategoryEnumModel;

namespace Bmerketo.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductServices _productServices;
        private readonly CategoryService _categoriesService;

        public ProductsController(ProductServices productServices, CategoryService categoriesService)
        {
            _productServices = productServices;
            _categoriesService = categoriesService;
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

            ViewBag.Categories = _categoriesService.GetCategorySelectListItems();

            var viewModel = new ProductRegistrationViewModel();
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Register(ProductRegistrationViewModel ViewModel, string[] tags)
        {
            ViewBag.Categories = _categoriesService.GetCategorySelectListItems(tags);

            if (ModelState.IsValid)
            {
                if(await _productServices.RegisterNewProduct(ViewModel, tags))
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

                if (model.Product.Categories.Count > 0)
                {
                    var relatedProductEnum = model.Product.Categories.FirstOrDefault().Category;
                    var relatedCards = await _productServices.GetByCategoryAsync(relatedProductEnum);
                    model.RelatedCards = relatedCards.Take(4).ToList();
                }

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Products");
            }
        }
    }
}
