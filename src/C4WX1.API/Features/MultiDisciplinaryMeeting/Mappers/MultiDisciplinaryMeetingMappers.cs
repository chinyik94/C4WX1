using C4WX1.API.Features.MultiDisciplinaryMeeting.Dtos;

namespace C4WX1.API.Features.MultiDisciplinaryMeeting.Mappers;

public class MultiDisciplinaryMeetingMappers
    : ResponseMapper<MultiDisciplinaryMeetingDto, Database.Models.MultiDisciplinaryMeeting>
{
    public override MultiDisciplinaryMeetingDto FromEntity(Database.Models.MultiDisciplinaryMeeting e)
        => new()
        {
            MultiDisciplinaryMeetingID = e.MultiDisciplinaryMeetingID,
            IssuesOverall = e.IssuesOverall,
            Remarks = e.Remarks,
            AssignedToFollowUp = e.AssignedToFollowUp,
            MultiDisciplinaryMeetingDetailList = [.. e.MultiDisciplinaryMeetingDetail
                    .Where(y => !y.IsDeleted)
                    .Select(y => new MultiDisciplinaryMeetingDetailDto
                    {
                        IssueCatID = y.IssueCatID,
                        IssueTitle = y.IssueTitle,
                        IssueContent = y.IssueContent,
                        AP = y.ActionPlan
                    })]
        };
}
