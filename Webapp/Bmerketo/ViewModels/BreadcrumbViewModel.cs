namespace Bmerketo.ViewModels
{
    public class BreadcrumbViewModel
    {
        public string Title { get; set; } = null!;
        public List<string> Crumbs { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
