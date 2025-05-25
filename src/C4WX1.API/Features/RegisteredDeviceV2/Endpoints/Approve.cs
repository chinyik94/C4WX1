using C4WX1.API.Features.RegisteredDeviceV2.Dtos;
using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.API.Features.RegisteredDeviceV2.Endpoints;

public class ApproveRegisteredDeviceV2Summary
    : EndpointSummary
{
    public ApproveRegisteredDeviceV2Summary()
    {
        Summary = "Approve Registered Device";
        Description = "Approve Registered Device";
        Responses[204] = "Registerd Device approved successfully";
    }
}

public class Approve(THCC_C4WDEVContext dbContext)
    : Endpoint<ApproveRegisteredDeviceV2Dto>
{
    public override void Configure()
    {
        Post("registered-device-v2/approve/{id}");
        Summary(new ApproveRegisteredDeviceV2Summary());
    }

    public override async Task HandleAsync(ApproveRegisteredDeviceV2Dto req, CancellationToken ct)
    {
        var entity = await dbContext.RegisteredDeviceV2
            .Where(x => !x.IsDeleted
                && x.RegisteredDeviceID == req.Id)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        entity.Status = Statuses.Active;
        entity.ModifiedBy_FK = req.UserId;
        entity.ModifiedDate = DateTime.Now;
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
