using C4WX1.API.Features.MultiDisciplinaryMeeting.Dtos;

namespace C4WX1.Tests.MultiDisciplinaryMeeting;

public class MultiDisciplinaryMeetingFaker
{
    public static CreateMultiDisciplinaryMeetingDto CreateDto => new()
    {
        PatientID_FK = 1,
        IssuesOverall = "control-IssuesOverall",
        AssignedToFollowUp = 1,
        Remarks = "control-Remarks",
        UserId = 1,
        MultiDisciplinaryMeetingDetailList = [
            CreateDetailDto
            ]
    };

    public static MultiDisciplinaryMeetingDetailDto CreateDetailDto => new()
    {
        IssueCatID = 1,
        IssueContent = "control-IssueContent",
        IssueTitle = "control-IssueTitle",
        AP = 1
    };

    public static CreateMultiDisciplinaryMeetingDto CreateDummy => new()
    {
        PatientID_FK = 1,
        IssuesOverall = C4WX1Faker.ShortString,
        AssignedToFollowUp = C4WX1Faker.Id,
        Remarks = C4WX1Faker.ShortString,
        UserId = 1
    };

    public static UpdateMultiDisciplinaryMeetingDto UpdateDto(int? id = null) => new()
    {
        Id = id ?? C4WX1Faker.Id,
        PatientID_FK = 1,
        IssuesOverall = "updated-control-IssuesOverall",
        AssignedToFollowUp = 1,
        Remarks = "updated-control-Remarks",
        UserId = 1,
        MultiDisciplinaryMeetingDetailList = [
            CreateDetailDto
            ]
    };
}
