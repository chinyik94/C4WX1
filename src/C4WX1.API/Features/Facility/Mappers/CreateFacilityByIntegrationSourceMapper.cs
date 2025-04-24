using C4WX1.API.Features.Facility.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.Facility.Mappers;

public class CreateFacilityByIntegrationSourceMapper
    : RequestMapper<CreateFacilityByIntegrationSourceDto, Database.Models.Facility>
{
    public override Database.Models.Facility ToEntity(CreateFacilityByIntegrationSourceDto r) => new()
    {
        FacilityName = r.FacilityName,
        OrganizationID_FK = r.OrganizationID_FK,
        _id = r.C_Id,
        IntegrationSource = r.IntegrationSource,
        Remarks = r.Remarks,
        CreatedBy_FK = r.UserId,
        CreatedDate = DateTime.Now,
    };
}
