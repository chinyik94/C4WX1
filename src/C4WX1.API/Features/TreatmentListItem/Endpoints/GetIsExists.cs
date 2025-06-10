using C4WX1.API.Features.TreatmentListItem.Dtos;

namespace C4WX1.API.Features.TreatmentListItem.Endpoints;

public class GetTreatmentListItemIsExistsSummary
    : C4WX1GetByIdSummary<Database.Models.TreatmentListItem>
{

}

public class GetIsExists(THCC_C4WDEVContext dbContext)
    : Endpoint<GetTreatmentListItemIsExistsDto, bool>
{
    public override void Configure()
    {
        Get("treatment-list-item/is-exists/{id}");
        Summary(new GetTreatmentListItemIsExistsSummary());
    }

    public override async Task HandleAsync(GetTreatmentListItemIsExistsDto req, CancellationToken ct)
    {
        var isExists = await dbContext.TreatmentListItem
            .Where(x => x.TListItemID != req.Id
                && (req.ProductTypeId == null || x.TListTypeID_FK == req.ProductTypeId)
                && (string.IsNullOrWhiteSpace(req.ProductName) || x.ItemName == req.ProductName)
                && !x.IsDeleted
                && (string.IsNullOrWhiteSpace(req.ProductBrand) || x.ItemBrand == req.ProductBrand))
            .AnyAsync(ct);
        await SendOkAsync(isExists, ct);
    }
}
