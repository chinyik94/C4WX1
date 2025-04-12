using C4WX1.API.Features.Branch.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.Branch.Mappers;

public class CreateBranchMapper : RequestMapper<CreateBranchDto, Database.Models.Branch>
{
    public override Database.Models.Branch ToEntity(CreateBranchDto r) => new()
    {
        BranchName = r.BranchName,
        Address1 = r.Address1,
        Address2 = r.Address2,
        Address3 = r.Address3,
        Email = r.Email,
        Contact = r.Contact,
        Status = r.Status,
        CurrencyID_FK = r.CurrencyID_FK,
        CreatedBy_FK = r.UserId,
        CreatedDate = DateTime.Now,
        IsDeleted = false
    };
}
