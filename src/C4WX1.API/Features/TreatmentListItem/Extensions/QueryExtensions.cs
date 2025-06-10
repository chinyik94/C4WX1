using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.TreatmentListItem.Constants;

namespace C4WX1.API.Features.TreatmentListItem.Extensions;

public static class QueryExtensions
{
    public static IQueryable<Database.Models.TreatmentListItem> Sort(
        this IQueryable<Database.Models.TreatmentListItem> query,
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
            SortColumns.ProductType => isDescending
                ? query.OrderByDescending(x => x.TListTypeID_FKNavigation.CodeName)
                : query.OrderBy(x => x.TListTypeID_FKNavigation.CodeName),
            SortColumns.ItemBrand => isDescending
                ? query.OrderByDescending(x => x.ItemBrand)
                : query.OrderBy(x => x.ItemBrand),
            SortColumns.IsActive => isDescending
                ? query.OrderByDescending(x => x.IsActive)
                : query.OrderBy(x => x.IsActive),
            _ => isDescending
                ? query.OrderByDescending(x => x.ItemName)
                : query.OrderBy(x => x.ItemName)
        };
        return query;
    }
}
