using C4WX1.API.Features.DischargeSummaryReport.Dtos;
using C4WX1.API.Features.DischargeSummaryReport.Extensions;
using C4WX1.API.Features.Shared.Extensions;

namespace C4WX1.API.Features.DischargeSummaryReport.Endpoints;

public class GetListSummary 
    : C4WX1GetListSummary<Database.Models.DischargeSummaryReport>
{
    public GetListSummary() { }
}

public class GetList(
    THCC_C4WDEVContext dbContext)
    : Endpoint<GetDischargeSummaryReportListDto, IEnumerable<DischargeSummaryReportDto>>
{
    public override void Configure()
    {
        Get("discharge-summary-report");
        Summary(new GetListSummary());
    }

    public override async Task HandleAsync(GetDischargeSummaryReportListDto req, CancellationToken ct)
    {
        var (startRowIndex, pageSize) = req.GetPaginationDetails();
        var dtos = await dbContext.DischargeSummaryReport
            .Where(x => x.PatientID_FK == req.PatientId)
            .Sort(req.OrderBy)
            .Skip(startRowIndex)
            .Take(pageSize)
            .Select(x => new DischargeSummaryReportDto
            {
                DischargeSummaryReportID = x.DischargeSummaryReportId,
                PatientID_FK = x.PatientID_FK,
                DischargeDate = x.DischargeDate,
                CreatedBy_FK = x.CreatedBy_FK,
                VisitDateEnd = x.VisitDateEnd,
                VisitDateStart = x.VisitDateStart,
                VisitedBy_FK = x.VisitedBy_FK,
                SummaryCaseNote = x.SummaryCaseNote ?? string.Empty,
                Status = x.Status,
                CreatedBy = dbContext.Users
                    .Where(x => x.UserId == x.CreatedBy_FK)
                    .Select(x => new DischargeSummaryReportUserDto
                    {
                        UserId = x.UserId,
                        Firstname = x.Firstname,
                        Lastname = x.Lastname,
                        Photo = x.Photo,
                    })
                    .FirstOrDefault(),
                CreatedDate = x.CreatedDate,
                ModifiedBy = dbContext.Users
                    .Where(x => x.UserId == x.ModifiedBy_FK)
                    .Select(x => new DischargeSummaryReportUserDto
                    {
                        UserId = x.UserId,
                        Firstname = x.Firstname,
                        Lastname = x.Lastname,
                        Photo = x.Photo,
                    })
                    .FirstOrDefault(),
                ModifiedDate = x.ModifiedDate
            })
            .ToListAsync(ct);

        await SendAsync(dtos, cancellation: ct);
    }
}
