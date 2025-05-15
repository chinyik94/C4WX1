
namespace C4WX1.API.Features.NutritionTaskReference.Endpoints;

public class GetNutritionTaskReferenceCountSummary
    : C4WX1GetCountSummary<Database.Models.NutritionTaskReference>
{

}

public class GetCount(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<int>
{
    public override void Configure()
    {
        Get("nutrition-task-reference/count");
        Summary(new GetNutritionTaskReferenceCountSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var count = await dbContext.NutritionTaskReference
            .Where(x => !x.IsDeleted)
            .CountAsync(ct);
        await SendOkAsync(count, ct);
    }
}
