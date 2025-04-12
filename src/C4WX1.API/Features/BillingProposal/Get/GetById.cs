using C4WX1.API.Features.BillingProposal.Dtos;
using C4WX1.API.Features.BillingProposal.Mappers;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.BillingProposal.Get;

public class GetBillingProposalSummary : EndpointSummary
{
    public GetBillingProposalSummary()
    {
        Summary = "Get Billing Proposal";
        Description = "Get Billing Proposal by its ID";
        Responses[200] = "Billing Proposal retrieved succesfully";
        Responses[404] = "Billing Proposal not found";
    }
}

public class GetById(THCC_C4WDEVContext dbContext)
    : Endpoint<GetByIdDto, BillingProposalDto, BillingProposalMapper>
{
    public override void Configure()
    {
        Get("billing-proposal/{id}");
        Description(b => b.Produces(404));
        Summary(new GetBillingProposalSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.BillingProposal
            .Where(x => !x.IsDeleted && x.BillingProposalID == req.Id)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);

        if (dto == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        await SendOkAsync(dto, cancellation: ct);
    }
}
