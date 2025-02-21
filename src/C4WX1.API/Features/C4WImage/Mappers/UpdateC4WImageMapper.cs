using C4WX1.API.Features.C4WImage.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.C4WImage.Mappers
{
    public class UpdateC4WImageMapper
        : RequestMapper<UpdateC4WImageDto, Database.Models.C4WImage>
    {
        public override Database.Models.C4WImage ToEntity(UpdateC4WImageDto r) => new()
        {
            WoundImageName = r.WoundImageName,
            WoundImageData = r.WoundImageData,
            WoundBedImageName = r.WoundBedImageName,
            WoundBedImageData = r.WoundBedImageData,
            TissueImageName = r.TissueImageName,
            TissueImageData = r.TissueImageData,
            DepthImageName = r.DepthImageName,
            DepthImageData = r.DepthImageData,
            ModifiedBy_FK = r.UserId,
            ModifiedDate = DateTime.Now
        };
    }
}
