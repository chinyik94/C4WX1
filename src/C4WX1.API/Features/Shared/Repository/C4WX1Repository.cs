using Dapper;
using Npgsql;

namespace C4WX1.API.Features.Shared.Repository;

public abstract class C4WX1Repository(IConfiguration configuration) : IDeletableRepository
{
    protected readonly string connectionString = configuration.GetConnectionString("Default")
            ?? throw new Exception("Invalid connection string");

    protected abstract string CanDeleteSql { get; }
    protected abstract string BatchCanDeleteSql { get; }

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
