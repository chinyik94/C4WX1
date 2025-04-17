namespace C4WX1.API.Features.CPGoals.Constants;

public class Sqls
{
    public const string BatchCanDelete = """
        SELECT id, "fn_CanDeleteCPGoals"(id) AS can_delete
        FROM UNNEST(@CPGoalsIds) AS id;
        """;

    public const string CanDelete = """
        SELECT "fn_CanDeleteCPGoals"(@CPGoalsId);
        """;
}
 