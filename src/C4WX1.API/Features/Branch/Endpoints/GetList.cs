using C4WX1.API.Features.Branch.Dtos;
using C4WX1.API.Features.Branch.Extensions;
using C4WX1.API.Features.Branch.Mappers;
using C4WX1.API.Features.Branch.Repository;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.Branch.Endpoints;

public class GetBranchListSummary : EndpointSummary
{
    public GetBranchListSummary()
    {
        Summary = "Get Branch List";
        Description = "Get a paged and sorted Branch List";
        Responses[200] = "Branch List retrieved successfully";
    }
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
            .Where(x => !x.IsDeleted)
            .Sort(req.OrderBy)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        var branchIds = dtos.Select(x => x.BranchID);
        var canDeleteDict = await repository.BatchCanDeleteBranchAsync(branchIds);
        foreach (var dto in dtos)
        {
            dto.CanDelete = canDeleteDict.TryGetValue(dto.BranchID, out var canDelete)
                && canDelete;
        }

        await SendOkAsync(dtos, cancellation: ct);
    }
}
