using C4WX1.API.Features.ErrorLog.Dtos;
using C4WX1.Database.Models;

namespace C4WX1.API.Features.ErrorLog.Endpoints;

public class CreateErrorLogSummary : EndpointSummary
{
    public CreateErrorLogSummary()
    {
        Summary = "Create Error Log";
        Description = "Create a new Error Log";
        ExampleRequest = new CreateErrorLogDto
        {
            ErrorDetails = "ErrorDetails"
        };
        Responses[200] = "Error Log created successfully";
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
