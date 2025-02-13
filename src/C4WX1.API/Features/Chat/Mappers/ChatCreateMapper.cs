using C4WX1.API.Features.Chat.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.Chat.Mappers
{
    public class ChatCreateMapper : RequestMapper<CreateChatDto, Database.Models.Chat>
    {
        public override Database.Models.Chat ToEntity(CreateChatDto r) => new()
        {
            Attachment = r.Attachment,
            Attachment_Physical = r.Attachment_Physical,
            Comment = r.Comment,
            CreatedBy_FK = r.CreatedBy_FK,
            CreatedDate = DateTime.Now,
            Family = r.Family,
            IsDeleted = false,
            ParentID_FK = r.ParentID_FK,
            PatientID_FK = r.PatientID_FK
        };
    }
}
