using C4WX1.API.Features.C4WImage.Dtos;

namespace C4WX1.API.Features.C4WImage.Endpoints;

public class GetC4WImageCountSummary 
    : C4WX1GetCountSummary<Database.Models.C4WImage>
{
    public GetC4WImageCountSummary() { }
}

public class GetCount(THCC_C4WDEVContext dbContext)
    : Endpoint<GetC4WImageCountByDateDto, int>
{
    public override void Configure()
    {
        Get("c4w-image/count");
        Summary(new GetC4WImageCountSummary());
    }

    public override async Task HandleAsync(GetC4WImageCountByDateDto req, CancellationToken ct)
    {
        var endDate = req.ToDate.AddDays(1);
        var count = await dbContext.C4WImage
            .Where(x => !x.IsDeleted
                && x.CreatedDate >= req.FromDate.Date
                && x.CreatedDate <= endDate)
            .CountAsync(ct);

        await SendOkAsync(count, cancellation: ct);
    }
}
