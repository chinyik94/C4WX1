namespace C4WX1.API.Features.Shared.Constants;

public class C4WX1Sqls
{
    public static string CanDelete(string funcName) => $"""
        SELECT "{funcName}"(@Id);
        """;

    public static string BatchCanDelete(string funcName) => $"""
        SELECT id, "{funcName}"(id) AS can_delete
        FROM UNNEST(@Ids) AS id;
        """;

    public static string BatchCanAccessPatient => """
        SELECT 
            patient_id,
            "fn_CanAccessPatientDashboard"(@UserId, patient_id, @FacilityId) AS can_access
        FROM 
            UNNEST(@PatientIds) AS patient_id;
        """;
}
