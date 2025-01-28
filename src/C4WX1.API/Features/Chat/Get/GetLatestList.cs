﻿using C4WX1.API.Features.Chat.Shared;
using FastEndpoints;

namespace C4WX1.API.Features.Chat.Get
{
    public class GetLatestChatListSummary : EndpointSummary
    {
        public GetLatestChatListSummary()
        {
            Summary = $"Get latest {nameof(Chat)} list";
            Description = $"Get the latest {nameof(Chat)} list";
            ExampleRequest = new GetChatListRequestDto
            {
                ChatID = 1,
                Count = 10,
                Family = true,
                PatientID = 1,
                UserID = 1
            };
            Responses[200] = $"{nameof(Chat)} list retrieved successfully";
        }
    }

    public class GetLatestList(
        IChatRepository chatRepository): Endpoint<GetChatListRequestDto, IEnumerable<ChatDto>>
    {
        public override void Configure()
        {
            Get("chat/list/latest");
            AllowAnonymous();
            Description(b => b
                .Accepts<GetChatListRequestDto>("application/json")
                .Produces<IEnumerable<ChatDto>>()
                .ProducesProblemFE<InternalErrorResponse>(500));
            Summary(new GetLatestChatListSummary());
        }

        public override async Task HandleAsync(GetChatListRequestDto req, CancellationToken ct)
        {
            var dtos = req.ChatID != null
                ? await chatRepository.GetLatestListAsync(req, ct)
                : await chatRepository.GetPreviousListAsync(req, ct);

            await SendAsync(dtos, cancellation: ct);
        }
    }
}
