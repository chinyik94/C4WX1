using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.Features.Skillset.Dtos;
using C4WX1.API.Features.Skillset.Mappers;

namespace C4WX1.API.Features.Skillset.Endpoints;

public class GetSkillsetByIdSummary
    : C4WX1GetByIdSummary<Database.Models.Code>
{

}

public class GetById(THCC_C4WDEVContext dbContext)
    : Endpoint<GetByIdDto, SkillsetDto, SkillsetMapper>
{
    public override void Configure()
    {
        Get("skillset/{id}");
        Summary(new GetSkillsetByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.Code
            .Include(x => x.ServiceSkillsetSkillsetID_FKNavigation)
                .ThenInclude(x => x.ServiceID_FKNavigation)
            .Where(x => !x.IsDeleted
                && x.CodeId == req.Id
                && x.CodeTypeId_FK == CodetableTypeKeys.Skillset)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        await ((dto == null)
            ? SendNotFoundAsync(ct)
            : SendOkAsync(dto, ct));
    }
}
