using C4WX1.API.Features.C4WDeviceToken.Dtos;
using C4WX1.API.Features.C4WDeviceToken.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.C4WDeviceToken.Endpoints;

public class UpdateC4WDeviceTokenSummary : EndpointSummary
{
    public UpdateC4WDeviceTokenSummary()
    {
        Summary = "Update C4W Device Token";
        Description = "Update an existing C4W Device Token";
        ExampleRequest = new UpdateC4WDeviceTokenDto
        {
            Id = 1,
            OldDeviceToken = "Old token",
            NewDeviceToken = "New token",
            ClientEnvironment = "test env",
            Device = "IPhone",
            UserId = 1
        };
        Responses[204] = "C4W Device Token updated successfully";
        Responses[404] = "C4W Device Token not found";
    }
}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateC4WDeviceTokenDto, UpdateC4WDeviceTokenMapper>
{
    public override void Configure()
    {
        Put("c4w-device-token/{id}");
        Summary(new UpdateC4WDeviceTokenSummary());
    }

    public override async Task HandleAsync(UpdateC4WDeviceTokenDto req, CancellationToken ct)
    {
        var entity = await dbContext.C4WDeviceToken
            .FirstOrDefaultAsync(
                x => !x.IsDeleted && x.C4WDeviceTokenId == req.Id,
                ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        entity = Map.UpdateEntity(req, entity);
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
