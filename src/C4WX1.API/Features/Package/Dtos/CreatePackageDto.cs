using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Package.Dtos;

public sealed class CreatePackageDto : CreateDto
{
    public string? PackageName { get; set; }
    public string? PackageDetails { get; set; }
}
