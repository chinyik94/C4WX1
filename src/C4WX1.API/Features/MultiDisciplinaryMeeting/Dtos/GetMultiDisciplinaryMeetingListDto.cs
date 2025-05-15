using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.MultiDisciplinaryMeeting.Dtos;

public sealed class GetMultiDisciplinaryMeetingListDto : GetListDto
{
    public int PatientID { get; set; }
}
