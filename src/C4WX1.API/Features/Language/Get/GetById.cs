using C4WX1.API.Features.Language.Dtos;
using C4WX1.API.Features.Language.Mappers;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.Language.Get
{
    public class GetLanguageByIdSummary : EndpointSummary
    {
        public GetLanguageByIdSummary()
        {
            Summary = "Get Language";
            Description = "Get a language by its Id";
            Responses[200] = "Language retrieved successfully";
            Responses[404] = "Language not found";
        }
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
}
