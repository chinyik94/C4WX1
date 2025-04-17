using C4WX1.API.Features.CPGoals.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.CPGoals.Mappers;

public class CreateCPGoalsMapper
    : RequestMapper<CreateCPGoalsDto, Database.Models.CPGoals>
{
    public override Database.Models.CPGoals ToEntity(CreateCPGoalsDto r) => new()
    {
        CPGoalsInfo = r.CPGoalsInfo,
        DiseaseID_FK = r.DiseaseID_FK,
        CreatedBy_FK = r.UserId,
        CreatedDate = DateTime.Now
    };
}
