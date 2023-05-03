using Bmerketo.Contexts;
using Bmerketo.Models;
using Bmerketo.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo.Services
{
    public class UserService
    {
        private readonly IdentityContext _identityContext;
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(IdentityContext context, UserManager<IdentityUser> userManager)
        {
            _identityContext = context;
            _userManager = userManager;
        }

        public async Task<UserProfileEntity?> GetUserProfileAsync(string userId)
        {
            var userProfileEntity = await _identityContext.UserProfiles.Include(x => x.User).Include(x=>x.Adress).FirstOrDefaultAsync(x => x.Id == userId);

            return userProfileEntity;
        }

        public async Task<IdentityProfileModel> GetIdentityProfileAsync(string email)
        {
            var _user = await _userManager.FindByNameAsync(email);
            var _profile = await GetUserProfileAsync(_user.Id);
            var _roles = await _userManager.GetRolesAsync(_user);

            IdentityProfileModel profile = new IdentityProfileModel
            {
                User = _user,
                Profile = _profile,
                Roles = _roles
            };

            return profile;
        }

        public async Task<IEnumerable<IdentityProfileModel>> GetIdentityProfilesRolesAsync(string role)
        {
            var UsersWithRole = await _userManager.GetUsersInRoleAsync(role);
            
            List<IdentityProfileModel> result = new List<IdentityProfileModel>();
            
            foreach (var item in UsersWithRole)
            {
                IdentityProfileModel profile = new IdentityProfileModel
                {
                    User = item,
                    Profile = await GetUserProfileAsync(item.Id),
                    Roles = await _userManager.GetRolesAsync(item)
                };

                result.Add(profile);
            }

            return result;
        }
    }
}
