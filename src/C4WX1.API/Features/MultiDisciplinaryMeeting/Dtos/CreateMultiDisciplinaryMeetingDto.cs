using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.MultiDisciplinaryMeeting.Dtos;

public sealed class CreateMultiDisciplinaryMeetingDto : CreateDto
{
    public int PatientID_FK { get; set; }
    public string IssuesOverall { get; set; } = null!;
    public int AssignedToFollowUp { get; set; }
    public string Remarks { get; set; } = null!;
    public ICollection<MultiDisciplinaryMeetingDetailDto> MultiDisciplinaryMeetingDetailList { get; set; } = [];
}
