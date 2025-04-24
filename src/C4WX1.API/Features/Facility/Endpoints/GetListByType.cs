using C4WX1.API.Features.Facility.Dtos;
using C4WX1.API.Features.Facility.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.Facility.Endpoints;

public class GetFacilityListByTypeSummary : EndpointSummary
{
    public GetFacilityListByTypeSummary()
    {
        Summary = "Get a list of facilities by Organization Type";
        Description = "Get a list of facilities by Organization Type";
        Responses[200] = "Facility list retrieved successfully";
    }
}

public class GetListByType(THCC_C4WDEVContext dbContext)
    : Endpoint<GetFacilityListByTypeDto, IEnumerable<FacilityDto>, FacilityMapper>
{
    public override void Configure()
    {
        Get("/facility/type/{type}");
        Summary(new GetFacilityListByTypeSummary());
    }

    public override async Task HandleAsync(GetFacilityListByTypeDto req, CancellationToken ct)
    {
        var dtos = await dbContext.Facility
            .Where(x => !x.IsDeleted && x.OrganizationID_FK == req.TypeId)
            .Include(x => x.OrganizationID_FKNavigation)
            .Include(x => x.UserCategoryFacility)
                .ThenInclude(x => x.UserCategoryID_FKNavigation)
                .ThenInclude(x => x.UserType)
                .ThenInclude(x => x.UserUserType)
                .ThenInclude(x => x.UserID_FKNavigation)
            .OrderBy(x => x.FacilityName)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendAsync(dtos, cancellation: ct);
    }
}
