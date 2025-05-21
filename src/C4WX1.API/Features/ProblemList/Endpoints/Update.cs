using C4WX1.API.Features.ProblemList.Dtos;
using C4WX1.API.Features.ProblemList.Mappers;

namespace C4WX1.API.Features.ProblemList.Endpoints;

public class UpdateProblemListSummary
    : C4WX1UpdateSummary<Database.Models.ProblemList>
{

}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateProblemListDto, UpdateProblemListMapper>
{
    public override void Configure()
    {
        Put("problem-list/{id}");
        Summary(new UpdateProblemListSummary());
    }

    public override async Task HandleAsync(UpdateProblemListDto req, CancellationToken ct)
    {
        var entity = await dbContext.ProblemList
            .Include(x => x.ProblemListGoal)
            .Where(x => x.ProblemListID == req.Id)
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
