using C4WX1.API.Features.Branch.Dtos;
using C4WX1.API.Features.Branch.Mappers;
using C4WX1.API.Features.Branch.Repository;
using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.Branch.Endpoints;

public class GetBranchListForControlSummary : EndpointSummary
{
    public GetBranchListForControlSummary()
    {
        Summary = "Get Branch List for Control";
        Description = "Get sorted Branch List for Control";
        Responses[200] = "Branch List retrieved successfully";
    }
}

public class GetListForControl(
    THCC_C4WDEVContext dbContext,
    IBranchRepository repository)
    : EndpointWithoutRequest<IEnumerable<BranchDto>, BranchMapper>
{
    public override void Configure()
    {
        Get("branch/for-control");
        Summary(new GetBranchListForControlSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var dtos = await dbContext.Branch
            .Where(x => !x.IsDeleted)
            .OrderBy(x => x.IsSystemUsed)
            .ThenBy(x => x.BranchName)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        var branchIds = dtos.Select(x => x.BranchID).ToArray();
        var canDeleteDict = await repository.BatchCanDeleteBranchAsync(branchIds);
        foreach (var dto in dtos)
        {
            dto.CanDelete = canDeleteDict.TryGetValue(dto.BranchID, out var canDelete)
                && canDelete;
        }

        await SendOkAsync(dtos, cancellation: ct);
    }
}
