using C4WX1.API.Features.CPGoals.Dtos;
using C4WX1.API.Features.CPGoals.Mappers;
using C4WX1.API.Features.CPGoals.Repository;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.CPGoals.Endpoints;

public class GetCPGoalsByIdSummary 
    : C4WX1GetByIdSummary<Database.Models.CPGoals>
{
    public GetCPGoalsByIdSummary() { }
}

public class GetById(THCC_C4WDEVContext dbContext, ICPGoalsRepository repository)
    : Endpoint<GetByIdDto, CPGoalsDto, CPGoalsMapper>
{
    public override void Configure()
    {
        Get("cp-goals/{id}");
        Summary(new GetCPGoalsByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.CPGoals
            .Include(x => x.DiseaseID_FKNavigation)
                .ThenInclude(x => x.SystemID_FKNavigation)
            .Where(x => x.CPGoalsID == req.Id && !x.IsDeleted)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        if (dto is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        dto.CanDelete = await repository.CanDeleteAsync(req.Id);
        await SendOkAsync(dto, cancellation: ct);
    }
}