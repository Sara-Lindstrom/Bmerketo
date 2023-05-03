using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace Bmerketo.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<CardModel> BestCollectionCards { get; set; }
        public IEnumerable<CardModel> NewestProducts { get; set; }
        public IEnumerable<CardModel> SaleBannerCards { get; set; }
        public IEnumerable<CardModel> TopSellers { get; set; }
    }
}
