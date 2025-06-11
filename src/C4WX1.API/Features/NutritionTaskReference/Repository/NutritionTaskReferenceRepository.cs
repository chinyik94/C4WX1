using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Repository;

namespace C4WX1.API.Features.NutritionTaskReference.Repository;

public class NutritionTaskReferenceRepository(IConfiguration configuration)
    : DeletableRepository(configuration), INutritionTaskReferenceRepository
{
    private const string CanDeleteFuncName = "fn_CanDeleteNutritionReference";

    protected override string CanDeleteSql
        => C4WX1Sqls.CanDelete(CanDeleteFuncName);

    protected override string BatchCanDeleteSql
        => C4WX1Sqls.BatchCanDelete(CanDeleteFuncName);
}
