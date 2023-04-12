using System.ComponentModel.DataAnnotations;

namespace Bmerketo.Extensions
{
    //https://copyprogramming.com/howto/how-to-validate-uploaded-file-in-asp-net-core#how-to-validate-uploaded-file-in-aspnet-core

    public class ValidateFileExtension : ValidationAttribute
    {
        private readonly string[] _validFileFormats;
        private readonly string _errorMessage;
        public ValidateFileExtension(string[] validFileFormats, string errorMessage)
        {
            _validFileFormats = validFileFormats;
            _errorMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is not null)
            {
                var extension = Path.GetExtension(file.FileName);
                if (_validFileFormats.Contains(extension.ToLower()) is false)
                {
                    return new ValidationResult(_errorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
