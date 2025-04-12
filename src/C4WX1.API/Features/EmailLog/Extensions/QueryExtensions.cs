using C4WX1.API.Features.EmailLog.Constants;
using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.API.Features.EmailLog.Extensions;

public static class QueryExtensions
{
    public static IQueryable<Database.Models.EmailLog> Sort(
        this IQueryable<Database.Models.EmailLog> query,
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
            SortColumns.CreatedDate => isDescending
            ? query.OrderByDescending(x => x.CreatedDate)
                : query.OrderBy(x => x.CreatedDate),
            SortColumns.MsgTo => isDescending
                ? query.OrderByDescending(x => x.msgTo)
                : query.OrderBy(x => x.msgTo),
            SortColumns.MsgSubj => isDescending
                ? query.OrderByDescending(x => x.msgSubj)
                : query.OrderBy(x => x.msgSubj),
            _ => isDescending
                ? query.OrderByDescending(x => x.EmailLogId)
                : query.OrderBy(x => x.EmailLogId)
        };
        return query;
    }
}
