using C4WX1.API.Features.RecentView.Dtos;
using C4WX1.API.Features.RecentView.Mappers;

namespace C4WX1.API.Features.RecentView.Endpoints;

public class UpsertRecentViewSummary
    : C4WX1CreateSummary<Database.Models.RecentView>
{

}

public class Upsert(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpsertRecentViewDto, UpsertRecentViewMapper>
{
    public override void Configure()
    {
        Post("recent-view/upsert");
        Summary(new UpsertRecentViewSummary());
    }

    public override async Task HandleAsync(UpsertRecentViewDto req, CancellationToken ct)
    {
        var entity = await dbContext.RecentView
            .Where(x => x.UserID_FK == req.UserID
                && x.PatientID_FK == req.PatientID)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            entity = Map.ToEntity(req);
            await dbContext.RecentView.AddAsync(entity, ct);
        }

        entity.DateView = DateTime.Now;
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
