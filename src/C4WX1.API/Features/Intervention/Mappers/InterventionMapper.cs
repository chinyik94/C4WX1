using C4WX1.API.Features.Intervention.Dtos;

namespace C4WX1.API.Features.Intervention.Mappers;

public class InterventionMapper
    : ResponseMapper<InterventionDto, Database.Models.Intervention>
{
    public override InterventionDto FromEntity(Database.Models.Intervention e)
        => new()
        {
            InterventionID = e.InterventionID,
            InterventionInfo = e.InterventionInfo,
            DiseaseID_FK = e.DiseaseID_FK,
            IsDeleted = e.IsDeleted,
            Disease = new InterventionDiseaseDto
            {
                DiseaseID = e.DiseaseID_FK,
                DiseaseName = e.DiseaseID_FKNavigation.DiseaseName
            }
        };
}
