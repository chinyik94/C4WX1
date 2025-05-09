using C4WX1.API.Features.Language.Dtos;
using C4WX1.API.Features.Language.Mappers;

namespace C4WX1.API.Features.Language.Endpoints;

public class GetLanguageListSummary 
    : C4WX1GetListSummary<Database.Models.Language>
{
    public GetLanguageListSummary() { }
}

public class GetList(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<IEnumerable<LanguageDto>, LanguageMapper>
{
    public override void Configure()
    {
        Get("language");
        Summary(new GetLanguageListSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var dtos = await dbContext.Language
            .OrderBy(x => x.Name)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, cancellation: ct);
    }
}
