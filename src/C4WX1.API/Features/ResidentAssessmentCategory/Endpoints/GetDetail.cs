using C4WX1.API.Features.ResidentAssessmentCategory.Dtos;
using C4WX1.API.Features.ResidentAssessmentCategory.Mappers;

namespace C4WX1.API.Features.ResidentAssessmentCategory.Endpoints;

public class GetResidentAssessmentCategoryResidentDetailSummary
    : C4WX1GetByIdSummary<Database.Models.ResidentAssessmentCategory>
{

}

public class GetDetail(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest<ResidentAssessmentCategoryDto, ResidentAssessmentCategoryMapper>
{
    public override void Configure()
    {
        Get("resident-assessment-category/detail");
        Summary(new GetResidentAssessmentCategoryResidentDetailSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var dto = await dbContext.ResidentAssessmentCategory
            .Where(x => !x.IsDeleted)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        await ((dto == null)
            ? SendNotFoundAsync(ct)
            : SendOkAsync(dto, ct));
    }
}
