namespace C4WX1.API.Features.Shared.EndpointSummaries;

public abstract class C4WX1GetListSummary<TTableName> : EndpointSummary
{
    public C4WX1GetListSummary(string? filterName = null)
    {
        var tableName = typeof(TTableName).Name;
        var baseDescription = $"Get a {tableName} List";
        Summary = $"Get {tableName} List";
        Description = string.IsNullOrWhiteSpace(filterName)
            ? baseDescription
            : $"{baseDescription} filtered by {filterName}";
        Responses[200] = $"{tableName} List retrieved successfully";
    }
}
