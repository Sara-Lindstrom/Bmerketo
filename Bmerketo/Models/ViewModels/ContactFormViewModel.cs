using Bmerketo.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Bmerketo.Models.ViewModels
{
    public class ContactFormViewModel
    {
        public BreadcrumbViewModel? Breadcrumb { get; set; }


        public Guid Id { get; set; } = Guid.NewGuid();


        [Required(ErrorMessage = "Your name is required.")]
        [Display(Name = "Name *")]
        [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "Please enter a valid name.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Your email is required.")]
        [Display(Name = "Email *")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email (Ex: Name@domain.com).")]
        public string Email { get; set; }


        [Display(Name = "Phone Number (optional)")]
        public string? Phone { get; set; }


        [Display(Name = "Company Name (optional)")]
        public string? CompanyName { get; set; }


        [Required(ErrorMessage = "A message is required.")]
        [Display(Name = "Message *")]
        public string Message { get; set; }


        [Display(Name = "Save my name, email in the this browser for the next time I comment.")]
        public bool SaveInfoInBrowser { get; set; }

        public static implicit operator ContactEntity(ContactFormViewModel model)
        {
            var _contactEntity = new ContactEntity
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                CompanyName = model.CompanyName,
                Message = model.Message,
                SaveInfoInBrowser = model.SaveInfoInBrowser,
            };

            return _contactEntity;
        }
    }
}
