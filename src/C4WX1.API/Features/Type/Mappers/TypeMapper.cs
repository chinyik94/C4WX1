using C4WX1.API.Features.Type.Dtos;

namespace C4WX1.API.Features.Type.Mappers;

public class TypeMapper
    : ResponseMapper<TypeDto, Types>
{
    public override TypeDto FromEntity(Types e)
        => new()
        {
            Code = e.code,
            CodeValue = e.codeValue,
            ParentCode = e.parentCode,
            Ordering = e.ordering,
            Created = e.created,
            Updated = e.updated,
        };
}
