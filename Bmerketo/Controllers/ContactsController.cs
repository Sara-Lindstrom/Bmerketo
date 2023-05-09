using Bmerketo.Models.ViewModels;
using Bmerketo.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Bmerketo.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactService _contactService;

        public ContactsController(ContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var viewModel = new ContactFormViewModel
            {
                Breadcrumb = new BreadcrumbViewModel
                {
                    Title = "CONTACT",
                    Crumbs = new List<string> { "HOME", "CONTACT" },
                }
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Index(ContactFormViewModel viewModel)
        {
            viewModel.Breadcrumb = new BreadcrumbViewModel
            {
                Title = "CONTACT",
                Crumbs = new List<string> { "HOME", "CONTACT" },
            };

            if (ModelState.IsValid)
            {
                _contactService.RegisterContactFormAsync(viewModel);
            }

            return View(viewModel);
        }
    }
}
