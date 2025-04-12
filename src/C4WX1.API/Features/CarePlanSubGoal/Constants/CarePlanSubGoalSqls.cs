namespace C4WX1.API.Features.CarePlanSubGoal.Constants;

public class CarePlanSubGoalSqls
{
    public const string CanDelete = """
        SELECT "fn_CanDeleteCarePlanSubGoal(@CarePlanSubGoalId)";
        """;
    public const string BatchCanDelete = """
        SELECT id, "fn_CanDeleteCarePlanSubGoal"(id) AS can_delete
        FROM UNNEST(@CarePlanSubGoalIds) AS id;
        """;
}
