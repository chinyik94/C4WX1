using C4WX1.API.Features.VisitAndBillingReport.Constants;
using C4WX1.API.Features.VisitAndBillingReport.Dtos;
using Dapper;
using Npgsql;

namespace C4WX1.API.Features.VisitAndBillingReport.Repository;

public class VisitRepository(IConfiguration configuration) : IVisitRepository
{
    protected readonly string connectionString = configuration.GetConnectionString("Default")
            ?? throw new Exception("Invalid connection string");

    public async Task<IEnumerable<VisitDetailsDto>> GetVisitDetailsAsync(
        int userId, 
        int userCategoryId, 
        DateTime startDate, 
        DateTime endDate)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var results = await connection.QueryAsync<VisitDetailsDto>(
            VisitSqls.GetVisitDetails,
            new
            {
                UserId = userId,
                UserCategoryId = userCategoryId,
                StartDate = startDate,
                EndDate = endDate
            });
        return results;
    }

    public async Task<IEnumerable<VisitSummaryDto>> GetVisitSummariesAsync(
        int userId,
        int userCategoryId,
        DateTime startDate,
        DateTime endDate)
    {
        using var connection = new NpgsqlConnection(connectionString);
        var results = await connection.QueryAsync<VisitSummaryDto>(
            VisitSqls.GetVisitSummary,
            new
            {
                UserId = userId,
                UserCategoryId = userCategoryId,
                StartDate = startDate,
                EndDate = endDate
            });
        return results;
    }
}
