using C4WX1.API.Features.Facility.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.Facility.Mappers;

public class CreateFacilityMapper
    : RequestMapper<CreateFacilityDto, Database.Models.Facility>
{
    public override Database.Models.Facility ToEntity(CreateFacilityDto r) => new()
    {
        FacilityName = r.FacilityName,
        OrganizationID_FK = r.OrganizationID_FK,
        CreatedBy_FK = r.UserId,
        CreatedDate = DateTime.Now,
    };
}
