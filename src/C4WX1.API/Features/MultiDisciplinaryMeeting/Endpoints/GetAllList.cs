using C4WX1.API.Features.MultiDisciplinaryMeeting.Dtos;
using C4WX1.API.Features.MultiDisciplinaryMeeting.Mappers;

namespace C4WX1.API.Features.MultiDisciplinaryMeeting.Endpoints;

public class GetAllMultiDisciplinaryMeetingListSummary
    : C4WX1GetListSummary<Database.Models.MultiDisciplinaryMeeting>
{

}

public class GetAllList(THCC_C4WDEVContext dbContext)
    : Endpoint<GetAllMultiDisciplinaryMeetingListDto, IEnumerable<MultiDisciplinaryMeetingDto>, MultiDisciplinaryMeetingListMappers>
{
    public override void Configure()
    {
        Get("multi-disciplinary-meeting/all-list/patientId/{patientId}");
        Summary(new GetAllMultiDisciplinaryMeetingListSummary());
    }

    public override async Task HandleAsync(GetAllMultiDisciplinaryMeetingListDto req, CancellationToken ct)
    {
        var dtos = await dbContext.MultiDisciplinaryMeeting
            .Where(x => !x.IsDeleted
                && x.PatientID_FK == req.PatientID)
            .OrderByDescending(x => x.CreatedDate)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
