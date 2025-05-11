using C4WX1.API.Features.Item.Constants;
using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.API.Features.Item.Extensions;

public static class QueryExtensions
{
    public static IQueryable<Database.Models.Item> Sort(
        this IQueryable<Database.Models.Item> query,
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
                ? query.OrderByDescending(x => x.CategoryID_FKNavigation.CodeName)
                : query.OrderBy(x => x.CategoryID_FKNavigation.CodeName),
            SortColumns.Unit => isDescending
                ? query.OrderByDescending(x => x.ItemUnitID_FKNavigation.CodeName)
                : query.OrderBy(x => x.ItemUnitID_FKNavigation.CodeName),
            SortColumns.UnitPrice => isDescending
                ? query.OrderByDescending(x => x.UnitPrice)
                : query.OrderBy(x => x.UnitPrice),
            SortColumns.Quantity => isDescending
                ? query.OrderByDescending(x => x.Quantity)
                : query.OrderBy(x => x.Quantity),
            SortColumns.Billing => isDescending
                ? query.OrderByDescending(x => x.AvailableInBilling)
                : query.OrderBy(x => x.AvailableInBilling),
            _ => isDescending
                ? query.OrderByDescending(x => x.ItemName)
                : query.OrderBy(x => x.ItemName)
        };
        return query;
    }
}
