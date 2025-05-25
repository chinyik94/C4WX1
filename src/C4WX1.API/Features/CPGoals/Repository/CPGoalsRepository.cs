using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Repository;

namespace C4WX1.API.Features.CPGoals.Repository;

public class CPGoalsRepository(IConfiguration configuration) 
    : C4WX1Repository(configuration), ICPGoalsRepository
{
    private const string CanDeleteFuncName = "fn_CanDeleteCPGoals";

    protected override string CanDeleteSql
        => C4WX1Sqls.CanDelete(CanDeleteFuncName);

    protected override string BatchCanDeleteSql
        => C4WX1Sqls.BatchCanDelete(CanDeleteFuncName);
}
