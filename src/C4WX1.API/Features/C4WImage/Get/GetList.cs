using C4WX1.API.Features.C4WImage.Dtos;
using C4WX1.API.Features.C4WImage.Extensions;
using C4WX1.API.Features.C4WImage.Mappers;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.C4WImage.Get
{
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
            var pageIndex = req.PageIndex ?? 1;
            var pageSize = req.PageSize ?? 10;
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
                .Take(startRowIndex)
                .Skip(pageSize)
                .ToListAsync(ct);

            await SendOkAsync(dtos, cancellation: ct);
        }
    }
}
