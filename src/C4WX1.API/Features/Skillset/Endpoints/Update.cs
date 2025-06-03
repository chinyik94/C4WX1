using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Skillset.Dtos;
using C4WX1.API.Features.Skillset.Mappers;

namespace C4WX1.API.Features.Skillset.Endpoints;

public class UpdateSkillsetSumamry
    : C4WX1UpdateSummary<Database.Models.Code>
{

}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateSkillsetDto, UpdateSkillsetMapper>
{
    public override void Configure()
    {
        Put("skillset/{id}");
        Summary(new UpdateSkillsetSumamry());
    }

    public override async Task HandleAsync(UpdateSkillsetDto req, CancellationToken ct)
    {
        var isDuplicate = await dbContext.Code
            .Where(x => !x.IsDeleted
                && x.CodeName == req.CodeName
                && x.CodeTypeId_FK == CodetableTypeKeys.Skillset
                && x.CodeId != req.Id)
            .AnyAsync(ct);
        if (isDuplicate)
        {
            ThrowError("DUPLICATE_NAME");
            return;
        }
        var entity = await dbContext.Code
            .Include(x => x.ServiceSkillsetSkillsetID_FKNavigation)
            .Where(x => !x.IsDeleted
                && x.CodeId == req.Id)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        entity = Map.UpdateEntity(req, entity);
        var servicesToRemove = entity.UserSkillset
            .Where(x => !req.Services.Contains(x.CodeID_FK))
            .ToList();
        foreach (var service in servicesToRemove)
        {
            entity.UserSkillset.Remove(service);
        }
        var currentServiceIds = entity.UserSkillset
            .Select(x => x.CodeID_FK)
            .ToHashSet();
        var servicesToAdd = req.Services.Except(currentServiceIds).ToList();
        var newServices = await dbContext.Code
            .Where(x => !x.IsDeleted
                && servicesToAdd.Contains(x.CodeId)
                && x.CodeTypeId_FK == CodetableTypeKeys.ServiceRequired)
            .ToListAsync(ct);
        if (newServices.Count != servicesToAdd.Count)
        {
            ThrowError("INVALID_SERVICES");
            return;
        }
        foreach (var service in newServices)
        {
            entity.ServiceSkillsetSkillsetID_FKNavigation.Add(new ServiceSkillset
            {
                ServiceID_FK = service.CodeId,
                SkillsetID_FK = entity.CodeId
            });
        }
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
