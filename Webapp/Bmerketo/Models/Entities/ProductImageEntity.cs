using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerketo.Models.Entities
{
    public class ProductImageEntity
    {
        [ForeignKey("ProductEntity")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string PrimaryImageData { get; set; }

        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string ImageDataOne { get; set; }

        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string ImageDatatwo { get; set; }

        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string ImageDatathree { get; set; }

        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string ImageDatafour { get; set; }

    }
}
