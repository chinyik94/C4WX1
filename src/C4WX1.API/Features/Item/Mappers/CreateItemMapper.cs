using C4WX1.API.Features.Item.Dtos;

namespace C4WX1.API.Features.Item.Mappers;

public class CreateItemMapper
    : RequestMapper<CreateItemDto, Database.Models.Item>
{
    public override Database.Models.Item ToEntity(CreateItemDto r)
        => new()
        {
            ItemName = r.ItemName,
            CategoryID_FK = r.CategoryID_FK,
            ItemUnitID_FK = r.ItemUnitID_FK,
            UnitPrice = r.UnitPrice,
            AvailableInBilling = r.AvailableInBilling,
            CreatedBy_FK = r.UserId,
            CreatedDate = DateTime.Now,
            IsDeleted = false,
            Quantity = 0
        };
}
