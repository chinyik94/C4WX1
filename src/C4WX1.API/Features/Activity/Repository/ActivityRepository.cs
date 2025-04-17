using C4WX1.API.Features.Activity.Constants;
using Dapper;
using Npgsql;

namespace C4WX1.API.Features.Activity.Repository;

public class ActivityRepository(IConfiguration configuration)
    : IActivityRepository
{
    private readonly string? connectionString = configuration.GetConnectionString("Default");

    public async Task<bool> CanDeleteAsync(int activityId)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new Exception("Invalid connection string");
        }

        using var connection = new NpgsqlConnection(connectionString);
        var canDelete = await connection.QuerySingleAsync<bool>(
            ActivitySqls.CanDelete,
            new { ActivityId = activityId });

        return canDelete;
    }

    public async Task<Dictionary<int, bool>> BatchCanDeleteAsync(int[] activityIds)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new Exception("Invalid connection string");
        }

        using var connection = new NpgsqlConnection(connectionString);
        var results = await connection.QueryAsync<(int Id, bool CanDelete)>(
            ActivitySqls.BatchCanDelete,
            new { ActivityIds = activityIds });

        return results.ToDictionary(x => x.Id, x => x.CanDelete);
    }
}
