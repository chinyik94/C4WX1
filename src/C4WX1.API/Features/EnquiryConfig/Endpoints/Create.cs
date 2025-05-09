using C4WX1.API.Features.EnquiryConfig.Dtos;
using C4WX1.API.Features.EnquiryConfig.Mappers;

namespace C4WX1.API.Features.EnquiryConfig.Endpoints;

public class CreateEnquiryConfigSummary 
    : C4WX1CreateSummary<Database.Models.EnquiryConfig>
{
    public CreateEnquiryConfigSummary() : base()
    {
        ExampleRequest = new CreateEnquiryConfigDto
        {
            SCMID_FK = 1,
            EmailContent = nameof(CreateEnquiryConfigDto.EmailContent),
            EscalatingPersonID_FK = 1,
            EscalationPeriod = 1,
            EscalationEmail = nameof(CreateEnquiryConfigDto.EscalationEmail),
            EmailtoCMContent = nameof(CreateEnquiryConfigDto.EmailtoCMContent),
            UserId = 1,
            SCMList = [1, 2, 3],
            EscPersonList = [1, 2, 3],
        };
    }
}

public class Create(THCC_C4WDEVContext dbContext)
    : Endpoint<CreateEnquiryConfigDto, int, CreateEnquiryConfigMapper>
{
    public override void Configure()
    {
        Post("enquiry-config");
        Summary(new CreateEnquiryConfigSummary());
    }

    public override async Task HandleAsync(CreateEnquiryConfigDto req, CancellationToken ct)
    {
        var entity = Map.ToEntity(req);

        var scmUserIds = await dbContext.Users
            .Where(x => !x.IsDeleted
                && req.SCMList.Contains(x.UserId))
            .Select(x => x.UserId)
            .ToListAsync(ct);
        foreach (var scmUserId in scmUserIds)
        {
            entity.EnquirySCM.Add(new EnquirySCM
            {
                UserID_FK = scmUserId
            });
        }

        var escPersonUserIds = await dbContext.Users
            .Where(x => !x.IsDeleted
                && req.EscPersonList.Contains(x.UserId))
            .Select(x => x.UserId)
            .ToListAsync(ct);
        foreach (var escPersonUserId in escPersonUserIds)
        {
            entity.EnquiryEscPerson.Add(new EnquiryEscPerson
            {
                UserID_FK = escPersonUserId
            });
        }

        await dbContext.EnquiryConfig.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(entity.EnquiryConfigID, cancellation: ct);
    }
}
