using C4WX1.API.Features.DischargeSummaryReport.Dtos;
using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.DischargeSummaryReport.Endpoints;

public class GetCountSummary : EndpointSummary
{
    public GetCountSummary()
    {
        Summary = "Get Discharge Summary Report Count";
        Description = "Get Discharge Summary Report Count";
        Responses[200] = "Discharge Summary Report Count retrieved successfully";
    }
}

public class GetCount(
    THCC_C4WDEVContext dbContext)
    : Endpoint<GetCountDto, int>
{
    public override void Configure()
    {
        Get("discharge-summary-report/count");
        Summary(new GetCountSummary());
    }

    public override async Task HandleAsync(GetCountDto req, CancellationToken ct)
    {
        var count = await dbContext.DischargeSummaryReport
            .CountAsync(x => x.PatientID_FK == req.PatientID, ct);
        await SendAsync(count, cancellation: ct);
    }
}
