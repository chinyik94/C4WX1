using C4WX1.API.Features.C4WImage.Dtos;
using C4WX1.API.Features.C4WImage.Mappers;

namespace C4WX1.API.Features.C4WImage.Endpoints;

public class UpdateC4WImageSummary 
    : C4WX1UpdateSummary<Database.Models.C4WImage>
{
    public UpdateC4WImageSummary() : base()
    {
        ExampleRequest = new UpdateC4WImageDto
        {
            Id = 1,
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
    }
}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateC4WImageDto, UpdateC4WImageMapper>
{
    public override void Configure()
    {
        Put("c4w-image/{id}");
        Description(b => b.Produces(404));
        Summary(new UpdateC4WImageSummary());
    }

    public override async Task HandleAsync(UpdateC4WImageDto req, CancellationToken ct)
    {
        var entity = await dbContext.C4WImage
            .FirstOrDefaultAsync(
                x => !x.IsDeleted && x.C4WImageId == req.Id,
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
