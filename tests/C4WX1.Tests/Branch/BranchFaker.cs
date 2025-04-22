using C4WX1.API.Features.Branch.Dtos;
using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.Tests.Branch;

public class BranchFaker
{
    public static Database.Models.CodeType DummyCodeType => new Faker<Database.Models.CodeType>()
        .RuleFor(x => x.CodeTypeName, f => f.Lorem.Word())
        .Generate();

    public static Database.Models.Code DummyCode => new Faker<Database.Models.Code>()
        .RuleFor(x => x.CodeName, f => f.Lorem.Word())
        .Generate();

    public static string DummyStatus => new Faker().Random.String2(10);

    public static string DummyAlphaNumeric => new Faker().Random.AlphaNumeric(10);

    public static CreateBranchDto DummyCreateDto => new Faker<CreateBranchDto>()
        .RuleFor(x => x.BranchName, f => f.Random.AlphaNumeric(10))
        .RuleFor(x => x.Status, f => Statuses.Active)
        .RuleFor(x => x.UserId, f => f.Random.Int())
        .RuleFor(x => x.UserDataList, f => [])
        .Generate();

    public static string DummyAddress => new Faker().Address.StreetAddress();

    public static string DummyEmail => new Faker().Internet.Email();

    public static string DummyContact => new Faker().Phone.PhoneNumber();
}
