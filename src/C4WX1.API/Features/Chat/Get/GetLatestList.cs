using C4WX1.API.Features.Chat.Dtos;
using C4WX1.API.Features.Chat.Repository;
using FastEndpoints;

namespace C4WX1.API.Features.Chat.Get
{
    public class GetLatestChatListSummary : EndpointSummary
    {
        public GetLatestChatListSummary()
        {
            Summary = "Get Latest Chat List";
            Description = "Get the latest Chat list";
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

    public class GetLatestList(IChatRepository chatRepository)
        : Endpoint<GetChatListDto, IEnumerable<ChatDto>>
    {
        public override void Configure()
        {
            Get("chat/latest");
            AllowAnonymous();
            Description(b => b
                .Accepts<GetChatListDto>()
                .Produces<IEnumerable<ChatDto>>()
                .ProducesProblemFE<InternalErrorResponse>(500));
            Summary(new GetLatestChatListSummary());
        }

        public override async Task HandleAsync(GetChatListDto req, CancellationToken ct)
        {
            var dtos = req.ChatID != null
                ? await chatRepository.ListLatestAsync(req)
                : await chatRepository.ListPreviousAsync(req);

            await SendAsync(dtos, cancellation: ct);
        }
    }
}
