using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Skillset.Columns;

namespace C4WX1.API.Features.Skillset.Extensions;

public static class QueryExtensions
{
    public static IQueryable<Database.Models.Code> Sort(
        this IQueryable<Database.Models.Code> query,
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
            SortColumns.Ordering => isDescending
                ? query.OrderByDescending(x => x.Ordering)
                : query.OrderBy(x => x.Ordering),
            _ => isDescending
                ? query.OrderByDescending(x => x.CodeName)
                : query.OrderBy(x => x.CodeName)
        };
        return query;
    }
}
