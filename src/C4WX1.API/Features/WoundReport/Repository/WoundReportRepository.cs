using C4WX1.API.Features.Shared.Repository;

namespace C4WX1.API.Features.WoundReport.Repository;

public class WoundReportRepository(IConfiguration configuration)
    : WoundStatusRepository(configuration), IWoundReportRepository
{

}
