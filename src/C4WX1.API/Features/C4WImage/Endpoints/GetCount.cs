using C4WX1.API.Features.C4WImage.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.C4WImage.Endpoints;

public class GetC4WImageCountSummary : EndpointSummary
{
    public GetC4WImageCountSummary()
    {
        Summary = "Get C4W Image Count";
        Description = "Get C4W Image Count based on its CreatedDate";
        Responses[200] = "C4W Image Count retrieved successfully";
    }
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
