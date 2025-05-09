using C4WX1.API.Features.Language.Dtos;
using C4WX1.API.Features.Language.Mappers;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Language.Endpoints;

public class GetLanguageByIdSummary 
    : C4WX1GetByIdSummary<Database.Models.Language>
{
    public GetLanguageByIdSummary() { }
}

public class GetById(THCC_C4WDEVContext dbContext)
    : Endpoint<GetByIdDto, LanguageDto, LanguageMapper>
{
    public override void Configure()
    {
        Get("language/{id}");
        Summary(new GetLanguageByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.Language
            .Where(x => x.LanguageId == req.Id)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        if (dto == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendOkAsync(dto, cancellation: ct);
    }
}
