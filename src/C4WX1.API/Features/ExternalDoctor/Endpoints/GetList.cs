using C4WX1.API.Features.C4WImage.Extensions;
using C4WX1.API.Features.ExternalDoctor.Dtos;
using C4WX1.API.Features.ExternalDoctor.Extensions;
using C4WX1.API.Features.ExternalDoctor.Mappers;
using C4WX1.API.Features.ExternalDoctor.Repositories;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.ExternalDoctor.Endpoints;

public class GetExternalDoctorListSummary : EndpointSummary
{
    public GetExternalDoctorListSummary()
    {
        Summary = "Get a list of external doctors";
        Description = "Get a filtered, sorted and paged list of external doctors";
        Responses[200] = "External doctors retrieved successfully";
    }
}

public class GetList(
    THCC_C4WDEVContext dbContext,
    IExternalDoctorRepository repository)
    : Endpoint<GetExternalDoctorListDto, IEnumerable<ExternalDoctorDto>, ExternalDoctorMapper>
{
    public override void Configure()
    {
        Get("/external-doctor");
        Summary(new GetExternalDoctorListSummary());
    }

    public override async Task HandleAsync(GetExternalDoctorListDto req, CancellationToken ct)
    {
        var pageIndex = req.PageIndex ?? PaginationDefaults.Index;
        var pageSize = req.PageSize ?? PaginationDefaults.Size;
        var startRowIndex = Math.Max(0, (pageIndex - 1) * pageSize);

        var query = dbContext.ExternalDoctor
            .Include(x => x.ClinicianTypeID_FKNavigation)
            .Where(x => !x.IsDeleted);
        if (!string.IsNullOrEmpty(req.Search))
        {
            query = query.Where(x => x.Name.Contains(req.Search)
                || (x.ClinicianTypeID_FKNavigation != null && x.ClinicianTypeID_FKNavigation.UserType1.Contains(req.Search))
                || (!string.IsNullOrWhiteSpace(x.Email) && x.Email.Contains(req.Search))
                || (!string.IsNullOrWhiteSpace(x.Contact) && x.Contact.Contains(req.Search)));
        }

        if (query == null)
        {
            await SendOkAsync([], cancellation: ct);
            return;
        }

        var dtos = await query
            .Sort(req.OrderBy)
            .Skip(startRowIndex)
            .Take(pageSize)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        var externalDoctorIds = dtos.Select(x => x.ExternalDoctorID).ToArray();
        var canDeleteDict = await repository.BatchCanDeleteAsync(externalDoctorIds);
        foreach (var dto in dtos)
        {
            dto.CanDelete = canDeleteDict.TryGetValue(dto.ExternalDoctorID, out var canDelete)
                && canDelete;
        }
        await SendOkAsync(dtos, cancellation: ct);
    }
}
