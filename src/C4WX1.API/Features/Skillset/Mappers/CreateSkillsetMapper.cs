using C4WX1.API.Features.Shared.Constants;
using C4WX1.API.Features.Skillset.Dtos;

namespace C4WX1.API.Features.Skillset.Mappers;

public class CreateSkillsetMapper
    : RequestMapper<CreateSkillsetDto, Database.Models.Code>
{
    public override Code ToEntity(CreateSkillsetDto r)
        => new()
        {
            CodeName = r.CodeName,
            CodeTypeId_FK = CodetableTypeKeys.Skillset,
            CreatedBy_FK = r.UserId,
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };
}
