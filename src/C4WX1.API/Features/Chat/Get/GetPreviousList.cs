using C4WX1.API.Features.Chat.Dtos;
using C4WX1.API.Features.Chat.Repository;
using FastEndpoints;

namespace C4WX1.API.Features.Chat.Get
{
    public class GetPreviousChatListSummary : EndpointSummary
    {
        public GetPreviousChatListSummary()
        {
            Summary = "Get Previous Chat List";
            Description = "Get the previous Chat list";
            ExampleRequest = new GetChatListDto
            {
                ChatID = 1,
                Count = 10,
                Family = true,
                PatientID = 1,
                UserID = 1
            };
            Responses[200] = "Chat list retrieved successfully";
        }
    }

    public class GetPreviousList(
        IChatRepository chatRepository) : Endpoint<GetChatListDto, IEnumerable<ChatDto>>
    {
        public override void Configure()
        {
            Get("chat/list/previous");
            AllowAnonymous();
            Description(b => b
                .Accepts<GetChatListDto>("application/json")
                .Produces<IEnumerable<ChatDto>>()
                .ProducesProblemFE<InternalErrorResponse>(500));
            Summary(new GetPreviousChatListSummary());
        }

        public override async Task HandleAsync(GetChatListDto req, CancellationToken ct)
        {
            var dtos = await chatRepository.GetPreviousListAsync(req, ct);

            await SendAsync(dtos, cancellation: ct);
        }
    }
}
