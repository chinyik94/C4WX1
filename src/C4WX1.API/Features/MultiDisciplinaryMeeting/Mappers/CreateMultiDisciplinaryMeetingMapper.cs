using C4WX1.API.Features.MultiDisciplinaryMeeting.Dtos;

namespace C4WX1.API.Features.MultiDisciplinaryMeeting.Mappers;

public class CreateMultiDisciplinaryMeetingMapper
    : RequestMapper<CreateMultiDisciplinaryMeetingDto, Database.Models.MultiDisciplinaryMeeting>
{
    public override Database.Models.MultiDisciplinaryMeeting ToEntity(CreateMultiDisciplinaryMeetingDto r)
        => new()
        {
            PatientID_FK = r.PatientID_FK,
            IssuesOverall = r.IssuesOverall,
            Remarks = r.Remarks,
            AssignedToFollowUp = r.AssignedToFollowUp,
            CreatedBy_FK = r.UserId,
            CreatedDate = DateTime.Now,
            MultiDisciplinaryMeetingDetail = [.. r.MultiDisciplinaryMeetingDetailList
                .Select(x => new MultiDisciplinaryMeetingDetail
                {
                    IssueCatID = x.IssueCatID,
                    IssueTitle = x.IssueTitle,
                    IssueContent = x.IssueContent,
                    CreatedBy_FK = r.UserId,
                    CreatedDate = DateTime.Now
                })],
            IsDeleted = false
        };
}
