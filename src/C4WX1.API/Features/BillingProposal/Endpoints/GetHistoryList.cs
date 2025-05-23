﻿using C4WX1.API.Features.BillingProposal.Dtos;
using C4WX1.API.Features.BillingProposal.Extensions;
using C4WX1.API.Features.BillingProposal.Mappers;

namespace C4WX1.API.Features.BillingProposal.Endpoints;

public class GetHistoryBillingProposalListSummary : EndpointSummary
{
    public GetHistoryBillingProposalListSummary()
    {
        Summary = "Get History Billing Proposal List";
        Description = "Get filtered and sorted History Billing Proposal List";
        Responses[200] = "Billing Proposal List retrieved successfully";
    }
}

public class GetHistoryList(THCC_C4WDEVContext dbContext)
    : Endpoint<GetHistoryBillingProposalListDto, IEnumerable<BillingProposalDto>, BillingProposalMapper>
{
    public override void Configure()
    {
        Get("billing-proposal/history");
        Summary(new GetHistoryBillingProposalListSummary());
    }

    public override async Task HandleAsync(GetHistoryBillingProposalListDto req, CancellationToken ct)
    {
        var dtos = await dbContext.BillingProposal
            .Where(x => !x.IsDeleted
                && string.IsNullOrWhiteSpace(x.Status)
                && x.GroupNumber == req.GroupNumber)
            .Sort(req.OrderBy)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);

        await SendAsync(dtos, cancellation: ct);
    }
}
