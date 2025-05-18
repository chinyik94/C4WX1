using C4WX1.API.Features.Package.Dtos;

namespace C4WX1.API.Features.Package.Mappers;

public class CreatePackageMapper
    : RequestMapper<CreatePackageDto, Database.Models.Package>
{
    public override Database.Models.Package ToEntity(CreatePackageDto r)
        => new()
        {
            PackageName = r.PackageName,
            PackageDetails = r.PackageDetails,
            CreatedBy_FK = r.UserId,
            CreatedDate = DateTime.Now
        };
}
