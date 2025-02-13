using C4WX1.API.Features.Activity.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.Activity.Mappers
{
    public class ActivityCreateMapper : RequestMapper<CreateActivityDto, Database.Models.Activity>
    {
        public override Database.Models.Activity ToEntity(CreateActivityDto r) => new()
        {
            ActivityDetail = r.ActivityDetail,
            CreatedBy_FK = r.UserId,
            CreatedDate = DateTime.Now,
            DiseaseID_FK = r.DiseaseID_FK,
            DiseaseSubInfoID_FK = r.DiseaseSubInfoID_FK,
            ProblemListID_FK = r.ProblemListID_FK,
            IsDeleted = false,
        };
    }
}
