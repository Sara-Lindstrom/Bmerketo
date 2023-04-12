using Bmerketo.Contexts;
using Bmerketo.Models.Entities;
using Bmerketo.Models.Enums;
using Bmerketo.Models.ViewModels;
using Bmerketo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Bmerketo.Models.Enums.RegisterEnumModel;
using static Bmerketo.Models.Enums.LoginEnumModel;

namespace Bmerketo.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AccountServices _service;

        public AccountsController(AccountServices service)
        {
            _service = service;
        }

        //Login
        public IActionResult Login()
        {
            ViewData["Title"] = "Login";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel loginViewModel)
        {
            ViewData["Title"] = "Login";

            if (ModelState.IsValid)
            {
                var returnKey = await _service.LoginToAccountAsync(loginViewModel);

                if(returnKey == LoginResponseEnum.Success)
                {
                    return RedirectToAction("Index", "Account");
                }
                else if(returnKey == LoginResponseEnum.Wrong)
                {
                    ModelState.AddModelError("", "Inaccurate email or password.");
                }
                else if(returnKey == LoginResponseEnum.Failed)
                {
                    ModelState.AddModelError("", "Oops, we can't log you in right now, please try again later!");
                }
            }

            return View(loginViewModel);
        }

        //Register
        public IActionResult Register()
        {
            ViewData["Title"] = "Register";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel registerViewModel)
        {
            ViewData["Title"] = "Register";

            if (ModelState.IsValid)
            {
                var returnedKey = await _service.RegisterNewAccountAsync(registerViewModel);

                if (returnedKey == ResponseEnum.Success)
                {
                    return RedirectToAction("Login", "accounts");
                }
                else if (returnedKey == ResponseEnum.EmailExists)
                {
                    ModelState.AddModelError("", "That email is already registered on our site.");
                }
                else if (returnedKey == ResponseEnum.Failed)
                {
                    ModelState.AddModelError("", "Oops, something went wrong and we could not register your account at the moment!");
                }
            }

            return View(registerViewModel);
        }

        //My Account
        public IActionResult Index()
        {
            return View();
        }
    }
}
