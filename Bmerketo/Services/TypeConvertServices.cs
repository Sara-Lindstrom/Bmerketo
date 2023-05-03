namespace Bmerketo.Services;

public static class TypeConvertServices
{
    public static string ImageIFormateFileTobase64Convert(IFormFile image)
    {
        var imageBase64string = "";

        if (image is not null)
        {
            using (var ms = new MemoryStream())
            {
                image.CopyTo(ms);
                var fileBytes = ms.ToArray();
                imageBase64string = Convert.ToBase64String(fileBytes);
                return imageBase64string;
            }
        }

        return imageBase64string;
    }
}
