using Dapper;
using Npgsql;

namespace C4WX1.API.Features.Shared.Repository;

public abstract class AccessibleRepository(IConfiguration configuration)
    : IAccessibleRepository
{
    protected string? ConnectionString => configuration.GetConnectionString("Default");

    protected abstract string BatchCanAccessPatientDashboardSql { get; }

    public async Task<Dictionary<int, bool>> BatchCanAccessPatientDashboardAsync(
        int userId,
        int facilityId,
        int[] patientIds)
    {
        if (string.IsNullOrWhiteSpace(ConnectionString))
        {
            throw new Exception("ConnectionString must be provided!");
        }

        using var connection = new NpgsqlConnection(ConnectionString);
        var results = await connection.QueryAsync<(int PatientId, bool CanAccess)>(
            BatchCanAccessPatientDashboardSql,
            new
            {
                UserId = userId,
                FacilityId = facilityId,
                PatientIds = patientIds
            });
        return results.ToDictionary(x => x.PatientId, x => x.CanAccess);
    }
}
