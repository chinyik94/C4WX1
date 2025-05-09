using C4WX1.API.Features.Activity.Dtos;
using C4WX1.API.Features.Activity.Mappers;
using C4WX1.API.Features.Activity.Repository;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Activity.Endpoints;

public class GetActivityByIdSummary 
    : C4WX1GetByIdSummary<Database.Models.Activity>
{
    public GetActivityByIdSummary() { }
}

public class GetById(
    THCC_C4WDEVContext dbContext,
    IActivityRepository repository)
    : Endpoint<GetByIdDto, ActivityDto, ActivityMapper>
{
    public override void Configure()
    {
        Get("activity/{Id}");
        Description(b => b.Produces(404));
        Summary(new GetActivityByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.Activity
            .Where(x => x.ActivityID == req.Id && !x.IsDeleted)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        if (dto == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        dto.CanDelete = await repository.CanDeleteAsync(dto.ActivityID);
        await SendAsync(dto, cancellation: ct);
    }
}
