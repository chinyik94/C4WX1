using FastEndpoints;

namespace C4WX1.API.Features.Facility.Dtos;

public sealed class GetFacilityCountDto
{
    [QueryParam]
    public string? Keyword { get; set; }

    [QueryParam]
    public int? OrganizationId { get; set; }
}
