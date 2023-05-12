using Bmerketo.Contexts;
using Bmerketo.Models;
using Bmerketo.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Bmerketo.Services
{
    public class UserService
    {
        private readonly IdentityContext _identityContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(IdentityContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _identityContext = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<UserProfileEntity?> GetUserProfileAsync(string userId)
        {
            var userProfileEntity = await _identityContext.UserProfiles.Include(x => x.User).Include(x=>x.Adress).FirstOrDefaultAsync(x => x.Id == userId);

            return userProfileEntity;
        }

        public async Task<IdentityProfileModel> GetIdentityProfileAsync(string email)
        {
            if(email != "")
            {
                var _user = await _userManager.FindByNameAsync(email);
                if(_user is not null)
                {
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
                return null!;
            }

            return null!;
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

        public async Task UpdateIdentityRoles(string id, string[] roles)
        {
            var user = await _userManager.FindByIdAsync(id);
            var newroles = new List<IdentityRole>();

            foreach (var item in roles)
            {
                if(item is not null)
                {
                    newroles.Add(await _roleManager.FindByIdAsync(item));
                }
            }

            if (user is not null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                if(userRoles is not null)
                {
                    await _userManager.RemoveFromRolesAsync(user, userRoles);

                    foreach (var role in newroles)
                    {
                        await _userManager.AddToRoleAsync(user, role.Name);
                    }
                }
            }
        }
    }
}
