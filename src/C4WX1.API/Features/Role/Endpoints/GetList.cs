using C4WX1.API.Features.Role.Dtos;
using C4WX1.API.Features.Role.Mappers;
using Microsoft.AspNetCore.Identity;

namespace C4WX1.API.Features.Role.Endpoints;

public class GetRoleListSummary
    : C4WX1GetListSummary<Database.Models.Role>
{

}

public class GetList(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<IEnumerable<RoleDto>, RoleMapper>
{
    public override void Configure()
    {
        Get("role");
        Summary(new GetRoleListSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var dtos = await dbContext.Role
            .Where(x => x.Active ?? false)
            .OrderBy(x => x.Ordering)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
