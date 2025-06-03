using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.Features.Skillset.Repository;

namespace C4WX1.API.Features.Skillset.Endpoints;

public class DeleteSkillsetSumamry
    : C4WX1DeleteSummary<Database.Models.Code>
{

}

public class Delete(
    THCC_C4WDEVContext dbContext,
    ISkillsetRepository repository)
    : Endpoint<DeleteByIdDto>
{
    public override void Configure()
    {
        Delete("skillset/{id}");
        Summary(new DeleteSkillsetSumamry());
    }

    public override async Task HandleAsync(DeleteByIdDto req, CancellationToken ct)
    {
        var entity = await dbContext.Code
            .Where(x => !x.IsDeleted
                && x.CodeId == req.Id)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        var canDelete = await repository.CanDeleteAsync(entity.CodeId);
        if (!canDelete)
        {
            ThrowError("UNABLE_DELETE");
            return;
        }
        entity.IsDeleted = true;
        entity.ModifiedBy_FK = req.UserId;
        entity.ModifiedDate = DateTime.Now;
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
