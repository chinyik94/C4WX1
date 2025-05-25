using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.PatientAccessLine.Dtos;

public sealed class CreatePatientAccessLineDto : CreateDto
{
    public int CareReportID { get; set; }
    public ICollection<PatientAccessLineDto> PatientAccessLines { get; set; } = [];
}
