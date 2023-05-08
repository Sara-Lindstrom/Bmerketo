using Bmerketo.Extensions;
using Bmerketo.Models.Entities;
using Bmerketo.Services;
using System.ComponentModel.DataAnnotations;
using static Bmerketo.Models.Enums.CategoryEnumModel;

namespace Bmerketo.Models.ViewModels;

public class ProductRegistrationViewModel
{

    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Product title is required")]
    [Display(Name = "Product Title *")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Product description is required.")]
    [Display(Name = "Product Description *")]
    public string Description { get; set; } = null!;

    [Display(Name = "Product Review (demonstrative porpoise)")]
    public int? Review { get; set; }

    [Required(ErrorMessage = "Product price is required.")]
    [Display(Name = "Product Price *")]
    [DataType(DataType.Currency)]
    [RegularExpression(@"^(?!0+$)\d{1,8}(\.\d{1,2})?$", ErrorMessage = "Please enter a valid Price")]
    public decimal? Price { get; set; }

    [Display(Name = "Discounted price (demonstrative porpoise)")]
    [DataType(DataType.Currency)]
    [RegularExpression(@"^\d{1,8}(\.\d{1,2})?$", ErrorMessage = "Please enter a valid discounted price")]
    public decimal? DiscountPrice { get; set; }

    [Required(ErrorMessage = "Primary image for the product is required")]
    [Display(Name = "Product primary Image *")]
    [ValidateFileExtension(new string[] { "jpeg",".jpg",".png",".gif",".bmp",".tiff",".webp",".svg" }, errorMessage: "Please enter Image in jpeg, jpg, png, gif, bmp, tiff, webp or svg format")]
    public IFormFile PrimaryImage { get; set; } = null!;

    [Required(ErrorMessage = "image is required")]
    [Display(Name = "Product Image *")]
    [ValidateFileExtension(new string[] { "jpeg", ".jpg", ".png", ".gif", ".bmp", ".tiff", ".webp", ".svg" }, errorMessage: "Please enter Image in jpeg, jpg, png, gif, bmp, tiff, webp or svg format")]
    public IFormFile ImageOne { get; set; } = null!;

    [Required(ErrorMessage = "image is required")]
    [Display(Name = "Product Image *")]
    [ValidateFileExtension(new string[] { "jpeg", ".jpg", ".png", ".gif", ".bmp", ".tiff", ".webp", ".svg" }, errorMessage: "Please enter Image in jpeg, jpg, png, gif, bmp, tiff, webp or svg format")]
    public IFormFile ImageTwo { get; set; } = null!;

    [Required(ErrorMessage = "image is required")]
    [ValidateFileExtension(new string[] { "jpeg", ".jpg", ".png", ".gif", ".bmp", ".tiff", ".webp", ".svg" }, errorMessage: "Please enter Image in jpeg, jpg, png, gif, bmp, tiff, webp or svg format")]
    [Display(Name = "Product Image *")]
    public IFormFile ImageThree { get; set; } = null!;

    [Required(ErrorMessage = "image is required")]
    [Display(Name = "Product Image *")]
    [ValidateFileExtension(new string[] { "jpeg", ".jpg", ".png", ".gif", ".bmp", ".tiff", ".webp", ".svg" }, errorMessage: "Please enter Image in jpeg, jpg, png, gif, bmp, tiff, webp or svg format")]
    public IFormFile ImageFour { get; set; } = null!;


    public static implicit operator ProductEntity(ProductRegistrationViewModel registrationViewModel)
    {
        return new ProductEntity
        {
            Id = registrationViewModel.Id,
            Title = registrationViewModel.Title,
            Description = registrationViewModel.Description,
            Review = registrationViewModel.Review,
            Price = Convert.ToDecimal(registrationViewModel.Price),
            DiscountPrice = registrationViewModel.DiscountPrice,
            ProductImageData = new ProductImageEntity
            {
                Id = Guid.NewGuid(),
                PrimaryImageData = TypeConvertServices.ImageIFormateFileTobase64Convert(registrationViewModel.PrimaryImage),
                PrimaryImageMimeType = registrationViewModel.PrimaryImage.ContentType,
                ImageDataOne = TypeConvertServices.ImageIFormateFileTobase64Convert(registrationViewModel.ImageOne),
                ImageOneMimeType = registrationViewModel.ImageOne.ContentType,
                ImageDatatwo = TypeConvertServices.ImageIFormateFileTobase64Convert(registrationViewModel.ImageTwo),
                ImageTwoMimeType = registrationViewModel.ImageTwo.ContentType,
                ImageDatathree = TypeConvertServices.ImageIFormateFileTobase64Convert(registrationViewModel.ImageThree),
                ImagethreeMimeType= registrationViewModel.ImageThree.ContentType,
                ImageDatafour = TypeConvertServices.ImageIFormateFileTobase64Convert(registrationViewModel.ImageFour),
                ImageFourMimeType= registrationViewModel.ImageFour.ContentType,
            }
        };
    }
}
