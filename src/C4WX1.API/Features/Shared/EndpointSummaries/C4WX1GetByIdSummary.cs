namespace C4WX1.API.Features.Shared.EndpointSummaries;

public abstract class C4WX1GetByIdSummary<TTableName> : EndpointSummary
{
    public C4WX1GetByIdSummary()
    {
        string tableName = typeof(TTableName).Name;
        Summary = $"Get {tableName}";
        Description = $"Get {tableName} by its ID";
        Responses[200] = $"{tableName} retrieved successfully";
        Responses[404] = $"{tableName} not found";
    }
}
