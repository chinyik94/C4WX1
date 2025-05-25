using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.API.Features.RecentView.Extensions;

public static class QueryExtensions
{
    public static IEnumerable<Database.Models.RecentView> Sort(
        this IEnumerable<Database.Models.RecentView> query,
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
            _ => isDescending
                ? query.OrderByDescending(x => x.DateView)
                : query.OrderBy(x => x.DateView)
        };
        return query;
    }
}
