using C4WX1.API.Features.NutritionTaskReference.Dtos;
using C4WX1.API.Features.NutritionTaskReference.Mappers;

namespace C4WX1.API.Features.NutritionTaskReference.Endpoints;

public class GetNutritionTaskReferenceByGroupIdSummary
    : C4WX1GetByIdSummary<Database.Models.NutritionTaskReference>
{

}

public class GetByGroupId(THCC_C4WDEVContext dbContext)
    : Endpoint<GetNutritionTaskReferenceByGroupIdDto, NutritionTaskReferenceGroupDto, NutritionTaskReferenceGroupMapper>
{
    public override void Configure()
    {
        Get("nutrition-task-reference/group/{groupId}");
        Summary(new GetNutritionTaskReferenceByGroupIdSummary());
    }

    public override async Task HandleAsync(GetNutritionTaskReferenceByGroupIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.CodeType
            .Where(x => !x.IsDeleted
                && x.CodeTypeId == req.GroupId)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        await ((dto == null)
            ? SendNotFoundAsync(ct)
            : SendOkAsync(dto, ct));
    }
}
