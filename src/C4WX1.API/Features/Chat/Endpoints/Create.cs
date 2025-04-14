using C4WX1.API.Features.Chat.Dtos;
using C4WX1.API.Features.Chat.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.Chat.Endpoints;

public class CreateChatSummary : EndpointSummary
{
    public CreateChatSummary()
    {
        Summary = "Create Chat";
        Description = "Create a new Chat";
        ExampleRequest = new CreateChatDto
        {
            Attachment = "Attachment",
            Attachment_Physical = "Attachment_Physical",
            CreatedBy_FK = 1,
            ParentID_FK = 1,
            PatientID_FK = 1,
            Comment = "Comment",
            Family = true
        };
        Responses[200] = "Chat created successfully";
        Responses[400] = "Invalid request";
        Responses[404] = "Chat not found";
    }
}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateChatDto, ChatDto, ChatCreateMapper>
{
    public override void Configure()
    {
        Post("chat");
        Description(b => b
            .ProducesProblemFE(400)
            .Produces(404));
        Summary(new CreateChatSummary());
    }

    public override async Task HandleAsync(CreateChatDto req, CancellationToken ct)
    {
        var lastPost = await dbContext.Chat
            .Where(x => x.CreatedBy_FK == req.CreatedBy_FK)
            .OrderByDescending(x => x.CreatedDate)
            .FirstOrDefaultAsync(ct);
        if (lastPost == null || lastPost.CreatedDate.AddSeconds(1) > DateTime.Now)
        {
            Log.Warning("Chat does not exists or creation rate limit exceeded for user {UserId}", req.CreatedBy_FK);
            await SendErrorsAsync(cancellation: ct);
            return;
        }

        if (req.Family == null)
        {
            var parentEntity = await dbContext.Chat
                .FirstOrDefaultAsync(x => x.ChatID == req.ParentID_FK
                    && !x.IsDeleted, ct);
            req.Family = parentEntity?.Family ?? false;
        }
        var entity = Map.ToEntity(req);
        dbContext.Chat.Add(entity);
        await dbContext.SaveChangesAsync(ct);

        var dto = new ChatDto
        {
            Attachment = entity.Attachment,
            Attachment_Physical = entity.Attachment_Physical,
            ChatID = entity.ChatID,
            Comment = entity.Comment,
            CreatedBy_FK = entity.CreatedBy_FK,
            CreatedDate = entity.CreatedDate,
            Family = entity.Family,
            ParentID_FK = entity.ParentID_FK,
            PatientID_FK = entity.PatientID_FK
        };
        await SendAsync(dto, cancellation: ct);
    }
}
