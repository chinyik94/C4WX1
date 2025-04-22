namespace C4WX1.API.Features.ExternalDoctor.Constants;

public class Sqls
{
    public const string CanDelete = """
        SELECT "fn_CanDeleteExternalDoctor"(@Id);
        """;
    public const string BatchCanDelete = """
        SELECT id, "fn_CanDeleteExternalDoctor"(id) AS can_delete
        FROM UNNEST(@Ids) AS id;
        """;
}
