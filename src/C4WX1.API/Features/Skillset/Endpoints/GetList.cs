using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.Features.Shared.Extensions;
using C4WX1.API.Features.Skillset.Dtos;
using C4WX1.API.Features.Skillset.Extensions;
using C4WX1.API.Features.Skillset.Mappers;

namespace C4WX1.API.Features.Skillset.Endpoints;

public class GetSkillsetListSummary
    : C4WX1GetListSummary<Database.Models.Code>
{

}

public class GetList(THCC_C4WDEVContext dbContext)
    : Endpoint<GetListDto, IEnumerable<SkillsetDto>, SkillsetMapper>
{
    public override void Configure()
    {
        Get("skillset");
        Summary(new GetSkillsetListSummary());
    }

    public override async Task HandleAsync(GetListDto req, CancellationToken ct)
    {
        var (startRowIndex, pageSize) = req.GetPaginationDetails();
        var dtos = await dbContext.Code
            .Where(x => !x.IsDeleted
                && x.CodeTypeId_FK == CodetableTypeKeys.Skillset)
            .Sort(req.OrderBy)
            .Skip(startRowIndex)
            .Take(pageSize)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
