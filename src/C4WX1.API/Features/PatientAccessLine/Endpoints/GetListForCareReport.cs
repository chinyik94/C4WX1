using C4WX1.API.Features.PatientAccessLine.Dtos;
using C4WX1.API.Features.PatientAccessLine.Mappers;

namespace C4WX1.API.Features.PatientAccessLine.Endpoints;

public class GetPatientAccessLineListForCareReportSummary
    : C4WX1GetListSummary<Database.Models.PatientAccessLine>
{

}

public class GetListForCareReport(THCC_C4WDEVContext dbContext)
    : Endpoint<GetPatientAccessLineListForCareReportDto, IEnumerable<PatientAccessLineDto>, PatientAccessLineMapper>
{
    public override void Configure()
    {
        Get("patient-access-line/list-for-care-report/{careReportID}");
        Summary(new GetPatientAccessLineListForCareReportSummary());
    }

    public override async Task HandleAsync(GetPatientAccessLineListForCareReportDto req, CancellationToken ct)
    {
        var dtos = await dbContext.PatientAccessLine
            .Where(x => !x.IsDeleted
                && x.CareReportID_FK == req.CareReportID)
            .Select(x => Map.FromEntity(x))
            .ToListAsync(ct);
        await SendOkAsync(dtos, ct);
    }
}
