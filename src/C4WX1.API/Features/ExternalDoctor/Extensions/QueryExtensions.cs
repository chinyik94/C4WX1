using C4WX1.API.Features.ExternalDoctor.Constants;
using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.API.Features.ExternalDoctor.Extensions;

public static class QueryExtensions
{
    public static IQueryable<Database.Models.ExternalDoctor> Sort(
        this IQueryable<Database.Models.ExternalDoctor> query,
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
            SortColumns.Name => isDescending
            ? query.OrderByDescending(x => x.Name)
                : query.OrderBy(x => x.Name),
            SortColumns.Type => isDescending
                ? query.OrderByDescending(x => x.ClinicianTypeID_FKNavigation != null
                    ? x.ClinicianTypeID_FKNavigation.UserType1
                    : null)
                : query.OrderBy(x => x.ClinicianTypeID_FKNavigation != null
                    ? x.ClinicianTypeID_FKNavigation.UserType1
                    : null),
            SortColumns.Email => isDescending
            ? query.OrderByDescending(x => x.Email)
                : query.OrderBy(x => x.Email),
            SortColumns.Contact => isDescending
                ? query.OrderByDescending(x => x.Contact)
                : query.OrderBy(x => x.Contact),
            _ => isDescending
                ? query.OrderByDescending(x => x.Name)
                : query.OrderBy(x => x.Name)
        };
        return query;
    }
}
