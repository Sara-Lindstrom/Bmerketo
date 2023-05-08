using Bmerketo.Models.Entities;
using Bmerketo.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Bmerketo.Models
{
    public class CardModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string ImageMimeType { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }


        public static implicit operator CardModel(ProductEntity model)
        {
            var _cardModel = new CardModel
            {
                Id = model.Id,
                Title = model.Title,
                ImageMimeType = model.ProductImageData.PrimaryImageMimeType,
                ImageUrl = model.ProductImageData.PrimaryImageData,
                Price = model.Price,
                DiscountPrice = model.DiscountPrice,
            };
            return _cardModel;
        }
    }
}
