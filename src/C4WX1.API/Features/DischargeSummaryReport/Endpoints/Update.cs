using C4WX1.API.Features.DischargeSummaryReport.Dtos;
using C4WX1.API.Features.DischargeSummaryReport.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.DischargeSummaryReport.Endpoints;

public class UpdateDischargeSummaryReportSummary : EndpointSummary
{
    public UpdateDischargeSummaryReportSummary()
    {
        Summary = "Update Discharge Summary Report";
        Description = "Update an existing Discharge Summary Report by its ID";
        ExampleRequest = new UpdateDischargeSummaryReportDto
        {
            Id = 1,
            DischargeDate = DateTime.Now,
            PatientID_FK = 1,
            VisitDateEnd = DateTime.Now,
            VisitDateStart = DateTime.Now,
            VisitedBy_FK = 1,
            SummaryCaseNote = "Updated-SummaryCaseNote",
            UserId = 1,
            AttachmentList =
            [
                new DischargeSummaryReportAttachmentDto
                {
                    Filename = "Updated-Filename",
                    Physical = "Updated-Physical"
                }
            ]
        };
        Responses[204] = "Discharge Summary Report updated successfully";
        Responses[404] = "Discharge Summary Report not found";
    }
}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateDischargeSummaryReportDto, UpdateDischargeSummaryReportMapper>
{
    public override void Configure()
    {
        Put("discharge-summary-report/{id}");
        Description(b => b
            .Produces(404));
        Summary(new UpdateDischargeSummaryReportSummary());
    }

    public override async Task HandleAsync(UpdateDischargeSummaryReportDto req, CancellationToken ct)
    {
        var entity = await dbContext.DischargeSummaryReport
            .Include(x => x.DischargeSummaryReportAttachment)
            .FirstOrDefaultAsync(x => x.DischargeSummaryReportId == req.Id, ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        entity = Map.UpdateEntity(req, entity);
        if (req.AttachmentList != null)
        {
            var attachmentsToDelete = entity.DischargeSummaryReportAttachment
                .Where(x => !req.AttachmentList.Any(y => y.DischargeSummaryReportAttachmentID == x.DischargeSummaryReportAttachmentID));
            foreach (var attachment in attachmentsToDelete)
            {
                attachment.ModifiedDate = DateTime.Now;
                attachment.ModifiedBy_FK = req.UserId;
                attachment.IsDeleted = true;
            }

            var newAttachments = req.AttachmentList
                .Where(x => x.DischargeSummaryReportAttachmentID == 0);
            foreach (var attachment in newAttachments)
            {
                entity.DischargeSummaryReportAttachment.Add(new DischargeSummaryReportAttachment
                {
                    Filename = attachment.Filename,
                    Physical = attachment.Physical,
                    CreatedDate = DateTime.Now,
                    CreatedBy_FK = req.UserId,
                    IsDeleted = false
                });
            }
        }

        await dbContext.SaveChangesAsync(ct);
    }
}
