using C4WX1.API.Features.ExternalDoctor.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.ExternalDoctor.Mappers;

public class CreateExternalDoctorMapper
    : RequestMapper<CreateExternalDoctorDto, Database.Models.ExternalDoctor>
{
    public override Database.Models.ExternalDoctor ToEntity(CreateExternalDoctorDto r) => new()
    {
        Name = r.Name,
        Email = r.Email,
        Contact = r.Contact,
        ClinicianTypeID_FK = r.ClinicianTypeID_FK,
        CreatedDate = DateTime.Now,
        CreatedBy_FK = r.UserId
    };
}
