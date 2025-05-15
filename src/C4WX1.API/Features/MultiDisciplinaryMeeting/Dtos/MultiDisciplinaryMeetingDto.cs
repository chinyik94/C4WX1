namespace C4WX1.API.Features.MultiDisciplinaryMeeting.Dtos;

public sealed class MultiDisciplinaryMeetingDto
{
    public int MultiDisciplinaryMeetingID { get; set; }
    public string IssuesOverall { get; set; } = null!;
    public int AssignedToFollowUp { get; set; }
    public string Remarks { get; set; } = null!;
    public string? Title { get; set; }
    public ICollection<MultiDisciplinaryMeetingDetailDto> MultiDisciplinaryMeetingDetailList { get; set; } = [];
}
