namespace C4WX1.API.Features.Shared.Repository;

public interface IAccessibleRepository
{
    Task<Dictionary<int, bool>> BatchCanAccessPatientDashboardAsync(
        int userId,
        int facilityId,
        int[] patientIds);
}
