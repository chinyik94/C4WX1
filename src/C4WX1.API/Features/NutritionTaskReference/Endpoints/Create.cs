using C4WX1.API.Features.NutritionTaskReference.Dtos;
using C4WX1.API.Features.NutritionTaskReference.Mappers;

namespace C4WX1.API.Features.NutritionTaskReference.Endpoints;

public class CreateNutritionTaskReferenceSummary
    : C4WX1CreateSummary<Database.Models.NutritionTaskReference>
{

}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateNutritionTaskReferenceDto, int, CreateNutritionTaskReferenceMapper>
{
    public override void Configure()
    {
        Post("nutrition-task-reference");
        Summary(new CreateNutritionTaskReferenceSummary());
    }

    public override async Task HandleAsync(CreateNutritionTaskReferenceDto req, CancellationToken ct)
    {
        var entity = Map.ToEntity(req);
        var codeCount = await dbContext.Code
            .Where(x => x.CodeTypeId_FK == req.GroupID_FK)
            .CountAsync(ct);
        entity.CodeId_FKNavigation.Ordering = codeCount;
        await dbContext.NutritionTaskReference.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.ReferenceID, ct);
    }
}
