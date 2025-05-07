namespace C4WX1.API.Features.Intervention.Constants;

public class Sqls
{
    public const string BatchCanDelete = """
        SELECT id, "fn_CanDeleteIntervention"(id) AS can_delete
        FROM UNNEST(@Ids) AS id;
        """;

    public const string CanDelete = """
        SELECT "fn_CanDeleteIntervention"(@Id);
        """;
}
