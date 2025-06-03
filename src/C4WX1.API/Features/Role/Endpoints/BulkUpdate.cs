using C4WX1.API.Features.Role.Dtos;

namespace C4WX1.API.Features.Role.Endpoints;

public class BulkUpdateRoleSummary
    : C4WX1UpdateSummary<Database.Models.Role>
{

}

public class BulkUpdate(THCC_C4WDEVContext dbContext)
    : Endpoint<BulkUpdateRoleDto>
{
    public override void Configure()
    {
        Post("role/bulk-update");
        Summary(new BulkUpdateRoleSummary());
    }

    public override async Task HandleAsync(BulkUpdateRoleDto req, CancellationToken ct)
    {
        var roleIds = req.Roles.Select(r => r.RoleId);
        var entities = await dbContext.Role
            .Where(r => roleIds.Contains(r.RoleId))
            .ToListAsync(ct);
        foreach (var entity in entities)
        {
            var reqRole = req.Roles.First(r => r.RoleId == entity.RoleId);
            entity.Active = reqRole.Active;
        }
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
