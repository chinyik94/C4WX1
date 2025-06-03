using C4WX1.API.Features.ResidentAssessmentCategory.Dtos;

namespace C4WX1.API.Features.ResidentAssessmentCategory.Mappers;

public class ResidentAssessmentCategoryMapper
    : ResponseMapper<ResidentAssessmentCategoryDto, Database.Models.ResidentAssessmentCategory>
{
    public override ResidentAssessmentCategoryDto FromEntity(Database.Models.ResidentAssessmentCategory e)
        => new()
        {
            ResidentAssessmentCategoryID = e.ResidentAssessmentCategoryID,
            Category1Description = e.Category1Description,
            Category1Recommendation = e.Category1Recommendation,
            Category2Description = e.Category2Description,
            Category2Recommendation = e.Category2Recommendation,
            Category3Description = e.Category3Description,
            Category3Recommendation = e.Category3Recommendation,
            Category4Description = e.Category4Description,
            Category4Recommendation = e.Category4Recommendation,
            IsDeleted = e.IsDeleted,
            CreatedDate = e.CreatedDate,
            CreatedBy_FK = e.CreatedBy_FK,
            ModifiedDate = e.ModifiedDate,
            ModifiedBy_FK = e.ModifiedBy_FK
        };
}
