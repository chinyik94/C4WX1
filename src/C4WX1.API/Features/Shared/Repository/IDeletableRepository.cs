namespace C4WX1.API.Features.Shared.Repository;

public interface IDeletableRepository
{
    Task<Dictionary<int, bool>> BatchCanDeleteAsync(int[] ids);
    Task<bool> CanDeleteAsync(int id);
}
