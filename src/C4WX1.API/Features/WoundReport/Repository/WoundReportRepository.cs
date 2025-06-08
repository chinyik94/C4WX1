using C4WX1.API.Features.Shared.Repository;

namespace C4WX1.API.Features.WoundReport.Repository;

public class WoundReportRepository(IConfiguration configuration)
    : C4WX1Repository(configuration), IWoundReportRepository
{
    protected override string CanDeleteSql => string.Empty;

    protected override string BatchCanDeleteSql => string.Empty;
}
