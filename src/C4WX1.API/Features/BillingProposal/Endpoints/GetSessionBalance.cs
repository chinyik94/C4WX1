using C4WX1.API.Features.BillingProposal.Dtos;

namespace C4WX1.API.Features.BillingProposal.Endpoints;

public class GetBillingProposalSessionBalanceSummary : EndpointSummary
{
    public GetBillingProposalSessionBalanceSummary()
    {
        Summary = "Get Billing Proposal Session Balance";
        Description = "Get Billing Proposal Session Balance by its ProposalId, ServiceId and EndDate";
        Responses[200] = "Billing Proposal Session Balance retrieved successfully";
    }
}

public class GetSessionBalance(THCC_C4WDEVContext dbContext)
    : Endpoint<GetBillingProposalSessionBalanceDto, string>
{
    public override void Configure()
    {
        Get("billing-proposal/session-balance");
        Summary(new GetBillingProposalSessionBalanceSummary());
    }

    public override async Task HandleAsync(GetBillingProposalSessionBalanceDto req, CancellationToken ct)
    {
        var sessions = await dbContext.BillingProposalService
            .Where(x => !x.IsDeleted
                && x.BillingProposalID_FK == req.ProposalId
                && x.ServiceID_FK == req.ServiceId)
            .Select(x => x.Session)
            .FirstOrDefaultAsync(ct);

        var sessionsUsed = await dbContext.BillingInvoiceService
            .Join(dbContext.BillingInvoice,
                bis => bis.BillingInvoiceID_FK,
                bi => bi.BillingInvoiceID,
                (bis, bi) => new { bis, bi })
            .Where(x => !x.bi.IsDeleted
                && x.bis.IsDeleted
                && x.bis.ProposalID_FK == req.ProposalId
                && x.bis.ServiceID_FK == req.ServiceId
                && x.bi.InvoiceDate <= req.EndDate)
            .Select(x => x.bis.Session)
            .DefaultIfEmpty(0)
            .SumAsync(ct);

        var sessionBalance = $"({sessionsUsed:0} out of {sessions:0})";
        await SendOkAsync(sessionBalance, cancellation: ct);
    }
}
