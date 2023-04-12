using Bmerketo.Extensions;
using Bmerketo.Models.Entities;
using Bmerketo.Services;
using System.ComponentModel.DataAnnotations;

namespace Bmerketo.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Your first name is required.")]
        [Display(Name = "First Name *")]
        [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage ="Please enter a valid first name.")]
        public string FirstName { get; set; } = null!;


        [Required(ErrorMessage = "Your last name is required.")]
        [Display(Name = "Last Name *")]
        [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "Please enter  a valid last name.")]
        public string LastName { get; set; } = null!;


        [Required(ErrorMessage = "Your street name is required.")]
        [Display(Name = "Street Name *")]
        public string StreetName { get; set; } = null!;


        [Required(ErrorMessage = "Your Postal Code is required.")]
        [Display(Name = "Postal Code *")]
        public string PostalCode { get; set; } = null!;


        [Required(ErrorMessage = "Your city is required.")]
        [Display(Name = "City *")]
        public string City { get; set; } = null!;


        [Display(Name = "Phone Number (optional)")]
        public string? PhoneNumber { get; set; }


        [Display(Name = "Company Name (optional)")]
        public string? CompanyName { get; set; }


        [Required(ErrorMessage = "Your email is required.")]
        [Display(Name = "Email *")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage ="Please enter an valid email (Ex: Name@domain.com).")]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = "Your passsword is required.")]
        [Display(Name = "Password *")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage ="Please enter a valid password.")]
        public string Password { get; set; } = null!;


        [Required(ErrorMessage = "Please confirm your password.")]
        [Display(Name = "Confirm Password *")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Your password confirmation doesn't match your password.")]
        public string ConfirmPassword { get; set; } = null!;


        [Display(Name = "Profile Image (optional)")]
        [ValidateFileExtension(new string[] { ".svg" }, errorMessage: "Please enter Image in svg format")]
        public IFormFile? ProfileImg { get; set; }


        public static implicit operator UserEntity(RegisterViewModel registerViewModel)
        {
            var _userEntity = new UserEntity
            {
                Id = Guid.NewGuid(),
                Email = registerViewModel.Email,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                PhoneNumber = registerViewModel.PhoneNumber,
                CompanyName = registerViewModel.CompanyName,
                ProfileImage = TypeConvertServices.ImageIFormateFileTobase64Convert(registerViewModel.ProfileImg)
            };

            _userEntity.GenerateSecurePassword(registerViewModel.Password);
            return _userEntity;
        }

        public static implicit operator AdressEntity(RegisterViewModel registerViewModel)
        {
            return new AdressEntity
            {
                Id = Guid.NewGuid(),
                StreetName = registerViewModel.StreetName,
                PostalCode = registerViewModel.PostalCode,
                City = registerViewModel.City
            };
        }
    }
}
