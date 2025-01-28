using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.Activity.Update
{
    public class UpdateActivityDto
    {
        public int ActivityID { get; set; }
        public int ProblemListID_FK { get; set; }
        public int DiseaseID_FK { get; set; }
        public string ActivityDetail { get; set; } = string.Empty;
        public int? DiseaseSubInfoID_FK { get; set; }
        public int UserId { get; set; }
    }

    public class UpdateActivitySummary : EndpointSummary
    {
        public UpdateActivitySummary()
        {
            Summary = $"Update {nameof(Activity)}";
            Description = $"Update an existing {nameof(Activity)}";
            ExampleRequest = new UpdateActivityDto
            {
                ActivityID = 1,
                ProblemListID_FK = 1,
                DiseaseID_FK = 1,
                ActivityDetail = "Activity Detail",
                DiseaseSubInfoID_FK = 1,
                UserId = 1
            };
            Responses[204] = $"{nameof(Activity)} updated successfully";
            Responses[404] = $"{nameof(Activity)} not found";
        }
    }

    public class Update(
        THCC_C4WDEVContext dbContext): Endpoint<UpdateActivityDto>
    {
        public override void Configure()
        {
            Put("activity");
            Description(b => b
                .Accepts<UpdateActivityDto>("application/json")
                .Produces(204)
                .Produces(404)
                .ProducesProblemFE<InternalErrorResponse>(500));
            Summary(new UpdateActivitySummary());
        }

        public override async System.Threading.Tasks.Task HandleAsync(UpdateActivityDto req, CancellationToken ct)
        {
            var entity = await dbContext.Activity
                .FirstOrDefaultAsync(a => a.ActivityID == req.ActivityID && !a.IsDeleted, ct);
            if (entity == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            entity.ActivityDetail = req.ActivityDetail;
            entity.DiseaseID_FK = req.DiseaseID_FK;
            entity.DiseaseSubInfoID_FK = req.DiseaseSubInfoID_FK;
            entity.ProblemListID_FK = req.ProblemListID_FK;
            entity.ModifiedBy_FK = req.UserId;
            entity.ModifiedDate = DateTime.Now;
            await dbContext.SaveChangesAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
