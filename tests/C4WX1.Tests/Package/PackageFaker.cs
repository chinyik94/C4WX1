using C4WX1.API.Features.Package.Dtos;

namespace C4WX1.Tests.Package;

public class PackageFaker
{
    public static CreatePackageDto CreateDto => new()
    {
        PackageName = "control-PackageName",
        PackageDetails = "control-PackageDetails",
        UserId = 1
    };

    public static CreatePackageDto CreateDummy => new Faker<CreatePackageDto>()
        .RuleFor(x => x.PackageName, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.PackageDetails, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.UserId, f => C4WX1Faker.Id)
        .Generate();

    public static UpdatePackageDto UpdateDto(int? id = null) => new()
    {
        Id = id ?? C4WX1Faker.Id,
        PackageName = $"updated-{CreateDto.PackageName}",
        PackageDetails = $"updated-{CreateDto.PackageDetails}",
        UserId = CreateDto.UserId
    };
}
