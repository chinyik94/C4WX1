using C4WX1.API.Features.VitalSignType.Dtos;
using C4WX1.API.Features.VitalSignType.Mappers;

namespace C4WX1.API.Features.VitalSignType.Endpoints;

public class GetVitalSignTypeListSummary
    : C4WX1GetListSummary<Database.Models.VitalSignTypes>
{

}

public class GetList(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<IEnumerable<VitalSignTypeDto>, VitalSignTypeMapper>
{
    public override void Configure()
    {
        Get("vital-sign-type");
        Summary(new GetVitalSignTypeListSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var dtos = await dbContext.VitalSignTypes
            .OrderBy(x => x.name)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
