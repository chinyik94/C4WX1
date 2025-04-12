using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Extensions;

namespace C4WX1.API.Features.CarePlanSubGoal.Extensions;

public static class QueryExtensions
{
    public static IQueryable<Database.Models.CarePlanSubGoal> Sort(
        this IQueryable<Database.Models.CarePlanSubGoal> query,
        string? orderBy)
    {
        if (string.IsNullOrWhiteSpace(orderBy))
        {
            orderBy = SortDirections.Default;
        }

        var order = orderBy.Split(' ');
        var isDescending = order[1].EqualsIgnoreCase(SortDirections.Desc);
        query = isDescending
            ? query.OrderByDescending(x => x.CarePlanSubGoalName)
            : query.OrderBy(x => x.CarePlanSubGoalName);
        return query;
    }
}
