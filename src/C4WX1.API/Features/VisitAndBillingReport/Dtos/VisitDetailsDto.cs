namespace C4WX1.API.Features.VisitAndBillingReport.Dtos;

public sealed class VisitDetailsDto
{
    public string Name { get; set; } = null!;
    public DateTime? VisitDate { get; set; }
    public string VisitType { get; set; } = null!;
    public string IsBill { get; set; } = null!;
    public decimal BillingAmount { get; set; }
}
