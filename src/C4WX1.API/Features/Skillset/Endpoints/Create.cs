using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Skillset.Dtos;
using C4WX1.API.Features.Skillset.Mappers;

namespace C4WX1.API.Features.Skillset.Endpoints;

public class CreateSkillsetSummary
    : C4WX1CreateSummary<Database.Models.Code>
{

}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateSkillsetDto, int, CreateSkillsetMapper>
{
    public override void Configure()
    {
        Post("skillset");
        Summary(new CreateSkillsetSummary());
    }

    public override async Task HandleAsync(CreateSkillsetDto req, CancellationToken ct)
    {
        var isDuplicate = await dbContext.Code
            .Where(x => !x.IsDeleted
                && x.CodeName == req.CodeName
                && x.CodeTypeId_FK == CodetableTypeKeys.Skillset)
            .AnyAsync(ct);
        if (isDuplicate)
        {
            ThrowError("DUPLICATE_NAME");
            return;
        }
        var entity = Map.ToEntity(req);
        var validServicesCount = await dbContext.Code
            .Where(x => !x.IsDeleted
                && req.Services.Contains(x.CodeId)
                && x.CodeTypeId_FK == CodetableTypeKeys.ServiceRequired)
            .CountAsync(ct);
        if (validServicesCount != req.Services.Count)
        {
            ThrowError("INVALID_SERVICES");
            return;
        }
        foreach (var serviceId in req.Services)
        {
            entity.ServiceSkillsetSkillsetID_FKNavigation.Add(new ServiceSkillset
            {
                ServiceID_FK = serviceId
            });
        }
        await dbContext.Code.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.CodeId, ct);
    }
}
