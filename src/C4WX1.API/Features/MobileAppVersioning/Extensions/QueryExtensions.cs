using C4WX1.API.Features.MobileAppVersioning.Constants;
using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.API.Features.MobileAppVersioning.Extensions;

public static class QueryExtensions
{
    public static IQueryable<Database.Models.MobileAppVersioning> Sort(
        this IQueryable<Database.Models.MobileAppVersioning> query,
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
            SortColumns.Version => isDescending
                ? query.OrderByDescending(x => x.Version)
                : query.OrderBy(x => x.Version),
            SortColumns.CreatedDate => isDescending
                ? query.OrderByDescending(x => x.CreatedDate)
                : query.OrderBy(x => x.CreatedDate),
            SortColumns.UpdatedBy => isDescending
                ? query.OrderByDescending(x => x.ModifiedBy_FK)
                : query.OrderBy(x => x.ModifiedBy_FK),
            _ => isDescending
                ? query.OrderByDescending(x => x.ModifiedDate)
                : query.OrderBy(x => x.ModifiedDate)
        };
        return query;
    }
}
