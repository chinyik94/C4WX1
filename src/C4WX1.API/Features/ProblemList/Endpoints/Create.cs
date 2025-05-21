using C4WX1.API.Features.ProblemList.Dtos;
using C4WX1.API.Features.ProblemList.Mappers;

namespace C4WX1.API.Features.ProblemList.Endpoints;

public class CreateProblemListSummary
    : C4WX1CreateSummary<Database.Models.ProblemList>
{

}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateProblemListDto, int, CreateProblemListMapper>
{
    public override void Configure()
    {
        Post("problem-list");
        Summary(new CreateProblemListSummary());
    }

    public override async Task HandleAsync(CreateProblemListDto req, CancellationToken ct)
    {
        var entity = Map.ToEntity(req);
        await dbContext.ProblemList.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.ProblemListID, ct);
    }
}
