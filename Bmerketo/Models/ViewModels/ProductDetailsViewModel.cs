using Bmerketo.Models.Entities;

namespace Bmerketo.Models.ViewModels
{
    public class ProductDetailsViewModel
    {
        public BreadcrumbViewModel Breadcrumb { get; set; }
        public ProductModel Product { get; set; }
        public List<CardModel> RelatedCards { get; set; }
    }
}
