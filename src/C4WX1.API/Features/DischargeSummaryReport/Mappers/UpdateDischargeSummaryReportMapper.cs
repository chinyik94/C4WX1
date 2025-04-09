using C4WX1.API.Features.DischargeSummaryReport.Dtos;
using C4WX1.API.Features.Shared.Constants;
using FastEndpoints;

namespace C4WX1.API.Features.DischargeSummaryReport.Mappers
{
    public class UpdateDischargeSummaryReportMapper
        : RequestMapper<UpdateDischargeSummaryReportDto, Database.Models.DischargeSummaryReport>
    {
        public override Database.Models.DischargeSummaryReport UpdateEntity(
            UpdateDischargeSummaryReportDto r, 
            Database.Models.DischargeSummaryReport e)
        {
            e.DischargeDate = r.DischargeDate;
            e.Status = Statuses.Active;
            e.PatientID_FK = r.PatientID_FK;
            e.VisitDateEnd = r.VisitDateEnd;
            e.VisitDateStart = r.VisitDateStart;
            e.VisitedBy_FK = r.VisitedBy_FK;
            e.SummaryCaseNote = r.SummaryCaseNote;
            e.ModifiedBy_FK = r.UserId;
            e.ModifiedDate = DateTime.Now;

            return e;
        }
    }
}
