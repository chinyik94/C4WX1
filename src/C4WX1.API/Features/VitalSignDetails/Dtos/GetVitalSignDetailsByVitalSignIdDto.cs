namespace C4WX1.API.Features.VitalSignDetails.Dtos;

public sealed class GetVitalSignDetailsByVitalSignIdDto
{
    [QueryParam]
    public int VitalSignId { get; set; }
}
