
using Bmerketo.Models.ViewModels;
using Bmerketo.Services;
using Microsoft.AspNetCore.Mvc;
using static Bmerketo.Models.Enums.CategoryEnumModel;

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
                BestCollectionCards = await _productService.GetByCategoryAsync(CategoryAlternativeEnum.Featured),

                NewestProducts = await _productService.GetNewestProductsAsync(8),

                SaleBannerCards = await _productService.GetRandomAsync(2),

                TopSellers = await _productService.GetByCategoryAsync(CategoryAlternativeEnum.Popular)
            };

            ViewData["title"] = "Home"; 
            return View(model);
        }
    }
}
