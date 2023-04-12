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

namespace Bmerketo.Services
{
    public class AccountServices
    {
        private readonly DataContext _context;

        public AccountServices(DataContext context)
        {
            _context = context;
        }

        public async Task<UserEntity?> GetUserByEmailAsync(string email)
        {
            var _userFromDb = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return _userFromDb;
        }

        public async Task<ResponseEnum> RegisterNewAccountAsync(RegisterViewModel registerViewModel)
        {
            try
            {
                //converts from registration to entities. 
                UserEntity userEntity = registerViewModel;
                AdressEntity adressEntity = registerViewModel;

                //create Address
                var _adressFromDB = await _context.Adresses.FirstOrDefaultAsync(x => x.StreetName == adressEntity.StreetName && x.PostalCode == adressEntity.PostalCode && x.City == adressEntity.City);
                var _userFromDB = await GetUserByEmailAsync(userEntity.Email);

                if (_userFromDB is null)
                {
                    if (_adressFromDB is null)
                    {
                        userEntity.AdressId = adressEntity.Id;

                        _context.Adresses.Add(adressEntity);
                        _context.Users.Add(userEntity);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        userEntity.AdressId = _adressFromDB.Id;

                        //Create User
                        _context.Users.Add(userEntity);
                        await _context.SaveChangesAsync();
                    }

                    return ResponseEnum.Success;

                }  
                
                return ResponseEnum.EmailExists;

            }
            catch
            {
                return ResponseEnum.Failed;
            }
        }

        public async Task<LoginResponseEnum> LoginToAccountAsync(LoginViewModel loginViewModel)
        {
            try
            {
                var _userFromDb = await GetUserByEmailAsync(loginViewModel.Email);

                if (_userFromDb is not null)
                {
                    if (_userFromDb.VerifySecurePassword(loginViewModel.Password))
                    {
                        return LoginResponseEnum.Success;
                    }
                }
                return LoginResponseEnum.Wrong;
            }
            catch { return LoginResponseEnum.Failed; }
        }
    }
}
