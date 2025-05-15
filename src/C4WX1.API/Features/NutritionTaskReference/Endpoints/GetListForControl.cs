using C4WX1.API.Features.NutritionTaskReference.Dtos;
using C4WX1.API.Features.Security;
using C4WX1.API.Features.Shared.Extensions;
using C4WX1.API.Features.SysConfig.Constants;
using System.Text;

namespace C4WX1.API.Features.NutritionTaskReference.Endpoints;

public class GetNutritionTaskReferenceListForControlSummary
    : C4WX1GetListSummary<Database.Models.NutritionTaskReference>
{

}

public class GetListForControl(
    THCC_C4WDEVContext dbContext,
    ISecurityService securityService)
    : Endpoint<GetNutritionTaskReferenceListByTypeDto, IEnumerable<NutritionTaskReferenceDto>>
{
    public override void Configure()
    {
        Get("nutrition-task-reference/type/{type}");
        Summary(new GetNutritionTaskReferenceListForControlSummary());
    }

    public override async Task HandleAsync(GetNutritionTaskReferenceListByTypeDto req, CancellationToken ct)
    {
        var siteUrl = await dbContext.SysConfig
            .Where(x => x.ConfigName == SysConfigNames.SiteUrl)
            .Select(x => x.ConfigValue)
            .FirstOrDefaultAsync(ct);

        var dtos = await dbContext.NutritionTaskReference
            .Include(x => x.CodeId_FKNavigation)
            .Where(x => !x.IsDeleted
                && x.CodeId_FK == req.Type)
            .Select(x => new NutritionTaskReferenceDto
            {
                CodeId_FK = x.CodeId_FK,
                ReferenceID = x.ReferenceID,
                Value = x.Value,
                ReferenceDetail = x.CodeId_FKNavigation.CodeName,
                ReferenceImage = x.ReferenceImage,
            })
            .ToListAsync(ct);

        foreach (var dto in dtos)
        {
            var encryptedPath = securityService.Encrypt($"~/upload_files/nutrition/{dto.ReferenceImage}");
            var sb = new StringBuilder();
            sb.Append(siteUrl)
                .Append("/helper?command=getimage&width=55&d=")
                .Append(encryptedPath.EncodeToHtml());
            dto.ReferenceImage = sb.ToString();
        }
        await SendOkAsync(dtos, ct);
    }
}
