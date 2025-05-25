namespace C4WX1.API.Features.PatientAccessLine.Dtos;

public sealed class PatientAccessLineDto
{
    public int PatientAccessLineID { get; set; }
    public string AccessLine { get; set; } = null!;
    public DateTime DateOfInsertion { get; set; }
    public string Patent { get; set; } = null!;
    public string? PatentReSited { get; set; }
    public DateTime? PatentReSitedDate { get; set; }
    public string? PatentSite { get; set; }
    public DateTime DateDueForChange { get; set; }
    public string? AccessLineRemarks { get; set; }
}
