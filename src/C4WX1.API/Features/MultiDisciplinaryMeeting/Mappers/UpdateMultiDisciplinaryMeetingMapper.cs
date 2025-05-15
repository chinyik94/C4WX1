using C4WX1.API.Features.MultiDisciplinaryMeeting.Dtos;

namespace C4WX1.API.Features.MultiDisciplinaryMeeting.Mappers;

public class UpdateMultiDisciplinaryMeetingMapper
    : RequestMapper<UpdateMultiDisciplinaryMeetingDto, Database.Models.MultiDisciplinaryMeeting>
{
    public override Database.Models.MultiDisciplinaryMeeting UpdateEntity(
        UpdateMultiDisciplinaryMeetingDto r, 
        Database.Models.MultiDisciplinaryMeeting e)
    {
        e.PatientID_FK = r.PatientID_FK;
        e.IssuesOverall = r.IssuesOverall;
        e.Remarks = r.Remarks;
        e.AssignedToFollowUp = r.AssignedToFollowUp;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        var existingDetails = e.MultiDisciplinaryMeetingDetail
            .Where(d => !d.IsDeleted)
            .ToList();
        var incomingDetails = r.MultiDisciplinaryMeetingDetailList;
        foreach (var existing in existingDetails)
        {
            var match = incomingDetails.FirstOrDefault(x => x.IssueCatID == existing.IssueCatID);
            if (match != null)
            {
                existing.IssueTitle = match.IssueTitle;
                existing.IssueContent = match.IssueContent;
                existing.ModifiedBy_FK = r.UserId;
                existing.ModifiedDate = DateTime.Now;
            }
            else
            {
                existing.IsDeleted = true;
                existing.ModifiedBy_FK = r.UserId;
                existing.ModifiedDate = DateTime.Now;
            }
        }

        var existingCatIds = existingDetails.Select(d => d.IssueCatID).ToHashSet();
        var newItems = incomingDetails
            .Where(x => !existingCatIds.Contains(x.IssueCatID))
            .Select(x => new MultiDisciplinaryMeetingDetail
            {
                IssueCatID = x.IssueCatID,
                IssueTitle = x.IssueTitle,
                IssueContent = x.IssueContent,
                CreatedDate = DateTime.Now,
                CreatedBy_FK = r.UserId,
                IsDeleted = false
            });

        foreach (var newDetail in newItems)
        {
            e.MultiDisciplinaryMeetingDetail.Add(newDetail);
        }

        return e;
    }
}
