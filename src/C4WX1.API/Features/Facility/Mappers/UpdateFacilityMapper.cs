using C4WX1.API.Features.Facility.Dtos;

namespace C4WX1.API.Features.Facility.Mappers;

public class UpdateFacilityMapper
    : RequestMapper<UpdateFacilityDto, Database.Models.Facility>
{
    public override Database.Models.Facility UpdateEntity(
        UpdateFacilityDto r, 
        Database.Models.Facility e)
    {
        e.FacilityName = r.FacilityName;
        e.OrganizationID_FK = r.OrganizationID_FK;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        return e;
    }
}
