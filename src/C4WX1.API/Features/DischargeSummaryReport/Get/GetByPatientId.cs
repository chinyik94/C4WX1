using C4WX1.API.Features.DischargeSummaryReport.Dtos;
using C4WX1.API.Features.DischargeSummaryReport.Mappers;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.DischargeSummaryReport.Get;

public class GetByPatientIdSummary : EndpointSummary
{
    public GetByPatientIdSummary()
    {
        Summary = "Get Discharge Summary Report";
        Description = "Get an Discharge Summary Report by its PatientID";
        Responses[200] = "Discharge Summary Report retrieved successfully";
        Responses[404] = "Discharge Summary Report not found";
    }
}

public class GetByPatientId(
    THCC_C4WDEVContext dbContext)
    : Endpoint<GetByPatientIdDto, DischargeSummaryReportDto, DischargeSummaryReportMapper>
{
    public override void Configure()
    {
        Get("discharge-summary-report/patient/{PatientId}");
        Description(b => b.Produces(404));
        Summary(new GetByIdSummary());
    }

    public override async Task HandleAsync(GetByPatientIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.DischargeSummaryReport
            .Where(x => !x.IsDeleted && x.PatientID_FK == req.PatientId)
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
