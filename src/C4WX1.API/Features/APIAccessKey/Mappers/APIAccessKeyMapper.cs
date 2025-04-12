using C4WX1.API.Features.APIAccessKey.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.APIAccessKey.Mappers;

public class APIAccessKeyMapper : ResponseMapper<APIAccessKeyDto, Database.Models.APIAccessKey>
{
    public override APIAccessKeyDto FromEntity(Database.Models.APIAccessKey e) => new()
    {
        APIAccessKeyID = e.APIAccessKeyID,
        TokenCode = e.TokenCode,
        AccessKey = e.AccessKey,
        ExpiryDate = e.ExpiryDate,
        CreatedDate = e.CreatedDate,
        UpdatedDate = e.UpdatedDate,
        UserId_FK = e.UserId_FK
    };
}
