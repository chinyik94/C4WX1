using C4WX1.API.Features.Shared.Dtos;

namespace C4WX1.API.Features.Chat.Delete;

public class DeleteChatSummary 
    : C4WX1DeleteSummary<Database.Models.Chat>
{
    public DeleteChatSummary() { }
}

public class Delete(THCC_C4WDEVContext dbContext) 
    : Endpoint<DeleteByIdDto>
{
    public override void Configure()
    {
        Delete("chat/{id}");
        Description(b => b.Produces(404));
        Summary(new DeleteChatSummary());
    }

    public override async Task HandleAsync(DeleteByIdDto req, CancellationToken ct)
    {
        var entity = dbContext.Chat
            .Where(x => !x.IsDeleted
                && x.ChatID == req.Id
                && x.CreatedBy_FK == req.UserId);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        var deleteDurationConfig = await dbContext.SysConfig
            .FirstOrDefaultAsync(x => x.ConfigName == "DeleteMessageDuration", ct);
        var deleteDuration = int
            .TryParse(deleteDurationConfig?.ConfigValue ?? string.Empty, out var value)
            ? value 
            : 30;
        foreach (var e in entity)
        {
            if ((DateTime.Now - e.CreatedDate).TotalMinutes <= deleteDuration 
                || e.ParentID_FK == req.Id)
            {
                e.IsDeleted = true;
            }
        }
        await dbContext.SaveChangesAsync(ct);
        await SendOkAsync(cancellation: ct);
    }
}
