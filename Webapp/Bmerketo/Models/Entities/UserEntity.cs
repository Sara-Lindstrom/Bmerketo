using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace Bmerketo.Models.Entities
{
    public class UserEntity
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(320)")]
        public string Email { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = null!;

        [Column(TypeName = "char(13)")]
        public string? PhoneNumber { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? CompanyName { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string? ProfileImage { get; set; }

        [Required]
        [Column(TypeName = "varbinary(max)")]
        public byte[] Password { get; private set; } = null!;

        [Required]
        [Column(TypeName = "varbinary(max)")]
        public byte[] SecurityKey { get; private set; } = null!;

        [ForeignKey("Adress")]
        [Required]
        [Column(TypeName = "uniqueidentifier")]
        public Guid AdressId { get; set; }
        public AdressEntity Adress { get; set; } = null!;

        public void GenerateSecurePassword(string password)
        {
            using var hmac = new HMACSHA512();
            SecurityKey = hmac.Key;
            Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public bool VerifySecurePassword (string password)
        {
            using var hmac = new HMACSHA512(SecurityKey);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for(int i = 0; i < hash.Length; i++)
            {
                if (hash[i] != Password[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
