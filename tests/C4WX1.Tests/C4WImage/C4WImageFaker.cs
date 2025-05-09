using C4WX1.API.Features.C4WImage.Dtos;

namespace C4WX1.Tests.C4WImage;

public class C4WImageFaker
{
    public static CreateC4WImageDto CreateDummy => new Faker<CreateC4WImageDto>()
        .RuleFor(x => x.WoundImageName, f => f.Random.AlphaNumeric(10))
        .RuleFor(x => x.WoundImageData, f => f.Random.AlphaNumeric(20))
        .RuleFor(x => x.WoundBedImageName, f => f.Random.AlphaNumeric(10))
        .RuleFor(x => x.WoundBedImageData, f => f.Random.AlphaNumeric(20))
        .RuleFor(x => x.TissueImageName, f => f.Random.AlphaNumeric(10))
        .RuleFor(x => x.TissueImageData, f => f.Random.AlphaNumeric(20))
        .RuleFor(x => x.DepthImageName, f => f.Random.AlphaNumeric(10))
        .RuleFor(x => x.DepthImageData, f => f.Random.AlphaNumeric(20))
        .RuleFor(x => x.UserId, f => f.Random.Int())
        .Generate();

    public static CreateC4WImageDto CreateDto => new()
    {
        WoundImageName = "Control-WoundImageName",
        WoundImageData = "Control-WoundImageData",
        WoundBedImageName = "Control-WoundBedImageName",
        WoundBedImageData = "Control-WoundBedImageData",
        TissueImageName = "Control-TissueImageName",
        TissueImageData = "Control-TissueImageData",
        DepthImageName = "Control-DepthImageName",
        DepthImageData = "Control-DepthImageData",
        UserId = 1
    };

    public static UpdateC4WImageDto UpdateDto(int? id = null) => new()
    {
        Id = id ?? C4WX1Faker.Id,
        WoundImageName = "Updated-Control-WoundImageName",
        WoundImageData = "Updated-Control-WoundImageData",
        WoundBedImageName = "Updated-Control-WoundBedImageName",
        WoundBedImageData = "Updated-Control-WoundBedImageData",
        TissueImageName = "Updated-Control-TissueImageName",
        TissueImageData = "Updated-Control-TissueImageData",
        DepthImageName = "Updated-Control-DepthImageName",
        DepthImageData = "Updated-Control-DepthImageData",
        UserId = 1
    };
}
