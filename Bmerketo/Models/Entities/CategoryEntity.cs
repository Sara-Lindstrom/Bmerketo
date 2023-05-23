using Bmerketo.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerketo.Models.Entities
{
    [PrimaryKey(nameof(ProductId), nameof(Category))]
    public class CategoryEntity
    {
        [Required]
        public Guid ProductId { get; set; }

        public ProductEntity Product { get; set; }

        [Required]
        [Column(TypeName = "tinyint")]
        public CategoryEnumModel.CategoryAlternativeEnum Category { get; set; }

    }
}
