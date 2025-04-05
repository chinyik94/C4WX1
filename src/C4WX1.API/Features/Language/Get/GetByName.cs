using C4WX1.API.Features.Language.Dtos;
using C4WX1.API.Features.Language.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.Language.Get
{
    public class GetLanguageByNameSummary : EndpointSummary
    {
        public GetLanguageByNameSummary()
        {
            Summary = "Get Language";
            Description = "Get a language by its Name";
            Responses[200] = "Language retrieved successfully";
            Responses[404] = "Language not found";
        }
    }

    public class GetByName(THCC_C4WDEVContext dbContext)
        : Endpoint<GetLanguageByNameDto, LanguageDto, LanguageMapper>
    {
        public override void Configure()
        {
            Get("language/name/{name}");
            Summary(new GetLanguageByNameSummary());
        }

        public override async Task HandleAsync(GetLanguageByNameDto req, CancellationToken ct)
        {
            var dto = await dbContext.Language
                .Where(x => x.Name == req.Name)
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
}
