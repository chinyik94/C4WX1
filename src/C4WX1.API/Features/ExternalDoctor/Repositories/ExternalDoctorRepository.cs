using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Repository;

namespace C4WX1.API.Features.ExternalDoctor.Repositories;

public class ExternalDoctorRepository(IConfiguration configuration) 
    : DeletableRepository(configuration), IExternalDoctorRepository
{
    private const string CanDeleteFuncName = "fn_CanDeleteExternalDoctor";

    protected override string CanDeleteSql
        => C4WX1Sqls.CanDelete(CanDeleteFuncName);

    protected override string BatchCanDeleteSql
        => C4WX1Sqls.BatchCanDelete(CanDeleteFuncName);
}
