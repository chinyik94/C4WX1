using C4WX1.API.Features.Activity.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.Activity.Delete
{
    public class DeleteActivitySummary : EndpointSummary
    {
        public DeleteActivitySummary()
        {
            Summary = "Delete Activity";
            Description = "Delete an existing Activity";
            ExampleRequest = new DeleteActivityDto
            {
                ActivityID = 1,
                UserID = 1
            };
            Responses[204] = "Activity deleted successfully";
            Responses[404] = "Activity not found";
        }
    }

    public class Delete(
        THCC_C4WDEVContext dbContext): Endpoint<DeleteActivityDto>
    {
        public override void Configure()
        {
            Delete("activity");
            AllowAnonymous();
            Description(b => b
                .Accepts<DeleteActivityDto>("application/json")
                .Produces(204)
                .Produces(404)
                .ProducesProblemFE<InternalErrorResponse>(500));
            Summary(new DeleteActivitySummary());
        }

        public override async Task HandleAsync(DeleteActivityDto req, CancellationToken ct)
        {
            var entity = await dbContext.Activity
                .FirstOrDefaultAsync(a => a.ActivityID == req.ActivityID && !a.IsDeleted, ct);
            if (entity == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            entity.IsDeleted = true;
            entity.ModifiedBy_FK = req.UserID;
            entity.ModifiedDate = DateTime.Now;
            await dbContext.SaveChangesAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
