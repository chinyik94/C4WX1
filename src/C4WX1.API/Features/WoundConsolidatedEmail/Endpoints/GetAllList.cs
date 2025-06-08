using C4WX1.API.Features.WoundConsolidatedEmail.Dtos;
using C4WX1.API.Features.WoundConsolidatedEmail.Mappers;

namespace C4WX1.API.Features.WoundConsolidatedEmail.Endpoints;

public class GetAllWoundConsolidatedEmailListSummary
    : C4WX1GetListSummary<Database.Models.WoundConsolidatedEmail>
{

}

public class GetAllList(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<IEnumerable<WoundConsolidatedEmailDto>, WoundConsolidatedEmailMapper>
{
    public override void Configure()
    {
        Get("wound-consolidated-email/all");
        Summary(new GetAllWoundConsolidatedEmailListSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var dtos = await dbContext.WoundConsolidatedEmail
            .Where(x => !x.IsDeleted)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
