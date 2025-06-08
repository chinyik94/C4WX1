using C4WX1.API.Features.VitalSignDetails.Dtos;
using C4WX1.API.Features.VitalSignDetails.Mappers;

namespace C4WX1.API.Features.VitalSignDetails.Endpoints;

public class GetVitalSignDetailsByVitalSignIdSummary
    : C4WX1GetListSummary<Database.Models.VitalSignDetails>
{

}

public class GetByVitalSignId(THCC_C4WDEVContext dbContext)
    : Endpoint<GetVitalSignDetailsByVitalSignIdDto, IEnumerable<VitalSignDetailsDto>, VitalSignDetailsMapper>
{
    public override void Configure()
    {
        Get("vital-sign-details/vital-sign");
        Summary(new GetVitalSignDetailsByVitalSignIdSummary());
    }

    public override async Task HandleAsync(GetVitalSignDetailsByVitalSignIdDto req, CancellationToken ct)
    {
        var dtos = await dbContext.VitalSignDetails
            .Include(x => x.vitalSignType)
            .Where(x => x.vitalSignId == req.VitalSignId)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
