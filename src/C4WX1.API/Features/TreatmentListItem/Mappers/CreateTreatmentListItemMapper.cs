using C4WX1.API.Features.TreatmentListItem.Dtos;

namespace C4WX1.API.Features.TreatmentListItem.Mappers;

public class CreateTreatmentListItemMapper
    : RequestMapper<CreateTreatmentListItemDto, Database.Models.TreatmentListItem>
{
    public override Database.Models.TreatmentListItem ToEntity(CreateTreatmentListItemDto r)
        => new()
        {
            ItemBrand = r.ItemBrand,
            ItemName = r.ItemName,
            TListTypeID_FK = r.TListTypeID_FK,
            Cost = r.Cost,
            StartDate = r.StartDate,
            EndDate = r.EndDate,
            CreatedDate = DateTime.Now,
            CreatedBy_FK = r.UserId,
            IsDeleted = false,
            IsSystemUsed = false,
            IsActive = true
        };
}
