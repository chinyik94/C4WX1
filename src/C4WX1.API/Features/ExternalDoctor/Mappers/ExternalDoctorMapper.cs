using C4WX1.API.Features.ExternalDoctor.Dtos;

namespace C4WX1.API.Features.ExternalDoctor.Mappers;

public class ExternalDoctorMapper
    : ResponseMapper<ExternalDoctorDto, Database.Models.ExternalDoctor>
{
    public override ExternalDoctorDto FromEntity(Database.Models.ExternalDoctor e) => new()
    {
        ExternalDoctorID = e.ExternalDoctorID,
        Name = e.Name,
        Email = e.Email,
        Contact = e.Contact,
        ClinicianTypeID_FK = e.ClinicianTypeID_FK,
        ClinicianTypeName = e.ClinicianTypeID_FKNavigation?.UserType1,
    };
}
