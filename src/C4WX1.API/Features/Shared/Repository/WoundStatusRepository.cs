using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;
using Dapper;
using Npgsql;

namespace C4WX1.API.Features.Shared.Repository;

public abstract class WoundStatusRepository(IConfiguration configuration)
    : IWoundStatusRepository
{
    protected string? ConnectionString => configuration.GetConnectionString("Default");

    public async Task<bool> GetWoundInfectionStatusAsync(
        int userId,
        int patientId,
        int patientWoundVisitId)
    {
        if (string.IsNullOrWhiteSpace(ConnectionString))
        {
            throw new Exception("ConnectionString must be provided!");
        }

        using var connection = new NpgsqlConnection(ConnectionString);
        return await connection.QuerySingleAsync<bool>(
            C4WX1Sqls.GetWoundInfectionStatus,
            new
            {
                UserId = userId,
                PatientId = patientId,
                PatientWoundVisitId = patientWoundVisitId
            });
    }

    public async Task<WoundInfectionStatusDetailsDto> GetWoundInfectionStatusDetailsAsync(
        int userId,
        int patientId,
        int patientWoundVisitId)
    {
        if (string.IsNullOrWhiteSpace(ConnectionString))
        {
            throw new Exception("ConnectionString must be provided!");
        }

        using var connection = new NpgsqlConnection(ConnectionString);
        return await connection.QueryFirstAsync<WoundInfectionStatusDetailsDto>(
            C4WX1Sqls.GetWoundInfectionStatusDetails,
            new
            {
                UserId = userId,
                PatientId = patientId,
                PatientWoundVisitId = patientWoundVisitId
            });
    }
}
