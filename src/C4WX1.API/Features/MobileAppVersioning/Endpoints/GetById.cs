using C4WX1.API.Features.MobileAppVersioning.Dtos;
using C4WX1.API.Features.MobileAppVersioning.Mappers;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.MobileAppVersioning.Endpoints;

public class GetMobileAppVersioningByIdSummary
    : C4WX1GetByIdSummary<Database.Models.MobileAppVersioning>
{

}

public class GetById(THCC_C4WDEVContext dbContext)
    : Endpoint<GetByIdDto, MobileAppVersioningDto, MobileAppVersioningMapper>
{
    public override void Configure()
    {
        Get("mobile-app-versioning/{id}");
        Summary(new GetMobileAppVersioningByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.MobileAppVersioning
            .Where(x => x.MobileVersionId == req.Id
                && !(x.IsDeleted ?? false))
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        if (dto == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        dto.CreatedBy = await dbContext.Users
            .Where(x => x.UserId == dto.CreatedBy_FK)
            .Select(x => new MobileAppVersioningUserDto
            {
                UserId = x.UserId,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                Photo = x.Photo
            })
            .FirstOrDefaultAsync(ct);
        dto.ModifiedBy = await dbContext.Users
            .Where(x => x.UserId == dto.ModifiedBy_FK)
            .Select(x => new MobileAppVersioningUserDto
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
