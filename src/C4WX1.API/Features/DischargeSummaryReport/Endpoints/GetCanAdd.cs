using C4WX1.API.Features.DischargeSummaryReport.Dtos;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.DischargeSummaryReport.Endpoints;

public class GetCanAddSummary : EndpointSummary
{
    public GetCanAddSummary()
    {
        Summary = "Get Discharge Summary Report Can Add";
        Description = "Get if a Discharge Summary Report can be added";
        Responses[200] = "Discharge Summary Report Can Add retrieved successfully";
    }
}

public class GetCanAdd(
    THCC_C4WDEVContext dbContext)
    : Endpoint<GetCanAddDto, bool>
{
    public override void Configure()
    {
        Get("discharge-summary-report/can-add");
        Summary(new GetCanAddSummary());
    }

    public override async Task HandleAsync(GetCanAddDto req, CancellationToken ct)
    {
        var isExist = await dbContext.DischargeSummaryReport
            .AnyAsync(x => x.PatientID_FK == req.PatientID && !x.IsDeleted, ct);

        if (!isExist)
        {
            await SendOkAsync(false, cancellation: ct);
            return;
        }

        var canAdd = await dbContext.Patient
            .AnyAsync(x => x.PatientID == req.PatientID
                && (x.Status == Statuses.Discharge || x.Status == Statuses.DischargeRIP),
                ct);

        await SendOkAsync(canAdd, cancellation: ct);
    }
}
