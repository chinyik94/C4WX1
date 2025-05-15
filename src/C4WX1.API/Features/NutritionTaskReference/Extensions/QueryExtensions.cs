using C4WX1.API.Features.NutritionTaskReference.Constants;
using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.API.Features.NutritionTaskReference.Extensions;

public static class QueryExtensions
{
    public static IQueryable<Database.Models.NutritionTaskReference> Sort(
        this IQueryable<Database.Models.NutritionTaskReference> query,
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
            SortColumns.GroupID => isDescending
                ? query.OrderByDescending(x => x.CodeId_FKNavigation.CodeTypeId_FK)
                : query.OrderBy(x => x.CodeId_FKNavigation.CodeTypeId_FK),
            _ => isDescending
                ? query.OrderByDescending(x => x.ReferenceID)
                : query.OrderBy(x => x.ReferenceID)
        };
        return query;
    }
}
