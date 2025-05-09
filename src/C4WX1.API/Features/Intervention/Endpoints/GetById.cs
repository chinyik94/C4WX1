using C4WX1.API.Features.Intervention.Dtos;
using C4WX1.API.Features.Intervention.Mappers;
using C4WX1.API.Features.Intervention.Repository;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Intervention.Endpoints;

public class GetInterventionByIdSummary 
    : C4WX1GetByIdSummary<Database.Models.Intervention>
{
    public GetInterventionByIdSummary() { }
}

public class GetById(
    THCC_C4WDEVContext dbContext,
    IInterventionRepository repository)
    : Endpoint<GetByIdDto, InterventionDto, InterventionMapper>
{
    public override void Configure()
    {
        Get("intervention/{id}");
        Summary(new GetInterventionByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.Intervention
            .Include(x => x.DiseaseID_FKNavigation)
            .Where(x => !x.IsDeleted
                && x.InterventionID == req.Id)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        if (dto == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        dto.CanDelete = await repository.CanDeleteAsync(req.Id);
        await SendOkAsync(dto, ct);
    }
}
