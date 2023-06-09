﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerketo.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; } = null!;

        [Column(TypeName = "tinyint")]
        public int? Review { get; set; }

        [Required]
        [Column(TypeName ="decimal(7, 2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(7, 2)")]
        public decimal? DiscountPrice { get; set; }

        public ICollection<CategoryEntity>? Categories { get; set; }

        [Required]
        [Column(TypeName ="bit")]
        public bool IsNew { get; set; }

        [Required]
        public ProductImageEntity ProductImageData { get; set; }

    }
}
