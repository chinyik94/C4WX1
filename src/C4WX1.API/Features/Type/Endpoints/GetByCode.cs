using C4WX1.API.Features.Type.Dtos;
using C4WX1.API.Features.Type.Mappers;

namespace C4WX1.API.Features.Type.Endpoints;

public class GetTypeByCodeSummary
    : C4WX1GetByIdSummary<Types>
{

}

public class GetByCode(THCC_C4WDEVContext dbContext)
    : Endpoint<GetTypeByCodeDto, TypeDto, TypeMapper>
{
    public override void Configure()
    {
        Get("type/{code}");
        Summary(new GetTypeByCodeSummary());
    }

    public override async Task HandleAsync(GetTypeByCodeDto req, CancellationToken ct)
    {
        var dto = await dbContext.Types
            .Where(x => x.code == req.Code)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        await ((dto == null)
            ? SendNotFoundAsync(ct)
            : SendOkAsync(dto, ct));
    }
}
