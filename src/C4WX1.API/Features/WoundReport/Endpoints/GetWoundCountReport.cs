using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.WoundReport.Dtos;

namespace C4WX1.API.Features.WoundReport.Endpoints;

public class GetWoundCountReportSummary
    : EndpointSummary
{
    public GetWoundCountReportSummary()
    {
        Summary = "Get Wound Count Report";
        Description = "Get Wound Count Report";
        Responses[200] = "Wound Count Report retrieved successfully";
    }
}

public class GetWoundCountReport(THCC_C4WDEVContext dbContext)
    : Endpoint<GetWoundCountReportDto, WoundCountReportDto>
{
    public override void Configure()
    {
        Get("wound-report/count");
        Summary(new GetWoundCountReportSummary());
    }

    public override async Task HandleAsync(GetWoundCountReportDto req, CancellationToken ct)
    {
        var wounds = await dbContext.PatientWound
            .Where(x => !x.IsDeleted
                && x.Status != Statuses.Draft
                && x.OccurDate.HasValue
                && (string.IsNullOrEmpty(req.Status) || x.Status == req.Status)
                && (x.PatientID_FKNavigation != null && x.PatientID_FKNavigation.PatientFacility
                    .Any(y => !y.FacilityID_FKNavigation.IsDeleted
                        && y.FacilityID_FK == req.FacilityId))
                && x.PatientWoundVisit
                    .Any(y => !y.IsDeleted
                        && y.Status != Statuses.Draft
                        && y.VisitDate.HasValue
                        && y.VisitDate.Value.Date >= req.StartDate.Date
                        && y.VisitDate.Value.Date <= req.EndDate.Date))
            .Select(x => new
            {
                x.PatientWoundID,
                OccurDate = x.OccurDate!.Value
            })
            .OrderBy(x => x.OccurDate)
            .ToListAsync(ct);

        var totalWoundCount = wounds.Count;
        var yearDifference = (req.EndDate.Year - req.StartDate.Year) * 12;
        var monthDifference = req.EndDate.Month - req.StartDate.Month + 1;
        var totalMonths = Math.Max(1, monthDifference + yearDifference);
        var averageWoundCount = (double)totalWoundCount / totalMonths;

        var woundCounts = new List<WoundCountDto>();
        var monthIndex = req.StartDate;
        while (monthIndex <= req.EndDate)
        {
            woundCounts.Add(new WoundCountDto
            {
                MonthInterval = monthIndex.ToString("MMM-yy"),
                Count = 0
            });
            monthIndex = monthIndex.AddMonths(1);
        }

        var groupedCounts = wounds
            .GroupBy(x => x.OccurDate.ToString("MMM-yy"))
            .ToDictionary(x => x.Key, x => x.Count());
        var newWoundCount = 0;
        foreach (var woundCount in woundCounts)
        {
            if (groupedCounts.TryGetValue(woundCount.MonthInterval, out var count))
            {
                woundCount.Count = count;
                newWoundCount += count;
            }
        }

        var dto = new WoundCountReportDto
        {
            Type = "NoOfWounds",
            Label = "No. of Wounds",
            Data = woundCounts,
            TotalCount = totalWoundCount.ToString(),
            AverageCount = averageWoundCount.ToString("N3"),
            NewWoundCount = newWoundCount.ToString()
        };
        await SendOkAsync(dto, ct);
    }
}
