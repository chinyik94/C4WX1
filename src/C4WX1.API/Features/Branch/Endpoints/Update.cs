using C4WX1.API.Features.Branch.Dtos;
using C4WX1.API.Features.Branch.Mappers;

namespace C4WX1.API.Features.Branch.Endpoints;

public class UpdateBranchSummary 
    : C4WX1UpdateSummary<Database.Models.Branch>
{
    public UpdateBranchSummary() : base()
    {
        ExampleRequest = new UpdateBranchDto
        {
            Id = 1,
            BranchName = "BranchName",
            Address1 = "Address1",
            Address2 = "Address2",
            Address3 = "Address3",
            Contact = "Contact",
            Email = "test@test.com",
            Status = "Active",
            CurrencyID_FK = 1,
            UserId = 1,
            UserDataList = [1, 2, 3]
        };
        Responses[400] = "Branch data invalid";
    }
}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateBranchDto, UpdateBranchMapper>
{
    public override void Configure()
    {
        Put("branch/{id}");
        Description(b => b
            .ProducesProblemFE(400)
            .Produces(404));
        Summary(new UpdateBranchSummary());
    }

    public override async Task HandleAsync(UpdateBranchDto req, CancellationToken ct)
    {
        var hasDuplicate = await dbContext.Branch
            .AnyAsync(x => !x.IsDeleted
                && x.BranchName == req.BranchName
                && x.BranchID != req.Id,
                ct);
        if (hasDuplicate)
        {
            ThrowError("DUPLICATE_NAME");
            return;
        }

        var entity = await dbContext.Branch
            .Include(x => x.UserBranch)
            .FirstOrDefaultAsync(x => !x.IsDeleted
                && x.BranchID == req.Id,
                ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        entity = Map.UpdateEntity(req, entity);

        var existingUsers = entity.UserBranch.Select(x => x.UserID_FK).ToHashSet();
        var validUsers = (await dbContext.Users
            .Where(x => !x.IsDeleted && req.UserDataList.Contains(x.UserId))
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
            .Where(x => !req.UserDataList.Contains(x.UserID_FK));

        dbContext.UserBranch.RemoveRange(usersToRemove);
        foreach (var item in usersToAdd)
        {
            entity.UserBranch.Add(item);
        }
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(ct);
    }
}
