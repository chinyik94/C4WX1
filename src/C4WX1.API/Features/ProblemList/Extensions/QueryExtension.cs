using C4WX1.API.Features.ProblemList.Constants;
using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.API.Features.ProblemList.Extensions;

public static class QueryExtensions
{
    public static IQueryable<Database.Models.ProblemList> Sort(
        this IQueryable<Database.Models.ProblemList> query,
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
            SortColumns.DiseaseName => isDescending
                ? query.OrderByDescending(x => x.DiseaseID_FKNavigation.DiseaseName)
                : query.OrderBy(x => x.DiseaseID_FKNavigation.DiseaseName),
            _ => isDescending
                ? query.OrderByDescending(x => x.ProblemInfo)
                : query.OrderBy(x => x.ProblemInfo)
        };
        return query;
    }
}