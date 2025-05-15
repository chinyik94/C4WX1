namespace C4WX1.API.Features.MultiDisciplinaryMeeting.Dtos;

public sealed class MultiDisciplinaryMeetingDetailDto
{
    public int IssueCatID { get; set; }
    public string IssueTitle { get; set; } = null!;
    public string IssueContent { get; set; } = null!;
    public int AP { get; set; }
}
