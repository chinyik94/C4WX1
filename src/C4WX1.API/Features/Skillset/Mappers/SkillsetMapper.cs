using C4WX1.API.Features.Skillset.Dtos;

namespace C4WX1.API.Features.Skillset.Mappers;

public class SkillsetMapper
    : ResponseMapper<SkillsetDto, Database.Models.Code>
{
    public override SkillsetDto FromEntity(Code e)
        => new()
        {
            CodeId = e.CodeId,
            CodeName = e.CodeName,
            Services = [.. e.ServiceSkillsetSkillsetID_FKNavigation
                .OrderBy(x => x.ServiceID_FKNavigation.CodeName)
                .Select(x => new SkillsetServiceDto
                {
                    CodeId = x.ServiceID_FK,
                    CodeName = x.ServiceID_FKNavigation.CodeName
                })]
        };
}