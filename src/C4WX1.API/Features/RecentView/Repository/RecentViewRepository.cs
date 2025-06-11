using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Repository;

namespace C4WX1.API.Features.RecentView.Repository;

public class RecentViewRepository(IConfiguration configuration)
    : AccessibleRepository(configuration), IRecentViewRepository
{
    protected override string BatchCanAccessPatientDashboardSql
        => C4WX1Sqls.BatchCanAccessPatient;
}
