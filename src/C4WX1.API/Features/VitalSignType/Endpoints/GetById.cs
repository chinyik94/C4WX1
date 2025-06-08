using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.Features.VitalSignType.Dtos;
using C4WX1.API.Features.VitalSignType.Mappers;

namespace C4WX1.API.Features.VitalSignType.Endpoints;

public class GetVitalSignTypeByIdSummary
    : C4WX1GetByIdSummary<Database.Models.VitalSignTypes>
{

}

public class GetById(THCC_C4WDEVContext dbContext)
    : Endpoint<GetByIdDto, VitalSignTypeDto, VitalSignTypeMapper>
{
    public override void Configure()
    {
        Get("vital-sign-type/{id}");
        Summary(new GetVitalSignTypeByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.VitalSignTypes
            .Where(x => x.id == req.Id)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        await ((dto == null)
            ? SendNotFoundAsync(ct)
            : SendOkAsync(dto, ct));
    }
}
