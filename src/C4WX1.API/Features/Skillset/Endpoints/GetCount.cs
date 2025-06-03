
using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.API.Features.Skillset.Endpoints;

public class GetSkillsetCountSummary
    : C4WX1GetCountSummary<Database.Models.Code>
{

}

public class GetCount(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<int>
{
    public override void Configure()
    {
        Get("skillset/count");
        Summary(new GetSkillsetCountSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var count = await dbContext.Code
            .Where(x => !x.IsDeleted
                && x.CodeTypeId_FK == CodetableTypeKeys.Skillset)
            .CountAsync(ct);
        await SendOkAsync(count, ct);
    }
}
