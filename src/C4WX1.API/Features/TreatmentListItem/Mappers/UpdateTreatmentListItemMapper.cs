
using C4WX1.API.Features.TreatmentListItem.Dtos;

namespace C4WX1.API.Features.TreatmentListItem.Mappers;

public class UpdateTreatmentListItemMapper
    : RequestMapper<UpdateTreatmentListItemDto, Database.Models.TreatmentListItem>
{
    public override Database.Models.TreatmentListItem UpdateEntity(
        UpdateTreatmentListItemDto r, 
        Database.Models.TreatmentListItem e)
    {
        e.ItemBrand = r.ItemBrand;
        e.ItemName = r.ItemName;
        e.TListTypeID_FK = r.TListTypeID_FK;
        e.Cost = r.Cost;
        e.StartDate = r.StartDate?.ToUniversalTime();
        e.EndDate = r.EndDate?.ToUniversalTime();
        e.ModifiedDate = DateTime.Now;
        e.ModifiedBy_FK = r.UserId;

        return e;
    }
}
