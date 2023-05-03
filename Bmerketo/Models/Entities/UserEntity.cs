using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerketo.Models.Entities
{
    public class UserProfileEntity
    {
        [Key, ForeignKey(nameof(User))]
        public string Id { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = null!;

        [Column(TypeName = "nvarchar(50)")]
        public string? CompanyName { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string? ProfileImage { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? ProfileImageMimeType { get; set; }

        [ForeignKey("Adress")]
        [Required]
        [Column(TypeName = "uniqueidentifier")]
        public Guid AdressId { get; set; }
        public AdressEntity Adress { get; set; } = null!;

        public IdentityUser User { get; set; } = null!;
    }
}
