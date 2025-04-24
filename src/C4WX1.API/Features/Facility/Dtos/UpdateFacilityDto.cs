using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Facility.Dtos;

public class UpdateFacilityDto : UpdateDto
{
    public string FacilityName { get; set; } = null!;
    public int OrganizationID_FK { get; set; }
}
