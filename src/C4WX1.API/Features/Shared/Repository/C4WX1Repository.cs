using C4WX1.API.Features.Shared.Constants;
using Dapper;
using Npgsql;

namespace C4WX1.API.Features.Shared.Repository;

public abstract class C4WX1Repository(IConfiguration configuration) 
    : IDeletableRepository, IAccessibleRepository
{
    protected readonly string connectionString = configuration.GetConnectionString("Default")
            ?? throw new Exception("Invalid connection string");

    protected abstract string CanDeleteSql { get; }
    protected abstract string BatchCanDeleteSql { get; }
    protected string BatchCanAccessPatientDashboardSql => C4WX1Sqls.BatchCanAccessPatient;

    public async Task<Dictionary<int, bool>> BatchCanDeleteAsync(int[] ids)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var results = await connection.QueryAsync<(int Id, bool CanDelete)>(
            BatchCanDeleteSql,
            new
            {
                Ids = ids
            });
        return results.ToDictionary(x => x.Id, x => x.CanDelete);
    }

    public async Task<Dictionary<int, bool>> BatchCanAccessPatientDashboardAsync(
        int userId,
        int facilityId,
        int[] patientIds)
    {
        using var connection = new NpgsqlConnection(connectionString);
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

    public async Task<bool> CanDeleteAsync(int id)
    {
        using var connection = new NpgsqlConnection(connectionString);
        return await connection.QuerySingleAsync<bool>(
            CanDeleteSql,
            new
            {
                Id = id
            });
    }
}
