using C4WX1.API.Features.ProblemList.Dtos;
using C4WX1.API.Features.ProblemList.Extensions;
using C4WX1.API.Features.ProblemList.Mappers;
using C4WX1.API.Features.ProblemList.Repository;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.Features.Shared.Extensions;

namespace C4WX1.API.Features.ProblemList.Endpoints;

public class GetProblemListSummary
    : C4WX1GetListSummary<Database.Models.ProblemList>
{

}

public class GetList(
    THCC_C4WDEVContext dbContext,
    IProblemListRepository repository)
    : Endpoint<GetListDto, IEnumerable<ProblemListDto>, ProblemListMapper>
{
    public override void Configure()
    {
        Get("problem-list");
        Summary(new GetProblemListSummary());
    }

    public override async Task HandleAsync(GetListDto req, CancellationToken ct)
    {
        var (startRowIndex, pageSize) = req.GetPaginationDetails();
        var dtos = await dbContext.ProblemList
            .Include(x => x.ProblemListGoal)
            .Include(x => x.DiseaseID_FK)
            .Where(x => !x.IsDeleted)
            .Sort(req.OrderBy)
            .Skip(startRowIndex)
            .Take(pageSize)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);

        var problemListIds = dtos.Select(x => x.InterventionID).ToArray();
        var canDeleteDict = await repository.BatchCanDeleteAsync(problemListIds);
        foreach (var dto in dtos)
        {
            dto.CanDelete = canDeleteDict.TryGetValue(dto.InterventionID, out var canDelete)
                && canDelete;
        }
        await SendOkAsync(dtos, ct);
    }
}
