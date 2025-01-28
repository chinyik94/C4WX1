using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpGetPatientList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_spGetPatientList"(
                    user_id_param integer
                )
                RETURNS TABLE (
                    "PatientID" integer,
                    "Firstname" varchar,
                    "Lastname" varchar,
                    "DisplayName" varchar,
                    "NRIC" varchar,
                    "DateOfBirth" timestamp,
                    "Age" integer,
                    "PostalCode" varchar,
                    "Photo" varchar,
                    "CareManagerAssignedID" integer,
                    "CaseID" varchar,
                    "DrugAllergy" varchar,
                    "Status" varchar,
                    "DischargeNoticePeriodInMonths" integer,
                    "AdmittedDate" timestamp,
                    "ReasonOfAdmission" varchar,
                    "AMD" boolean,
                    "ACP" boolean,
                    "PACEMAKER" boolean,
                    "ACID" boolean,
                    "MobilePhone" varchar,
                    "HomePhone" varchar,
                    "Email" varchar,
                    "GenogramPicture" varchar,
                    "ReferringDiagnosis" varchar,
                    "MailForVitalAlert1" varchar,
                    "MailForVitalAlert2" varchar,
                    "MailForVitalAlert3" varchar,
                    "MailForFamilyNotification1" varchar,
                    "MailForFamilyNotification2" varchar,
                    "VisitingFrequency" varchar,
                    "NumberOfChildren" integer,
                    "Occupation" varchar,
                    "UpfrontPayment" varchar,
                    "CareReviewDate" timestamp,
                    "CreatedDate" timestamp,
                    "CreatedBy_FK" integer,
                    "ModifiedDate" timestamp,
                    "ModifiedBy_FK" integer,
                    "PatientTypeID_FK" integer,
                    "MailingAddress1" varchar,
                    "MailingAddress2" varchar,
                    "MailingAddress3" varchar,
                    "GenderID_FK" integer,
                    "BloodTypeID_FK" integer,
                    "ResidentTypeID_FK" integer,
                    "MaritalStatusID_FK" integer,
                    "ReligionID_FK" integer,
                    "PatientProfileID_FK" integer,
                    "RaceID_FK" integer,
                    "PatientAdditionalInfoID_FK" integer,
                    "PatientReferralID_FK" integer,
                    "MedicalHistoryRemarks" varchar,
                    "PatientMedicationID_FK" integer,
                    "PatientReferralByID_FK" integer,
                    "IdentificationNumber" varchar,
                    "IdentificationAttachmentFilename" varchar,
                    "IdentificationAttachmentPhysical" varchar,
                    "OtherRace" varchar,
                    "CreatedBy" varchar,
                    "ModifiedBy" varchar,
                    "PatientType" varchar,
                    "ResidentType" varchar,
                    "Gender" varchar,
                    "BloodType" varchar,
                    "Region" varchar,
                    "MaritalStatus" varchar,
                    "Race" varchar,
                    "BloodTypeID" integer,
                    "ReligionID" integer,
                    "Location" varchar,
                    "Bed" varchar,
                    "Ward" varchar,
                    "Note" varchar,
                    "NursingStation" varchar
                ) AS $$
                BEGIN
                	IF EXISTS (
                        SELECT 1 
                        FROM "Users" u
                        INNER JOIN "UserUserType" uut ON u."UserId" = uut."UserID_FK"
                        INNER JOIN "UserType" ut ON uut."UserTypeID_FK" = ut."UserTypeID"
                        INNER JOIN "UserCategoryRole" ucr ON ucr."UserCategoryID_FK" = ut."UserCategoryID_FK"
                        LEFT JOIN "Role" r ON r."RoleId" = ucr."RoleID_FK" AND r."RoleDescription" = 'Patients Assignment'
                        WHERE u."UserId" = user_id_param 
                        AND (ut."UserCategoryID_FK" = 1 OR r."RoleId" > 0) 
                        AND u."Status" = 'Active'
                    ) THEN
                	    RETURN QUERY
                	    SELECT 
                	        p."PatientID",
                	        p."Firstname",
                	        p."Lastname",
                	        p."DisplayName",
                	        p."NRIC",
                	        p."DateOfBirth",
                	        EXTRACT(YEAR FROM AGE(CURRENT_TIMESTAMP, p."DateOfBirth"))::integer AS "Age",
                	        p."PostalCode",
                	        p."Photo",
                	        p."CareManagerAssignedID",
                	        p."CaseID",
                	        p."DrugAllergy",
                	        p."Status",
                	        p."DischargeNoticePeriodInMonths",
                	        p."AdmittedDate",
                	        p."ReasonOfAdmission",
                	        p."AMD",
                	        p."ACP",
                	        p."PACEMAKER",
                	        p."ACID",
                	        p."MobilePhone",
                	        p."HomePhone",
                	        p."Email",
                	        p."GenogramPicture",
                	        p."ReferringDiagnosis",
                	        p."MailForVitalAlert1",
                	        p."MailForVitalAlert2",
                	        p."MailForVitalAlert3",
                	        p."MailForFamilyNotification1",
                	        p."MailForFamilyNotification2",
                	        p."VisitingFrequency",
                	        p."NumberOfChildren",
                	        p."Occupation",
                	        p."UpfrontPayment",
                	        p."CareReviewDate",
                	        p."CreatedDate",
                	        p."CreatedBy_FK",
                	        p."ModifiedDate",
                	        p."ModifiedBy_FK",
                	        p."PatientTypeID_FK",
                	        p."MailingAddress1",
                	        p."MailingAddress2",
                	        p."MailingAddress3",
                	        p."GenderID_FK",
                	        p."BloodTypeID_FK",
                	        p."ResidentTypeID_FK",
                	        p."MaritalStatusID_FK",
                	        p."ReligionID_FK",
                	        p."PatientProfileID_FK",
                	        p."RaceID_FK",
                	        p."PatientAdditionalInfoID_FK",
                	        p."PatientReferralID_FK",
                	        p."MedicalHistoryRemarks",
                	        p."PatientMedicationID_FK",
                	        p."PatientReferralByID_FK",
                	        p."IdentificationNumber",
                	        p."IdentificationAttachmentFilename",
                	        p."IdentificationAttachmentPhysical",
                	        p."OtherRace",
                	        creator."Firstname" || ' ' || creator."Lastname" AS "CreatedBy",
                	        modifier."Firstname" || ' ' || modifier."Lastname" AS "ModifiedBy",
                	        patient_type."CodeName" AS "PatientType",
                	        resident_type."CodeName" AS "ResidentType",
                	        gender."CodeName" AS "Gender",
                	        blood_type."CodeName" AS "BloodType",
                	        religion."CodeName" AS "Region",
                	        marital."CodeName" AS "MaritalStatus",
                	        race."CodeName" AS "Race",
                	        pf."BloodTypeID_FK" AS "BloodTypeID",
                	        pf."ReligionID_FK" AS "ReligionID",
                	        pf."Location",
                	        pf."Bed",
                	        pf."Ward",
                	        pf."Note",
                	        p."NursingStation"
                	    FROM "Patient" p
                	    LEFT JOIN "PatientProfile" pf ON pf."PatientProfileID" = p."PatientProfileID_FK"
                	    LEFT JOIN "Users" creator ON creator."UserId" = p."CreatedBy_FK"
                	    LEFT JOIN "Users" modifier ON modifier."UserId" = p."CreatedBy_FK"
                	    LEFT JOIN "Code" patient_type ON patient_type."CodeId" = p."PatientTypeID_FK"
                	    LEFT JOIN "Code" gender ON gender."CodeId" = p."GenderID_FK"
                	    LEFT JOIN "Code" resident_type ON resident_type."CodeId" = p."ResidentTypeID_FK"
                	    LEFT JOIN "Code" blood_type ON blood_type."CodeId" = pf."BloodTypeID_FK"
                	    LEFT JOIN "Code" religion ON religion."CodeId" = pf."ReligionID_FK"
                	    LEFT JOIN "Code" marital ON marital."CodeId" = p."MaritalStatusID_FK"
                	    LEFT JOIN "Code" race ON race."CodeId" = p."RaceID_FK"
                	    WHERE p."Status" = 'Active'
                	    ORDER BY p."CreatedDate" DESC, p."ModifiedDate" DESC;
                	ELSIF EXISTS (
                        SELECT 1 
                        FROM "PatientClinician" pc
                        WHERE pc."IsDeleted" = FALSE 
                        AND pc."UserID_FK" = user_id_param
                    ) 
                    AND EXISTS (
                        SELECT 1 
                        FROM "Patient" p 
                        WHERE p."CreatedBy_FK" = user_id_param 
                        OR p."ModifiedBy_FK" = user_id_param
                    ) THEN
                	    RETURN QUERY
                		(
                	        SELECT 
                	            p.*,
                	            creator."Firstname" || ' ' || creator."Lastname" AS "CreatedBy",
                	            modifier."Firstname" || ' ' || modifier."Lastname" AS "ModifiedBy",
                	            patientType."CodeName" AS "PatientType",
                	            residentType."CodeName" AS "ResidentType",
                	            gender."CodeName" AS "Gender",
                	            bloodType."CodeName" AS "BloodType",
                	            religion."CodeName" AS "Region",
                	            marital."CodeName" AS "MaritalStatus",
                	            race."CodeName" AS "Race",
                	            pf."BloodTypeID_FK" AS "BloodTypeID",
                	            pf."ReligionID_FK" AS "ReligionID",
                	            pf."Location",
                	            pf."Bed",
                	            pf."Ward",
                	            pf."Note",
                	            p."NursingStation"
                	        FROM "Patient" p
                	        LEFT JOIN "PatientProfile" pf ON pf."PatientProfileID" = p."PatientProfileID_FK"
                	        LEFT JOIN "Users" creator ON creator."UserId" = p."CreatedBy_FK"
                	        LEFT JOIN "Users" modifier ON modifier."UserId" = p."ModifiedBy_FK"
                	        LEFT JOIN "Code" patientType ON patientType."CodeId" = p."PatientTypeID_FK"
                	        LEFT JOIN "Code" gender ON gender."CodeId" = p."GenderID_FK"
                	        LEFT JOIN "Code" residentType ON residentType."CodeId" = p."ResidentTypeID_FK"
                	        LEFT JOIN "Code" bloodType ON bloodType."CodeId" = pf."BloodTypeID_FK"
                	        LEFT JOIN "Code" religion ON religion."CodeId" = pf."ReligionID_FK"
                	        LEFT JOIN "Code" marital ON marital."CodeId" = p."MaritalStatusID_FK"
                	        LEFT JOIN "Code" race ON race."CodeId" = p."RaceID_FK"
                	        WHERE p."PatientID" IN (
                	            SELECT pc."PatientID_FK" 
                	            FROM "PatientClinician" pc 
                	            WHERE pc."PatientID_FK" IS NOT NULL 
                	            AND pc."UserID_FK" = user_id_param 
                	            AND pc."IsDeleted" = FALSE
                	        )
                	        AND p."Status" = 'Active'
                	    )
                	    UNION
                	    (
                	        SELECT 
                	            p.*,
                	            creator."Firstname" || ' ' || creator."Lastname" AS "CreatedBy",
                	            modifier."Firstname" || ' ' || modifier."Lastname" AS "ModifiedBy",
                	            patientType."CodeName" AS "PatientType",
                	            residentType."CodeName" AS "ResidentType",
                	            gender."CodeName" AS "Gender",
                	            bloodType."CodeName" AS "BloodType",
                	            religion."CodeName" AS "Region",
                	            marital."CodeName" AS "MaritalStatus",
                	            race."CodeName" AS "Race",
                	            pf."BloodTypeID_FK" AS "BloodTypeID",
                	            pf."ReligionID_FK" AS "ReligionID",
                	            pf."Location",
                	            pf."Bed",
                	            pf."Ward",
                	            pf."Note",
                	            p."NursingStation"
                	        FROM "Patient" p
                	        LEFT JOIN "PatientProfile" pf ON pf."PatientProfileID" = p."PatientProfileID_FK"
                	        LEFT JOIN "Users" creator ON creator."UserId" = p."CreatedBy_FK"
                	        LEFT JOIN "Users" modifier ON modifier."UserId" = p."ModifiedBy_FK"
                	        LEFT JOIN "Code" patientType ON patientType."CodeId" = p."PatientTypeID_FK"
                	        LEFT JOIN "Code" gender ON gender."CodeId" = p."GenderID_FK"
                	        LEFT JOIN "Code" residentType ON residentType."CodeId" = p."ResidentTypeID_FK"
                	        LEFT JOIN "Code" bloodType ON bloodType."CodeId" = pf."BloodTypeID_FK"
                	        LEFT JOIN "Code" religion ON religion."CodeId" = pf."ReligionID_FK"
                	        LEFT JOIN "Code" marital ON marital."CodeId" = p."MaritalStatusID_FK"
                	        LEFT JOIN "Code" race ON race."CodeId" = p."RaceID_FK"
                	        WHERE (p."CreatedBy_FK" = user_id_param OR p."ModifiedBy_FK" = user_id_param)
                	        AND p."Status" = 'Active'
                	    )
                	    ORDER BY "CreatedDate" DESC, "ModifiedDate" DESC;
                	ELSIF EXISTS (SELECT 1 FROM "PatientClinician" WHERE NOT "IsDeleted" AND "UserID_FK" = user_id_param) THEN
                        RETURN QUERY
                        SELECT 
                            p."PatientID",
                            p."Firstname",
                            p."Lastname",
                            p."DisplayName",
                            p."NRIC",
                            p."DateOfBirth",
                            EXTRACT(YEAR FROM AGE(CURRENT_TIMESTAMP, p."DateOfBirth"))::INTEGER AS "Age",
                            p."PostalCode",
                            p."Photo",
                            p."CareManagerAssignedID",
                            p."CaseID",
                            p."DrugAllergy",
                            p."Status",
                            p."DischargeNoticePeriodInMonths",
                            p."AdmittedDate",
                            p."ReasonOfAdmission",
                            p."AMD",
                            p."ACP",
                            p."PACEMAKER",
                            p."ACID",
                            p."MobilePhone",
                            p."HomePhone",
                            p."Email",
                            p."GenogramPicture",
                            p."ReferringDiagnosis",
                            p."MailForVitalAlert1",
                            p."MailForVitalAlert2",
                            p."MailForVitalAlert3",
                            p."MailForFamilyNotification1",
                            p."MailForFamilyNotification2",
                            p."VisitingFrequency",
                            p."NumberOfChildren",
                            p."Occupation",
                            p."UpfrontPayment",
                            p."CareReviewDate",
                            p."CreatedDate",
                            p."CreatedBy_FK",
                            p."ModifiedDate",
                            p."ModifiedBy_FK",
                            p."PatientTypeID_FK",
                            p."MailingAddress1",
                            p."MailingAddress2",
                            p."MailingAddress3",
                            p."GenderID_FK",
                            p."BloodTypeID_FK",
                            p."ResidentTypeID_FK",
                            p."MaritalStatusID_FK",
                            p."ReligionID_FK",
                            p."PatientProfileID_FK",
                            p."RaceID_FK",
                            p."PatientAdditionalInfoID_FK",
                            p."PatientReferralID_FK",
                            p."MedicalHistoryRemarks",
                            p."PatientMedicationID_FK",
                            p."PatientReferralByID_FK",
                            p."IdentificationNumber",
                            p."IdentificationAttachmentFilename",
                            p."IdentificationAttachmentPhysical",
                            p."OtherRace",
                            creator."Firstname" || ' ' || creator."Lastname" AS "CreatedBy",
                            modifier."Firstname" || ' ' || modifier."Lastname" AS "ModifiedBy",
                            patient_type."CodeName" AS "PatientType",
                            resident_type."CodeName" AS "ResidentType",
                            gender."CodeName" AS "Gender",
                            blood_type."CodeName" AS "BloodType",
                            religion."CodeName" AS "Region",
                            marital."CodeName" AS "MaritalStatus",
                            race."CodeName" AS "Race",
                            pf."BloodTypeID_FK" AS "BloodTypeID",
                            pf."ReligionID_FK" AS "ReligionID",
                            pf."Location",
                            pf."Bed",
                            pf."Ward",
                            pf."Note",
                            p."NursingStation"
                        FROM "Patient" p
                        LEFT JOIN "PatientProfile" pf ON pf."PatientProfileID" = p."PatientProfileID_FK"
                        LEFT JOIN "Users" creator ON creator."UserId" = p."CreatedBy_FK"
                        LEFT JOIN "Users" modifier ON modifier."UserId" = p."ModifiedBy_FK"
                        LEFT JOIN "Code" patient_type ON patient_type."CodeId" = p."PatientTypeID_FK"
                        LEFT JOIN "Code" gender ON gender."CodeId" = p."GenderID_FK"
                        LEFT JOIN "Code" resident_type ON resident_type."CodeId" = p."ResidentTypeID_FK"
                        LEFT JOIN "Code" blood_type ON blood_type."CodeId" = pf."BloodTypeID_FK"
                        LEFT JOIN "Code" religion ON religion."CodeId" = pf."ReligionID_FK"
                        LEFT JOIN "Code" marital ON marital."CodeId" = p."MaritalStatusID_FK"
                        LEFT JOIN "Code" race ON race."CodeId" = p."RaceID_FK"
                        WHERE p."PatientID" IN (
                            SELECT pc."PatientID_FK" 
                            FROM "PatientClinician" pc 
                            WHERE pc."PatientID_FK" IS NOT NULL 
                            AND pc."UserID_FK" = user_id_param 
                            AND NOT pc."IsDeleted"
                        )
                        AND p."Status" = 'Active'
                        ORDER BY p."CreatedDate" DESC, p."ModifiedDate" DESC;
                	ELSIF EXISTS (SELECT 1 FROM "Patient" p WHERE p."CreatedBy_FK" = user_id_param OR p."ModifiedBy_FK" = user_id_param) THEN
                        RETURN QUERY
                        SELECT 
                            p."PatientID",
                            p."Firstname",
                            p."Lastname",
                            p."DisplayName",
                            p."NRIC",
                            p."DateOfBirth",
                            EXTRACT(YEAR FROM AGE(CURRENT_TIMESTAMP, p."DateOfBirth"))::INTEGER AS "Age",
                            p."PostalCode",
                            p."Photo",
                            p."CareManagerAssignedID",
                            p."CaseID",
                            p."DrugAllergy",
                            p."Status",
                            p."DischargeNoticePeriodInMonths",
                            p."AdmittedDate",
                            p."ReasonOfAdmission",
                            p."AMD",
                            p."ACP",
                            p."PACEMAKER",
                            p."ACID",
                            p."MobilePhone",
                            p."HomePhone",
                            p."Email",
                            p."GenogramPicture",
                            p."ReferringDiagnosis",
                            p."MailForVitalAlert1",
                            p."MailForVitalAlert2",
                            p."MailForVitalAlert3",
                            p."MailForFamilyNotification1",
                            p."MailForFamilyNotification2",
                            p."VisitingFrequency",
                            p."NumberOfChildren",
                            p."Occupation",
                            p."UpfrontPayment",
                            p."CareReviewDate",
                            p."CreatedDate",
                            p."CreatedBy_FK",
                            p."ModifiedDate",
                            p."ModifiedBy_FK",
                            p."PatientTypeID_FK",
                            p."MailingAddress1",
                            p."MailingAddress2",
                            p."MailingAddress3",
                            p."GenderID_FK",
                            p."BloodTypeID_FK",
                            p."ResidentTypeID_FK",
                            p."MaritalStatusID_FK",
                            p."ReligionID_FK",
                            p."PatientProfileID_FK",
                            p."RaceID_FK",
                            p."PatientAdditionalInfoID_FK",
                            p."PatientReferralID_FK",
                            p."MedicalHistoryRemarks",
                            p."PatientMedicationID_FK",
                            p."PatientReferralByID_FK",
                            p."IdentificationNumber",
                            p."IdentificationAttachmentFilename",
                            p."IdentificationAttachmentPhysical",
                            p."OtherRace",
                            creator."Firstname" || ' ' || creator."Lastname" AS "CreatedBy",
                            modifier."Firstname" || ' ' || modifier."Lastname" AS "ModifiedBy",
                            patient_type."CodeName" AS "PatientType",
                            resident_type."CodeName" AS "ResidentType",
                            gender."CodeName" AS "Gender",
                            blood_type."CodeName" AS "BloodType",
                            religion."CodeName" AS "Region",
                            marital."CodeName" AS "MaritalStatus",
                            race."CodeName" AS "Race",
                            pf."BloodTypeID_FK" AS "BloodTypeID",
                            pf."ReligionID_FK" AS "ReligionID",
                            pf."Location",
                            pf."Bed",
                            pf."Ward",
                            pf."Note",
                            p."NursingStation"
                        FROM "Patient" p
                        LEFT JOIN "PatientProfile" pf ON pf."PatientProfileID" = p."PatientProfileID_FK"
                        LEFT JOIN "Users" creator ON creator."UserId" = p."CreatedBy_FK"
                        LEFT JOIN "Users" modifier ON modifier."UserId" = p."ModifiedBy_FK"
                        LEFT JOIN "Code" patient_type ON patient_type."CodeId" = p."PatientTypeID_FK"
                        LEFT JOIN "Code" gender ON gender."CodeId" = p."GenderID_FK"
                        LEFT JOIN "Code" resident_type ON resident_type."CodeId" = p."ResidentTypeID_FK"
                        LEFT JOIN "Code" blood_type ON blood_type."CodeId" = pf."BloodTypeID_FK"
                        LEFT JOIN "Code" religion ON religion."CodeId" = pf."ReligionID_FK"
                        LEFT JOIN "Code" marital ON marital."CodeId" = p."MaritalStatusID_FK"
                        LEFT JOIN "Code" race ON race."CodeId" = p."RaceID_FK"
                        WHERE (p."CreatedBy_FK" = user_id_param OR p."ModifiedBy_FK" = user_id_param)
                        AND p."Status" = 'Active'
                        ORDER BY p."CreatedDate" DESC, p."ModifiedDate" DESC;
                	ELSIF EXISTS (SELECT 1 FROM "Users" u WHERE (u."UserId") = user_id_param AND u."PatientID_FK" IS NOT NULL) THEN
                		RETURN QUERY
                        SELECT 
                            p."PatientID",
                            p."Firstname",
                            p."Lastname",
                            p."DisplayName",
                            p."NRIC",
                            p."DateOfBirth",
                            EXTRACT(YEAR FROM AGE(CURRENT_TIMESTAMP, p."DateOfBirth"))::INTEGER AS "Age",
                            p."PostalCode",
                            p."Photo",
                            p."CareManagerAssignedID",
                            p."CaseID",
                            p."DrugAllergy",
                            p."Status",
                            p."DischargeNoticePeriodInMonths",
                            p."AdmittedDate",
                            p."ReasonOfAdmission",
                            p."AMD",
                            p."ACP",
                            p."PACEMAKER",
                            p."ACID",
                            p."MobilePhone",
                            p."HomePhone",
                            p."Email",
                            p."GenogramPicture",
                            p."ReferringDiagnosis",
                            p."MailForVitalAlert1",
                            p."MailForVitalAlert2",
                            p."MailForVitalAlert3",
                            p."MailForFamilyNotification1",
                            p."MailForFamilyNotification2",
                            p."VisitingFrequency",
                            p."NumberOfChildren",
                            p."Occupation",
                            p."UpfrontPayment",
                            p."CareReviewDate",
                            p."CreatedDate",
                            p."CreatedBy_FK",
                            p."ModifiedDate",
                            p."ModifiedBy_FK",
                            p."PatientTypeID_FK",
                            p."MailingAddress1",
                            p."MailingAddress2",
                            p."MailingAddress3",
                            p."GenderID_FK",
                            p."BloodTypeID_FK",
                            p."ResidentTypeID_FK",
                            p."MaritalStatusID_FK",
                            p."ReligionID_FK",
                            p."PatientProfileID_FK",
                            p."RaceID_FK",
                            p."PatientAdditionalInfoID_FK",
                            p."PatientReferralID_FK",
                            p."MedicalHistoryRemarks",
                            p."PatientMedicationID_FK",
                            p."PatientReferralByID_FK",
                            p."IdentificationNumber",
                            p."IdentificationAttachmentFilename",
                            p."IdentificationAttachmentPhysical",
                            p."OtherRace",
                            creator."Firstname" || ' ' || creator."Lastname" AS "CreatedBy",
                            modifier."Firstname" || ' ' || modifier."Lastname" AS "ModifiedBy",
                            patient_type."CodeName" AS "PatientType",
                            resident_type."CodeName" AS "ResidentType",
                            gender."CodeName" AS "Gender",
                            blood_type."CodeName" AS "BloodType",
                            religion."CodeName" AS "Region",
                            marital."CodeName" AS "MaritalStatus",
                            race."CodeName" AS "Race",
                            pf."BloodTypeID_FK" AS "BloodTypeID",
                            pf."ReligionID_FK" AS "ReligionID",
                            pf."Location",
                            pf."Bed",
                            pf."Ward",
                            pf."Note",
                            p."NursingStation"
                        FROM "Users" usr
                		INNER JOIN "Patient" p ON usr."PatientID_FK" = p."PatientID"
                        LEFT JOIN "PatientProfile" pf ON pf."PatientProfileID" = p."PatientProfileID_FK"
                        LEFT JOIN "Users" creator ON creator."UserId" = p."CreatedBy_FK"
                        LEFT JOIN "Users" modifier ON modifier."UserId" = p."ModifiedBy_FK"
                        LEFT JOIN "Code" patient_type ON patient_type."CodeId" = p."PatientTypeID_FK"
                        LEFT JOIN "Code" gender ON gender."CodeId" = p."GenderID_FK"
                        LEFT JOIN "Code" resident_type ON resident_type."CodeId" = p."ResidentTypeID_FK"
                        LEFT JOIN "Code" blood_type ON blood_type."CodeId" = pf."BloodTypeID_FK"
                        LEFT JOIN "Code" religion ON religion."CodeId" = pf."ReligionID_FK"
                        LEFT JOIN "Code" marital ON marital."CodeId" = p."MaritalStatusID_FK"
                        LEFT JOIN "Code" race ON race."CodeId" = p."RaceID_FK"
                        WHERE (usr."UserId" = user_id_param)
                        AND p."Status" = 'Active'
                        ORDER BY p."CreatedDate" DESC, p."ModifiedDate" DESC;
                	END IF;
                END;
                $$ LANGUAGE plpgsql;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_spGetPatientList";
                """);
        }
    }
}
