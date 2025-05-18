using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.API.Features.Package.Extensions;

public static class QueryExtensions
{
    public static IQueryable<Database.Models.Package> Sort(
        this IQueryable<Database.Models.Package> query,
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
                ? query.OrderByDescending(x => x.PackageName)
                : query.OrderBy(x => x.PackageName)
        };
        return query;
    }
}
