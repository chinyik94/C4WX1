using C4WX1.API.Features.VitalSignDetails.Dtos;
using C4WX1.API.Features.VitalSignDetails.Mappers;

namespace C4WX1.API.Features.VitalSignDetails.Endpoints;
public class GetVitalSignDetailsByPatientIdSummary
    : C4WX1GetListSummary<Database.Models.VitalSignDetails>
{

}

public class GetByPatientId(THCC_C4WDEVContext dbContext)
    : Endpoint<GetVitalSignDetailsByPatientIdDto, IEnumerable<VitalSignDetailsDto>, VitalSignDetailsMapper>
{
    public override void Configure()
    {
        Get("vital-sign-details/patient");
        Summary(new GetVitalSignDetailsByPatientIdSummary());
    }

    public override async Task HandleAsync(GetVitalSignDetailsByPatientIdDto req, CancellationToken ct)
    {
        var latestDetails = await dbContext.VitalSignDetails
            .Include(x => x.vitalSign)
            .Include(x => x.vitalSignType)
            .Where(x => x.vitalSign.patientId == req.PatientId
                && !x.vitalSign.isDeleted)
            .GroupBy(x => x.vitalSignTypeId)
            .Select(x => x
                .OrderByDescending(y => y.id)
                .FirstOrDefault())
            .ToListAsync(ct);

        var dtos = latestDetails
            .Where(x => x != null)
            .Select(x => new VitalSignDetailsDto
            {
                Id = x.id.ToString(),
                VitalSignTypeId = x.vitalSignTypeId.ToString(),
                VitalSignId = x.vitalSignId.ToString(),
                DetailValue = x.detailValue.ToString(),
                VitalSignType = new VitalSignTypeDto
                {
                    Id = x.vitalSignTypeId.ToString(),
                    Name = x.vitalSignType.name
                }
            })
            .ToList();
        await SendOkAsync(dtos, ct);
    }
}
