using C4WX1.API.Features.C4WImage.Dtos;
using C4WX1.API.Features.C4WImage.Extensions;
using C4WX1.API.Features.C4WImage.Mappers;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.C4WImage.Endpoints;

public class GetC4WImageListSummary : EndpointSummary
{
    public GetC4WImageListSummary()
    {
        Summary = "Get C4W Image List";
        Description = "Get a filtered, paged and sorted C4W Image List";
        Responses[200] = "C4W Image List retrieved successfully";
    }
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
        var pageIndex = req.PageIndex ?? PaginationDefaults.Index;
        var pageSize = req.PageSize ?? PaginationDefaults.Size;
        var startRowIndex = Math.Max(0, (pageIndex - 1) * pageSize);

        var orderBy = string.IsNullOrWhiteSpace(req.OrderBy)
            ? SortDirections.Default
            : req.OrderBy;
        var order = orderBy.Split(' ');
        var sortColumn = order[0];
        var isDescending = order[1].Equals(SortDirections.Default, StringComparison.OrdinalIgnoreCase);

        var endDate = req.ToDate.Date.AddDays(1);

        var dtos = await dbContext.C4WImage
            .Where(x => !x.IsDeleted
                && x.CreatedDate >= req.FromDate.Date
                && x.CreatedDate <= endDate)
            .Sort(orderBy)
            .Select(x => Map.FromEntity(x))
            .Skip(startRowIndex)
            .Take(pageSize)
            .ToListAsync(ct);

        await SendOkAsync(dtos, cancellation: ct);
    }
}
