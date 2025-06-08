using C4WX1.API.Features.WoundConsolidatedEmail.Dtos;
using C4WX1.API.Features.WoundConsolidatedEmail.Mappers;

namespace C4WX1.API.Features.WoundConsolidatedEmail.Endpoints;

public class UpdateWoundConsolidatedEmailSummary
    : C4WX1UpdateSummary<Database.Models.WoundConsolidatedEmail>
{

}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateWoundConsolidatedEmailDto, UpdateWoundConsolidatedEmailMapper>
{
    public override void Configure()
    {
        Put("wound-consolidated-email/{id}");
        Summary(new UpdateWoundConsolidatedEmailSummary());
    }

    public override async Task HandleAsync(UpdateWoundConsolidatedEmailDto req, CancellationToken ct)
    {
        var entity = await dbContext.WoundConsolidatedEmail
            .Where(x => !x.IsDeleted
                && x.WoundConsolidatedEmailID == req.Id)
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
