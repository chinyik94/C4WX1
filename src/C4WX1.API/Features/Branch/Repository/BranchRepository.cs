using C4WX1.API.Features.Branch.Constants;
using Dapper;
using Npgsql;

namespace C4WX1.API.Features.Branch.Repository
{
    public class BranchRepository(IConfiguration configuration)
        : IBranchRepository
    {
        private readonly string? connectionString = configuration.GetConnectionString("Default");

        public async Task<bool> CanDeleteBranchAsync(int branchId)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new Exception("Invalid connection string");
            }

            using var connection = new NpgsqlConnection(connectionString);
            var canDelete = await connection.QuerySingleAsync<bool>(
                BranchSqls.CanDelete,
                new { BranchId = branchId });

            return canDelete;
        }

        public async Task<Dictionary<int, bool>> BatchCanDeleteBranchAsync(IEnumerable<int> branchIds)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new Exception("Invalid connection string");
            }

            using var connection = new NpgsqlConnection(connectionString);
            var results = await connection.QueryAsync<(int Id, bool CanDelete)>(
                BranchSqls.BatchCanDelete,
                new { BranchIds = branchIds });

            return results.ToDictionary(x => x.Id, x => x.CanDelete);
        }
    }
}
