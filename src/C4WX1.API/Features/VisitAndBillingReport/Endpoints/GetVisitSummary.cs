using C4WX1.API.Features.VisitAndBillingReport.Dtos;
using C4WX1.API.Features.VisitAndBillingReport.Repository;

namespace C4WX1.API.Features.VisitAndBillingReport.Endpoints;

public class GetVisitSummarySummary
    : EndpointSummary
{
    public GetVisitSummarySummary()
    {
        Summary = "Get Visit Summary";
        Description = "Get Visit Summary";
        Responses[200] = "Visit Summary retrieved successfully";
    }
}

public class GetVisitSummary(IVisitRepository repository)
    : Endpoint<GetVisitSummaryDto, IEnumerable<VisitSummaryDto>>
{
    public override void Configure()
    {
        Get("visit-billing-report/visit-summary");
        Summary(new GetVisitSummarySummary());
    }

    public override async Task HandleAsync(GetVisitSummaryDto req, CancellationToken ct)
    {
        var dtos = await repository.GetVisitSummariesAsync(
            req.UserId,
            req.UserCategoryId,
            req.StartDate,
            req.EndDate);
        await SendOkAsync(dtos, ct);
    }
}
