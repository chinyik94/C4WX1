using C4WX1.API.Features.TreatmentListItem.Dtos;

namespace C4WX1.API.Features.TreatmentListItem.Mappers;

public class TreatmentListItemMapper
    : ResponseMapper<TreatmentListItemDto, Database.Models.TreatmentListItem>
{
    public override TreatmentListItemDto FromEntity(Database.Models.TreatmentListItem e)
        => new()
        {
            TListItemID = e.TListItemID,
            ItemName = e.ItemName,
            ItemBrand = e.ItemBrand,
            TListTypeID_FK = e.TListTypeID_FK,
            IsActive = e.IsActive,
            IsSystemUsed = e.IsSystemUsed,
            CanEdit = !(e.IsSystemUsed ?? false),
            CanEditType = !(e.IsSystemUsed ?? false)
                && !e.PatientWoundVisitTreatmentList
                .Any(y => !y.IsDeleted
                    && y.TListItemID_FK == e.TListItemID),
            CanDelete = !(e.IsSystemUsed ?? false)
                && !e.PatientWoundVisitTreatmentList
                .Any(y => !y.IsDeleted
                    && y.TListItemID_FK == e.TListItemID),
            CanDeactivate = !(e.IsSystemUsed ?? false)
                && e.PatientWoundVisitTreatmentList
                .Any(y => !y.IsDeleted
                    && y.TListItemID_FK == e.TListItemID),
            Cost = e.Cost,
            StartDate = e.StartDate?.ToLocalTime(),
            EndDate = e.EndDate?.ToLocalTime(),
        };
}
