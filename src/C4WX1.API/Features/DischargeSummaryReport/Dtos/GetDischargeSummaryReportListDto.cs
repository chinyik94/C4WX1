using C4WX1.API.Features.Shared.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.DischargeSummaryReport.Dtos
{
    public class GetDischargeSummaryReportListDto : GetListDto
    {
        [QueryParam]
        public int PatientId { get; set; }
    }
}
