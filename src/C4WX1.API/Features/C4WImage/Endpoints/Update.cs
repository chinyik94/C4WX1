using C4WX1.API.Features.C4WImage.Dtos;
using C4WX1.API.Features.C4WImage.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.C4WImage.Endpoints;

public class UpdateC4WImageSummary : EndpointSummary
{
    public UpdateC4WImageSummary()
    {
        Summary = "Update C4W Image";
        Description = "Update an existing C4W Image";
        ExampleRequest = new UpdateC4WImageDto
        {
            C4WImageId = 1,
            WoundImageName = "wound image name",
            WoundImageData = "wound image data",
            WoundBedImageName = "wound bed image name",
            WoundBedImageData = "wound bed image data",
            TissueImageName = "tissue image name",
            TissueImageData = "tissue image data",
            DepthImageName = "depth image name",
            DepthImageData = "depth image data",
            UserId = 1
        };
        Responses[204] = "C4W Image updated successfully";
        Responses[404] = "C4W Image not found";
    }
}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateC4WImageDto, UpdateC4WImageMapper>
{
    public override void Configure()
    {
        Put("c4w-image/{c4wImageId}");
        Description(b => b.Produces(404));
        Summary(new UpdateC4WImageSummary());
    }

    public override async Task HandleAsync(UpdateC4WImageDto req, CancellationToken ct)
    {
        var entity = await dbContext.C4WImage
            .FirstOrDefaultAsync(
                x => !x.IsDeleted && x.C4WImageId == req.C4WImageId,
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
