using C4WX1.API.Features.DischargeSummaryReport.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.DischargeSummaryReport.Mappers
{
    public class DischargeSummaryReportMapper
        : ResponseMapper<DischargeSummaryReportDto, Database.Models.DischargeSummaryReport>
    {
        public override DischargeSummaryReportDto FromEntity(Database.Models.DischargeSummaryReport e) 
            => new()
            {
                CreatedBy_FK = e.CreatedBy_FK,
                PatientID_FK = e.PatientID_FK,
                CreatedDate = e.CreatedDate,
                DischargeDate = e.DischargeDate,
                DischargeSummaryReportID = e.DischargeSummaryReportId,
                IsDeleted = e.IsDeleted,
                ModifiedBy_FK = e.ModifiedBy_FK,
                ModifiedDate = e.ModifiedDate,
                Status = e.Status,
                SummaryCaseNote = e.SummaryCaseNote ?? string.Empty,
                VisitDateEnd = e.VisitDateEnd,
                VisitDateStart = e.VisitDateStart,
                VisitedBy_FK = e.VisitedBy_FK,
                AttachmentList = e.DischargeSummaryReportAttachment
                    .Select(x => new DischargeSummaryReportAttachmentDto
                    {
                        DischargeSummaryReportAttachmentID = x.DischargeSummaryReportAttachmentID,
                        Physical = x.Physical,
                        Filename = x.Filename,
                    })
                    .ToList()
            };
    }
}
