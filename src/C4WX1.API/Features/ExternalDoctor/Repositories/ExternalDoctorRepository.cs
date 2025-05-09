using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Repository;

namespace C4WX1.API.Features.ExternalDoctor.Repositories;

public class ExternalDoctorRepository(IConfiguration configuration) 
    : C4WX1Repository(configuration), IExternalDoctorRepository
{
    private const string CanDeleteFuncName = "fn_CanDeleteExternalDoctor";

    protected override string CanDeleteSql
        => C4WX1CanDeleteSqls.CanDelete(CanDeleteFuncName);

    protected override string BatchCanDeleteSql
        => C4WX1CanDeleteSqls.BatchCanDelete(CanDeleteFuncName);
}
