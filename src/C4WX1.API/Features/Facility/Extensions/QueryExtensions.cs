using C4WX1.API.Features.Facility.Constants;
using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.API.Features.Facility.Extensions;

public static class QueryExtensions
{
    public static IQueryable<Database.Models.Facility> Sort(
        this IQueryable<Database.Models.Facility> query,
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
            SortColumns.Group => isDescending
                ? query.OrderByDescending(x => x.OrganizationID_FKNavigation.CodeName)
                : query.OrderBy(x => x.OrganizationID_FKNavigation.CodeName),
            _ => isDescending
                ? query.OrderByDescending(x => x.FacilityName)
                : query.OrderBy(x => x.FacilityName)
        };
        return query;
    }
}
