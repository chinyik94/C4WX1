using C4WX1.API.Features.MultiDisciplinaryMeeting.Dtos;
using C4WX1.API.Features.MultiDisciplinaryMeeting.Mappers;

namespace C4WX1.API.Features.MultiDisciplinaryMeeting.Endpoints;

public class CreateMultiDisciplinaryMeetingSummary
    : C4WX1CreateSummary<Database.Models.MultiDisciplinaryMeeting>
{

}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateMultiDisciplinaryMeetingDto, int, CreateMultiDisciplinaryMeetingMapper>
{
    public override void Configure()
    {
        Post("multi-disciplinary-meeting");
        Summary(new CreateMultiDisciplinaryMeetingSummary());
    }

    public override async Task HandleAsync(CreateMultiDisciplinaryMeetingDto req, CancellationToken ct)
    {
        var entity = Map.ToEntity(req);
        await dbContext.MultiDisciplinaryMeeting.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.MultiDisciplinaryMeetingID, ct);
    }
}
