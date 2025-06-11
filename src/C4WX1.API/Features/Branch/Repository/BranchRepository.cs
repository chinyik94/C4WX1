using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Repository;

namespace C4WX1.API.Features.Branch.Repository;

public class BranchRepository(IConfiguration configuration)
    : DeletableRepository(configuration), IBranchRepository
{
    private const string CanDeleteFuncName = "fn_CanDeleteBranch";

    protected override string CanDeleteSql
        => C4WX1Sqls.CanDelete(CanDeleteFuncName);

    protected override string BatchCanDeleteSql
        => C4WX1Sqls.BatchCanDelete(CanDeleteFuncName);
}
