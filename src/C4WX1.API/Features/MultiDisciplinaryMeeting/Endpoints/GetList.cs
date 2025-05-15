using C4WX1.API.Features.MultiDisciplinaryMeeting.Dtos;
using C4WX1.API.Features.MultiDisciplinaryMeeting.Mappers;
using C4WX1.API.Features.Shared.Extensions;

namespace C4WX1.API.Features.MultiDisciplinaryMeeting.Endpoints;

public class GetMultiDisciplinaryMeetingListSummary
    : C4WX1GetListSummary<Database.Models.MultiDisciplinaryMeeting>
{

}

public class GetList(THCC_C4WDEVContext dbContext)
    : Endpoint<GetMultiDisciplinaryMeetingListDto, IEnumerable<MultiDisciplinaryMeetingDto>, MultiDisciplinaryMeetingListMappers>
{
    public override void Configure()
    {
        Get("multi-disciplinary-meeting/list/patientId/{patientId}");
        Summary(new GetMultiDisciplinaryMeetingListSummary());
    }

    public override async Task HandleAsync(GetMultiDisciplinaryMeetingListDto req, CancellationToken ct)
    {
        var (startRowIndex, pageSize) = req.GetPaginationDetails();
        var dtos = await dbContext.MultiDisciplinaryMeeting
            .Where(x => !x.IsDeleted
                && x.PatientID_FK == req.PatientID)
            .OrderByDescending(x => x.CreatedDate)
            .Skip(startRowIndex)
            .Take(pageSize)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}