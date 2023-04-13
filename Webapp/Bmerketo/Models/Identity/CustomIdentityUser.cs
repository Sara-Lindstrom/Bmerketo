using Microsoft.AspNetCore.Identity;

namespace Bmerketo.Models.Identity
{
    public class CustomIdentityUser : IdentityUser
    {
        [ProtectedPersonalData]
        public string FirstName { get; set; } = null!;
        //USER ENTITY? "Hur min user ska se ut"+det som finns i IdentutyUser
    }
}
