using C4WX1.API.Features.Facility.Dtos;
using C4WX1.API.Features.Facility.Mappers;

namespace C4WX1.API.Features.Facility.Endpoints;

public class GetFacilityListByIntegrationSourceSummary : EndpointSummary
{
    public GetFacilityListByIntegrationSourceSummary()
    {
        Summary = "Get a list of facilities by integration source";
        Description = "Get a list of facilities by integration source";
        Responses[200] = "Facilities retrieved successfully";
    }
}

public class GetListByIntegrationSource(THCC_C4WDEVContext dbContext)
    : Endpoint<GetFacilityListByIntegrationSourceDto, IEnumerable<FacilityDto>, FacilityMapper>
{
    public override void Configure()
    {
        Get("/facility/integration-source/{integrationSource}");
        Summary(new GetFacilityListByIntegrationSourceSummary());
    }

    public override async Task HandleAsync(GetFacilityListByIntegrationSourceDto req, CancellationToken ct)
    {
        var query = dbContext.Facility
            .Where(x => !x.IsDeleted && x.IntegrationSource == req.IntegrationSource);
        if (req.FacilityId != null)
        {
            query = query.Where(x => x.FacilityID == req.FacilityId);
        }
        var dtos = await query
            .Include(x => x.OrganizationID_FKNavigation)
            .Include(x => x.UserCategoryFacility)
                .ThenInclude(x => x.UserCategoryID_FKNavigation)
                .ThenInclude(x => x.UserType)
                .ThenInclude(x => x.UserUserType)
                .ThenInclude(x => x.UserID_FKNavigation)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendAsync(dtos, cancellation: ct);
    }
}
