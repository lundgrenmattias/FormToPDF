using System.Linq;

namespace FormToPDF.Models.Extensions
{
    public static class StringExtension
    {
        public static string GetFirstName(this string fullName)
        {
            return fullName?.Split(' ').First() ?? string.Empty;
        }

        public static string WithFallback(this string value, string fallback)
        {
            return string.IsNullOrWhiteSpace(value)
                ? fallback
                : value;
        }
    }
}
