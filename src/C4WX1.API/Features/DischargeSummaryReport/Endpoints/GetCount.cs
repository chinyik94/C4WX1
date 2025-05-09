using C4WX1.API.Features.DischargeSummaryReport.Dtos;

namespace C4WX1.API.Features.DischargeSummaryReport.Endpoints;

public class GetCountSummary 
    : C4WX1GetCountSummary<Database.Models.DischargeSummaryReport>
{
    public GetCountSummary() { }
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
