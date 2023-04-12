
using Bmerketo.Models;
using Bmerketo.Models.Enums;
using Bmerketo.Models.ViewModels;
using Bmerketo.Services;
using Microsoft.AspNetCore.Mvc;
using static Bmerketo.Models.Enums.CategoryEnumModel;
using System.Linq;

namespace Bmerketo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductServices _productService;

        public HomeController(ProductServices productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel
            {
                BestCollectionCards = await _productService.GetByCategoryAsync(CategoryAlternativeEnum.BestSelection),

                SaleBannerCards = (await _productService.GetByCategoryAsync(CategoryAlternativeEnum.Sale)).Take(2),

                TopSellers = await _productService.GetRandomAsync(6)
            };

            ViewData["title"] = "Home"; 
            return View(model);
        }
    }
}
