using C4WX1.API.Features.Language.Dtos;
using C4WX1.API.Features.Language.Mappers;

namespace C4WX1.API.Features.Language.Endpoints;

public class GetLanguageByFullNameSummary : EndpointSummary
{
    public GetLanguageByFullNameSummary()
    {
        Summary = "Get Language";
        Description = "Get a language by its FullName";
        Responses[200] = "Language retrieved successfully";
        Responses[404] = "Language not found";
    }
}

public class GetByFullName(THCC_C4WDEVContext dbContext)
    : Endpoint<GetLanguageByFullNameDto, LanguageDto, LanguageMapper>
{
    public override void Configure()
    {
        Get("language/full-name/{fullName}");
        Summary(new GetLanguageByFullNameSummary());
    }

    public override async Task HandleAsync(GetLanguageByFullNameDto req, CancellationToken ct)
    {
        var dto = await dbContext.Language
            .Where(x => x.FullName == req.FullName)
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
