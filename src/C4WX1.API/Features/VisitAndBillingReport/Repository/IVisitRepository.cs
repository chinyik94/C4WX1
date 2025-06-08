using C4WX1.API.Features.VisitAndBillingReport.Dtos;

namespace C4WX1.API.Features.VisitAndBillingReport.Repository;

public interface IVisitRepository
{
    Task<IEnumerable<VisitSummaryDto>> GetVisitSummariesAsync(
        int userId,
        int userCategoryId,
        DateTime startDate,
        DateTime endDate);

    Task<IEnumerable<VisitDetailsDto>> GetVisitDetailsAsync(
        int userId,
        int userCategoryId,
        DateTime startDate,
        DateTime endDate);
}
