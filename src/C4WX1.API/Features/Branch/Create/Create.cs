using C4WX1.API.Features.Branch.Dtos;
using C4WX1.API.Features.Branch.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.Branch.Create;

public class CreateBranchSummary : EndpointSummary
{
    public CreateBranchSummary()
    {
        Summary = "Create Branch";
        Description = "Create a new Branch";
        ExampleRequest = new CreateBranchDto
        {
            BranchID = 0,
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
        Responses[204] = "Branch created successfully";
        Responses[400] = "Branch data invalid";
    }
}

public class Create(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<CreateBranchDto, CreateBranchMapper>
{
    public override void Configure()
    {
        Post("branch");
        Description(b => b.ProducesProblemFE(400));
        Summary(new CreateBranchSummary());
    }

    public override async Task HandleAsync(CreateBranchDto req, CancellationToken ct)
    {
        var hasDuplicate = await dbContext.Branch
            .AnyAsync(x => x.BranchName == req.BranchName 
                && x.BranchID != req.BranchID,
                ct);
        if (hasDuplicate)
        {
            ThrowError("DUPLICATE_NAME");
            return;
        }

        var entity = Map.ToEntity(req);
        var validUsers = (await dbContext.Users
            .Where(x => !x.IsDeleted && req.UserDataList.Select(y => y.UserId).Contains(x.UserId))
            .Select(x => x.UserId)
            .ToListAsync(ct))
            .ToHashSet();

        entity.UserBranch = req.UserDataList
            .Where(x => validUsers.Contains(x.UserId))
            .Select(x => new UserBranch
            {
                UserID_FK = x.UserId
            })
            .ToList();
        
        dbContext.Branch.Add(entity);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(ct);
    }
}
