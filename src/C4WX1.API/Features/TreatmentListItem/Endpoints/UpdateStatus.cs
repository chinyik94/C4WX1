namespace C4WX1.API.Features.TreatmentListItem.Endpoints;

public class UpdateTreatmentListItemStatusSummary
    : C4WX1UpdateSummary<Database.Models.TreatmentListItem>
{

}

public class UpdateStatus(THCC_C4WDEVContext dbContext)
    : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("treatment-list-item/update-status");
        Summary(new UpdateTreatmentListItemStatusSummary());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var sql = """
            UPDATE 
                "TreatmentListItem"
            SET
                "IsActive" = False
            WHERE
                "StartDate" IS NOT NULL
                AND "EndDate" IS NOT NULL;
            """;
        await dbContext.Database.ExecuteSqlRawAsync(sql, ct);
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
