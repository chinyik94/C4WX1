using C4WX1.API.Features.Chat.Shared;
using C4WX1.API.Features.Shared;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.Chat.Get
{
    public class GetChatByIdSummary : EndpointSummary
    {
        public GetChatByIdSummary()
        {
            Summary = $"Get {nameof(Chat)} by ID";
            Description = $"Get a {nameof(Chat)} by its ID";
            Responses[200] = $"{nameof(Chat)} retrieved successfully";
            Responses[404] = $"{nameof(Chat)} not found";
        }
    }

    public class GetById(
        THCC_C4WDEVContext dbContext): Endpoint<GetByIdRequestDto, ChatDto>
    {
        public override void Configure()
        {
            Get("chat/{id}");
            AllowAnonymous();
            Description(b => b
                .Accepts<GetByIdRequestDto>("application/json")
                .Produces<ChatDto>()
                .ProducesProblemFE<InternalErrorResponse>(500));
            Summary(new GetChatByIdSummary());
        }

        public override async System.Threading.Tasks.Task HandleAsync(GetByIdRequestDto req, CancellationToken ct)
        {
            var query = dbContext.Chat.Where(x => x.ChatID == req.Id && !x.IsDeleted);
            var isExists = await query.AnyAsync(ct);
            if (!isExists)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            var dto = await query
                .Select(x => new ChatDto
                {
                    Attachment = x.Attachment,
                    Attachment_Physical = x.Attachment_Physical,
                    ChatID = x.ChatID,
                    Comment = x.Comment,
                    CreatedDate = x.CreatedDate,
                    CreatedBy_FK = x.CreatedBy_FK,
                    Family = x.Family,
                    ParentID_FK = x.ParentID_FK,
                    PatientID_FK = x.PatientID_FK,
                    UserData = new ChatUserDto
                    {
                        UserId = x.CreatedBy_FKNavigation.UserId,
                        Firstname = x.CreatedBy_FKNavigation.Firstname,
                        Lastname = x.CreatedBy_FKNavigation.Lastname,
                        Photo = x.CreatedBy_FKNavigation.Photo
                    },
                    PatientData = new ChatPatientDto
                    {
                        PatientID = x.PatientID_FKNavigation.PatientID,
                        Firstname = x.PatientID_FKNavigation.Firstname,
                        Lastname = x.PatientID_FKNavigation.Lastname,
                        Photo = x.PatientID_FKNavigation.Photo
                    },
                    CommentList = x.InverseParentID_FKNavigation
                        .Where(y => !y.IsDeleted)
                        .OrderByDescending(y => y.CreatedDate)
                        .Select(y => new ChatDto
                        {
                            Attachment = y.Attachment,
                            Attachment_Physical = y.Attachment_Physical,
                            ChatID = y.ChatID,
                            Comment = y.Comment,
                            CreatedDate = y.CreatedDate,
                            ParentID_FK = y.ParentID_FK,
                            PatientID_FK = y.PatientID_FK,
                            UserData = new ChatUserDto
                            {
                                UserId = y.CreatedBy_FKNavigation.UserId,
                                Firstname = y.CreatedBy_FKNavigation.Firstname,
                                Lastname = y.CreatedBy_FKNavigation.Lastname,
                                Photo = y.CreatedBy_FKNavigation.Photo
                            }
                        })
                        .ToList()
                })
                .FirstAsync(ct);
            await SendAsync(dto, cancellation: ct);
        }
    }
}
