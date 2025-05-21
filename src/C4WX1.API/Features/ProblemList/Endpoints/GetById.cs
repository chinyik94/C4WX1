using C4WX1.API.Features.ProblemList.Dtos;
using C4WX1.API.Features.ProblemList.Mappers;
using C4WX1.API.Features.ProblemList.Repository;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.ProblemList.Endpoints;

public class GetProblemListByIdSummary
    : C4WX1GetByIdSummary<Database.Models.ProblemList>
{

}

public class GetById(
    THCC_C4WDEVContext dbContext,
    IProblemListRepository repository)
    : Endpoint<GetByIdDto, ProblemListDto, ProblemListMapper>
{
    public override void Configure()
    {
        Get("problem-list/{id}");
        Summary(new GetProblemListByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.ProblemList
            .Include(x => x.ProblemListGoal)
            .Include(x => x.DiseaseID_FKNavigation)
            .Where(x => !x.IsDeleted
                && x.ProblemListID == req.Id)
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
