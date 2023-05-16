using System.Globalization;
using System.Text.RegularExpressions;

namespace Bmerketo.Services
{
    public class FormatService
    {
        public static string FormatPhoneNumber(string? phoneNumber)
        {
            if (phoneNumber is not null)
            {
                string cleanedNumber = Regex.Replace(phoneNumber, @"\D", "");
                string formattedNumber = Regex.Replace(cleanedNumber, @"(\d{3})(\d{3})(\d{2})(\d{2})", "$1 $2 $3 $4");
                return formattedNumber;
            }

            return "";
        }

        public static string FormatPostalCode(string phoneNumber)
        {
            string cleanedNumber = Regex.Replace(phoneNumber, @"\D", "");
            string formattedNumber = Regex.Replace(cleanedNumber, @"(\d{3})(\d{2})", "$1 $2");

            return formattedNumber;
        }

        public static string FormatName(string name)
        {
            string trimmedName = name.Trim();
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            string formattedName = textInfo.ToTitleCase(trimmedName);

            return formattedName;
        }
    }
}
