namespace C4WX1.API.Features.Shared.EndpointSummaries;

public abstract class C4WX1DeleteSummary<TTableName> : EndpointSummary
{
    public C4WX1DeleteSummary()
    {
        string tableName = typeof(TTableName).Name;
        Summary = $"Delete {tableName}";
        Description = $"Delete an existing {tableName} by its ID";
        Responses[204] = $"{tableName} deleted successfully";
        Responses[404] = $"{tableName} not found";
    }
}
