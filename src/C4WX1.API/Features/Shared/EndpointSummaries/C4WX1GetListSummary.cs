namespace C4WX1.API.Features.Shared.EndpointSummaries;

public abstract class C4WX1GetListSummary<TTableName> : EndpointSummary
{
    public C4WX1GetListSummary()
    {
        string tableName = typeof(TTableName).Name;
        Summary = $"Get {tableName} List";
        Description = $"Get a filtered, sorted and paged {tableName} List";
        Responses[200] = $"{tableName} List retrieved successfully";
    }
}
