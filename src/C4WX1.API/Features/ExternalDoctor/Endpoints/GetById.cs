using C4WX1.API.Features.ExternalDoctor.Dtos;
using C4WX1.API.Features.ExternalDoctor.Mappers;
using C4WX1.API.Features.ExternalDoctor.Repositories;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.ExternalDoctor.Endpoints;

public class GetExternalDoctorByIdSummary 
    : C4WX1GetByIdSummary<Database.Models.ExternalDoctor>
{
    public GetExternalDoctorByIdSummary() { }
}

public class GetById(
    THCC_C4WDEVContext dbContext,
    IExternalDoctorRepository repository)
    : Endpoint<GetByIdDto, ExternalDoctorDto, ExternalDoctorMapper>
{
    public override void Configure()
    {
        Get("/external-doctor/{id}");
        Summary(new GetExternalDoctorByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.ExternalDoctor
            .Include(x => x.ClinicianTypeID_FKNavigation)
            .Where(x => x.ExternalDoctorID == req.Id)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        if (dto == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        dto.CanDelete = await repository.CanDeleteAsync(dto.ExternalDoctorID);
        await SendOkAsync(dto, cancellation: ct);
    }
}
