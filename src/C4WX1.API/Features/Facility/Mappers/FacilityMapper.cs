using C4WX1.API.Features.Facility.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.Facility.Mappers;

public class FacilityMapper
    : ResponseMapper<FacilityDto, Database.Models.Facility>
{
    public override FacilityDto FromEntity(Database.Models.Facility e) => new()
    {
        FacilityID = e.FacilityID,
        FacilityName = e.FacilityName,
        OrganizationID_FK = e.OrganizationID_FK,
        OrganizationName = e.OrganizationID_FKNavigation.CodeName,
        Remarks = e.Remarks,
        IntegrationSource = e.IntegrationSource,
        C_id = e._id,
        CanDelete = e.UserCategoryFacility
            .Any(ucf => ucf.UserCategoryID_FKNavigation.UserType
                .Any(ut => ut.UserUserType
                    .Any(uut => !uut.UserID_FKNavigation.IsDeleted)))
    };
}
