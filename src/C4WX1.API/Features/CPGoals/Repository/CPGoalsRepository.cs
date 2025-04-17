using C4WX1.API.Features.CPGoals.Constants;
using Dapper;
using Npgsql;

namespace C4WX1.API.Features.CPGoals.Repository;

public class CPGoalsRepository(IConfiguration configuration) 
    : ICPGoalsRepository
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
            new { CPGoalsIds = ids });
        return results.ToDictionary(x => x.Id, x => x.CanDelete);
    }

    public async Task<bool> CanDeleteAsync(int id)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new Exception("Invalid connection string");
        }
        using var connection = new NpgsqlConnection(connectionString);
        var result = await connection.QuerySingleAsync<bool>(
            Sqls.CanDelete,
            new { CPGoalsId = id });
        return result;
    }
}
