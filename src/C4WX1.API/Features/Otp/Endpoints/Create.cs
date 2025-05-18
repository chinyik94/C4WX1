using C4WX1.API.Features.Generator;
using C4WX1.API.Features.Otp.Dtos;
using C4WX1.API.Features.Otp.Mappers;

namespace C4WX1.API.Features.Otp.Endpoints;

public class CreateOtpSummary
    : C4WX1CreateSummary<Database.Models.Otp>
{

}

public class Create(
    THCC_C4WDEVContext dbContext,
    IPasswordGenerator passwordGenerator)
    : Endpoint<CreateOtpDto, OtpDto, OtpMapper>
{
    public override void Configure()
    {
        Post("otp");
        Summary(new CreateOtpSummary());
    }

    public override async Task HandleAsync(CreateOtpDto req, CancellationToken ct)
    {
        var password = passwordGenerator.Generate(true, true, 6, 6);
        var entity = new Database.Models.Otp
        {
            UserId = req.UserId,
            Password = password,
            CreatedDate = DateTime.Now
        };
        await dbContext.Otp.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
        var dto = Map.FromEntity(entity);
        await SendOkAsync(dto, ct);
    }
}
