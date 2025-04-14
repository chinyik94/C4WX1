using C4WX1.API.Features.C4WImage.Dtos;
using C4WX1.API.Features.C4WImage.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.C4WImage.Endpoints;

public class CreateC4WImageSummary : EndpointSummary
{
    public CreateC4WImageSummary()
    {
        Summary = "Create C4W Image";
        Description = "Create a new C4W Image";
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
        Responses[204] = "C4W Image created successfully";
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
