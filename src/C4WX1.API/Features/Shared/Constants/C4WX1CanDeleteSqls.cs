namespace C4WX1.API.Features.Shared.Constants;

public class C4WX1CanDeleteSqls
{
    public static string CanDelete(string funcName) => $"""
        SELECT "{funcName}"(@Id);
        """;

    public static string BatchCanDelete(string funcName) => $"""
        SELECT id, "{funcName}"(id) AS can_delete
        FROM UNNEST(@Ids) AS id;
        """;
}
