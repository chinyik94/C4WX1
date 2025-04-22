using C4WX1.API.Features.ExternalDoctor.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.ExternalDoctor.Endpoints;

public class GetExternalDoctorCountSummary : EndpointSummary
{
    public GetExternalDoctorCountSummary()
    {
        Summary = "Get the count of external doctors";
        Description = "Get the count of external doctors";
        Responses[200] = "Count of external doctors retrieved successfully";
    }
}

public class GetCount(THCC_C4WDEVContext dbContext)
    : Endpoint<GetExternalDoctorCountDto, int>
{
    public override void Configure()
    {
        Get("/external-doctor/count");
        Summary(new GetExternalDoctorCountSummary());
    }

    public override async Task HandleAsync(GetExternalDoctorCountDto req, CancellationToken ct)
    {
        var count = await dbContext.ExternalDoctor
            .Include(x => x.ClinicianTypeID_FKNavigation)
            .Where(x => (string.IsNullOrWhiteSpace(req.Search) 
                || x.Name.Contains(req.Search)
                || (x.ClinicianTypeID_FKNavigation != null && x.ClinicianTypeID_FKNavigation.UserType1.Contains(req.Search))
                || (!string.IsNullOrWhiteSpace(x.Email) && x.Email.Contains(req.Search))
                || (!string.IsNullOrWhiteSpace(x.Contact) && x.Contact.Contains(req.Search))))
            .CountAsync(ct);
        await SendOkAsync(count, cancellation: ct);
    }
}
