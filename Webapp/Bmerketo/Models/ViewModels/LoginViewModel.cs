using System.ComponentModel.DataAnnotations;

namespace Bmerketo.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Your email is required.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = "Your passsword is required.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Please keep me logged in ")]
        public bool KeepMeLoggedIn { get; set; } = false;
    }
}
