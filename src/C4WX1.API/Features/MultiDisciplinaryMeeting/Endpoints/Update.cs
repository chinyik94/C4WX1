using C4WX1.API.Features.MultiDisciplinaryMeeting.Dtos;
using C4WX1.API.Features.MultiDisciplinaryMeeting.Mappers;

namespace C4WX1.API.Features.MultiDisciplinaryMeeting.Endpoints;

public class UpdateMultiDisciplinaryMeetingSummary
    : C4WX1UpdateSummary<Database.Models.MultiDisciplinaryMeeting>
{

}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateMultiDisciplinaryMeetingDto, UpdateMultiDisciplinaryMeetingMapper>
{
    public override void Configure()
    {
        Put("multi-disciplinary-meeting/{id}");
        Summary(new UpdateMultiDisciplinaryMeetingSummary());
    }

    public override async Task HandleAsync(UpdateMultiDisciplinaryMeetingDto req, CancellationToken ct)
    {
        var entity = await dbContext.MultiDisciplinaryMeeting
            .Where(x => !x.IsDeleted
                && x.MultiDisciplinaryMeetingID == req.Id)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        entity = Map.UpdateEntity(req, entity);
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
