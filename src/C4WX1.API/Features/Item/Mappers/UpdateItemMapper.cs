using C4WX1.API.Features.Item.Dtos;

namespace C4WX1.API.Features.Item.Mappers;

public class UpdateItemMapper
    : RequestMapper<UpdateItemDto, Database.Models.Item>
{
    public override Database.Models.Item UpdateEntity(
        UpdateItemDto r, 
        Database.Models.Item e)
    {
        e.ItemName = r.ItemName;
        e.CategoryID_FK = r.CategoryID_FK;
        e.ItemUnitID_FK = r.ItemUnitID_FK;
        e.UnitPrice = r.UnitPrice;
        e.AvailableInBilling = r.AvailableInBilling;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        return e;
    }
}
