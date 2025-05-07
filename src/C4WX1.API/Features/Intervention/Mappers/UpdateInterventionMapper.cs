using C4WX1.API.Features.Intervention.Dtos;

namespace C4WX1.API.Features.Intervention.Mappers;

public class UpdateInterventionMapper
    : RequestMapper<UpdateInterventionDto, Database.Models.Intervention>
{
    public override Database.Models.Intervention UpdateEntity(
        UpdateInterventionDto r, 
        Database.Models.Intervention e)
    {
        e.InterventionInfo = r.InterventionInfo;
        e.DiseaseID_FK = r.DiseaseID_FK;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        return e;
    }
}
