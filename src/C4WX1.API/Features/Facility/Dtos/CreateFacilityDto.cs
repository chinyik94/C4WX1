using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Facility.Dtos;

public sealed class CreateFacilityDto : CreateDto
{
    public string FacilityName { get; set; } = null!;
    public int OrganizationID_FK { get; set; }
}
