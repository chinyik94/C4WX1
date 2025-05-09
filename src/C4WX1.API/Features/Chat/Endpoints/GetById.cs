using C4WX1.API.Features.Chat.Dtos;
using C4WX1.API.Features.Chat.Mappers;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Chat.Endpoints;

public class GetChatByIdSummary 
    : C4WX1GetByIdSummary<Database.Models.Chat>
{
    public GetChatByIdSummary() { }
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
