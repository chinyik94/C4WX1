﻿using C4WX1.API.Features.Branch.Dtos;
using C4WX1.API.Features.Branch.Mappers;

namespace C4WX1.API.Features.Branch.Endpoints;

public class CreateBranchSummary 
    : C4WX1CreateSummary<Database.Models.Branch>
{
    public CreateBranchSummary() : base()
    {
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
            UserDataList = [1, 2, 3]
        };
    }
}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateBranchDto, int, CreateBranchMapper>
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
        var validUserIds = await dbContext.Users
            .Where(x => !x.IsDeleted && req.UserDataList.Contains(x.UserId))
            .Select(x => x.UserId)
            .ToListAsync(ct);
        foreach (var userId in validUserIds)
        {
            entity.UserBranch.Add(new UserBranch
            {
                UserID_FK = userId
            });
        }

        dbContext.Branch.Add(entity);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.BranchID, cancellation: ct);
    }
}
