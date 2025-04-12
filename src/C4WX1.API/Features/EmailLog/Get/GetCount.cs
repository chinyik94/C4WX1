using C4WX1.API.Features.EmailLog.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.EmailLog.Get;

public class GetEmailLogCountSummary : EndpointSummary
{
    public GetEmailLogCountSummary()
    {
        Summary = "Get Email Log Count";
        Description = "Get Email Log Count";
        Responses[200] = "Email Log Count retrieved successfully";
    }
}

public class GetCount(THCC_C4WDEVContext dbContext)
    : Endpoint<GetEmailLogCountDto, int>
{
    public override void Configure()
    {
        Get("email-log/count");
        Summary(new GetEmailLogCountSummary());
    }

    public override async Task HandleAsync(GetEmailLogCountDto req, CancellationToken ct)
    {
        var query = dbContext.EmailLog
            .Where(x =>
                (string.IsNullOrWhiteSpace(req.MsgFrom)
                    || (!string.IsNullOrWhiteSpace(x.msgFrom) && x.msgFrom.Contains(req.MsgFrom))) &&
                (string.IsNullOrWhiteSpace(req.MsgFromName)
                    || (!string.IsNullOrWhiteSpace(x.msgFromName) && x.msgFromName.Contains(req.MsgFromName))) &&
                (string.IsNullOrWhiteSpace(req.MsgTo)
                    || (!string.IsNullOrWhiteSpace(x.msgTo) && x.msgTo.Contains(req.MsgTo))) &&
                (string.IsNullOrWhiteSpace(req.MsgSubj)
                    || (!string.IsNullOrWhiteSpace(x.msgSubj) && x.msgSubj.Contains(req.MsgSubj))));
        if (bool.TryParse(req.IsSent, out bool isSent))
        {
            query = query.Where(x => x.isSent == isSent);
        }
        var count = await query
            .Where(x => x.CreatedDate.HasValue &&
                x.CreatedDate >= req.FromDate && x.CreatedDate <= req.ToDate)
            .CountAsync(ct);
        await SendOkAsync(count, cancellation: ct);
    }
}
