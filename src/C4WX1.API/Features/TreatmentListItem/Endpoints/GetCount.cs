using C4WX1.API.Features.TreatmentListItem.Dtos;

namespace C4WX1.API.Features.TreatmentListItem.Endpoints;

public class GetTreatmentListItemCountSummary
    : C4WX1GetCountSummary<Database.Models.TreatmentListItem>
{

}

public class GetCount(THCC_C4WDEVContext dbContext)
    : Endpoint<GetTreatmentListItemCountDto, int>
{
    public override void Configure()
    {
        Get("treatment-list-item/count");
        Summary(new GetTreatmentListItemCountSummary());
    }

    public override async Task HandleAsync(GetTreatmentListItemCountDto req, CancellationToken ct)
    {
        var count = await dbContext.TreatmentListItem
            .Where(x => !x.IsDeleted
                && (string.IsNullOrWhiteSpace(req.ProductName) || x.ItemName.Contains(req.ProductName))
                && (req.ProductType == null || x.TListTypeID_FK == req.ProductType))
            .CountAsync(ct);
        await SendOkAsync(count, ct);
    }
}
