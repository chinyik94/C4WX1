using C4WX1.API.Features.Language.Dtos;

namespace C4WX1.API.Features.Language.Mappers;

public class LanguageMapper : ResponseMapper<LanguageDto, Database.Models.Language>
{
    public override LanguageDto FromEntity(Database.Models.Language e) => new()
    {
        LanguageId = e.LanguageId,
        Name = e.Name,
        FullName = e.FullName
    };
}
