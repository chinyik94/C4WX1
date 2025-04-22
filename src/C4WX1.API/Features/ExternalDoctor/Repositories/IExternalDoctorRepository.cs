namespace C4WX1.API.Features.ExternalDoctor.Repositories;

public interface IExternalDoctorRepository
{
    Task<bool> CanDeleteAsync(int id);
    Task<Dictionary<int, bool>> BatchCanDeleteAsync(int[] ids);
}
