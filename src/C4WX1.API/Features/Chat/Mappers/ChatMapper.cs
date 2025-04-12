using C4WX1.API.Features.Chat.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.Chat.Mappers;

public class ChatMapper : ResponseMapper<ChatDto, Database.Models.Chat>
{
    public override ChatDto FromEntity(Database.Models.Chat e) => new()
    {
        Attachment = e.Attachment,
        Attachment_Physical = e.Attachment_Physical,
        ChatID = e.ChatID,
        Comment = e.Comment,
        CreatedDate = e.CreatedDate,
        CreatedBy_FK = e.CreatedBy_FK,
        Family = e.Family,
        ParentID_FK = e.ParentID_FK,
        PatientID_FK = e.PatientID_FK,
        UserData = new ChatUserDto
        {
            UserId = e.CreatedBy_FKNavigation.UserId,
            Firstname = e.CreatedBy_FKNavigation.Firstname,
            Lastname = e.CreatedBy_FKNavigation.Lastname,
            Photo = e.CreatedBy_FKNavigation.Photo
        },
        PatientData = e.PatientID_FKNavigation == null
            ? null
            : new ChatPatientDto
            {
                PatientID = e.PatientID_FKNavigation.PatientID,
                Firstname = e.PatientID_FKNavigation.Firstname,
                Lastname = e.PatientID_FKNavigation.Lastname,
                Photo = e.PatientID_FKNavigation.Photo
            },
        CommentList = e.InverseParentID_FKNavigation
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
    };
}
