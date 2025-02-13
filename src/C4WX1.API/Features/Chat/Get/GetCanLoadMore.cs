using C4WX1.API.Features.Chat.Dtos;
using Dapper;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Npgsql;

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

    public class GetCanLoadMore(
        IConfiguration configuration) : Endpoint<GetCanLoadMoreChatDto, bool>
    {
        public override void Configure()
        {
            Get("chat/can-load-more");
            AllowAnonymous();
            Description(b => b
                .Accepts<GetCanLoadMoreChatDto>("application/json")
                .Produces<bool>()
                .ProducesProblemFE<InternalErrorResponse>(500));
            Summary(new GetCanLoadMoreChatSummary());
        }

        public override async Task HandleAsync(GetCanLoadMoreChatDto req, CancellationToken ct)
        {
            if (req.Min == null)
            {
                await SendAsync(false, cancellation: ct);
                return;
            }

            var sql =
                """
                SELECT EXISTS(
                    SELECT 1
                    FROM "Chat"
                    WHERE "IsDeleted" = FALSE
                        AND (@patientId IS NULL OR "PatientID_FK" = @patientId)
                        AND (@userId IS NULL OR "fn_CanAccessPatient"(@userId, "PatientID_FK"))
                        AND "ChatID" < @min
                )
                """;

            using var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
            var canLoadMore = await connection.QuerySingleAsync<bool>(sql, new
            {
                patientId = req.PatientId,
                userId = req.UserId,
                min = req.Min.Value
            });

            await SendAsync(canLoadMore, cancellation: ct);
        }
    }
}
