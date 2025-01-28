namespace C4WX1.API.Features.Activity.Shared
{
    public class ActivitySqls
    {
        public const string GetCanDeleteActivity = @"
SELECT ""fn_CanDeleteActivity(@ActivityID)""";

        public const string GetList =
            """
            SELECT 
                d."ActivityID",
                d."ProblemListID_FK",
                d."DiseaseID_FK",
                d."ActivityDetail",
                d."CreatedDate",
                d."CreatedBy_FK",
                d."DiseaseSubInfoID_FK",
                d."Disease",
                d."ProblemList",
                d."IsDeleted",
                fn_CanDeleteActivity(d."ActivityID") AS "CanDelete"
            FROM 
                "Activities" d
            WHERE 
                d."IsDeleted" = FALSE
            ORDER BY 
                d."CreatedDate" DESC
            OFFSET @StartRowIndex ROWS
            FETCH NEXT @PageSize ROWS ONLY
            """;
    }
}
