using C4WX1.API.Features.Activity.Dtos;

namespace C4WX1.API.Features.Activity.Mappers;

public class UpdateActivityMapper 
    : RequestMapper<UpdateActivityDto, Database.Models.Activity>
{
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
