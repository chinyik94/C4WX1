using C4WX1.API.Features.C4WImage.Dtos;
using C4WX1.API.Features.C4WImage.Mappers;

namespace C4WX1.API.Features.C4WImage.Endpoints;

public class CreateC4WImageSummary 
    : C4WX1CreateSummary<Database.Models.C4WImage>
{
    public CreateC4WImageSummary() : base()
    {
        ExampleRequest = new CreateC4WImageDto
        {
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

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateC4WImageDto, int, CreateC4WImageMapper>
{
    public override void Configure()
    {
        Post("c4w-image");
        Summary(new CreateC4WImageSummary());
    }

    public override async Task HandleAsync(CreateC4WImageDto req, CancellationToken ct)
    {
        var entity = Map.ToEntity(req);
        dbContext.C4WImage.Add(entity);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.C4WImageId, cancellation: ct);
    }
}
