using C4WX1.API.Features.Branch.Dtos;
using C4WX1.API.Features.Branch.Extensions;
using C4WX1.API.Features.Branch.Mappers;
using C4WX1.API.Features.Branch.Repository;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Branch.Endpoints;

public class GetBranchListSummary 
    : C4WX1GetListSummary<Database.Models.Branch>
{
    public GetBranchListSummary() { }
}

public class GetList(
    THCC_C4WDEVContext dbContext,
    IBranchRepository repository)
    : Endpoint<GetListDto, IEnumerable<BranchDto>, BranchMapper>
{
    public override void Configure()
    {
        Get("branch");
        Summary(new GetBranchListSummary());
    }

    public override async Task HandleAsync(GetListDto req, CancellationToken ct)
    {
        var dtos = await dbContext.Branch
            .Include(x => x.CurrencyID_FKNavigation)
            .Include(x => x.UserBranch)
                .ThenInclude(x => x.UserID_FKNavigation)
            .Where(x => !x.IsDeleted)
            .Sort(req.OrderBy)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        var branchIds = dtos.Select(x => x.BranchID).ToArray();
        var canDeleteDict = await repository.BatchCanDeleteAsync(branchIds);
        foreach (var dto in dtos)
        {
            dto.CanDelete = canDeleteDict.TryGetValue(dto.BranchID, out var canDelete)
                && canDelete;
        }

        await SendOkAsync(dtos, cancellation: ct);
    }
}
