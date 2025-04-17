using C4WX1.API.Features.CPGoals.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.CPGoals.Mappers;

public class CPGoalsMapper 
    : ResponseMapper<CPGoalsDto, Database.Models.CPGoals>
{
    public override CPGoalsDto FromEntity(Database.Models.CPGoals e) => new()
    {
        CPGoalsID = e.CPGoalsID,
        CPGoalsInfo = e.CPGoalsInfo,
        CPGoalsName = e.DiseaseID_FKNavigation.SystemID_FKNavigation.System
            + " - "
            + e.DiseaseID_FKNavigation.DiseaseName,
        DiseaseID_FK = e.DiseaseID_FK,
        IsDeleted = e.IsDeleted,
        Disease = new CPGoalsDiseaseDto
        {
            DiseaseName = e.DiseaseID_FKNavigation.DiseaseName
        }
    };
}
