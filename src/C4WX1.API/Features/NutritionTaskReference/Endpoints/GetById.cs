using C4WX1.API.Features.NutritionTaskReference.Dtos;
using C4WX1.API.Features.NutritionTaskReference.Mappers;
using C4WX1.API.Features.NutritionTaskReference.Repository;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.NutritionTaskReference.Endpoints;

public class GetNutritionTaskReferenceByIdSummary
    : C4WX1GetByIdSummary<Database.Models.NutritionTaskReference>
{

}

public class GetById(
    THCC_C4WDEVContext dbContext,
    INutritionTaskReferenceRepository repository)
    : Endpoint<GetByIdDto, NutritionTaskReferenceDto, NutritionTaskReferenceMapper>
{
    public override void Configure()
    {
        Get("nutrition-task-reference/{id}");
        Summary(new GetNutritionTaskReferenceByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.NutritionTaskReference
            .Include(x => x.CodeId_FKNavigation)
                .ThenInclude(x => x.CodeTypeId_FKNavigation)
            .Where(x => !x.IsDeleted
                && x.ReferenceID == req.Id)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        if (dto == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        dto.CanDelete = await repository.CanDeleteAsync(req.Id);
        await SendOkAsync(dto, ct);
    }
}
