using C4WX1.API.Features.Activity.Repository;
using C4WX1.API.Features.Branch.Dtos;
using C4WX1.API.Features.Branch.Mappers;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.Branch.Get;

public class GetBranchByIdSummary : EndpointSummary
{
    public GetBranchByIdSummary()
    {
        Summary = "Get Branch";
        Description = "Get Branch by its ID";
        Responses[200] = "Branch retrieved successfully";
        Responses[404] = "Branch not found";
    }
}

public class GetById(
    THCC_C4WDEVContext dbContext,
    IActivityRepository repository)
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
