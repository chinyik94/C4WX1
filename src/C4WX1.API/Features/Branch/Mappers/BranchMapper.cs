using C4WX1.API.Features.Branch.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.Branch.Mappers
{
    public class BranchMapper : ResponseMapper<BranchDto, Database.Models.Branch>
    {
        public override BranchDto FromEntity(Database.Models.Branch e) => new()
        {
            BranchID = e.BranchID,
            BranchName = e.BranchName,
            Address1 = e.Address1,
            Address2 = e.Address2,
            Address3 = e.Address3,
            Contact = e.Contact,
            Email = e.Email,
            Status = e.Status,
            IsSystemUsed = e.IsSystemUsed,
            CurrencyID_FK = e.CurrencyID_FK,
            CurrencyName = e.CurrencyID_FKNavigation?.CodeName ?? string.Empty,
            UserDataList = e.UserBranch
                .Select(x => new BranchUserDto
                {
                    UserId = x.UserID_FK,
                    FirstName = x.UserID_FKNavigation.Firstname,
                    LastName = x.UserID_FKNavigation.Lastname
                })
                .ToList()
        };
    }
}
