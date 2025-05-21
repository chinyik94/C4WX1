using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.ProblemList.Endpoints;

public class DeleteProblemListSummary
    : C4WX1DeleteSummary<Database.Models.ProblemList>
{

}

public class Delete(THCC_C4WDEVContext dbContext)
    : Endpoint<DeleteByIdDto>
{
    public override void Configure()
    {
        Delete("problem-list/{id}");
        Summary(new DeleteProblemListSummary());
    }

    public override async Task HandleAsync(DeleteByIdDto req, CancellationToken ct)
    {
        var entity = await dbContext.ProblemList
            .Where(x => !x.IsDeleted
                && x.ProblemListID == req.Id)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        entity.IsDeleted = true;
        entity.ModifiedBy_FK = req.UserId;
        entity.ModifiedDate = DateTime.Now;
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
