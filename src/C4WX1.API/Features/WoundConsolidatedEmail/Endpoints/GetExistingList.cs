using C4WX1.API.Features.WoundConsolidatedEmail.Dtos;
using C4WX1.API.Features.WoundConsolidatedEmail.Mappers;

namespace C4WX1.API.Features.WoundConsolidatedEmail.Endpoints;

public class GetExistingWoundConsolidatedEmailListSummary
    : C4WX1GetListSummary<Database.Models.WoundConsolidatedEmail>
{

}

public class GetExistingList(THCC_C4WDEVContext dbContext)
    : Endpoint<GetExistingWoundConsolidatedEmailListDto, IEnumerable<WoundConsolidatedEmailDto>, WoundConsolidatedEmailMapper>
{
    public override void Configure()
    {
        Get("wound-consolidated-email/existing");
        Summary(new GetExistingWoundConsolidatedEmailListSummary());
    }

    public override async Task HandleAsync(GetExistingWoundConsolidatedEmailListDto req, CancellationToken ct)
    {
        var dtos = await dbContext.WoundConsolidatedEmail
            .Where(x => !x.IsDeleted
                && x.PatientWoundVisitID_FK == req.WoundVisitId
                && x.MailSettingsID_FK == req.MailSettingsId
                && x.CreatedDate.Date == DateTime.Now.Date)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
