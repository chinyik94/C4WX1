using C4WX1.API.Features.Shared.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.ExternalDoctor.Dtos;

public sealed class GetExternalDoctorListDto : GetListDto
{
    [QueryParam]
    public string? Search { get; set; }
}
