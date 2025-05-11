using C4WX1.API.Features.Item.Dtos;
using C4WX1.API.Features.Item.Mappers;

namespace C4WX1.API.Features.Item.Endpoints;

public class CreateItemSummary
    : C4WX1CreateSummary<Database.Models.Item>
{
    public CreateItemSummary() : base()
    {
        ExampleRequest = new CreateItemDto
        {
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

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateItemDto, int, CreateItemMapper>
{
    public override void Configure()
    {
        Post("item");
        Summary(new CreateItemSummary());
    }

    public override async Task HandleAsync(CreateItemDto req, CancellationToken ct)
    {
        var entity = Map.ToEntity(req);
        await dbContext.Item.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.ItemID, ct);
    }
}
