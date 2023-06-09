﻿using Bmerketo.Models.ViewModels;
using Bmerketo.Services;
using Microsoft.AspNetCore.Mvc;
using static Bmerketo.Models.Enums.RegisterEnumModel;
using static Bmerketo.Models.Enums.LoginEnumModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Bmerketo.Models;
using System.Linq;

namespace Bmerketo.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AccountServices _service;
        private readonly UserService _userService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountsController(UserService userService, AccountServices service, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userService = userService;
            _service = service;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        //My Account
        [Authorize]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "My Page";

            AccountIndexViewModel model = new AccountIndexViewModel
            {
                ProfileInformation = await _userService.GetIdentityProfileAsync(User.Identity.Name)
            };

            return View(model);
        }

        //Register
        public IActionResult Register()
        {
            ViewData["Title"] = "Register";
            ViewBag.Roles = _userService.GetRolesSelectListItems();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(UserRegisterViewModel ViewModel)
        {
            ViewData["Title"] = "Register";

            if (User.IsInRole("admin"))
            {
                ViewModel.TermsAndAgreements = true;
                var role = await _roleManager.FindByIdAsync(ViewModel.Role);
                if (role is not null)
                {
                    ViewModel.Role = role.Name;
                }
            }
            else
            {
                ViewModel.Role = "user";
            }

            if (ModelState.IsValid)
            {
                var returnedKey = await _service.RegisterNewAccountAsync(ViewModel);

                if (returnedKey == ResponseEnum.Success)
                {
                    if (User.IsInRole("admin"))
                    {
                        return RedirectToAction("index", "admin");
                    }
                    return RedirectToAction("login", "accounts");
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

            if (!ViewModel.TermsAndAgreements)
            {
                ModelState.AddModelError(nameof(ViewModel.TermsAndAgreements), "You must accept the terms and agreements to register.");
            }

            return View(ViewModel);
        }


        //Login
        public IActionResult Login()
        {
            ViewData["Title"] = "Login";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel ViewModel)
        {
            ViewData["Title"] = "Login";

            if (ModelState.IsValid)
            {
                var returnKey = await _service.LoginToAccountAsync(ViewModel);
                var user = await _userService.GetIdentityProfileAsync(ViewModel.Email);

                if (returnKey == LoginResponseEnum.Success && user != null)
                {
                    if (user.Roles.Contains("admin"))
                    {
                        return RedirectToAction("index", "admin");
                    }
                    else
                    {
                        return RedirectToAction("index", "accounts");
                    }

                }
                else if (returnKey == LoginResponseEnum.Wrong || user == null)
                {
                    ModelState.AddModelError("", "Inaccurate email or password.");
                }
                else if (returnKey == LoginResponseEnum.Failed)
                {
                    ModelState.AddModelError("", "Oops, we can't log you in right now, please try again later!");
                }
            }

            return View(ViewModel);
        }

        //Logout
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            if (await _service.LogoutAsync(User))
                return LocalRedirect("/");

            return RedirectToAction("index");
        }

    }
}
