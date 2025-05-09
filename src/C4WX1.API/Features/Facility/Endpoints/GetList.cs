using C4WX1.API.Features.Facility.Dtos;
using C4WX1.API.Features.Facility.Extensions;
using C4WX1.API.Features.Facility.Mappers;
using C4WX1.API.Features.Shared.Extensions;

namespace C4WX1.API.Features.Facility.Endpoints;

public class GetFacilityListSummary 
    : C4WX1GetListSummary<Database.Models.Facility>
{
    public GetFacilityListSummary() { }
}

public class GetList(THCC_C4WDEVContext dbContext)
    : Endpoint<GetFacilityListDto, IEnumerable<FacilityDto>, FacilityMapper>
{
    public override void Configure()
    {
        Get("/facility");
        Summary(new GetFacilityListSummary());
    }

    public override async Task HandleAsync(GetFacilityListDto req, CancellationToken ct)
    {
        var (startRowIndex, pageSize) = req.GetPaginationDetails();
        var query = dbContext.Facility
            .Where(x => !x.IsDeleted);
        if (!string.IsNullOrEmpty(req.Keyword))
        {
            query = query.Where(x => x.FacilityName.Contains(req.Keyword));
        }
        if (req.OrganizationId != null)
        {
            query = query.Where(x => x.OrganizationID_FK == req.OrganizationId);
        }

        var dtos = await query
            .Include(x => x.OrganizationID_FKNavigation)
            .Include(x => x.UserCategoryFacility)
                .ThenInclude(x => x.UserCategoryID_FKNavigation)
                .ThenInclude(x => x.UserType)
                .ThenInclude(x => x.UserUserType)
                .ThenInclude(x => x.UserID_FKNavigation)
            .Sort(req.OrderBy)
            .Skip(startRowIndex)
            .Take(pageSize)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendAsync(dtos, cancellation: ct);
    }
}
