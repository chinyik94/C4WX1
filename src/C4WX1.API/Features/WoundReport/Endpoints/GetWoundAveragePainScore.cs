using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.WoundReport.Dtos;

namespace C4WX1.API.Features.WoundReport.Endpoints;

public class GetWoundAveragePainScoreSummary
    : EndpointSummary
{
    public GetWoundAveragePainScoreSummary()
    {
        Summary = "Get Wound Average Pain Score";
        Description = "Get Wound Average Pain Score";
        Responses[200] = "Wound Average Pain Score retrieved successfully";
    }
}

public class GetWoundAveragePainScore(THCC_C4WDEVContext dbContext)
    : Endpoint<GetWoundAveragePainScoreDto, WoundAveragePainScoreDto>
{
    public override void Configure()
    {
        Get("wound-report/wound-average-pain-score");
        Summary(new GetWoundAveragePainScoreSummary());
    }

    public override async Task HandleAsync(GetWoundAveragePainScoreDto req, CancellationToken ct)
    {
        var visits = await dbContext.PatientWoundVisit
            .Where(x => !x.IsDeleted
                && x.Status != Statuses.Draft
                && x.VisitDate.HasValue
                && x.VisitDate.Value.Date >= req.StartDate.Date
                && x.VisitDate.Value.Date <= req.EndDate.Date
                && x.PatientWoundID_FKNavigation != null
                && !x.PatientWoundID_FKNavigation.IsDeleted
                && x.PatientWoundID_FKNavigation.Status != Statuses.Draft
                && (string.IsNullOrWhiteSpace(req.Status) || x.PatientWoundID_FKNavigation.Status == req.Status)
                && x.PatientWoundID_FKNavigation.OccurDate.HasValue
                && x.PatientWoundID_FKNavigation.PatientID_FKNavigation != null
                && (req.PatientId == 0 || x.PatientWoundID_FKNavigation.PatientID_FK == req.PatientId)
                && x.PatientWoundID_FKNavigation.PatientID_FKNavigation.PatientFacility
                    .Any(pf => !pf.FacilityID_FKNavigation.IsDeleted
                        && pf.FacilityID_FK == req.FacilityId))
            .Select(x => new
            {
                VisitDate = x.VisitDate!.Value,
                PainScore = x.Suffering ?? 0
            })
            .ToListAsync(ct);

        var totalWoundCount = visits.Count;
        var yearDifference = (req.EndDate.Year - req.StartDate.Year) * 12;
        var monthDifference = req.EndDate.Month - req.StartDate.Month + 1;
        var totalMonths = Math.Max(1, monthDifference + yearDifference);
        var averageWoundCount = (double)totalWoundCount / totalMonths;

        var visitCounts = new List<WoundCountDto>();
        var monthIndex = req.StartDate;
        while (monthIndex <= req.EndDate)
        {
            visitCounts.Add(new WoundCountDto
            {
                MonthInterval = monthIndex.ToString("MMM-yy"),
                Count = 0
            });
            monthIndex = monthIndex.AddMonths(1);
        }
        var groupedPainScores = visits
            .GroupBy(v => v.VisitDate.ToString("MMM-yy"))
            .ToDictionary(g => g.Key, g => g.Average(v => v.PainScore));
        foreach (var month in visitCounts)
        {
            if (groupedPainScores.TryGetValue(month.MonthInterval, out var avg))
            {
                month.Count = (int)avg;
            }
        }

        var dto = new WoundAveragePainScoreDto
        {
            Type = "PainScore",
            Label = "Average Pain Score",
            Data = visitCounts
        };
        await SendOkAsync(dto, ct);
    }
}
