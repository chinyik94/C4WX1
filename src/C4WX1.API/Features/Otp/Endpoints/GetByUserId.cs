using C4WX1.API.Features.Otp.Dtos;
using C4WX1.API.Features.Otp.Mappers;

namespace C4WX1.API.Features.Otp.Endpoints;

public class GetOtpByUserIdSummary
    : C4WX1GetByIdSummary<Database.Models.Otp>
{

}

public class GetByUserId(THCC_C4WDEVContext dbContext)
    : Endpoint<GetOtpByUserIdDto, OtpDto, OtpMapper>
{
    public override void Configure()
    {
        Get("otp/user/{userId}");
        Summary(new GetOtpByUserIdSummary());
    }

    public override async Task HandleAsync(GetOtpByUserIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.Otp
            .Where(x => x.UserId == req.UserId)
            .OrderByDescending(x => x.OtpId)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        await ((dto == null)
            ? SendNotFoundAsync(ct)
            : SendOkAsync(dto, ct));
    }
}
