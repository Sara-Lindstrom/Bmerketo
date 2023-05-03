namespace Bmerketo.Models.ViewModels
{
    public class UserAdministrationViewModel
    {
        public IEnumerable<IdentityProfileModel> Users { get; set; }
        public IEnumerable<IdentityProfileModel> Employees { get; set; }
    }
}
