namespace C4WX1.API.Features.Shared.Extensions;

public static class StringComparisonExtensions
{
    public static bool EqualsIgnoreCase(this string a, string b)
    {
        return a.Equals(b, StringComparison.OrdinalIgnoreCase);
    }
}
