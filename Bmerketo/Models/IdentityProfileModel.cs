using Bmerketo.Models.Entities;
using Bmerketo.Services;
using Microsoft.AspNetCore.Identity;

namespace Bmerketo.Models
{
    public class IdentityProfileModel
    {
        public IdentityUser User { get; set; }
        public UserProfileEntity Profile { get; set; }
        public IList<string> Roles { get; set; }
    }
}
