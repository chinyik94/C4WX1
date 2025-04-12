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

public class GetAllBillingProposalListSummary : EndpointSummary
{
    public GetAllBillingProposalListSummary()
    {
        Summary = "Get All Billing Proposal List";
        Description = "Get all filtered and sorted Billing Proposal List";
        Responses[200] = "Billing Proposal List retrieved successfully";
    }
}

public class GetAllList(THCC_C4WDEVContext dbContext)
    : Endpoint<GetAllBillingProposalListDto, IEnumerable<BillingProposalDto>, BillingProposalMapper>
{
    public override void Configure()
    {
        Get("billing-proposal/all");
        Summary(new GetAllBillingProposalListSummary());
    }

    public override async Task HandleAsync(GetAllBillingProposalListDto req, CancellationToken ct)
    {
        var dtos = await dbContext.BillingProposal
            .Where(x => !x.IsDeleted
                && !string.IsNullOrWhiteSpace(req.Status)
                && (string.IsNullOrWhiteSpace(req.Keyword)
                    || x.ProposalNumber.Contains(req.Keyword)
                    || x.Title.Contains(req.Keyword)
                    || (x.PatientID_FKNavigation.Firstname + " " + x.PatientID_FKNavigation.Lastname).Contains(req.Keyword))
                && (string.IsNullOrWhiteSpace(req.Status) || x.Status == req.Status))
            .Sort(req.OrderBy)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);

        await SendAsync(dtos, cancellation: ct);
    }
}
