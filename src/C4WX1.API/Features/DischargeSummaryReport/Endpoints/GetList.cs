using C4WX1.API.Features.DischargeSummaryReport.Dtos;
using C4WX1.API.Features.DischargeSummaryReport.Extensions;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.DischargeSummaryReport.Endpoints;

public class GetListSummary : EndpointSummary
{
    public GetListSummary()
    {
        Summary = "Get Disharge Summary Report List";
        Description = "Get a filtered, paged and sorted list of Disharge Summary Reports";
        Responses[200] = "Disharge Summary Report List retrieved successfully";
    }
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
        var pageIndex = req.PageIndex ?? PaginationDefaults.Index;
        var pageSize = req.PageSize ?? PaginationDefaults.Size;
        var startRowIndex = Math.Max(0, (pageIndex - 1) * pageSize);

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
