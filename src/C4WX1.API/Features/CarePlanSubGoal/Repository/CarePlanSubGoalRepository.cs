using C4WX1.API.Features.CarePlanSubGoal.Constants;
using Dapper;
using Npgsql;

namespace C4WX1.API.Features.CarePlanSubGoal.Repository;

public class CarePlanSubGoalRepository(IConfiguration configuration)
    : ICarePlanSubGoalRepository
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
            CarePlanSubGoalSqls.BatchCanDelete,
            new { CarePlanSubGoalIds = ids});

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
            CarePlanSubGoalSqls.CanDelete,
            new { CarePlanSubGoalId = id });

        return canDelete;
    }
}
