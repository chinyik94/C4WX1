using C4WX1.API.Features.ExternalDoctor.Dtos;
using C4WX1.API.Features.ExternalDoctor.Mappers;

namespace C4WX1.API.Features.ExternalDoctor.Endpoints;

public class UpdateExternalDoctorSummary 
    : C4WX1UpdateSummary<Database.Models.ExternalDoctor>
{
    public UpdateExternalDoctorSummary() : base()
    {
        ExampleRequest = new UpdateExternalDoctorDto
        {
            Name = "Name",
            Email = "Email",
            Contact = "Contact",
            ClinicianTypeID_FK = 1,
            UserId = 1
        };
        Responses[400] = "Invalid request";
    }
}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateExternalDoctorDto, UpdateExternalDoctorMapper>
{
    public override void Configure()
    {
        Put("/external-doctor/{id}");
        Summary(new UpdateExternalDoctorSummary());
    }

    public override async Task HandleAsync(UpdateExternalDoctorDto req, CancellationToken ct)
    {
        var isDuplicate = await dbContext.ExternalDoctor
            .Where(x => !x.IsDeleted && x.Name == req.Name && x.ExternalDoctorID != req.Id)
            .AnyAsync(ct);
        if (isDuplicate)
        {
            ThrowError("DOCTOR_EXISTS");
            return;
        }

        var isDuplicateUser = await dbContext.Users
            .Where(x => !x.IsDeleted && (x.Firstname + " " + x.Lastname) == req.Name)
            .AnyAsync(ct);
        if (isDuplicateUser)
        {
            ThrowError("DOCTOR_USER_EXISTS");
            return;
        }

        var entity = await dbContext.ExternalDoctor
            .Where(x => x.ExternalDoctorID == req.Id)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        entity = Map.UpdateEntity(req, entity);
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
