using C4WX1.API.Features.Item.Dtos;
using C4WX1.API.Features.Item.Mappers;

namespace C4WX1.API.Features.Item.Endpoints;

public class UpdateItemSummary
    : C4WX1UpdateSummary<Database.Models.Item>
{
    public UpdateItemSummary() : base()
    {
        ExampleRequest = new UpdateItemDto
        {
            Id = 1,
            ItemName = "example-ItemName",
            CategoryID_FK = 1,
            ItemUnitID_FK = 1,
            Quantity = 1,
            UnitPrice = 1M,
            AvailableInBilling = true,
            UserId = 1
        };
    }
}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateItemDto, UpdateItemMapper>
{
    public override void Configure()
    {
        Put("item/{id}");
        Summary(new UpdateItemSummary());
    }

    public override async Task HandleAsync(UpdateItemDto req, CancellationToken ct)
    {
        var entity = await dbContext.Item
            .Where(x => !x.IsDeleted
                && x.ItemID == req.Id)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        entity = Map.UpdateEntity(req, entity);
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
