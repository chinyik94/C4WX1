using FastEndpoints;

namespace C4WX1.API.Features.ExternalDoctor.Dtos;

public sealed class GetExternalDoctorCountDto
{
    [QueryParam]
    public string? Search { get; set; }
}
