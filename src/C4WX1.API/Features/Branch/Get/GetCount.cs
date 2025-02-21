using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.Branch.Get
{
    public class GetBranchCountSummary : EndpointSummary
    {
        public GetBranchCountSummary()
        {
            Summary = "Get Branch Count";
            Description = "Get number of Branch";
            Responses[200] = "Branch Count retrieved successfully";
        }
    }

    public class GetCount(THCC_C4WDEVContext dbContext)
        : EndpointWithoutRequest<int>
    {
        public override void Configure()
        {
            Get("branch/count");
            Summary(new GetBranchCountSummary());
            Description(b => b
                .Produces<int>()
                .ProducesProblemFE<InternalErrorResponse>(500));
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var count = await dbContext.Branch
                .CountAsync(x => !x.IsDeleted, ct);

            await SendOkAsync(count, cancellation: ct);
        }
    }
}
