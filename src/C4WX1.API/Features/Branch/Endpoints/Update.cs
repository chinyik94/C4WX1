using C4WX1.API.Features.Branch.Dtos;
using C4WX1.API.Features.Branch.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.Branch.Endpoints;

public class UpdateBranchSummary : EndpointSummary
{
    public UpdateBranchSummary()
    {
        Summary = "Update Branch";
        Description = "Update an existing Branch by its ID";
        ExampleRequest = new UpdateBranchDto
        {
            BranchID = 1,
            BranchName = "BranchName",
            Address1 = "Address1",
            Address2 = "Address2",
            Address3 = "Address3",
            Contact = "Contact",
            Email = "test@test.com",
            Status = "Active",
            CurrencyID_FK = 1,
            UserId = 1,
            UserDataList = [
                new BranchUserDto { UserId = 1}
                ]
        };
        Responses[204] = "Branch updated successfully";
        Responses[400] = "Branch data invalid";
        Responses[404] = "Branch not found";
    }
}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateBranchDto, UpdateBranchMapper>
{
    public override void Configure()
    {
        Put("branch/{branchID}");
        Description(b => b
            .ProducesProblemFE(400)
            .Produces(404));
        Summary(new UpdateBranchSummary());
    }

    public override async Task HandleAsync(UpdateBranchDto req, CancellationToken ct)
    {
        var hasDuplicate = await dbContext.Branch
            .Include(x => x.UserBranch)
            .AnyAsync(x => !x.IsDeleted
                && x.BranchName == req.BranchName
                && x.BranchID != req.BranchID,
                ct);
        if (hasDuplicate)
        {
            ThrowError("DUPLICATE_NAME");
            return;
        }

        var entity = await dbContext.Branch
            .FirstOrDefaultAsync(x => !x.IsDeleted
                && x.BranchID == req.BranchID,
                ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        entity = Map.UpdateEntity(req, entity);

        var existingUsers = entity.UserBranch.Select(x => x.UserID_FK).ToHashSet();
        var incomingUsers = req.UserDataList.Select(x => x.UserId).ToHashSet();
        var validUsers = (await dbContext.Users
            .Where(x => !x.IsDeleted && incomingUsers.Contains(x.UserId))
            .Select(x => x.UserId)
            .ToListAsync(ct))
            .ToHashSet();

        var usersToAdd = validUsers
            .Except(existingUsers)
            .Select(userId => new UserBranch
            {
                UserID_FK = userId,
                BranchID_FK = entity.BranchID
            });
        var usersToRemove = entity.UserBranch
            .Where(x => !incomingUsers.Contains(x.UserID_FK));

        dbContext.UserBranch.RemoveRange(usersToRemove);
        foreach (var item in usersToAdd)
        {
            entity.UserBranch.Add(item);
        }
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(ct);
    }
}
