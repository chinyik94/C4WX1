namespace C4WX1.API.Features.Shared.EndpointSummaries;

public abstract class C4WX1GetByIdSummary<TTableName> : EndpointSummary
{
    public C4WX1GetByIdSummary(string? filterName = null)
    {
        var tableName = typeof(TTableName).Name;
        var baseDescription = $"Get {tableName} by";
        Summary = $"Get {tableName}";
        Description = string.IsNullOrWhiteSpace(filterName)
            ? $"{baseDescription} its ID"
            : $"{baseDescription} its {filterName}";
        Responses[200] = $"{tableName} retrieved successfully";
        Responses[404] = $"{tableName} not found";
    }
}
