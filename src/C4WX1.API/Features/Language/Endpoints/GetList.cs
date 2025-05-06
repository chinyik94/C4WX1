using C4WX1.API.Features.Language.Dtos;
using C4WX1.API.Features.Language.Mappers;
using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.Language.Endpoints;

public class GetLanguageListSummary : EndpointSummary
{
    public GetLanguageListSummary()
    {
        Summary = "Get Language List";
        Description = "Get a sorted Language List";
        Responses[200] = "Language List retrieved successfully";
    }
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
