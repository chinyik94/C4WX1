using C4WX1.API.Features.Activity.Dtos;
using C4WX1.API.Features.Activity.Extensions;
using C4WX1.API.Features.Activity.Mappers;
using C4WX1.API.Features.Activity.Repository;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.Features.Shared.Extensions;

namespace C4WX1.API.Features.Activity.Endpoints;

public class GetActivityListSummary 
    : C4WX1GetListSummary<Database.Models.Activity>
{
    public GetActivityListSummary() { }
}

public class GetList(
    THCC_C4WDEVContext dbContext,
    IActivityRepository repository)
    : Endpoint<GetListDto, IEnumerable<ActivityDto>, ActivityMapper>
{
    public override void Configure()
    {
        Get("activity");
        Summary(new GetActivityListSummary());
    }

    public override async Task HandleAsync(GetListDto req, CancellationToken ct)
    {
        var (startRowIndex, pageSize) = req.GetPaginationDetails();
        var dtos = await dbContext.Activity
            .Include(x => x.ProblemListID_FKNavigation)
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

        var activityIds = dtos.Select(x => x.ActivityID).ToArray();
        var canDeleteDict = await repository.BatchCanDeleteAsync(activityIds);
        foreach (var dto in dtos)
        {
            dto.CanDelete = canDeleteDict.TryGetValue(dto.ActivityID, out var canDelete)
                && canDelete;
        }

        await SendAsync(dtos, cancellation: ct);
    }
}
