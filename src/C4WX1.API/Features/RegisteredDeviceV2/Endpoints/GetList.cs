using C4WX1.API.Features.RegisteredDeviceV2.Dtos;
using C4WX1.API.Features.RegisteredDeviceV2.Extensions;
using C4WX1.API.Features.RegisteredDeviceV2.Mappers;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.Features.Shared.Extensions;

namespace C4WX1.API.Features.RegisteredDeviceV2.Endpoints;

public class GetRegisteredDeviceV2ListSummary
    : C4WX1GetListSummary<Database.Models.RegisteredDeviceV2>
{

}

public class GetList(THCC_C4WDEVContext dbContext)
    : Endpoint<GetListDto, IEnumerable<RegisteredDeviceV2Dto>, RegisteredDeviceV2Mapper>
{
    public override void Configure()
    {
        Get("registered-device-v2");
        Summary(new GetRegisteredDeviceV2ListSummary());
    }

    public override async Task HandleAsync(GetListDto req, CancellationToken ct)
    {
        var (startRowIndex, pageSize) = req.GetPaginationDetails();
        var dtos = await dbContext.RegisteredDeviceV2
            .Where(x => !x.IsDeleted)
            .Sort(req.OrderBy)
            .Skip(startRowIndex)
            .Take(pageSize)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
