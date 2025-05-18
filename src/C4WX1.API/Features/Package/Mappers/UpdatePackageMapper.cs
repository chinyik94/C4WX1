using C4WX1.API.Features.Package.Dtos;

namespace C4WX1.API.Features.Package.Mappers;

public class UpdatePackageMapper
    : RequestMapper<UpdatePackageDto, Database.Models.Package>
{
    public override Database.Models.Package UpdateEntity(
        UpdatePackageDto r, 
        Database.Models.Package e)
    {
        e.PackageName = r.PackageName;
        e.PackageDetails = r.PackageDetails;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        return e;
    }
}
