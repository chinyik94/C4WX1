using Dapper;
using Npgsql;

namespace C4WX1.API.Features.Shared.Repository;

public abstract class DeletableRepository(IConfiguration configuration)
    : IDeletableRepository
{
    protected string? ConnectionString => configuration.GetConnectionString("Default");

    protected abstract string CanDeleteSql { get; }
    protected abstract string BatchCanDeleteSql { get; }

    public async Task<Dictionary<int, bool>> BatchCanDeleteAsync(int[] ids)
    {
        if (string.IsNullOrWhiteSpace(ConnectionString))
        {
            throw new Exception("ConnectionString must be provided!");
        }

        using var connection = new NpgsqlConnection(ConnectionString);
        var results = await connection.QueryAsync<(int Id, bool CanDelete)>(
            BatchCanDeleteSql,
            new
            {
                Ids = ids
            });
        return results.ToDictionary(x => x.Id, x => x.CanDelete);
    }

    public async Task<bool> CanDeleteAsync(int id)
    {
        if (string.IsNullOrWhiteSpace(ConnectionString))
        {
            throw new Exception("ConnectionString must be provided!");
        }

        using var connection = new NpgsqlConnection(ConnectionString);
        return await connection.QuerySingleAsync<bool>(
            CanDeleteSql,
            new
            {
                Id = id
            });
    }
}
