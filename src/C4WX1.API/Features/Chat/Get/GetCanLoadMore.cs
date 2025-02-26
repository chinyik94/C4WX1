using C4WX1.API.Features.Chat.Dtos;
using C4WX1.API.Features.Chat.Repository;
using FastEndpoints;

namespace C4WX1.API.Features.Chat.Get
{
    public class GetCanLoadMoreChatSummary : EndpointSummary
    {
        public GetCanLoadMoreChatSummary()
        {
            Summary = "Get Can Load More Chat";
            Description = "Check if there are more chats to load";
            ExampleRequest = new GetCanLoadMoreChatDto
            {
                Min = 1,
                PatientId = 1,
                UserId = 1
            };
        }
    }

    public class GetCanLoadMore(IChatRepository repository) 
        : Endpoint<GetCanLoadMoreChatDto, bool>
    {
        public override void Configure()
        {
            Get("chat/can-load-more");
            Summary(new GetCanLoadMoreChatSummary());
        }

        public override async Task HandleAsync(GetCanLoadMoreChatDto req, CancellationToken ct)
        {
            if (req.Min == null)
            {
                await SendAsync(false, cancellation: ct);
                return;
            }

            var canLoadMore = await repository.CanLoadMoreAsync(req.PatientId, req.UserId, req.Min ?? 0);
            await SendAsync(canLoadMore, cancellation: ct);
        }
    }
}
