using C4WX1.API.Features.BillingProposal.Dtos;
using C4WX1.API.Features.BillingProposal.Extensions;
using C4WX1.API.Features.BillingProposal.Mappers;
using C4WX1.API.Features.Shared.Extensions;

namespace C4WX1.API.Features.BillingProposal.Endpoints;

public class GetBillingProposalListSummary 
    : C4WX1GetListSummary<Database.Models.BillingProposal>
{
    public GetBillingProposalListSummary() { }
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
        var (startRowIndex, pageSize) = req.GetPaginationDetails();
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
