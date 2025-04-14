using C4WX1.API.Features.EmailLog.Dtos;
using C4WX1.API.Features.EmailLog.Extensions;
using C4WX1.API.Features.EmailLog.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.EmailLog.Endpoints;

public class GetEmailLogListSummary : EndpointSummary
{
    public GetEmailLogListSummary()
    {
        Summary = "Get Email Log List";
        Description = "Get a filtered, sorted and paged List of Email Log";
        Responses[200] = "Email Log List retrieved successfully";
    }
}

public class GetList(THCC_C4WDEVContext dbContext)
    : Endpoint<GetEmailLogListDto, IEnumerable<EmailLogDto>, EmailLogMapper>
{
    public override void Configure()
    {
        Get("email-log");
        Summary(new GetEmailLogListSummary());
    }

    public override async Task HandleAsync(GetEmailLogListDto req, CancellationToken ct)
    {
        var pageIndex = req.PageIndex ?? 1;
        var pageSize = req.PageSize ?? 10;
        var startRowIndex = Math.Max(0, (pageIndex - 1) * pageSize);

        var query = dbContext.EmailLog
            .Where(x =>
                (string.IsNullOrWhiteSpace(req.MsgFrom)
                    || !string.IsNullOrWhiteSpace(x.msgFrom) && x.msgFrom.Contains(req.MsgFrom)) &&
                (string.IsNullOrWhiteSpace(req.MsgFromName)
                    || !string.IsNullOrWhiteSpace(x.msgFromName) && x.msgFromName.Contains(req.MsgFromName)) &&
                (string.IsNullOrWhiteSpace(req.MsgTo)
                    || !string.IsNullOrWhiteSpace(x.msgTo) && x.msgTo.Contains(req.MsgTo)) &&
                (string.IsNullOrWhiteSpace(req.MsgSubj)
                    || !string.IsNullOrWhiteSpace(x.msgSubj) && x.msgSubj.Contains(req.MsgSubj)));
        if (bool.TryParse(req.IsSent, out bool isSent))
        {
            query = query.Where(x => x.isSent == isSent);
        }
        var dtos = await query
            .Where(x => x.CreatedDate.HasValue
                && x.CreatedDate >= req.FromDate && x.CreatedDate <= req.ToDate)
            .Sort(req.OrderBy)
            .Skip(startRowIndex)
            .Take(pageSize)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, cancellation: ct);
    }
}
