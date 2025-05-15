using C4WX1.API.Features.NutritionTaskReference.Dtos;

namespace C4WX1.API.Features.NutritionTaskReference.Mappers;

public class NutritionTaskReferenceMapper
    : ResponseMapper<NutritionTaskReferenceDto, Database.Models.NutritionTaskReference>
{
    public override NutritionTaskReferenceDto FromEntity(Database.Models.NutritionTaskReference e)
        => new()
        {
            ReferenceID = e.ReferenceID,
            CodeId_FK = e.CodeId_FK,
            ReferenceDetail = e.CodeId_FKNavigation.CodeName,
            Value = e.Value,
            ReferenceImage = e.ReferenceImage,
            GroupID_FK = e.CodeId_FKNavigation.CodeTypeId_FK,
            GroupName = e.CodeId_FKNavigation.CodeTypeId_FKNavigation.CodeTypeName,
            CreatedDate = e.CreatedDate,
            CreatedBy_FK = e.CreatedBy_FK
        };
}
