using C4WX1.API.Features.C4WImage.Dtos;
using C4WX1.API.Features.C4WImage.Mappers;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.C4WImage.Endpoints;

public class GetC4WImageByIdSummary
    : C4WX1GetByIdSummary<Database.Models.C4WImage>
{
    public GetC4WImageByIdSummary() { }
}

public class GetById(THCC_C4WDEVContext dbContext)
    : Endpoint<GetByIdDto, C4WImageDto, C4WImageMapper>
{
    public override void Configure()
    {
        Get("c4w-image/{id}");
        Description(b => b.Produces(404));
        Summary(new GetC4WImageByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.C4WImage
            .Where(x => !x.IsDeleted && x.C4WImageId == req.Id)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        if (dto == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendOkAsync(dto, cancellation: ct);
    }
}
