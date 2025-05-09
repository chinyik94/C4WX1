using C4WX1.API.Features.CarePlanSubGoal.Dtos;
using C4WX1.API.Features.CarePlanSubGoal.Mappers;
using C4WX1.API.Features.CarePlanSubGoal.Repository;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.CarePlanSubGoal.Endpoints;

public class GetCarePlanSubGoalByIdSummary 
    : C4WX1GetByIdSummary<Database.Models.CarePlanSubGoal>
{
    public GetCarePlanSubGoalByIdSummary() { }
}

public class GetById(
    THCC_C4WDEVContext dbContext,
    ICarePlanSubGoalRepository repository)
    : Endpoint<GetByIdDto, CarePlanSubGoalDto, CarePlanSubGoalMapper>
{
    public override void Configure()
    {
        Get("care-plan-sub-goal/{id}");
        Description(b => b.Produces(404));
        Summary(new GetCarePlanSubGoalByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.CarePlanSubGoal
            .Where(x => !(x.IsDeleted ?? false) && x.CarePlanSubGoalID == req.Id)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        if (dto == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        dto.CanDelete = await repository.CanDeleteAsync(req.Id);
        await SendOkAsync(dto, cancellation: ct);
    }
}
