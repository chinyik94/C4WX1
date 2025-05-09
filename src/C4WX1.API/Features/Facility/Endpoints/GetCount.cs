using C4WX1.API.Features.Facility.Dtos;

namespace C4WX1.API.Features.Facility.Endpoints;

public class GetFacilityCountSummary 
    : C4WX1GetCountSummary<Database.Models.Facility>
{
    public GetFacilityCountSummary() { }
}

public class GetCount(THCC_C4WDEVContext dbContext)
    : Endpoint<GetFacilityCountDto, int>
{
    public override void Configure()
    {
        Get("/facility/count");
        Summary(new GetFacilityCountSummary());
    }

    public override async Task HandleAsync(GetFacilityCountDto req, CancellationToken ct)
    {
        var query = dbContext.Facility.Where(x => !x.IsDeleted);
        if (!string.IsNullOrEmpty(req.Keyword))
        {
            query = query.Where(x => x.FacilityName.Contains(req.Keyword));
        }
        if (req.OrganizationId.HasValue)
        {
            query = query.Where(x => x.OrganizationID_FK == req.OrganizationId);
        }
        var count = await query.CountAsync(ct);
        await SendOkAsync(count, cancellation: ct);
    }
}
