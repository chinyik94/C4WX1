using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Package.Endpoints;

public class DeletePackageSummary
    : C4WX1DeleteSummary<Database.Models.Package>
{

}

public class Delete(THCC_C4WDEVContext dbContext)
    : Endpoint<DeleteByIdDto>
{
    public override void Configure()
    {
        Delete("package/{id}");
        Summary(new DeletePackageSummary());
    }

    public override async Task HandleAsync(DeleteByIdDto req, CancellationToken ct)
    {
        var entity = await dbContext.Package
            .Where(x => !x.IsDeleted
                && x.PackageID == req.Id)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var isPackageInUse = entity.PatientPackage
            .Where(x => x.PackageID_FK == entity.PackageID)
            .Any();
        if (isPackageInUse)
        {
            ThrowError("UNABLE_DELETE");
            return;
        }

        entity.IsDeleted = true;
        entity.ModifiedBy_FK = req.UserId;
        entity.ModifiedDate = DateTime.Now;
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
