using C4WX1.API.Features.GeoFencing.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.GeoFencing.Mappers;

public class CreateGeoFancingMapper
    : RequestMapper<CreateGeoFencingDto, Database.Models.GeoFencing>
{
    public override Database.Models.GeoFencing ToEntity(CreateGeoFencingDto r) => new()
    {
        IP = r.IP,
        Description = r.Description,
        CreatedBy_FK = r.UserId,
        CreatedDate = DateTime.Now,
        IsDeleted = false
    };
}
