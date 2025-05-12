using C4WX1.API.Features.MailSettings.Dtos;
using C4WX1.API.Features.MailSettings.Mappers;

namespace C4WX1.API.Features.MailSettings.Endpoints;

public class UpdateMailSettingsSummary
    : C4WX1UpdateSummary<Database.Models.MailSettings>
{
    
}

public class Update(THCC_C4WDEVContext dbContext)
    : EndpointWithMapper<UpdateMailSettingsDto, UpdateMailSettingsMapper>
{
    public override void Configure()
    {
        Put("mail-settings/{id}");
        Summary(new UpdateMailSettingsSummary());
    }

    public override async Task HandleAsync(UpdateMailSettingsDto req, CancellationToken ct)
    {
        var entity = await dbContext.MailSettings
            .Where(x => !x.IsDeleted
                && x.id == req.Id)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        entity = Map.UpdateEntity(req, entity);
        var userTypesToRemove = entity.MailSettingsMsgToUserType
            .Where(x => !req.recipientUserType.Contains(x.UserTypeID_FK));
        foreach (var userType in userTypesToRemove)
        {
            entity.MailSettingsMsgToUserType.Remove(userType);
        }
        var existingUserTypeIds = entity.MailSettingsMsgToUserType
            .Select(x => x.UserTypeID_FK)
            .ToHashSet();
        var userTypeIdsToAdd = req.recipientUserType
            .Where(id => !existingUserTypeIds.Contains(id));
        var validUserTypeIds = await dbContext.UserType
            .Where(x => !x.IsDeleted && userTypeIdsToAdd.Contains(x.UserTypeID))
            .Select(x => x.UserTypeID)
            .ToListAsync(ct);
        foreach (var userTypeId in validUserTypeIds)
        {
            entity.MailSettingsMsgToUserType.Add(new MailSettingsMsgToUserType
            {
                UserTypeID_FK = userTypeId,
                MailSetting_FK = entity.id
            });
        }
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
