using C4WX1.API.Features.Branch.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.Branch.Mappers;

public class UpdateBranchMapper : RequestMapper<UpdateBranchDto, Database.Models.Branch>
{
    public override Database.Models.Branch UpdateEntity(UpdateBranchDto r, Database.Models.Branch e)
    {
        e.BranchName = r.BranchName;
        e.Address1 = r.Address1;
        e.Address2 = r.Address2;
        e.Address3 = r.Address3;
        e.Email = r.Email;
        e.Contact = r.Contact;
        e.Status = r.Status;
        e.CurrencyID_FK = r.CurrencyID_FK;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        return e;
    }
}
