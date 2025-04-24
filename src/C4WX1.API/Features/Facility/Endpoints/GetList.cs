using C4WX1.API.Features.Facility.Dtos;
using C4WX1.API.Features.Facility.Extensions;
using C4WX1.API.Features.Facility.Mappers;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.Facility.Endpoints;

public class GetFacilityListSummary : EndpointSummary
{
    public GetFacilityListSummary()
    {
        Summary = "Get a list of facilities";
        Description = "Get a filtered, sorted and paged list of facilities";
        Responses[200] = "List of facilities retrieved successfully";
    }
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
        var pageIndex = req.PageIndex ?? PaginationDefaults.Index;
        var pageSize = req.PageSize ?? PaginationDefaults.Size;
        var startRowIndex = Math.Max(0, (pageIndex - 1) * pageSize);

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
