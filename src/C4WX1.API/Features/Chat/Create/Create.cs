using C4WX1.API.Features.Chat.Shared;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace C4WX1.API.Features.Chat.Create
{
    public class CreateChatRequestDto
    {
        public string? Attachment { get; set; }
        public string? Attachment_Physical { get; set; }
        public int CreatedBy_FK { get; set; }
        public int? ParentID_FK { get; set; }
        public int? PatientID_FK { get; set; }
        public string? Comment { get; set; }
        public bool? Family { get; set; }
    }

    public class CreateChatSummary : EndpointSummary
    {
        public CreateChatSummary()
        {
            Summary = $"Create {nameof(Chat)}";
            Description = $"Create a new {nameof(Chat)}";
            ExampleRequest = new CreateChatRequestDto
            {
                Attachment = "Attachment",
                Attachment_Physical = "Attachment_Physical",
                CreatedBy_FK = 1,
                ParentID_FK = 1,
                PatientID_FK = 1,
                Comment = "Comment",
                Family = true
            };
            Responses[200] = $"{nameof(Chat)} created successfully";
            Responses[400] = "Invalid request";
            Responses[404] = $"{nameof(Chat)} not found";
        }
    }

    public class Create(
        THCC_C4WDEVContext dbContext): Endpoint<CreateChatRequestDto, ChatDto>
    {
        public override void Configure()
        {
            Post("chat");
            AllowAnonymous();
            Description(b => b
                .Accepts<CreateChatRequestDto>("application/json")
                .Produces<ChatDto>()
                .ProducesProblemFE()
                .ProducesProblemFE<InternalErrorResponse>(500));
            Summary(new CreateChatSummary());
        }

        public override async System.Threading.Tasks.Task HandleAsync(CreateChatRequestDto req, CancellationToken ct)
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
            var entity = new Database.Models.Chat()
            {
                Attachment = req.Attachment,
                Attachment_Physical = req.Attachment_Physical,
                Comment = req.Comment,
                CreatedBy_FK = req.CreatedBy_FK,
                CreatedDate = DateTime.Now,
                Family = req.Family,
                IsDeleted = false,
                ParentID_FK = req.ParentID_FK,
                PatientID_FK = req.PatientID_FK
            };
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
}
