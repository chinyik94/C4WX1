namespace C4WX1.API.Features.VisitAndBillingReport.Dtos;

public sealed class VisitSummaryDto
{
    public string Name { get; set; } = null!;
    public int ScheduleCount { get; set; }
    public int? ActualCount { get; set; }
    public decimal? BillingAmount { get; set; }
    public decimal? Average { get; set; }
}
