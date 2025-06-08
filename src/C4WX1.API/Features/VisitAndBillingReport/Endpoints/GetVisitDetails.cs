using C4WX1.API.Features.VisitAndBillingReport.Dtos;
using C4WX1.API.Features.VisitAndBillingReport.Repository;

namespace C4WX1.API.Features.VisitAndBillingReport.Endpoints;

public class GetVisitDetailsSummary
    : EndpointSummary
{
    public GetVisitDetailsSummary()
    {
        Summary = "Get Visit Details";
        Description = "Get Visit Details";
        Responses[200] = "Visit Summary retrieved successfully";
    }
}

public class GetVisitDetails(IVisitRepository repository)
    : Endpoint<GetVisitDetailsDto, IEnumerable<VisitDetailsDto>>
{
    public override void Configure()
    {
        Get("visit-billing-report/visit-details");
        Summary(new GetVisitDetailsSummary());
    }

    public override async Task HandleAsync(GetVisitDetailsDto req, CancellationToken ct)
    {
        var dtos = await repository.GetVisitDetailsAsync(
            req.UserId,
            req.UserCategoryId,
            req.StartDate,
            req.EndDate);
        await SendOkAsync(dtos, ct);
    }
}
