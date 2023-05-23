using Bmerketo.Contexts;
using Bmerketo.Models.Entities;
using Bmerketo.Models.Enums;
using Bmerketo.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Runtime.CompilerServices;
using static Bmerketo.Models.Enums.RegisterEnumModel;
using static Bmerketo.Models.Enums.LoginEnumModel;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;
using Bmerketo.Models;

namespace Bmerketo.Services
{
    public class AccountServices
    {
        private readonly IdentityContext _identityContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public readonly RoleManager<IdentityRole> _roleManager;

        public AccountServices(IdentityContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _identityContext = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        public async Task<ResponseEnum> RegisterNewAccountAsync(UserRegisterViewModel model)
        {

            try
            {

                IdentityUser identityUser = model;

                if ((await _userManager.CreateAsync(identityUser, model.Password)).Succeeded)
                {
                    //Add Admin as role
                    if (await _userManager.Users.CountAsync() == 1)
                    {
                        await _userManager.AddToRoleAsync(identityUser, "admin");
                    }
                    else
                    {
                        //Add user as role
                        var role = await _roleManager.FindByNameAsync(model.Role);
                        await _userManager.AddToRoleAsync(identityUser, role.Name);
                    }

                    //converts from registration to entities. 
                    UserProfileEntity userProfileEntity = model;
                    userProfileEntity.Id = identityUser.Id;

                    AdressEntity adressEntity = model;

                    //create Address
                    var _adressFromDB = await _identityContext.Adresses
                        .FirstOrDefaultAsync(x => x.StreetName == adressEntity.StreetName && x.PostalCode == adressEntity.PostalCode && x.City == adressEntity.City);


                    if (_adressFromDB is null)
                    {
                        userProfileEntity.AdressId = adressEntity.Id;

                        _identityContext.Adresses.Add(adressEntity);
                        _identityContext.UserProfiles.Add(userProfileEntity);
                        await _identityContext.SaveChangesAsync();
                    }
                    else
                    {
                        userProfileEntity.AdressId = _adressFromDB.Id;

                        //Create User
                        _identityContext.UserProfiles.Add(userProfileEntity);
                        await _identityContext.SaveChangesAsync();

                    }

                    return ResponseEnum.Success;
                }

                return ResponseEnum.EmailExists;

            }
            catch
            {
                IdentityUser identityUser = model;
                AdressEntity adressEntity = model;

                var existingUser = await _userManager.FindByEmailAsync(identityUser.Email);
                if (existingUser is not null)
                {
                    var existingProfile = await _identityContext.UserProfiles
                        .Where(p => p.User == existingUser)
                        .FirstOrDefaultAsync();

                    if (existingProfile is not null)
                    {
                        _identityContext.UserProfiles.Remove(existingProfile);
                    }

                    await _userManager.DeleteAsync(existingUser);
                    await _identityContext.SaveChangesAsync();
                }

                DeleteUnreferencedAddresses();

                return ResponseEnum.Failed;
            }
        }

        public async Task DeleteUnreferencedAddresses()
        {
            var unreferencedAddresses = await _identityContext.Adresses
                .Where(a => !_identityContext.UserProfiles.Any(p => p.AdressId == a.Id))
                .ToListAsync();

            _identityContext.Adresses.RemoveRange(unreferencedAddresses);
            var numDeleted = await _identityContext.SaveChangesAsync();
        }

        public async Task<LoginResponseEnum> LoginToAccountAsync(LoginViewModel model)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.KeepMeLoggedIn, false);
                
                if (result.Succeeded)
                {
                    return LoginResponseEnum.Success;
                }

                return LoginResponseEnum.Wrong;
            }
            catch { return LoginResponseEnum.Failed; }
        }

        public async Task<bool> LogoutAsync(ClaimsPrincipal user)
        {
            await _signInManager.SignOutAsync();

            return _signInManager.IsSignedIn(user);
        }
    }
}
