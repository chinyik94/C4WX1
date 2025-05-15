using C4WX1.API.Features.MultiDisciplinaryMeeting.Dtos;
using C4WX1.API.Features.MultiDisciplinaryMeeting.Mappers;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.MultiDisciplinaryMeeting.Endpoints;

public class GetMultiDisciplinaryMeetingByIdSummary
    : C4WX1GetListSummary<Database.Models.MultiDisciplinaryMeeting>
{

}

public class GetById(THCC_C4WDEVContext dbContext)
    : Endpoint<GetByIdDto, MultiDisciplinaryMeetingDto, MultiDisciplinaryMeetingMappers>
{
    public override void Configure()
    {
        Get("multi-disciplinary-meeting/{id}");
        Summary(new GetMultiDisciplinaryMeetingByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.MultiDisciplinaryMeeting
            .Include(x => x.MultiDisciplinaryMeetingDetail)
            .Where(x => !x.IsDeleted
                && x.MultiDisciplinaryMeetingID == req.Id)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        await ((dto == null)
            ? SendNotFoundAsync(ct)
            : SendOkAsync(dto, ct));
    }
}
