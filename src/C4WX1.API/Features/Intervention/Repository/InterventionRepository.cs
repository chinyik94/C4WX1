using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Repository;

namespace C4WX1.API.Features.Intervention.Repository;

public class InterventionRepository(IConfiguration configuration) 
    : DeletableRepository(configuration), IInterventionRepository
{
    private const string CanDeleteFuncName = "fn_CanDeleteIntervention";

    protected override string CanDeleteSql 
        => C4WX1Sqls.CanDelete(CanDeleteFuncName);

    protected override string BatchCanDeleteSql 
        => C4WX1Sqls.BatchCanDelete(CanDeleteFuncName);
}
