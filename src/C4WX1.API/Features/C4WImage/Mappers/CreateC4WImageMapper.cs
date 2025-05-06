using C4WX1.API.Features.C4WImage.Dtos;

namespace C4WX1.API.Features.C4WImage.Mappers;

public class CreateC4WImageMapper
    : RequestMapper<CreateC4WImageDto, Database.Models.C4WImage>
{
    public override Database.Models.C4WImage ToEntity(CreateC4WImageDto r) => new()
    {
        WoundImageName = r.WoundImageName,
        WoundImageData = r.WoundImageData,
        WoundBedImageName = r.WoundBedImageName,
        WoundBedImageData = r.WoundBedImageData,
        TissueImageName = r.TissueImageName,
        TissueImageData = r.TissueImageData,
        DepthImageName = r.DepthImageName,
        DepthImageData = r.DepthImageData,
        CreatedBy_FK = r.UserId,
        CreatedDate = DateTime.Now
    };
}
