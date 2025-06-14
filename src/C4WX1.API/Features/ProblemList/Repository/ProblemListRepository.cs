﻿using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Repository;

namespace C4WX1.API.Features.ProblemList.Repository;

public class ProblemListRepository(IConfiguration configuration)
    : DeletableRepository(configuration), IProblemListRepository
{
    private const string CanDeleteFuncName = "fn_CanDeleteProblemList";

    protected override string CanDeleteSql
        => C4WX1Sqls.CanDelete(CanDeleteFuncName);

    protected override string BatchCanDeleteSql
        => C4WX1Sqls.BatchCanDelete(CanDeleteFuncName);
}
