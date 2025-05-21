using C4WX1.API.Features.ProblemList.Dtos;
using C4WX1.API.Features.ProblemList.Mappers;

namespace C4WX1.API.Features.ProblemList.Endpoints;

public class GetAllProblemListSummary
    : C4WX1GetListSummary<Database.Models.ProblemList>
{

}

public class GetAllList(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<IEnumerable<ProblemListDto>, ProblemListMapper>
{
    public override void Configure()
    {
        Get("problem-list/all");
        Summary(new GetAllProblemListSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var dtos = await dbContext.ProblemList
            .Include(x => x.ProblemListGoal)
            .Include(x => x.DiseaseID_FKNavigation)
            .Where(x => !x.IsDeleted)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos);
    }
}
