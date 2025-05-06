using C4WX1.API.Features.Facility.Dtos;
using C4WX1.API.Features.Facility.Mappers;
using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.Facility.Endpoints;

public class GetFacilityByCIdSummary : EndpointSummary
{
    public GetFacilityByCIdSummary()
    {
        Summary = "Get Facility By CId";
        Description = "Get Facility By CId";
        Responses[200] = "Facility retrieved successfully";
        Responses[404] = "Facility not found";
    }
}

public class GetByCId(THCC_C4WDEVContext dbContext)
    : Endpoint<GetFacilityByCIdDto, FacilityDto, FacilityMapper>
{
    public override void Configure()
    {
        Get("/facility/cid/{cid}");
        Summary(new GetFacilityByCIdSummary());
    }

    public override async Task HandleAsync(GetFacilityByCIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.Facility
            .Include(x => x.OrganizationID_FKNavigation)
            .Include(x => x.UserCategoryFacility)
                .ThenInclude(x => x.UserCategoryID_FKNavigation)
                .ThenInclude(x => x.UserType)
                .ThenInclude(x => x.UserUserType)
                .ThenInclude(x => x.UserID_FKNavigation)
            .Where(x => !x.IsDeleted && x._id == req.CId)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        if (dto == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        await SendOkAsync(dto, cancellation: ct);
    }
}
