using C4WX1.API.Features.ExternalDoctor.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.ExternalDoctor.Mappers;

public class UpdateExternalDoctorMapper
    : RequestMapper<UpdateExternalDoctorDto, Database.Models.ExternalDoctor>
{
    public override Database.Models.ExternalDoctor UpdateEntity(
        UpdateExternalDoctorDto r, 
        Database.Models.ExternalDoctor e)
    {
        e.Name = r.Name;
        e.Email = r.Email;
        e.Contact = r.Contact;
        e.ClinicianTypeID_FK = r.ClinicianTypeID_FK;
        e.ModifiedDate = DateTime.Now;
        e.ModifiedBy_FK = r.UserId;

        return e;
    }
}
