using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.NutritionTaskReference.Endpoints;

public class DeleteNutritionTaskReferenceSummary
    : C4WX1DeleteSummary<Database.Models.NutritionTaskReference>
{

}

public class Delete(THCC_C4WDEVContext dbContext)
    : Endpoint<DeleteByIdDto>
{
    public override void Configure()
    {
        Delete("nutrition-task-reference/{id}");
        Summary(new DeleteNutritionTaskReferenceSummary());
    }

    public override async Task HandleAsync(DeleteByIdDto req, CancellationToken ct)
    {
        var entity = await dbContext.NutritionTaskReference
            .Include(x => x.CodeId_FKNavigation)
            .Where(x => !x.IsDeleted
                && x.ReferenceID == req.Id)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        entity.IsDeleted = true;
        entity.ModifiedBy_FK = req.UserId;
        entity.ModifiedDate = DateTime.Now;
        entity.CodeId_FKNavigation.IsDeleted = true;
        entity.CodeId_FKNavigation.ModifiedBy_FK = req.UserId;
        entity.CodeId_FKNavigation.ModifiedDate = DateTime.Now;
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
