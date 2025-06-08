namespace C4WX1.API.Features.WoundReport.Dtos;

public sealed class GetInfectedVisitReportDto
{
    [QueryParam]
    public DateTime StartDate { get; set; }

    [QueryParam]
    public DateTime EndDate { get; set; }

    [QueryParam]
    public string? Status { get; set; }

    [QueryParam]
    public int PatientId { get; set; }

    [QueryParam]
    public int FacilityId { get; set; }

    [QueryParam]
    public int UserId { get; set; }
}
