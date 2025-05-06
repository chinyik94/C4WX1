using C4WX1.API.Features.Facility.Dtos;
using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.Facility.Endpoints;

public class GetFacilityCountSummary : EndpointSummary
{
    public GetFacilityCountSummary()
    {
        Summary = "Get the count of facilities";
        Description = "Get the count of facilities";
        Responses[200] = "Facility count retrieved successfully";
    }
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
