using C4WX1.API.Features.EmailLog.Dtos;
using C4WX1.API.Features.EmailLog.Mappers;
using C4WX1.Database.Models;

namespace C4WX1.API.Features.EmailLog.Endpoints;

public class CreateEmailLogSummary : EndpointSummary
{
    public CreateEmailLogSummary()
    {
        Summary = "Create Email Log";
        Description = "Create a new Email Log";
        ExampleRequest = new CreateEmailLogDto
        {
            msgBCC = "bcc@test.com",
            msgCC = "cc@test.com",
            msgTo = "to@test.com",
            msgSubj = nameof(CreateEmailLogDto.msgSubj),
            msgBody = nameof(CreateEmailLogDto.msgBody),
            msgFromName = nameof(CreateEmailLogDto.msgFromName),
            msgFrom = "from@test.com",
            isHtml = true,
            attachmentName = nameof(CreateEmailLogDto.attachmentName),
            isSent = true,
            smtpLogin = "smtp-user",
            smtpPassword = "smtp-password",
            smtpPort = "25",
            smtpServerAddress = "smtp@test.com"
        };
        Responses[200] = "Email Log created successfully";
    }
}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateEmailLogDto, int, CreateEmailLogMapper>
{
    public override void Configure()
    {
        Post("email-log");
        Summary(new CreateEmailLogSummary());
    }

    public override async Task HandleAsync(CreateEmailLogDto req, CancellationToken ct)
    {
        var entity = Map.ToEntity(req);
        await dbContext.EmailLog.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.EmailLogId, cancellation: ct);
    }
}
