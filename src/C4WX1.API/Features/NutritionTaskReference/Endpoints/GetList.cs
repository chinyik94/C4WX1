using C4WX1.API.Features.NutritionTaskReference.Dtos;
using C4WX1.API.Features.NutritionTaskReference.Extensions;
using C4WX1.API.Features.NutritionTaskReference.Mappers;
using C4WX1.API.Features.NutritionTaskReference.Repository;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.Features.Shared.Extensions;

namespace C4WX1.API.Features.NutritionTaskReference.Endpoints;

public class GetNutritionTaskReferenceListSummary
    : C4WX1GetListSummary<Database.Models.NutritionTaskReference>
{

}

public class GetList(
    THCC_C4WDEVContext dbContext,
    INutritionTaskReferenceRepository repository)
    : Endpoint<GetListDto, IEnumerable<NutritionTaskReferenceDto>, NutritionTaskReferenceMapper>
{
    public override void Configure()
    {
        Get("nutrition-task-reference");
        Summary(new GetNutritionTaskReferenceListSummary());
    }

    public override async Task HandleAsync(GetListDto req, CancellationToken ct)
    {
        var (startRowIndex, pageSize) = req.GetPaginationDetails();
        var dtos = await dbContext.NutritionTaskReference
            .Include(x => x.CodeId_FKNavigation)
                .ThenInclude(x => x.CodeTypeId_FKNavigation)
            .Where(x => !x.IsDeleted)
            .Sort(req.OrderBy)
            .Skip(startRowIndex)
            .Take(pageSize)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        if (dtos.Count == 0)
        {
            await SendOkAsync(dtos, ct);
            return;
        }

        var interventionIds = dtos.Select(x => x.ReferenceID).ToArray();
        var canDeleteDict = await repository.BatchCanDeleteAsync(interventionIds);
        foreach (var dto in dtos)
        {
            dto.CanDelete = canDeleteDict.TryGetValue(dto.ReferenceID, out var canDelete)
                && canDelete;
        }
        await SendOkAsync(dtos, ct);

    }
}
