using C4WX1.API.Features.Branch.Dtos;
using C4WX1.API.Features.Branch.Mappers;
using C4WX1.API.Features.Branch.Repository;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Branch.Endpoints;

public class GetBranchByIdSummary 
    : C4WX1GetByIdSummary<Database.Models.Branch>
{
    public GetBranchByIdSummary() { }
}

public class GetById(
    THCC_C4WDEVContext dbContext,
    IBranchRepository repository)
    : Endpoint<GetByIdDto, BranchDto, BranchMapper>
{
    public override void Configure()
    {
        Get("branch/{id}");
        Description(b => b.Produces(404));
        Summary(new GetBranchByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.Branch
            .Include(x => x.CurrencyID_FKNavigation)
            .Include(x => x.UserBranch)
                .ThenInclude(x => x.UserID_FKNavigation)
            .Where(x => !x.IsDeleted && x.BranchID == req.Id)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        if (dto == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        dto.CanDelete = await repository.CanDeleteAsync(req.Id);
        await SendOkAsync(dto, cancellation: ct);
    }
}
