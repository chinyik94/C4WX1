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

    public static string GetWoundInfectionStatus => """
        SELECT 
            "InfectionStatus"
        FROM
            "fn_SpGetWoundInfectionStatus"(@UserId, @PatientId, @PatientWoundVisitId);
        """;

    public static string GetWoundInfectionStatusDetails => """
        SELECT 
            "InfectionStatus",
            "infection_items_value" AS "InfectionItemsValue",
            "bSlowHealing" AS "BSlowHealing",
            "bIncreasedPain" AS "BIncreasedPain",
            "bIncreasedExudate" AS "BIncreasedExudate,
            "bSwelling" AS "BSwelling",
            "bRedness" AS "BRedness",
            "bSmell" AS "BSmell",
            "bWarmToTouch" AS "BWarmToTouch",
            "exudate_value" AS "ExudateValue",
            "prev_exudate_value" AS "PrevExudateValue",
            "PatientWoundVisitId",
            "prev_exudate" AS "BSwelling",
            "exudate" AS "Exudate",
            "BPDias",
            "BPSys",
            "PulseRate",
            "Temperature"
        FROM
            "fn_SpGetWoundInfectionStatusDetails"(@UserId, @PatientId, @PatientWoundVisitId);
        """;
}
