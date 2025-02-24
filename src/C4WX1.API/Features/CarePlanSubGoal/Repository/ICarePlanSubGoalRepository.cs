namespace C4WX1.API.Features.CarePlanSubGoal.Repository
{
    public interface ICarePlanSubGoalRepository
    {
        Task<Dictionary<int, bool>> BatchCanDeleteAsync(IEnumerable<int> ids);
        Task<bool> CanDeleteAsync(int id);
    }
}
