using C4WX1.API.Features.MobileAppVersioning.Dtos;
using C4WX1.API.Features.MobileAppVersioning.Extensions;
using C4WX1.API.Features.MobileAppVersioning.Mappers;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.Features.Shared.Extensions;

namespace C4WX1.API.Features.MobileAppVersioning.Endpoints;

public class GetMobileAppVersioningListSummary
    : C4WX1GetListSummary<Database.Models.MobileAppVersioning>
{

}

public class GetList(THCC_C4WDEVContext dbContext)
    : Endpoint<GetListDto, IEnumerable<MobileAppVersioningDto>, MobileAppVersioningMapper>
{
    public override void Configure()
    {
        Get("mobile-app-versioning");
        Summary(new GetMobileAppVersioningListSummary());
    }

    public override async Task HandleAsync(GetListDto req, CancellationToken ct)
    {
        var (startRowIndex, pageSize) = req.GetPaginationDetails();
        var dtos = await dbContext.MobileAppVersioning
            .Include(x => x.CreatedBy_FKNavigation)
            .Include(x => x.ModifiedBy_FKNavigation)
            .Where(x => !(x.IsDeleted ?? false))
            .Sort(req.OrderBy)
            .Skip(startRowIndex)
            .Take(pageSize)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
