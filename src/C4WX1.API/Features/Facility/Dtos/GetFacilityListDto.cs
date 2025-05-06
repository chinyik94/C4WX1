using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Facility.Dtos;

public sealed class GetFacilityListDto : GetListDto
{
    [QueryParam]
    public string? Keyword { get; set; }

    [QueryParam]
    public int? OrganizationId { get; set; }
}
