using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Item.Endpoints;

public class DeleteItemSummary
    : C4WX1DeleteSummary<Database.Models.Item>
{

}

public class Delete(THCC_C4WDEVContext dbContext)
    : Endpoint<DeleteByIdDto>
{
    public override void Configure()
    {
        Delete("item/{id}");
        Summary(new DeleteItemSummary());
    }

    public override async Task HandleAsync(DeleteByIdDto req, CancellationToken ct)
    {
        var entity = await dbContext.Item
            .Where(x => !x.IsDeleted
                && x.ItemID == req.Id
                && !x.BillingInvoiceConsumable
                    .Any(bic => !bic.IsDeleted 
                        && !bic.BillingInvoiceID_FKNavigation.IsDeleted))
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        entity.IsDeleted = true;
        entity.ModifiedBy_FK = req.UserId;
        entity.ModifiedDate = DateTime.Now;
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
