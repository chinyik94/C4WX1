using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Shared.Repository;

public interface IWoundStatusRepository
{
    Task<bool> GetWoundInfectionStatusAsync(
        int userId,
        int patientId,
        int patientWoundVisitId);

    Task<WoundInfectionStatusDetailsDto> GetWoundInfectionStatusDetailsAsync(
        int userId,
        int patientId,
        int patientWoundVisitId);
}
