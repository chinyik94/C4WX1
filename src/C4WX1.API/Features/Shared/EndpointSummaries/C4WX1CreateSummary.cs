namespace C4WX1.API.Features.Shared.EndpointSummaries;

public abstract class C4WX1CreateSummary<TTableName> : EndpointSummary
{
    public C4WX1CreateSummary()
    {
        string tableName = typeof(TTableName).Name;
        Summary = $"Create {tableName}";
        Description = $"Create a new {tableName}";
        Responses[200] = $"{tableName} created successfully";
    }
}
