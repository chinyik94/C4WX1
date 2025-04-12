using C4WX1.API.Features.EnquiryConfig.Dtos;
using C4WX1.API.Features.EnquiryConfig.Mappers;
using C4WX1.API.Features.Shared.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.EnquiryConfig.Endpoints;

public class GetEnquiryConfigByIdSummary : EndpointSummary
{
    public GetEnquiryConfigByIdSummary()
    {
        Summary = "Get Enquiry Config";
        Description = "Get Enquiry Config by its ID";
        Responses[200] = "Enquiry Config retrieved successfully";
        Responses[404] = "Enquiry Config not found";
    }
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
