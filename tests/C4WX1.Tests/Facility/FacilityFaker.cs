using C4WX1.API.Features.Facility.Dtos;

namespace C4WX1.Tests.Facility;
public class FacilityFaker
{
    public static string CId => new Faker().Random.Number().ToString();
    public static string FacilityName => new Faker().Random.String2(10);

    public static CreateFacilityDto CreateDummy => new Faker<CreateFacilityDto>()
        .RuleFor(x => x.FacilityName, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.OrganizationID_FK, f => 1)
        .RuleFor(x => x.UserId, f => C4WX1Faker.Id)
        .Generate();

    public static CreateFacilityDto CreateDto => new()
    {
        FacilityName = "control-FacilityName",
        OrganizationID_FK = 1,
        UserId = 1,
    };

    public static CreateFacilityByIntegrationSourceDto CreateByIntegrationSourceDto => new()
    {
        FacilityName = "control-FacilityName",
        OrganizationID_FK = 1,
        UserId = 1,
        IntegrationSource = "control-IntegrationSource",
        C_Id = "1",
        Remarks = "control-Remarks",
    };
}
