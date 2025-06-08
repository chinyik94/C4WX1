namespace C4WX1.API.Features.WoundReport.Dtos;

public sealed class GetWoundCountReportDto
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
}
