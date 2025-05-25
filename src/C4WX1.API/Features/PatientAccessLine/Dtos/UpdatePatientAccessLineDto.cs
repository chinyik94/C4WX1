using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.PatientAccessLine.Dtos;

public sealed class UpdatePatientAccessLineDto : UpdateDto
{
    public int PatientAccessLineID { get; set; }
    public string AccessLine { get; set; } = null!;
    public int CareReportID_FK { get; set; }
    public DateTime DateOfInsertion { get; set; }
    public string Patent { get; set; } = null!;
    public string? PatentReSited { get; set; }
    public DateTime? PatentReSitedDate { get; set; }
    public string? PatentSite { get; set; }
    public DateTime DateDueForChange { get; set; }
    public string? AccessLineRemarks { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? CreatedBy_FK { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? ModifiedBy_FK { get; set; }
}
