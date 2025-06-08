using C4WX1.API.Features.WoundConsolidatedEmail.Dtos;
using C4WX1.API.Features.WoundConsolidatedEmail.Mappers;

namespace C4WX1.API.Features.WoundConsolidatedEmail.Endpoints;

public class CreateWoundConsolidatedEmailSummary
    : C4WX1CreateSummary<Database.Models.WoundConsolidatedEmail>
{

}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateWoundConsolidatedEmailDto, int, CreateWoundConsolidatedEmailMapper>
{
    public override void Configure()
    {
        Post("wound-consolidated-email");
        Summary(new CreateWoundConsolidatedEmailSummary());
    }

    public override async Task HandleAsync(CreateWoundConsolidatedEmailDto req, CancellationToken ct)
    {
        var entity = Map.ToEntity(req);
        await dbContext.WoundConsolidatedEmail.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.WoundConsolidatedEmailID, ct);
    }
}
