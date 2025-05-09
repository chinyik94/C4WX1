using C4WX1.API.Features.ExternalDoctor.Dtos;

namespace C4WX1.Tests.ExternalDoctor;

public class ExternalDoctorFaker
{
    public static CreateExternalDoctorDto DummyCreate => new Faker<CreateExternalDoctorDto>()
        .RuleFor(x => x.Name, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.Email, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.Contact, f => C4WX1Faker.AlphaNumeric)
        .RuleFor(x => x.ClinicianTypeID_FK, f => 1)
        .RuleFor(x => x.UserId, f => C4WX1Faker.Id)
        .Generate();

    public static CreateExternalDoctorDto CreateDto => new()
    {
        Name = "control Name",
        Email = "control-Email",
        Contact = "control-Contact",
        ClinicianTypeID_FK = 1,
        UserId = 1
    };
}
