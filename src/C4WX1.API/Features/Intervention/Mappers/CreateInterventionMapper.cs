using C4WX1.API.Features.Intervention.Dtos;

namespace C4WX1.API.Features.Intervention.Mappers;

public class CreateInterventionMapper
    : RequestMapper<CreateInterventionDto, Database.Models.Intervention>
{
    public override Database.Models.Intervention ToEntity(CreateInterventionDto r)
        => new()
        {
            InterventionInfo = r.InterventionInfo,
            DiseaseID_FK = r.DiseaseID_FK,
            IsDeleted = false,
            CreatedBy_FK = r.UserId,
            CreatedDate = DateTime.Now
        };
}
