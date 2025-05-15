using C4WX1.API.Features.MultiDisciplinaryMeeting.Dtos;

namespace C4WX1.API.Features.MultiDisciplinaryMeeting.Endpoints;

public class GetMultiDisciplinaryMeetingCountSummary
    : C4WX1GetCountSummary<Database.Models.MultiDisciplinaryMeeting>
{

}

public class GetCount(THCC_C4WDEVContext dbContext)
    : Endpoint<GetMultiDisciplinaryMeetingCountDto, int>
{
    public override void Configure()
    {
        Get("multi-disciplinary-meeting/count/{patientId}");
        Summary(new GetMultiDisciplinaryMeetingCountSummary());
    }

    public override async Task HandleAsync(GetMultiDisciplinaryMeetingCountDto req, CancellationToken ct)
    {
        var count = await dbContext.MultiDisciplinaryMeeting
            .Where(x => !x.IsDeleted
                && x.PatientID_FK == req.PatientID)
            .CountAsync(ct);
        await SendOkAsync(count, ct);
    }
}
