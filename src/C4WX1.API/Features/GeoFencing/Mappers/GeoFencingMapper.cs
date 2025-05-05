using C4WX1.API.Features.GeoFencing.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.GeoFencing.Mappers;

public class GeoFencingMapper
    : ResponseMapper<GeoFencingDto, Database.Models.GeoFencing>
{
    public override GeoFencingDto FromEntity(Database.Models.GeoFencing e) => new()
    {
        GeoFencingId = e.GeoFencingId,
        IP = e.IP,
        Description = e.Description,
        IsWhitelisted = e.IsWhitelisted,
        CreatedBy_FK = e.CreatedBy_FK,
        CreatedDate = e.CreatedDate,
        ModifiedBy_FK = e.ModifiedBy_FK,
        ModifiedDate = e.ModifiedDate
    };
}
