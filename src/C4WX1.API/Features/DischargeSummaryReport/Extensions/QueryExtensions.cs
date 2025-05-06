using C4WX1.API.Features.DischargeSummaryReport.Constants;
using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.API.Features.DischargeSummaryReport.Extensions;

public static class QueryExtensions
{
    public static IQueryable<Database.Models.DischargeSummaryReport> Sort(
        this IQueryable<Database.Models.DischargeSummaryReport> query, 
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
            SortColumns.Status => isDescending
            ? query.OrderByDescending(x => x.Status)
                : query.OrderBy(x => x.Status),
            SortColumns.CreatedDate => isDescending
                ? query.OrderByDescending(x => x.CreatedDate)
                : query.OrderBy(x => x.CreatedDate),
            _ => isDescending
                ? query.OrderByDescending(x => x.ModifiedDate != null
                    ? x.ModifiedDate
                    : x.CreatedDate)
                : query.OrderBy(x => x.ModifiedDate != null
                    ? x.ModifiedDate
                    : x.CreatedDate)
        };
        return query;
    }
}
