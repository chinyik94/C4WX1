using C4WX1.API.Features.C4WImage.Dtos;

namespace C4WX1.API.Features.C4WImage.Mappers;

public class UpdateC4WImageMapper
    : RequestMapper<UpdateC4WImageDto, Database.Models.C4WImage>
{
    public override Database.Models.C4WImage UpdateEntity(
        UpdateC4WImageDto r, 
        Database.Models.C4WImage e)
    {
        e.WoundImageName = r.WoundImageName;
        e.WoundImageData = r.WoundImageData;
        e.WoundBedImageName = r.WoundBedImageName;
        e.WoundBedImageData = r.WoundBedImageData;
        e.TissueImageName = r.TissueImageName;
        e.TissueImageData = r.TissueImageData;
        e.DepthImageName = r.DepthImageName;
        e.DepthImageData = r.DepthImageData;
        e.ModifiedBy_FK = r.UserId;

        return e;
    }
}
