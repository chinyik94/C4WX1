using C4WX1.API.Features.DischargeSummaryReport.Dtos;
using C4WX1.API.Features.Shared.Constants;
using FastEndpoints;

namespace C4WX1.API.Features.DischargeSummaryReport.Mappers
{
    public class CreateDischargeSummaryReportMapper
        : RequestMapper<CreateDischargeSummaryReportDto, Database.Models.DischargeSummaryReport>
    {
        public override Database.Models.DischargeSummaryReport ToEntity(CreateDischargeSummaryReportDto r)
            => new()
            {
                DischargeDate = r.DischargeDate,
                Status = Statuses.Active,
                PatientID_FK = r.PatientID_FK,
                VisitDateEnd = r.VisitDateEnd,
                VisitDateStart = r.VisitDateStart,
                VisitedBy_FK = r.VisitedBy_FK,
                SummaryCaseNote = r.SummaryCaseNote,
                CreatedBy_FK = r.UserId,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };
    }
}
