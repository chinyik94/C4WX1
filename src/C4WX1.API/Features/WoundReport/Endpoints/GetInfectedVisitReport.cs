using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.WoundReport.Dtos;
using C4WX1.API.Features.WoundReport.Repository;

namespace C4WX1.API.Features.WoundReport.Endpoints;

public class GetInfectedVisitReportSummary
    : EndpointSummary
{
    public GetInfectedVisitReportSummary()
    {
        Summary = "Get Infected Visit Report";
        Description = "Get Infected Visit Report";
        Responses[200] = "Infected Visit Report retrieved successfully";
    }
}
public class GetInfectedVisitReport(
    THCC_C4WDEVContext dbContext,
    IWoundReportRepository repository)
    : Endpoint<GetInfectedVisitReportDto, InfectedVisitReportDto>
{
    public override void Configure()
    {
        Get("wound-report/infected-visit");
        Summary(new GetInfectedVisitReportSummary());
    }

    public override async Task HandleAsync(GetInfectedVisitReportDto req, CancellationToken ct)
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
                PatientWoundVisitId = x.PatientWoundVisitID,
                PatientId = x.PatientWoundID_FKNavigation.PatientID_FK!.Value,
                PatientWoundId = x.PatientWoundID_FK,
                VisitDate = x.VisitDate!.Value
            })
            .ToListAsync(ct);

        var yearDifference = (req.EndDate.Year - req.StartDate.Year) * 12;
        var monthDifference = req.EndDate.Month - req.StartDate.Month + 1;
        var totalMonths = Math.Max(1, monthDifference + yearDifference);
        var monthBuckets = Enumerable.Range(0, totalMonths)
                     .Select(req.StartDate.AddMonths)
                     .ToList();
        var infectedVisitCounts = new List<WoundCountDto>();
        var nonInfectedVisitCounts = new List<WoundCountDto>();
        var infectedCount = 0;
        var nonInfectedCount = 0;
        var slowHealingCount = 0;

        foreach (var monthStart in monthBuckets)
        {
            var monthEnd = monthStart.AddMonths(1);
            var visitsInMonth = visits.Where(v => v.VisitDate >= monthStart && v.VisitDate < monthEnd);

            foreach (var visit in visits)
            {
                var result = await repository.GetWoundInfectionStatusAsync(
                    req.UserId, visit.PatientId, visit.PatientWoundVisitId);
                if (result == true)
                {
                    infectedCount++;
                }
                else
                {
                    nonInfectedCount++;
                }
            }

            infectedVisitCounts.Add(new WoundCountDto 
            { 
                MonthInterval = monthStart.ToString("MMM-yy"), 
                Count = infectedCount 
            });
            nonInfectedVisitCounts.Add(new WoundCountDto 
            { 
                MonthInterval = monthStart.ToString("MMM-yy"), 
                Count = nonInfectedCount 
            });
        }

        var groupedVisits = visits
            .GroupBy(v => v.PatientWoundId);
        foreach (var visit in groupedVisits)
        {
            var firstVisit = visit.First();
            var lastVisit = visit.Last();

            var result = await repository.GetWoundInfectionStatusDetailsAsync(
                req.UserId, firstVisit.PatientId, lastVisit.PatientWoundVisitId);

            if (result.BSlowHealing ?? false)
                slowHealingCount++;
        }

        int totalInfected = infectedVisitCounts.Sum(x => x.Count);
        int totalNonInfected = nonInfectedVisitCounts.Sum(x => x.Count);
        double avgInfected = totalInfected / (double)monthBuckets.Count;

        var dto = new InfectedVisitReportDto
        {
            Type = "NoOfInfectedVisits",
            Label = "Infected Visits",
            Data = infectedVisitCounts,
            ExtraData =
            [
                new() 
                { 
                    Label = "Non Infected Visits", 
                    Data = nonInfectedVisitCounts 
                }
            ],
            TotalCount = totalInfected.ToString(),
            NonInfectedCount = totalNonInfected.ToString(),
            AverageCount = avgInfected.ToString("N3"),
            SlowHealingCount = slowHealingCount.ToString()
        };
        await SendOkAsync(dto, ct);
    }
}
