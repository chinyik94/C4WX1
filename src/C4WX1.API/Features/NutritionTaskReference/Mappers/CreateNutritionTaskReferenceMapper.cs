using C4WX1.API.Features.NutritionTaskReference.Dtos;

namespace C4WX1.API.Features.NutritionTaskReference.Mappers;

public class CreateNutritionTaskReferenceMapper
    : RequestMapper<CreateNutritionTaskReferenceDto, Database.Models.NutritionTaskReference>
{
    public override Database.Models.NutritionTaskReference ToEntity(CreateNutritionTaskReferenceDto r)
        => new()
        {
            ReferenceImage = r.ReferenceImage,
            Value = r.Value,
            CreatedBy_FK = r.UserId,
            CreatedDate = DateTime.Now,
            CodeId_FKNavigation = new Code
            {
                CodeName = r.ReferenceDetail,
                CodeTypeId_FK = r.GroupID_FK,
                IsSystemUsed = false,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                CreatedBy_FK = r.UserId
            }
        };
}
