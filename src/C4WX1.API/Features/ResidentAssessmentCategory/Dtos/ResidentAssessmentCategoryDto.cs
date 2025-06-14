﻿namespace C4WX1.API.Features.ResidentAssessmentCategory.Dtos;

public sealed class ResidentAssessmentCategoryDto
{
    public int ResidentAssessmentCategoryID { get; set; }
    public string Category1Description { get; set; } = null!;
    public string Category1Recommendation { get; set; } = null!;
    public string Category2Description { get; set; } = null!;
    public string Category2Recommendation { get; set; } = null!;
    public string Category3Description { get; set; } = null!;
    public string Category3Recommendation { get; set; } = null!;
    public string Category4Description { get; set; } = null!;
    public string Category4Recommendation { get; set; } = null!;
    public bool IsDeleted { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? CreatedBy_FK { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? ModifiedBy_FK { get; set; }
}
