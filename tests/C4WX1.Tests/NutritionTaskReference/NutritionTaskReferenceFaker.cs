using C4WX1.API.Features.NutritionTaskReference.Dtos;

namespace C4WX1.Tests.NutritionTaskReference;

public class NutritionTaskReferenceFaker
{
    public static CreateNutritionTaskReferenceDto CreateDto => new()
    {
        ReferenceImage = "control-ReferenceImage",
        Value = 1,
        ReferenceDetail = "control-ReferenceDetail",
        GroupID_FK = 1
    };

    public static CreateNutritionTaskReferenceDto CreateDummy => new Faker<CreateNutritionTaskReferenceDto>()
        .RuleFor(x => x.ReferenceImage, f => C4WX1Faker.AlphaNumeric)
        .RuleFor(x => x.Value, f => C4WX1Faker.Id)
        .RuleFor(x => x.ReferenceDetail, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.GroupID_FK, f => 1)
        .Generate();

    public static UpdateNutritionTaskReferenceDto UpdateDto(int? id = null) => new()
    {
        Id = id ?? C4WX1Faker.Id,
        ReferenceImage = "updated-control-ReferenceImage",
        Value = 1,
        ReferenceDetail = "updated-control-ReferenceDetail",
    };
}
