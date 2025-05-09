using C4WX1.API.Features.ErrorLog.Dtos;

namespace C4WX1.API.Features.ErrorLog.Endpoints;

public class CreateErrorLogSummary 
    : C4WX1CreateSummary<Database.Models.ErrorLog>
{
    public CreateErrorLogSummary() : base()
    {
        ExampleRequest = new CreateErrorLogDto
        {
            ErrorDetails = "ErrorDetails"
        };
    }
}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateErrorLogDto, int>
{
    public override void Configure()
    {
        Post("/errorlog");
        Summary(new CreateErrorLogSummary());
    }

    public override async Task HandleAsync(CreateErrorLogDto req, CancellationToken ct)
    {
        var entity = new Database.Models.ErrorLog
        {
            ErrorDetails = req.ErrorDetails,
            DateCreated = DateTime.Now
        };
        await dbContext.ErrorLog.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.ErrorLogId, cancellation: ct);
    }
}
