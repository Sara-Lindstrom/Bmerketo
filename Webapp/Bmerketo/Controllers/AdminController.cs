using Bmerketo.Models.ViewModels;
using Bmerketo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly UserService _userService;

        public AdminController(UserService userService)
        {
            _userService = userService;
        }


        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Admin";

            AdminIndexViewModel model = new AdminIndexViewModel
            {
                ProfileInformation = await _userService.GetIdentityProfileAsync(User.Identity.Name),
            };

            return View(model);
        }


        public async Task<IActionResult> UserAdministration()
        {
            ViewData["Title"] = "User Admin";

            UserAdministrationViewModel model = new UserAdministrationViewModel
            {
                Users = await _userService.GetIdentityProfilesRolesAsync("user"),
                Employees = await _userService.GetIdentityProfilesRolesAsync("admin")
            };

            return View(model);
        }
    }
}
