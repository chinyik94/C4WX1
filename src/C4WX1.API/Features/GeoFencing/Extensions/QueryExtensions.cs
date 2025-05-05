using C4WX1.API.Features.GeoFencing.Constants;
using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.API.Features.GeoFencing.Extensions;

public static class QueryExtensions
{
    public static IQueryable<Database.Models.GeoFencing> Sort(
        this IQueryable<Database.Models.GeoFencing> query,
        string? orderBy)
    {
        if (string.IsNullOrWhiteSpace(orderBy))
        {
            orderBy = SortDirections.Default;
        }

        var order = orderBy.Split(' ');
        var sortColumn = order[0];
        var isDescending = order[1].Equals(SortDirections.Desc, StringComparison.OrdinalIgnoreCase);
        query = sortColumn switch
        {
            SortColumns.Ip => isDescending
                ? query.OrderByDescending(x => x.IP)
                : query.OrderBy(x => x.IP),
            SortColumns.Description => isDescending
                ? query.OrderByDescending(x => x.Description)
                : query.OrderBy(x => x.Description),
            _ => isDescending
                ? query.OrderByDescending(x => x.IP)
                : query.OrderBy(x => x.IP)
        };
        return query;
    }
}
