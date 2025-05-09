using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.SysConfig.Constants;

namespace C4WX1.API.Features.SysConfig.Extensions;

public static class QueryExtensions
{
    public static IQueryable<Database.Models.SysConfig> Sort(
        this IQueryable<Database.Models.SysConfig> query,
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
            SortColumns.ConfigValue => isDescending
                ? query.OrderByDescending(x => x.ConfigValue)
                : query.OrderBy(x => x.ConfigValue),
            _ => isDescending
                ? query.OrderByDescending(x => x.ConfigName)
                : query.OrderBy(x => x.ConfigName)
        };
        return query;
    }
}
