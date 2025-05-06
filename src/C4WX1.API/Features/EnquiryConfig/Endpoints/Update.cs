using C4WX1.API.Features.EnquiryConfig.Dtos;
using C4WX1.API.Features.EnquiryConfig.Mappers;
using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.EnquiryConfig.Endpoints;

public class UpdateEnquiryConfigSummary : EndpointSummary
{
    public UpdateEnquiryConfigSummary()
    {
        Summary = "Update Enquiry Config";
        Description = "Update an existing Enquiry Config";
        ExampleRequest = new UpdateEnquiryConfigDto
        {
            Id = 1,
            SCMID_FK = 1,
            EmailContent = nameof(UpdateEnquiryConfigDto.EmailContent),
            EscalatingPersonID_FK = 1,
            EscalationPeriod = 1,
            EscalationEmail = nameof(UpdateEnquiryConfigDto.EscalationEmail),
            EmailtoCMContent = nameof(UpdateEnquiryConfigDto.EmailtoCMContent),
            UserId = 1,
            SCMList = [1, 2, 3],
            EscPersonList = [1, 2, 3],
        };
        Responses[204] = "Enquiry Config updated successfully";
        Responses[404] = "Enquiry Config not found";
    }
}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateEnquiryConfigDto, UpdateEnquiryConfigMapper>
{
    public override void Configure()
    {
        Put("enquiry-config/{id}");
        Summary(new UpdateEnquiryConfigSummary());
    }

    public override async Task HandleAsync(UpdateEnquiryConfigDto req, CancellationToken ct)
    {
        var entity = await dbContext.EnquiryConfig
            .Include(x => x.EnquirySCM)
            .Include(x => x.EnquiryEscPerson)
            .Where(x => !(x.IsDeleted ?? false) && x.EnquiryConfigID == req.Id)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        entity = Map.UpdateEntity(req, entity);
        var scmsToRemove = entity.EnquirySCM
            .Where(x => !req.SCMList.Any(y => y == x.UserID_FK))
            .ToList();
        foreach (var scm in scmsToRemove)
        {
            entity.EnquirySCM.Remove(scm);
        }
        var newScmUserIds = req.SCMList
            .Where(x => !entity.EnquirySCM.Any(y => y.UserID_FK == x));
        foreach (var scmUserId in newScmUserIds)
        {
            entity.EnquirySCM.Add(new EnquirySCM
            {
                UserID_FK = scmUserId
            });
        }

        var escPersonsToRemove = entity.EnquiryEscPerson
            .Where(x => !req.EscPersonList.Any(y => y == x.UserID_FK))
            .ToList();
        foreach (var escPerson in escPersonsToRemove)
        {
            entity.EnquiryEscPerson.Remove(escPerson);
        }
        var newEscPersonUserId = req.EscPersonList
            .Where(x => !entity.EnquiryEscPerson.Any(y => y.UserID_FK == x));
        foreach (var escPersonUserId in newEscPersonUserId)
        {
            entity.EnquiryEscPerson.Add(new EnquiryEscPerson
            {
                UserID_FK = escPersonUserId
            });
        }

        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
