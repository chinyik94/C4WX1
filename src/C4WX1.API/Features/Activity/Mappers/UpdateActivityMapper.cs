using C4WX1.API.Features.Activity.Dtos;

namespace C4WX1.API.Features.Activity.Mappers;

/// <summary>
/// Direct Update Activity API DTO to Activty DB Entity Mapper.
/// </summary>
public class UpdateActivityMapper 
    : RequestMapper<UpdateActivityDto, Database.Models.Activity>
{
    /// <summary>
    /// Convert Update Activity API DTO to Activity DB Entity.
    /// </summary>
    /// <param name="r">Update Activity API DTO</param>
    /// <param name="e">Activity Entity</param>
    /// <returns>An updated Activity Entity</returns>
    public override Database.Models.Activity UpdateEntity(
        UpdateActivityDto r, 
        Database.Models.Activity e)
    {
        e.ActivityDetail = r.ActivityDetail;
        e.DiseaseID_FK = r.DiseaseID_FK;
        e.DiseaseSubInfoID_FK = r.DiseaseSubInfoID_FK;
        e.ProblemListID_FK = r.ProblemListID_FK;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        return e;
    }
}
