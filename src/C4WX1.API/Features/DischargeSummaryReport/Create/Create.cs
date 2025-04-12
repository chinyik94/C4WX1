using C4WX1.API.Features.DischargeSummaryReport.Dtos;
using C4WX1.API.Features.DischargeSummaryReport.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.DischargeSummaryReport.Create;

public class CreateDischargeSummaryReportSummary : EndpointSummary
{
    public CreateDischargeSummaryReportSummary()
    {
        Summary = "Create Discharge Summary Report";
        Description = "Create a new Discharge Summary Report";
        ExampleRequest = new CreateDischargeSummaryReportDto()
        {
            DischargeDate = DateTime.Now,
            PatientID_FK = 1,
            VisitDateEnd = DateTime.Now,
            VisitDateStart = DateTime.Now,
            VisitedBy_FK = 1,
            SummaryCaseNote = "SummaryCaseNote",
            UserId = 1,
            AttachmentList =
            [
                new DischargeSummaryReportAttachmentDto
                {
                    Filename = "Filename",
                    Physical = "Physical"
                }
            ]
        };
        Responses[204] = "Discharge Summary Report created successfully";
    }
}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateDischargeSummaryReportDto, int, CreateDischargeSummaryReportMapper>
{
    public override void Configure()
    {
        Post("discharge-summary-report");
        Summary(new CreateDischargeSummaryReportSummary());
    }

    public override async Task HandleAsync(CreateDischargeSummaryReportDto req, CancellationToken ct)
    {
        var entity = Map.ToEntity(req);
        dbContext.DischargeSummaryReport.Add(entity);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.DischargeSummaryReportId, cancellation: ct);
    }
}
