using C4WX1.API.Features.DischargeSummaryReport.Dtos;
using C4WX1.API.Features.DischargeSummaryReport.Mappers;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.DischargeSummaryReport.Endpoints;

public class GetDischargeSummaryReportByIdSummary 
    : C4WX1GetByIdSummary<Database.Models.DischargeSummaryReport>
{
    public GetDischargeSummaryReportByIdSummary() { }
}

public class GetById(
    THCC_C4WDEVContext dbContext)
    : Endpoint<GetByIdDto, DischargeSummaryReportDto, DischargeSummaryReportMapper>
{
    public override void Configure()
    {
        Get("discharge-summary-report/{Id}");
        Description(b => b.Produces(404));
        Summary(new GetDischargeSummaryReportByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.DischargeSummaryReport
            .Where(x => !x.IsDeleted && x.DischargeSummaryReportId == req.Id)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);

        if (dto == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendOkAsync(dto, cancellation: ct);
    }
}
