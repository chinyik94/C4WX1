using C4WX1.API.Features.NutritionTaskReference.Dtos;

namespace C4WX1.API.Features.NutritionTaskReference.Mappers;

public class NutritionTaskReferenceGroupMapper
    : ResponseMapper<NutritionTaskReferenceGroupDto, Database.Models.CodeType>
{
    public override NutritionTaskReferenceGroupDto FromEntity(CodeType e)
        => new()
        {
            GroupID = e.CodeTypeId,
            GroupName = e.CodeTypeName
        };
}
