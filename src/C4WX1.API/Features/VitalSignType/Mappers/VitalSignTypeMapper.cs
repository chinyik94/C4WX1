using C4WX1.API.Features.VitalSignType.Dtos;

namespace C4WX1.API.Features.VitalSignType.Mappers;

public class VitalSignTypeMapper
    : ResponseMapper<VitalSignTypeDto, VitalSignTypes>
{
    public override VitalSignTypeDto FromEntity(VitalSignTypes e)
        => new()
        {
            Id = e.id,
            Name = e.name
        };
}
