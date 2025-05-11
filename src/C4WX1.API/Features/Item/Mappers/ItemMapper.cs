using C4WX1.API.Features.Item.Dtos;

namespace C4WX1.API.Features.Item.Mappers;

public class ItemMapper
    : ResponseMapper<ItemDto, Database.Models.Item>
{
    public override ItemDto FromEntity(Database.Models.Item e)
        => new()
        {
            ItemID = e.ItemID,
            ItemName = e.ItemName,
            ItemUnitID_FK = e.ItemUnitID_FK,
            ItemUnitName = e.ItemUnitID_FKNavigation.CodeName,
            CategoryID_FK = e.CategoryID_FK,
            CategoryName = e.CategoryID_FKNavigation.CodeName,
            UnitPrice = e.UnitPrice,
            Quantity = e.Quantity,
            AvailableInBilling = e.AvailableInBilling,
            CanDelete = !e.BillingInvoiceConsumable
                .Any(x => !x.IsDeleted
                    && !x.BillingInvoiceID_FKNavigation.IsDeleted)
        };
}
