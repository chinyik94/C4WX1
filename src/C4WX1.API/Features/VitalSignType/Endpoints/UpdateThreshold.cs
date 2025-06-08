using C4WX1.API.Features.VitalSignType.Dtos;
using C4WX1.API.Features.VitalSignType.Mappers;

namespace C4WX1.API.Features.VitalSignType.Endpoints;

public class UpdateThresholdSummary
    : C4WX1UpdateSummary<VitalSignTypeThreshold>
{ 

}

public class UpdateThreshold(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateVitalSignTypeThresholdDto, UpdateVitalSignTypeThresholdMapper>
{
    public override void Configure()
    {
        Put("vital-sign-type/threshold/{id}");
        Summary(new UpdateThresholdSummary());
    }

    public override async Task HandleAsync(UpdateVitalSignTypeThresholdDto req, CancellationToken ct)
    {
        var entity = await dbContext.VitalSignTypeThreshold
            .Where(x => x.VitalSignTypeID_FK == req.Id)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        entity = Map.UpdateEntity(req, entity);
        await dbContext.VitalSignTypeThreshold.AddAsync(entity, ct);
        await SendNoContentAsync(ct);
    }
}
