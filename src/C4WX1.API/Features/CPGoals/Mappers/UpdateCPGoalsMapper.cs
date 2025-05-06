using C4WX1.API.Features.CPGoals.Dtos;

namespace C4WX1.API.Features.CPGoals.Mappers;

public class UpdateCPGoalsMapper
    : RequestMapper<UpdateCPGoalsDto, Database.Models.CPGoals>
{
    public override Database.Models.CPGoals UpdateEntity(
        UpdateCPGoalsDto r, 
        Database.Models.CPGoals e)
    {
        e.CPGoalsInfo = r.CPGoalsInfo;
        e.DiseaseID_FK = r.DiseaseID_FK;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        return e;
    }
}
