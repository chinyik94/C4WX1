using C4WX1.API.Features.GeoFencing.Dtos;

namespace C4WX1.API.Features.GeoFencing.Mappers;

public class UpdateGeoFencingMapper
    : RequestMapper<UpdateGeoFencingDto, Database.Models.GeoFencing>
{
    public override Database.Models.GeoFencing UpdateEntity(
        UpdateGeoFencingDto r, 
        Database.Models.GeoFencing e)
    {
        e.IP = r.IP;
        e.Description = r.Description;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        return e;
    }
}
