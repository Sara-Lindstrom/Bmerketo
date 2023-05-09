using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerketo.Models.Entities
{
    public class ContactEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(320)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? Phone { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? CompanyName { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Message { get; set; }

        public bool SaveInfoInBrowser { get; set; }
    }
}
