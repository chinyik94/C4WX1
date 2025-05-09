using C4WX1.API.Features.DischargeSummaryReport.Dtos;
using C4WX1.API.Features.DischargeSummaryReport.Mappers;

namespace C4WX1.API.Features.DischargeSummaryReport.Endpoints;

public class CreateDischargeSummaryReportSummary 
    : C4WX1CreateSummary<Database.Models.DischargeSummaryReport>
{
    public CreateDischargeSummaryReportSummary() : base()
    {
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
