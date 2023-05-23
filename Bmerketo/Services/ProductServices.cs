using Bmerketo.Contexts;
using Bmerketo.Models;
using Bmerketo.Models.Entities;
using Bmerketo.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using static Bmerketo.Models.Enums.CategoryEnumModel;

namespace Bmerketo.Services
{
    public class ProductServices
    {
        private readonly DataContext _context;
        private readonly CategoryService _categoriesService;

        public ProductServices(DataContext context, CategoryService categoriesService)
        {
            _context = context;
            _categoriesService = categoriesService;
        }

        public async Task<bool> RegisterNewProduct(ProductRegistrationViewModel registerViewModel, string[] tags)
        {
            try
            {
                ProductEntity _newProduct = registerViewModel;
                _newProduct.CreatedDate = DateTime.Now;
                _newProduct.IsNew = true;

                EntityEntry<ProductEntity> entry = await _context.Products.AddAsync(_newProduct);
                ProductEntity _entity = entry.Entity;

                if (_entity != null )
                {
                    await UpdateOldProductsAsync();
                    await AddProductsTagsAsync(_entity, tags);

                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
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

            var products = new List<CardModel>();

            foreach (var item in items)
            {
                products.Add(item);
            }

            return products;
        }

        public async Task<IEnumerable<CardModel>> GetByCategoryAsync(CategoryAlternativeEnum category)
        {

            var items = await _context.Categories
                .Where(x => x.Category == category)
                .ToListAsync();

            var products = new List<CardModel>();

            foreach (var item in items)
            {
                var product = await _context.Products
                    .Where(p => p.Id == item.ProductId)
                    .Include(p => p.ProductImageData)
                    .FirstOrDefaultAsync();

                if(product != null)
                {
                    products.Add(product);
                }
            }

            return products;

        }

        public async Task<ProductModel> GetByIdAsync(string id)
        {
            var _id = Guid.Parse(id);
            var item = await _context.Products
                .Where(x => x.Id == _id)
                .Include(p => p.ProductImageData)
                .FirstOrDefaultAsync();

            List<CategoryEntity> categories = await _context.Categories
                .Where(c => c.ProductId == item.Id)
                .ToListAsync();

            ProductModel product = new ProductModel
            {
                Product = item,
                ProductImages = item.ProductImageData,
                Categories = categories
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

            var products = new List<CardModel>();

            foreach (var item in items)
            {
                products.Add(item);
            }

            return products;
        }

        public async Task<IEnumerable<CardModel>> GetNewestProductsAsync(int amount)
        {
            var items = await _context.Products
                .Where(p => p.IsNew == true)
                .Take(amount)
                .Include(p => p.ProductImageData)
                .ToListAsync();

            var products = new List<CardModel>();

            foreach (var item in items)
            {
                products.Add(item);
            }

            return products;

        }

        private async Task UpdateOldProductsAsync()
        {
            var oldProducts = await _context.Products
                .OrderByDescending(p => p.CreatedDate)
                .Skip(7)
                .Where(p => p.IsNew == true)
                .ToListAsync();

            if (oldProducts.Count() > 0)
            {
                foreach (var oldProduct in oldProducts)
                {
                    oldProduct.IsNew = false;
                }
            }

            await _context.SaveChangesAsync();
        }

        private async Task AddProductsTagsAsync(ProductEntity entity, string[] tags)
        {
            foreach (var tag in tags)
            {
                var tagId = Convert.ToInt32(tag);
                await _categoriesService.RegisterCategoryAsync(new CategoryEntity
                {
                    ProductId = entity.Id,
                    Product = entity,
                    Category = (CategoryAlternativeEnum)tagId
                });
            }
        }
    }
}
