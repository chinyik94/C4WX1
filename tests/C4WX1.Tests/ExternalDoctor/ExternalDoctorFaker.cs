using C4WX1.API.Features.ExternalDoctor.Dtos;
using C4WX1.Tests.Shared;

namespace C4WX1.Tests.ExternalDoctor;

public class ExternalDoctorFaker
{
    public static string Name => new Faker().Person.FullName;
    public static string Email => new Faker().Internet.Email();
    public static string Contact => new Faker().Phone.PhoneNumber("###-###-####");

    public static CreateExternalDoctorDto DummyCreate => new()
    {
        Name = Name,
        Email = Email,
        Contact = Contact,
        ClinicianTypeID_FK = 1,
        UserId = C4WX1Faker.Id
    };
}
