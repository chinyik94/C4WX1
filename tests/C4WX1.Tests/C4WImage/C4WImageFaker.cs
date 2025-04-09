using C4WX1.API.Features.C4WImage.Dtos;
using C4WX1.Tests.Shared;

namespace C4WX1.Tests.C4WImage
{
    public class C4WImageFaker : C4WX1Faker
    {
        public static CreateC4WImageDto CreateDto() => new Faker<CreateC4WImageDto>()
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
    }
}
