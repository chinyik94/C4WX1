using C4WX1.API.Features.Activity.Dtos;

namespace C4WX1.API.Features.Activity.Mappers;

public class ActivityMapper 
    : ResponseMapper<ActivityDto, Database.Models.Activity>
{
    public override ActivityDto FromEntity(Database.Models.Activity e) => new()
    {
        ActivityID = e.ActivityID,
        ActivityDetail = e.ActivityDetail ?? string.Empty,
        CreatedBy_FK = e.CreatedBy_FK,
        CreatedDate = e.CreatedDate,
        DiseaseID_FK = e.DiseaseID_FK,
        DiseaseSubInfoID_FK = e.DiseaseSubInfoID_FK,
        IsDeleted = e.IsDeleted,
        ModifiedBy_FK = e.ModifiedBy_FK,
        ModifiedDate = e.ModifiedDate,
        ProblemListID_FK = e.ProblemListID_FK
    };
}
