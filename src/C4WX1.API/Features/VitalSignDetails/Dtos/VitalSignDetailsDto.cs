namespace C4WX1.API.Features.VitalSignDetails.Dtos;

public sealed class VitalSignDetailsDto
{
    public string Id { get; set; } = null!;
    public string VitalSignTypeId { get; set; } = null!;
    public string VitalSignId { get; set; } = null!;
    public string DetailValue { get; set; } = null!;
    public VitalSignTypeDto VitalSignType { get; set; } = null!;
}

public sealed class VitalSignTypeDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
}