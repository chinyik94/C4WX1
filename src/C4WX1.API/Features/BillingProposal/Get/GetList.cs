using C4WX1.API.Features.BillingProposal.Constants;
using C4WX1.API.Features.BillingProposal.Dtos;
using C4WX1.API.Features.BillingProposal.Extensions;
using C4WX1.API.Features.BillingProposal.Mappers;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.BillingProposal.Get;

public class GetBillingProposalListSummary : EndpointSummary
{
    public GetBillingProposalListSummary()
    {
        Summary = "Get Billing Proposal List";
        Description = "Get a filtered, paged and sorted list of Billing Proposals";
        Responses[200] = "Billing Proposal List retrieved successfully";
    }
}

public class GetList(THCC_C4WDEVContext dbContext)
    : Endpoint<GetBillingProposalListDto, IEnumerable<BillingProposalDto>, BillingProposalMapper>
{
    public override void Configure()
    {
        Get("billing-proposal");
        Summary(new GetBillingProposalListSummary());
    }

    public override async Task HandleAsync(GetBillingProposalListDto req, CancellationToken ct)
    {
        var pageIndex = req.PageIndex ?? 1;
        var pageSize = req.PageSize ?? 10;
        var startRowIndex = Math.Max(0, (pageIndex - 1) * pageSize);

        var dtos = await dbContext.BillingProposal
            .Where(x => !x.IsDeleted
                && !string.IsNullOrWhiteSpace(req.Status)
                && (string.IsNullOrWhiteSpace(req.Keyword)
                    || x.ProposalNumber.Contains(req.Keyword)
                    || x.Title.Contains(req.Keyword)
                    || (x.PatientID_FKNavigation.Firstname + " " + x.PatientID_FKNavigation.Lastname).Contains(req.Keyword))
                && (string.IsNullOrWhiteSpace(req.Status) || x.Status == req.Status))
            .Sort(req.OrderBy)
            .Skip(startRowIndex)
            .Take(pageSize)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);

        await SendAsync(dtos, cancellation: ct);
    }
}
