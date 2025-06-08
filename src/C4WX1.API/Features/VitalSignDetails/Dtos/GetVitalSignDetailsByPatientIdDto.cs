namespace C4WX1.API.Features.VitalSignDetails.Dtos;

public class GetVitalSignDetailsByPatientIdDto
{
    [QueryParam]
    public int PatientId { get; set; }
}
