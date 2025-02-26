using C4WX1.API.Features.Chat.Dtos;
using C4WX1.API.Features.Chat.Mappers;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.Chat.Get
{
    public class GetChatByIdSummary : EndpointSummary
    {
        public GetChatByIdSummary()
        {
            Summary = "Get Chat";
            Description = "Get Chat by its ID";
            Responses[200] = "Chat retrieved successfully";
            Responses[404] = "Chat not found";
        }
    }

    public class GetById(THCC_C4WDEVContext dbContext)
        : Endpoint<GetByIdDto, ChatDto, ChatMapper>
    {
        public override void Configure()
        {
            Get("chat/{id}");
            Summary(new GetChatByIdSummary());
        }

        public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
        {
            var query = dbContext.Chat.Where(x => x.ChatID == req.Id && !x.IsDeleted);
            var isExists = await query.AnyAsync(ct);
            if (!isExists)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            var dto = await query
                .Select(x => Map.FromEntity(x))
                .FirstAsync(ct);
            await SendAsync(dto, cancellation: ct);
        }
    }
}
