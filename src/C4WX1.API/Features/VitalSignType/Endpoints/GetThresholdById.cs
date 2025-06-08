using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.Features.VitalSignType.Dtos;
using C4WX1.API.Features.VitalSignType.Mappers;

namespace C4WX1.API.Features.VitalSignType.Endpoints;

public class GetThresholdByIdSummary
    : C4WX1GetByIdSummary<Database.Models.VitalSignTypeThreshold>
{

}

public class GetThresholdById(THCC_C4WDEVContext dbContext)
    : Endpoint<GetByIdDto, VitalSignTypeThresholdDto, VitalSignTypeThersholdMapper>
{
    public override void Configure()
    {
        Get("vital-sign-type/threshold/{id}");
        Summary(new GetThresholdByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.VitalSignTypeThreshold
            .Where(x => x.VitalSignTypeID_FK == req.Id)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        await ((dto == null)
            ? SendNotFoundAsync(ct)
            : SendOkAsync(dto, ct));
    }
}
