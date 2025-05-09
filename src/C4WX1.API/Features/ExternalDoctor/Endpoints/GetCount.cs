using C4WX1.API.Features.ExternalDoctor.Dtos;

namespace C4WX1.API.Features.ExternalDoctor.Endpoints;

public class GetExternalDoctorCountSummary 
    : C4WX1GetCountSummary<Database.Models.ExternalDoctor>
{
    public GetExternalDoctorCountSummary() { }
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
