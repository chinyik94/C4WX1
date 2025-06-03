using C4WX1.API.Features.Skillset.Dtos;

namespace C4WX1.API.Features.Skillset.Mappers;

public class UpdateSkillsetMapper
    : RequestMapper<UpdateSkillsetDto, Database.Models.Code>
{
    public override Code UpdateEntity(UpdateSkillsetDto r, Code e)
    {
        e.CodeName = r.CodeName;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        return e;
    }
}
