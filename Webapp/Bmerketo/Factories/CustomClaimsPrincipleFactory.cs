using Bmerketo.Models.Entities;
using Bmerketo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Bmerketo.Factories
{
    public class CustomClaimsPrincipleFactory : UserClaimsPrincipalFactory<IdentityUser>
    {
        private readonly UserService _userService;
        public CustomClaimsPrincipleFactory(UserManager<IdentityUser> userManager, IOptions<IdentityOptions> optionsAccessor, UserService userService) : base(userManager, optionsAccessor)
        {
            _userService = userService;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
        {
            var claimIdentity = await base.GenerateClaimsAsync(user);
            var userProfileEntity = await _userService.GetUserProfileAsync(user.Id);

            claimIdentity.AddClaim(new Claim("DisplayName", $"{userProfileEntity.FirstName} {userProfileEntity.LastName}"));

            var roles = await UserManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claimIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            return claimIdentity;
        }
    }
}
