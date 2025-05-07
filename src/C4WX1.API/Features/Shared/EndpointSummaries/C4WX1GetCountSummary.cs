namespace C4WX1.API.Features.Shared.EndpointSummaries;

public abstract class C4WX1GetCountSummary<TTableName> : EndpointSummary
{
    public C4WX1GetCountSummary()
    {
        string tableName = typeof(TTableName).Name;
        Summary = $"Get {tableName} Count";
        Description = $"Get {tableName} Count";
        Responses[200] = $"{tableName} Count retrieved successfully";
    }
}
