using C4WX1.API.Features.ExternalDoctor.Dtos;
using C4WX1.API.Features.ExternalDoctor.Mappers;

namespace C4WX1.API.Features.ExternalDoctor.Endpoints;

public class CreateExternalDoctorSummary 
    : C4WX1CreateSummary<Database.Models.ExternalDoctor>
{
    public CreateExternalDoctorSummary() : base()
    {
        ExampleRequest = new CreateExternalDoctorDto
        {
            Name = "Name",
            Email = "Email",
            Contact = "Contact",
            ClinicianTypeID_FK = 1
        };
    }
}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateExternalDoctorDto, int, CreateExternalDoctorMapper>
{
    public override void Configure()
    {
        Post("/external-doctor");
        Summary(new CreateExternalDoctorSummary());
    }

    public override async Task HandleAsync(CreateExternalDoctorDto req, CancellationToken ct)
    {
        var isDuplicate = await dbContext.ExternalDoctor
            .Where(x => !x.IsDeleted && x.Name == req.Name)
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

        var entity = Map.ToEntity(req);
        await dbContext.ExternalDoctor.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.ExternalDoctorID, cancellation: ct);
    }
}
