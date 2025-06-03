using C4WX1.API.Features.Role.Dtos;
using C4WX1.API.Features.Role.Mappers;

namespace C4WX1.API.Features.Role.Endpoints;

public class GetAllRoleListForConfigurationSummary
    : C4WX1GetListSummary<Database.Models.Role>
{

}

public class GetAllListForConfiguration(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<IEnumerable<RoleDto>, RoleMapper>
{
    public override void Configure()
    {
        Get("role/all");
        Summary(new GetRoleListSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var dtos = await dbContext.Role
            .OrderBy(x => x.Ordering)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
