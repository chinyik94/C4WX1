using C4WX1.API.Features.Security;
using C4WX1.API.Features.Type.Dtos;

namespace C4WX1.API.Features.Type.Endpoints;

public class UpdateTypeByCodeSummary
    : C4WX1UpdateSummary<Types>
{

}

public class UpdateByCode(
    THCC_C4WDEVContext dbContext,
    ISecurityService securityService)
    : Endpoint<UpdateTypeDto>
{
    public override void Configure()
    {
        Put("type/{code}");
        Summary(new UpdateTypeByCodeSummary());
    }

    public override async Task HandleAsync(UpdateTypeDto req, CancellationToken ct)
    {
        var entity = await dbContext.Types
            .Where(x => x.code == req.Code)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        entity.codeValue = securityService.Encrypt(req.Code);
        entity.updated = DateTime.Now;
        await dbContext.SaveChangesAsync(ct);
    }
}
