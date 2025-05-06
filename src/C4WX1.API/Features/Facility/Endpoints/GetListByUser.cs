using C4WX1.API.Features.Facility.Dtos;
using C4WX1.API.Features.Facility.Mappers;
using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.Facility.Endpoints;

public class GetFacilityListByUserSummary : EndpointSummary
{
    public GetFacilityListByUserSummary()
    {
        Summary = "Get a list of facilities by user";
        Description = "Get a list of facilities by user";
        Responses[200] = "Facilities retrieved successfully";
    }
}

public class GetListByUser(THCC_C4WDEVContext dbContext)
    : Endpoint<GetFacilityListByUserDto, IEnumerable<FacilityDto>, FacilityMapper>
{
    public override void Configure()
    {
        Get("/facility/user/{userId}");
        Summary(new GetFacilityListByUserSummary());
    }

    public override async Task HandleAsync(GetFacilityListByUserDto req, CancellationToken ct)
    {
        var dtos = await dbContext.Facility
            .Include(x => x.OrganizationID_FKNavigation)
            .Include(x => x.UserCategoryFacility)
                .ThenInclude(x => x.UserCategoryID_FKNavigation)
                .ThenInclude(x => x.UserType)
                .ThenInclude(x => x.UserUserType)
                .ThenInclude(x => x.UserID_FKNavigation)
            .Where(x => !x.IsDeleted && x.UserCategoryFacility
                .Any(ucf => ucf.UserCategoryID_FKNavigation.UserType
                    .Any(ut => ut.UserUserType
                        .Any(uut => uut.UserID_FK == req.UserId))))
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendAsync(dtos, cancellation: ct);
    }
}
