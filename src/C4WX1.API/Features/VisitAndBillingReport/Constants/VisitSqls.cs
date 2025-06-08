namespace C4WX1.API.Features.VisitAndBillingReport.Constants;

public class VisitSqls
{
    public const string GetVisitSummary = """
        SELECT 
            "Name",
            "ScheduledCount",
            "ActualCount",
            "BillingAmount",
            "Average"
        FROM "fn_SpRptVisitSummary"(@UserId, @UserCategoryId, @StartDate, @EndDate);
        """;

    public const string GetVisitDetails = """
        SELECT 
            "Name",
            "VisitDate",
            "VisitType",
            "IsBill",
            "BillingAmount"
        FROM "fn_SpRptVisitDetail"(@UserId, @UserCategoryId, @StartDate, @EndDate);
        """;
}