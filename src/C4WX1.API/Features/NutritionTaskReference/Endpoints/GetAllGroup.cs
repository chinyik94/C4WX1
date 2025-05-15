using C4WX1.API.Features.NutritionTaskReference.Dtos;
using C4WX1.API.Features.NutritionTaskReference.Mappers;
using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.API.Features.NutritionTaskReference.Endpoints;

public class GetAllNutritionTaskReferenceGroupSummary
    : C4WX1GetListSummary<Database.Models.NutritionTaskReference>
{

}

public class GetAllGroup(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<IEnumerable<NutritionTaskReferenceGroupDto>, NutritionTaskReferenceGroupMapper>
{
    private readonly int[] supportedCodeTypeIds = [
        CodetableTypeKeys.StoolOutputAmount,
        CodetableTypeKeys.StoolOutputType,
        CodetableTypeKeys.LiquidOutputAmount,
        CodetableTypeKeys.LiquidOutputColor
        ]; 

    public override void Configure()
    {
        Get("nutrition-task-reference/group/all");
        Summary(new GetAllNutritionTaskReferenceGroupSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var dtos = await dbContext.CodeType
            .Where(x => !x.IsDeleted
                && supportedCodeTypeIds.Contains(x.CodeTypeId))
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
