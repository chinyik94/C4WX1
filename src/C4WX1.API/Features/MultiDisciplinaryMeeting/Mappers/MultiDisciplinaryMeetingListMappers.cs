using C4WX1.API.Features.MultiDisciplinaryMeeting.Dtos;

namespace C4WX1.API.Features.MultiDisciplinaryMeeting.Mappers;

public class MultiDisciplinaryMeetingListMappers
    : ResponseMapper<MultiDisciplinaryMeetingDto, Database.Models.MultiDisciplinaryMeeting>
{
    public override MultiDisciplinaryMeetingDto FromEntity(Database.Models.MultiDisciplinaryMeeting e)
        => new()
        {
            MultiDisciplinaryMeetingID = e.MultiDisciplinaryMeetingID,
            Title = "Multi Disciplinary Meeting on " + e.CreatedDate
        };
}
