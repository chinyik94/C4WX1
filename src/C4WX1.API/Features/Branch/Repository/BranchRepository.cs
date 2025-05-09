using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Repository;

namespace C4WX1.API.Features.Branch.Repository;

public class BranchRepository(IConfiguration configuration)
    : C4WX1Repository(configuration), IBranchRepository
{
    private const string CanDeleteFuncName = "fn_CanDeleteBranch";

    protected override string CanDeleteSql
        => C4WX1CanDeleteSqls.CanDelete(CanDeleteFuncName);

    protected override string BatchCanDeleteSql
        => C4WX1CanDeleteSqls.BatchCanDelete(CanDeleteFuncName);
}
