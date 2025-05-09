using C4WX1.API.Features.Activity.Dtos;
using C4WX1.API.Features.Activity.Mappers;

namespace C4WX1.API.Features.Activity.Endpoints;

public class UpdateActivitySummary 
    : C4WX1UpdateSummary<Database.Models.Activity>
{
    public UpdateActivitySummary() : base()
    {
        ExampleRequest = new UpdateActivityDto
        {
            Id = 1,
            ProblemListID_FK = 1,
            DiseaseID_FK = 1,
            ActivityDetail = "Activity Detail",
            DiseaseSubInfoID_FK = 1,
            UserId = 1
        };
    }
}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateActivityDto, UpdateActivityMapper>
{
    public override void Configure()
    {
        Put("activity/{id}");
        Description(b => b.Produces(404));
        Summary(new UpdateActivitySummary());
    }

    public override async Task HandleAsync(UpdateActivityDto req, CancellationToken ct)
    {
        var entity = await dbContext.Activity
            .FirstOrDefaultAsync(a => a.ActivityID == req.Id && !a.IsDeleted, ct);
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
