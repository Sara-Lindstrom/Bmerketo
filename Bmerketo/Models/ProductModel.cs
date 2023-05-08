using Bmerketo.Models.Entities;

namespace Bmerketo.Models
{
    public class ProductModel
    {
        public ProductEntity Product { get; set; }
        public ProductImageEntity ProductImages { get; set; }
        public List<CategoryEntity>? Categories { get; set; }
    }
}
