using C4WX1.API.Features.WoundReport.Dtos;

namespace C4WX1.API.Features.WoundReport.Endpoints;

public class GetWoundAverageFalangaScoreSummary
    : EndpointSummary
{
    public GetWoundAverageFalangaScoreSummary()
    {
        Summary = "Get Wound Average Falanga Score";
        Description = "Get Wound Average Falanga Score";
        Responses[200] = "Wound Average Falanga Score retrieved successfully";
    }
}

public class GetWoundAverageFalangaScore(THCC_C4WDEVContext dbContext)
    : Endpoint<GetWoundAverageFalangaScoreDto, WoundAverageFalangaScoreDto>
{
    public override void Configure()
    {
        Get("wound-report/wound-average-falanga-score");
        Summary(new GetWoundAverageFalangaScoreSummary());
    }

    public override async Task HandleAsync(GetWoundAverageFalangaScoreDto req, CancellationToken ct)
    {
        // TODO
    }
}
