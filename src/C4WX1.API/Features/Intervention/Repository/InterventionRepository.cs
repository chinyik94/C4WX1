using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Repository;

namespace C4WX1.API.Features.Intervention.Repository;

public class InterventionRepository(IConfiguration configuration) 
    : C4WX1Repository(configuration), IInterventionRepository
{
    private const string CanDeleteFuncName = "fn_CanDeleteIntervention";

    protected override string CanDeleteSql 
        => C4WX1CanDeleteSqls.CanDelete(CanDeleteFuncName);

    protected override string BatchCanDeleteSql 
        => C4WX1CanDeleteSqls.BatchCanDelete(CanDeleteFuncName);
}
