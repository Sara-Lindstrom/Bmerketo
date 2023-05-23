using Bmerketo.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerketo.Models.Entities
{
    //I have done this because i want it to be only five images, no more, no less.
    //While this design does not adhere to the principles of normalization strictly, i saw it suitable for this assignment.
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
