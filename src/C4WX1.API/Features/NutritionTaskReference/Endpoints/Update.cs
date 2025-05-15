using C4WX1.API.Features.NutritionTaskReference.Dtos;
using C4WX1.API.Features.NutritionTaskReference.Mappers;

namespace C4WX1.API.Features.NutritionTaskReference.Endpoints;

public class UpdateNutritionTaskReferenceSummary
    : C4WX1UpdateSummary<Database.Models.NutritionTaskReference>
{

}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateNutritionTaskReferenceDto, UpdateNutritionTaskReferenceMapper>
{
    public override void Configure()
    {
        Put("nutrition-task-reference/{id}");
        Summary(new UpdateNutritionTaskReferenceSummary());
    }

    public override async Task HandleAsync(UpdateNutritionTaskReferenceDto req, CancellationToken ct)
    {
        var entity = await dbContext.NutritionTaskReference
            .Include(x => x.CodeId_FKNavigation)
            .Where(x => x.ReferenceID == req.Id
                && !x.IsDeleted)
            .FirstOrDefaultAsync(ct);
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
