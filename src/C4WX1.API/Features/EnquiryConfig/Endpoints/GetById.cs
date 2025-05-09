using C4WX1.API.Features.EnquiryConfig.Dtos;
using C4WX1.API.Features.EnquiryConfig.Mappers;
using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.EnquiryConfig.Endpoints;

public class GetEnquiryConfigByIdSummary 
    : C4WX1GetByIdSummary<Database.Models.EnquiryConfig>
{
    public GetEnquiryConfigByIdSummary() { }
}

public class GetById(THCC_C4WDEVContext dbContext)
    : Endpoint<GetByIdDto, EnquiryConfigDto, EnquiryConfigMapper>
{
    public override void Configure()
    {
        Get("enquiry-config/{id}");
        Summary(new GetEnquiryConfigByIdSummary());
    }

    public override async Task HandleAsync(GetByIdDto req, CancellationToken ct)
    {
        var dto = await dbContext.EnquiryConfig
            .Where(x => !(x.IsDeleted ?? false) && x.EnquiryConfigID == req.Id)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);

        await ((dto == null)
            ? SendNotFoundAsync(ct)
            : SendOkAsync(dto, cancellation: ct));
    }
}
