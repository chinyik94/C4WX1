using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.WoundReport.Dtos;

namespace C4WX1.API.Features.WoundReport.Endpoints;

public class GetWoundVisitReportSummary
    : EndpointSummary
{
    public GetWoundVisitReportSummary()
    {
        Summary = "Get Wound Visit Report";
        Description = "Get Wound Visit Report";
        Responses[200] = "Wound Visit Report retrieved successfully";
    }
}

public class GetWoundVisitReport(THCC_C4WDEVContext dbContext)
    : Endpoint<GetWoundVisitReportDto, WoundVisitReportDto>
{
    public override void Configure()
    {
        Get("wound-report/visit");
        Summary(new GetWoundVisitReportSummary());
    }

    public override async Task HandleAsync(GetWoundVisitReportDto req, CancellationToken ct)
    {
        var visits = await dbContext.PatientWoundVisit
            .Where(x => !x.IsDeleted
                && x.Status != Statuses.Draft
                && x.VisitDate.HasValue
                && x.VisitDate.Value.Date >= req.StartDate.Date
                && x.VisitDate.Value.Date <= req.EndDate.Date
                && !x.PatientWoundID_FKNavigation.IsDeleted
                && x.PatientWoundID_FKNavigation.Status != Statuses.Draft
                && x.PatientWoundID_FKNavigation.OccurDate.HasValue
                && (string.IsNullOrWhiteSpace(req.Status) || x.PatientWoundID_FKNavigation.Status == req.Status)
                && x.PatientWoundID_FKNavigation.PatientID_FKNavigation!.PatientFacility
                    .Any(y => !y.FacilityID_FKNavigation.IsDeleted
                        && y.FacilityID_FK == req.FacilityId)
                && (req.PatientId == 0 || x.PatientWoundID_FKNavigation.PatientID_FK!.Value == req.PatientId))
            .Select(x => new
            {
                x.PatientWoundVisitID,
                VisitDate = x.VisitDate!.Value,
                PainScore = x.Suffering ?? 0,
                WoundId = x.PatientWoundID_FK
            })
            .ToListAsync(ct);

        var totalVisitCount = visits.Count;
        var yearDifference = (req.EndDate.Year - req.StartDate.Year) * 12;
        var monthDifference = req.EndDate.Month - req.StartDate.Month + 1;
        var totalMonths = Math.Max(1, monthDifference + yearDifference);
        var averageVisitCount = (double)totalVisitCount / totalMonths;
        var painScoreMoreThan2Count = visits.Count(v => v.PainScore > 2);
        var distinctWoundCount = visits.Select(v => v.WoundId).Distinct().Count();

        var groupedCounts = visits
            .GroupBy(v => v.VisitDate.ToString("MMM-yy"))
            .ToDictionary(g => g.Key, g => g.Count());

        var visitCounts = Enumerable
            .Range(0, totalMonths)
            .Select(req.StartDate.AddMonths)
            .Select(month => new WoundCountDto
            {
                MonthInterval = month.ToString("MMM-yy"),
                Count = groupedCounts.TryGetValue(month.ToString("MMM-yy"), out int count) 
                    ? count 
                    : 0
            })
            .ToList();

        var dto = new WoundVisitReportDto
        {
            Type = "NoOfVisits",
            Label = "No. of Visits",
            Data = visitCounts,
            TotalCount = totalVisitCount.ToString(),
            AverageCount = averageVisitCount.ToString("N3"),
            PainScoreMoreThan2Count = painScoreMoreThan2Count.ToString(),
            WoundCount = distinctWoundCount.ToString()
        };
        await SendOkAsync(dto, ct);
    }
}
