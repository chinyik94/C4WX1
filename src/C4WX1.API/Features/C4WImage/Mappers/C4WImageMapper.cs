using C4WX1.API.Features.C4WImage.Dtos;

namespace C4WX1.API.Features.C4WImage.Mappers;

public class C4WImageMapper : ResponseMapper<C4WImageDto, Database.Models.C4WImage>
{
    public override C4WImageDto FromEntity(Database.Models.C4WImage e) => new()
    {
        C4WImageId = e.C4WImageId,
        WoundImageName = e.WoundImageName,
        WoundImageData = e.WoundImageData,
        WoundBedImageName = e.WoundBedImageName,
        WoundBedImageData = e.WoundBedImageData,
        TissueImageName = e.TissueImageName,
        TissueImageData = e.TissueImageData,
        DepthImageName = e.DepthImageName,
        DepthImageData = e.DepthImageData,
        CreatedDate = e.CreatedDate,
        CreatedBy_FK = e.CreatedBy_FK,
        ModifiedDate = e.ModifiedDate
    };
}
