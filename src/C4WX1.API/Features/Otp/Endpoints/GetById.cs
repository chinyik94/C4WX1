using C4WX1.API.Features.Otp.Dtos;
using C4WX1.API.Features.Otp.Mappers;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Otp.Endpoints;

public class GetOtpByIdSummary
    : C4WX1GetByIdSummary<Database.Models.Otp>
{

}

public class GetById(THCC_C4WDEVContext dbContext)
    : Endpoint<GetByIdDto, OtpDto, OtpMapper>
{
    public override void Configure()
    {
        Get("otp/{id}");
        Summary(new GetOtpByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.Otp
            .Where(x => x.OtpId == req.Id)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);
        await ((dto == null)
            ? SendNotFoundAsync(ct)
            : SendOkAsync(dto, ct));
    }
}
