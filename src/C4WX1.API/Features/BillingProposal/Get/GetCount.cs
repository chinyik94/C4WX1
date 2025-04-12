using C4WX1.API.Features.BillingProposal.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.BillingProposal.Get;

public class GetBillingProposalCountSummary : EndpointSummary
{
    public GetBillingProposalCountSummary()
    {
        Summary = "Get Billing Proposal Count";
        Description = "Get filtered Billing Proposal Count";
        Responses[200] = "Billing Proposal Count retrieved successfully";
    }
}

public class GetCount(THCC_C4WDEVContext dbContext)
    : Endpoint<GetBillingProposalCountDto, int>
{
    public override void Configure()
    {
        Get("billing-proposal/count");
        Summary(new GetBillingProposalCountSummary());
    }

    public override async Task HandleAsync(GetBillingProposalCountDto req, CancellationToken ct)
    {
        var count = await dbContext.BillingProposal
            .Where(x => !x.IsDeleted
                && !string.IsNullOrWhiteSpace(x.Status)
                && (string.IsNullOrWhiteSpace(req.Keyword)
                    || x.ProposalNumber.Contains(req.Keyword)
                    || x.Title.Contains(req.Keyword)
                    || (x.PatientID_FKNavigation.Firstname + " " + x.PatientID_FKNavigation.Lastname).Contains(req.Keyword))
                && (string.IsNullOrWhiteSpace(req.Status)
                    || x.Status == req.Status))
            .CountAsync(ct);

        await SendOkAsync(count, cancellation: ct);
    }
}
