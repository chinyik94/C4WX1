using System.Globalization;

namespace C4WX1.API.Features.Shared.Extensions;

public static class DateTimeExtensions
{
    public static DateTime? ParseExact(this string? dateTimeString, string format)
    {
        if (string.IsNullOrWhiteSpace(dateTimeString))
        {
            return null;
        }
        if (DateTime.TryParseExact(dateTimeString, format, new CultureInfo("en-US"), DateTimeStyles.None, out var result))
        {
            return result;
        }
        return null;
    }
}