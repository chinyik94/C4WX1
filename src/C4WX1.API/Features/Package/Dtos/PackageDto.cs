namespace C4WX1.API.Features.Package.Dtos;

public sealed class PackageDto
{
    public int PackageID { get; set; }
    public string? PackageName { get; set; }
    public string? PackageDetails { get; set; }
    public bool CanDelete { get; set; }
}
