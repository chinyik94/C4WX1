namespace C4WX1.API.Features.DischargeSummaryReport.Dtos;

public class DischargeSummaryReportUserDto
{
    public int UserId { get; set; }
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string? Photo { get; set; }
}
