using C4WX1.API.Features.Intervention.Constants;
using C4WX1.API.Features.Shared.Repository;

namespace C4WX1.API.Features.Intervention.Repository;

public class InterventionRepository(IConfiguration configuration) 
    : C4WX1Repository(configuration), IInterventionRepository
{
    protected override string CanDeleteSql => Sqls.CanDelete;

    protected override string BatchCanDeleteSql => Sqls.BatchCanDelete;
}
