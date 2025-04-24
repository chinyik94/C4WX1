using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Facility.Dtos;

public sealed class CreateFacilityByIntegrationSourceDto : CreateDto
{
    public string FacilityName { get; set; } = null!;
    public int OrganizationID_FK { get; set; }
    public string? C_Id { get; set; }
    public string? IntegrationSource { get; set; }
    public string? Remarks { get; set; }
}
