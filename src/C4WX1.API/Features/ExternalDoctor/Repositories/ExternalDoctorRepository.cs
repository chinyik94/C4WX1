using C4WX1.API.Features.ExternalDoctor.Constants;
using Dapper;
using Npgsql;

namespace C4WX1.API.Features.ExternalDoctor.Repositories;

public class ExternalDoctorRepository(IConfiguration configuration) 
    : IExternalDoctorRepository
{
    private readonly string? connectionString = configuration.GetConnectionString("Default");

    public async Task<Dictionary<int, bool>> BatchCanDeleteAsync(int[] ids)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new Exception("Invalid connection string");
        }

        using var connection = new NpgsqlConnection(connectionString);
        var results = await connection.QueryAsync<(int Id, bool CanDelete)>(
            Sqls.BatchCanDelete,
            new { Ids = ids });

        return results.ToDictionary(x => x.Id, x => x.CanDelete);
    }

    public async Task<bool> CanDeleteAsync(int id)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new Exception("Invalid connection string");
        }

        using var connection = new NpgsqlConnection(connectionString);
        var canDelete = await connection.QuerySingleAsync<bool>(
            Sqls.CanDelete,
            new { Id = id });

        return canDelete;
    }
}
