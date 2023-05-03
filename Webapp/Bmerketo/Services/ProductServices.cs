using Bmerketo.Contexts;
using Bmerketo.Models;
using Bmerketo.Models.Entities;
using Bmerketo.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using static Bmerketo.Models.Enums.CategoryEnumModel;

namespace Bmerketo.Services
{
    public class ProductServices
    {
        private readonly DataContext _context;

        public ProductServices(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterNewProduct(ProductRegistrationViewModel registerViewModel)
        {
            try
            {
                ProductEntity _newProduct = registerViewModel;
                _newProduct.CreatedDate = DateTime.Now;
                _newProduct.IsNew = true;

                _context.Products.Add(_newProduct);

                var oldProducts = await _context.Products
                    .OrderByDescending(p => p.CreatedDate)
                    .Skip(8)
                    .Where(p=>p.IsNew == true)
                    .ToListAsync();

                if (oldProducts.Count() > 0)
                {
                    foreach (var oldProduct in oldProducts)
                    {
                        oldProduct.IsNew = false;
                    }
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<CardModel>> GetAllAsync()
        {
            var items = await _context.Products
                .Include(p => p.ProductImageData)
                .ToListAsync();

            var products = ProductEntityToCardModel(items);

            return products;
        }

        public async Task<IEnumerable<CardModel>> GetByCategoryAsync(CategoryAlternativeEnum category)
        {
            var items = await _context.Products
                .Where(x => x.Category == category)
                .Include(p=> p.ProductImageData)
                .ToListAsync();

            var products = ProductEntityToCardModel(items);

            return products;

        }

        public async Task<ProductModel> GetByIdAsync(string id)
        {
            var _id = new Guid(id);
            var item = await _context.Products
                .Where(x => x.Id == _id)
                .Include(p => p.ProductImageData)
                .FirstOrDefaultAsync();

            ProductModel product = new ProductModel
            {
                Product = item,
                ProductImages = item.ProductImageData
            };

            return product;

        }

        //https://stackoverflow.com/questions/7781893/ef-code-first-how-to-get-random-rows
        public async Task<IEnumerable<CardModel>> GetRandomAsync(int amount)
        {
            var items = await _context.Products
                .OrderBy(r => EF.Functions.Random())
                .Where(p => p.DiscountPrice != null)
                .Take(amount)
                .Include(p => p.ProductImageData)
                .ToListAsync();

            var products = ProductEntityToCardModel(items);
            return products;
        }

        public async Task<IEnumerable<CardModel>> GetNewestProductsAsync(int amount)
        {
            var items = await _context.Products
                .Where(p => p.IsNew == true)
                .Take(amount)
                .Include(p => p.ProductImageData)
                .ToListAsync();

            var products = ProductEntityToCardModel(items);
            return products;

        }

        private IEnumerable<CardModel> ProductEntityToCardModel(List<ProductEntity> items)
        {
            var products = new List<CardModel>();

            if (items.Count != 0)
            {
                foreach (var item in items)
                {
                    var productCard = new CardModel
                    {
                        Id = item.Id,
                        Title = item.Title,
                        ImageUrl = item.ProductImageData.PrimaryImageData,
                        ImageMimeType = item.ProductImageData.PrimaryImageMimeType,
                        Price = item.Price,
                        DiscountPrice = item.DiscountPrice,
                    };
                    products.Add(productCard);
                }
            }
            return products;

        }
    }
}
