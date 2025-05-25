using C4WX1.API.Features.RegisteredDeviceV2.Dtos;
using C4WX1.API.Features.RegisteredDeviceV2.Mappers;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.RegisteredDeviceV2.Endpoints;

public class GetRegisteredDeviceV2ByIdSummary
    : C4WX1GetByIdSummary<Database.Models.RegisteredDeviceV2>
{

}

public class GetById(THCC_C4WDEVContext dbContext)
    : Endpoint<GetByIdDto, RegisteredDeviceV2Dto, RegisteredDeviceV2Mapper>
{
    public override void Configure()
    {
        Get("registered-device-v2/{id}");
        Summary(new GetRegisteredDeviceV2ByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.RegisteredDeviceV2
            .Where(x => !x.IsDeleted
                && x.RegisteredDeviceID == req.Id)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        if (dto == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        dto.CreatedBy = await dbContext.Users
            .Where(x => x.UserId == dto.CreatedBy_FK)
            .Select(x => new RegisteredDeviceV2UserDto
            {
                UserId = x.UserId,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                Photo = x.Photo
            })
            .FirstOrDefaultAsync(ct);
        dto.ModifiedBy = await dbContext.Users
            .Where(x => x.UserId == dto.ModifiedBy_FK)
            .Select(x => new RegisteredDeviceV2UserDto
            {
                UserId = x.UserId,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                Photo = x.Photo
            })
            .FirstOrDefaultAsync(ct);
        await SendOkAsync(dto, ct);
    }
}
