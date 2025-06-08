using C4WX1.API.Features.VitalSignType.Dtos;
using C4WX1.API.Features.VitalSignType.Mappers;

namespace C4WX1.API.Features.VitalSignType.Endpoints;

public class CreateThresholdSummary
    : C4WX1CreateSummary<VitalSignTypeThreshold>
{

}

public class CreateThreshold(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateVitalSignTypeThresholdDto, int, CreateVitalSignTypeThresholdMapper>
{
    public override void Configure()
    {
        Post("vital-sign-type/threshold");
        Summary(new CreateThresholdSummary());
    }

    public override async Task HandleAsync(CreateVitalSignTypeThresholdDto req, CancellationToken ct)
    {
        var entity = Map.ToEntity(req);
        await dbContext.VitalSignTypeThreshold.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.VitalSignTypeID_FK, ct);
    }
}
