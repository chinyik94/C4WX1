using System.Net;

namespace C4WX1.API.Features.Shared.Extensions;

public static class StringHtmlExtensions
{
    public static string EncodeToHtml(this string value)
    {
        return WebUtility.HtmlEncode(value);
    }

    public static string DecodeFromHtml(this string html)
    {
        return WebUtility.HtmlDecode(html);
    }
}
