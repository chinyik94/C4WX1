using C4WX1.API.Features.NutritionTaskReference.Dtos;

namespace C4WX1.API.Features.NutritionTaskReference.Mappers;

public class UpdateNutritionTaskReferenceMapper
    : RequestMapper<UpdateNutritionTaskReferenceDto, Database.Models.NutritionTaskReference>
{
    public override Database.Models.NutritionTaskReference UpdateEntity(
        UpdateNutritionTaskReferenceDto r, 
        Database.Models.NutritionTaskReference e)
    {
        e.ReferenceImage = r.ReferenceImage;
        e.Value = r.Value;
        e.CodeId_FKNavigation.CodeName = r.ReferenceDetail;
        e.ModifiedBy_FK = r.UserId;
        e.ModifiedDate = DateTime.Now;

        return e;
    }
}
