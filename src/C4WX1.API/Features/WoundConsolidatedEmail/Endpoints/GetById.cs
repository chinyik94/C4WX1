using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.Features.WoundConsolidatedEmail.Dtos;
using C4WX1.API.Features.WoundConsolidatedEmail.Mappers;

namespace C4WX1.API.Features.WoundConsolidatedEmail.Endpoints;

public class GetWoundConsolidatedEmailByIdSummary
    : C4WX1GetByIdSummary<Database.Models.WoundConsolidatedEmail>
{

}

public class GetById(THCC_C4WDEVContext dbContext)
    : Endpoint<GetByIdDto, WoundConsolidatedEmailDto, WoundConsolidatedEmailMapper>
{
    public override void Configure()
    {
        Get("wound-consolidated-email/{id}");
        Summary(new GetWoundConsolidatedEmailByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.WoundConsolidatedEmail
            .Where(x => !x.IsDeleted
                && x.WoundConsolidatedEmailID == req.Id)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        await (dto == null
            ? SendNotFoundAsync(ct)
            : SendOkAsync(dto, ct));
    }
}
