using C4WX1.API.Features.Package.Dtos;

namespace C4WX1.API.Features.Package.Mappers;

public class PackageMapper
    : ResponseMapper<PackageDto, Database.Models.Package>
{
    public override PackageDto FromEntity(Database.Models.Package e)
        => new()
        {
            PackageID = e.PackageID,
            PackageName = e.PackageName,
            PackageDetails = e.PackageDetails,
            CanDelete = e.PatientPackage
                .Any(x => x.PackageID_FK != e.PackageID)
        };
}
