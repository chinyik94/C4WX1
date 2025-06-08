namespace C4WX1.API.Features.VisitAndBillingReport.Dtos;

public sealed class GetVisitSummaryDto
{
    [QueryParam]
    public int UserId { get; set; }

    [QueryParam]
    public int UserCategoryId { get; set; }

    [QueryParam]
    public DateTime StartDate { get; set; }

    [QueryParam]
    public DateTime EndDate { get; set; }
}
