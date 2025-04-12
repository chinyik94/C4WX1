namespace C4WX1.API.Features.Activity.Repository;

public interface IActivityRepository
{
    Task<bool> CanDeleteAsync(int activityId);
    Task<Dictionary<int, bool>> BatchCanDeleteAsync(IEnumerable<int> activityIds);
}
