namespace C4WX1.API.Features.Activity.Constants;

public class ActivitySqls
{
    public const string CanDelete = """
        SELECT "fn_CanDeleteActivity"(@ActivityId)
        """;
    public const string BatchCanDelete = """
        SELECT id, "fn_CanDeleteActivity"(id) AS can_delete
        FROM UNNEST(@ActivityIds) AS id;
        """;
}
