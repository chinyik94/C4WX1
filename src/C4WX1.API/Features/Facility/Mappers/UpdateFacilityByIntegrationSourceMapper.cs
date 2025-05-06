using C4WX1.API.Features.Facility.Dtos;

namespace C4WX1.API.Features.Facility.Mappers;

public class UpdateFacilityByIntegrationSourceMapper
    : RequestMapper<UpdateFacilityByIntegrationSourceDto, Database.Models.Facility>
{
    public override Database.Models.Facility UpdateEntity(
        UpdateFacilityByIntegrationSourceDto r,
        Database.Models.Facility e)
    {
        e.FacilityName = r.FacilityName;
        e.OrganizationID_FK = r.OrganizationID_FK;
        e._id = r.C_Id;
        e.IntegrationSource = r.IntegrationSource;
        e.Remarks = r.Remarks;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        return e;
    }
}
