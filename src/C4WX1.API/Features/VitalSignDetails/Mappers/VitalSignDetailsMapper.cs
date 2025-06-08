using C4WX1.API.Features.VitalSignDetails.Dtos;

namespace C4WX1.API.Features.VitalSignDetails.Mappers;

public class VitalSignDetailsMapper
    : ResponseMapper<VitalSignDetailsDto, Database.Models.VitalSignDetails>
{
    public override VitalSignDetailsDto FromEntity(Database.Models.VitalSignDetails e)
        => new()
        {
            Id = e.id.ToString(),
            VitalSignTypeId = e.vitalSignTypeId.ToString(),
            VitalSignId = e.vitalSignId.ToString(),
            DetailValue = e.detailValue.ToString(),
            VitalSignType = new()
            {
                Id = e.vitalSignTypeId.ToString(),
                Name = e.vitalSignType.name
            }
        };
}
