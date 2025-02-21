using C4WX1.API.Features.Chat.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.Chat.Delete
{
    public class DeleteChatSummary : EndpointSummary
    {
        public DeleteChatSummary()
        {
            Summary = "Delete Chat";
            Description = "Delete an existing Chat";
            ExampleRequest = new DeleteChatDto
            {
                ChatID = 1,
                UserID = 1
            };
            Responses[204] = "Chat deleted successfully";
            Responses[404] = "Chat not found";
        }
    }

    public class Delete(THCC_C4WDEVContext dbContext) 
        : Endpoint<DeleteChatDto>
    {
        public override void Configure()
        {
            Delete("chat/{chatID}");
            AllowAnonymous();
            Description(b => b
                .Accepts<DeleteChatDto>()
                .Produces(404)
                .ProducesProblemFE<InternalErrorResponse>(500));
            Summary(new DeleteChatSummary());
        }

        public override async Task HandleAsync(DeleteChatDto req, CancellationToken ct)
        {
            var entity = dbContext.Chat
                .Where(x => !x.IsDeleted
                    && x.ChatID == req.ChatID
                    && x.CreatedBy_FK == req.UserID);
            if (entity == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }
            var deleteDurationConfig = await dbContext.SysConfig
                .FirstOrDefaultAsync(x => x.ConfigName == "DeleteMessageDuration", ct);
            var deleteDuration = int.TryParse(deleteDurationConfig?.ConfigValue ?? string.Empty, out var value)
                ? value 
                : 30;
            foreach (var e in entity)
            {
                if ((DateTime.Now - e.CreatedDate).TotalMinutes <= deleteDuration || e.ParentID_FK == req.ChatID)
                {
                    e.IsDeleted = true;
                }
            }
            await dbContext.SaveChangesAsync(ct);
            await SendOkAsync(cancellation: ct);
        }
    }
}
