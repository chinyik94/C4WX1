using C4WX1.API.Features.CPGoals.Dtos;
using C4WX1.API.Features.CPGoals.Extensions;
using C4WX1.API.Features.CPGoals.Mappers;
using C4WX1.API.Features.CPGoals.Repository;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.Features.Shared.Extensions;

namespace C4WX1.API.Features.CPGoals.Endpoints;

public class GetCPGoalsListSummary 
    : C4WX1GetListSummary<Database.Models.CPGoals>
{
    public GetCPGoalsListSummary() { }
}

public class GetList(
    THCC_C4WDEVContext dbContext,
    ICPGoalsRepository repository)
    : Endpoint<GetListDto, IEnumerable<CPGoalsDto>, CPGoalsMapper>
{
    public override void Configure()
    {
        Get("cp-goals");
        Summary(new GetCPGoalsListSummary());
    }

    public override async Task HandleAsync(GetListDto req, CancellationToken ct)
    {
        var (startRowIndex, pageSize) = req.GetPaginationDetails();
        var dtos = await dbContext.CPGoals
            .Include(x => x.DiseaseID_FKNavigation)
                .ThenInclude(x => x.SystemID_FKNavigation)
            .Where(x => !x.IsDeleted)
            .Sort(req.OrderBy)
            .Skip(startRowIndex)
            .Take(pageSize)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);

        if (dtos.Count <= 0)
        {
            await SendOkAsync(dtos, cancellation: ct);
            return;
        }

        var activityIds = dtos.Select(x => x.CPGoalsID).ToArray();
        var canDeleteDict = await repository.BatchCanDeleteAsync(activityIds);
        foreach (var dto in dtos)
        {
            dto.CanDelete = canDeleteDict.TryGetValue(dto.CPGoalsID, out var canDelete)
                && canDelete;
        }

        await SendAsync(dtos, cancellation: ct);
    }
}
