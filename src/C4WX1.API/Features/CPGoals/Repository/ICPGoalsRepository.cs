namespace C4WX1.API.Features.CPGoals.Repository;

public interface ICPGoalsRepository
{
    Task<Dictionary<int, bool>> BatchCanDeleteAsync(int[] ids);
    Task<bool> CanDeleteAsync(int id);
}
