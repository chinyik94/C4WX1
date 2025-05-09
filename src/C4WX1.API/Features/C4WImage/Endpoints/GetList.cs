using C4WX1.API.Features.C4WImage.Dtos;
using C4WX1.API.Features.C4WImage.Extensions;
using C4WX1.API.Features.C4WImage.Mappers;
using C4WX1.API.Features.Shared.Extensions;

namespace C4WX1.API.Features.C4WImage.Endpoints;

public class GetC4WImageListSummary 
    : C4WX1GetListSummary<Database.Models.C4WImage>
{
    public GetC4WImageListSummary() { }
}

public class GetList(THCC_C4WDEVContext dbContext)
    : Endpoint<GetC4WImageListDto, IEnumerable<C4WImageDto>, C4WImageMapper>
{
    public override void Configure()
    {
        Get("c4w-image");
        Summary(new GetC4WImageListSummary());
    }

    public override async Task HandleAsync(GetC4WImageListDto req, CancellationToken ct)
    {
        var (startRowIndex, pageSize) = req.GetPaginationDetails();
        var endDate = req.ToDate.Date.AddDays(1);
        var dtos = await dbContext.C4WImage
            .Where(x => !x.IsDeleted
                && x.CreatedDate >= req.FromDate.Date
                && x.CreatedDate <= endDate)
            .Sort(req.OrderBy)
            .Select(x => Map.FromEntity(x))
            .Skip(startRowIndex)
            .Take(pageSize)
            .ToListAsync(ct);

        await SendOkAsync(dtos, cancellation: ct);
    }
}
