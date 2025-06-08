using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.WoundReport.Dtos;

namespace C4WX1.API.Features.WoundReport.Endpoints;

public class GetWoundCategoryStageSummary
    : EndpointSummary
{
    public GetWoundCategoryStageSummary()
    {
        Summary = "Get Wound Category Stage";
        Description = "Get Wound Category Stage";
        Responses[200] = "Wound Category Stage retrieved successfully";
    }
}

public class GetWoundCategoryStage(THCC_C4WDEVContext dbContext)
    : Endpoint<GetWoundCategoryStageDto, IEnumerable<WoundCategoryStageDto>>
{
    public override void Configure()
    {
        Get("wound-report/wound-category-stage");
        Summary(new GetWoundCategoryStageSummary());
    }

    public override async Task HandleAsync(GetWoundCategoryStageDto req, CancellationToken ct)
    {
        var dtos = await dbContext.PatientWound
            .Where(x => !x.IsDeleted
                && x.Status != Statuses.Draft
                && (string.IsNullOrWhiteSpace(req.Status) || x.Status == req.Status)
                && x.PatientWoundVisit.Count > 0
                && x.PatientWoundVisit
                    .Any(pwv => !pwv.IsDeleted
                        && pwv.Status != Statuses.Draft
                        && pwv.VisitDate.HasValue
                        && pwv.VisitDate.Value.Date >= req.StartDate.Date
                        && pwv.VisitDate.Value.Date <= req.EndDate.Date)
                && x.PatientID_FKNavigation!.PatientFacility
                    .Any(pf => !pf.FacilityID_FKNavigation.IsDeleted
                        && pf.FacilityID_FK == req.FacilityId))
            .OrderBy(x => x.OccurDate)
            .Select(x => new WoundCategoryStageDto
            {
                PatientWoundID = x.PatientWoundID,
                OccurDate = x.OccurDate!.Value,
                Category = x.Category!,
                Stage = x.Stage!
            })
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
