using C4WX1.API.WoundConsolidatedEmail.Dtos;
using C4WX1.API.WoundConsolidatedEmail.Mappers;

namespace C4WX1.API.WoundConsolidatedEmail.Endpoints;

public class GetAllWoundConsolidatedEmailListByEmailTypeSummary
    : C4WX1GetListSummary<Database.Models.WoundConsolidatedEmail>
{

}

public class GetAllListByEmailType(THCC_C4WDEVContext dbContext)
    : Endpoint<GetAllWoundConsolidatedEmailByEmailTypeDto, IEnumerable<WoundConsolidatedEmailDto>, WoundConsolidatedEmailMapper>
{
    public override void Configure()
    {
        Get("wound-consolidated-email/email-type/{id}");
        Summary(new GetAllWoundConsolidatedEmailListByEmailTypeSummary());
    }

    public override async Task HandleAsync(GetAllWoundConsolidatedEmailByEmailTypeDto req, CancellationToken ct)
    {
        var dtos = await dbContext.WoundConsolidatedEmail
            .Where(x => !x.IsDeleted
                && x.MailSettingsID_FK == req.Id)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
