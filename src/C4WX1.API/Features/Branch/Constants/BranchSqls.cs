namespace C4WX1.API.Features.Branch.Constants;

public class BranchSqls
{
    public const string CanDelete = """
        SELECT "fn_CanDeleteBranch"(@BranchId);
        """;
    public const string BatchCanDelete = """
        SELECT id, "fn_CanDeleteBranch"(id) AS can_delete
        FROM UNNEST(@BranchIds) AS id;
        """;
}
