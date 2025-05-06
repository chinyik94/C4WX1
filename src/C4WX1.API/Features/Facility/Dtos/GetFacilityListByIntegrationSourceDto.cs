namespace C4WX1.API.Features.Facility.Dtos;

public sealed class GetFacilityListByIntegrationSourceDto
{
    public string IntegrationSource { get; set; } = null!;

    [QueryParam]
    public int? FacilityId { get; set; }
}
