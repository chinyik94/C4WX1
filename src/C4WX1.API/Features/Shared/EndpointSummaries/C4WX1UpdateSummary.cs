namespace C4WX1.API.Features.Shared.EndpointSummaries;

public abstract class C4WX1UpdateSummary<TTableName> : EndpointSummary
{
    public C4WX1UpdateSummary()
    {
        string tableName = typeof(TTableName).Name;
        Summary = $"Update {tableName}";
        Description = $"Update an existing {tableName} by its ID";
        Responses[204] = $"{tableName} updated successfully";
        Responses[404] = $"{tableName} not found";
    }
}
