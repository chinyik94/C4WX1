using C4WX1.API.Features.Activity.Constants;
using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.API.Features.Activity.Extensions;

public static class QueryExtensions
{
    public static IQueryable<Database.Models.Activity> Sort(
        this IQueryable<Database.Models.Activity> query,
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
            SortColumns.ProblemInfo => isDescending
            ? query.OrderByDescending(x => x.ProblemListID_FKNavigation.ProblemInfo)
                : query.OrderBy(x => x.ProblemListID_FKNavigation.ProblemInfo),
            _ => isDescending
                ? query.OrderByDescending(x => x.ActivityDetail)
                : query.OrderBy(x => x.ActivityDetail)
        };
        return query;
    }
}
