using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Repository;

namespace C4WX1.API.Features.CarePlanSubGoal.Repository;

public class CarePlanSubGoalRepository(IConfiguration configuration)
    : C4WX1Repository(configuration), ICarePlanSubGoalRepository
{
    private const string CanDeleteFuncName = "fn_CanDeleteCarePlanSubGoal";

    protected override string CanDeleteSql
        => C4WX1Sqls.CanDelete(CanDeleteFuncName);

    protected override string BatchCanDeleteSql
        => C4WX1Sqls.BatchCanDelete(CanDeleteFuncName);
}
