using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSpCreatePatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_SpCreatePatient"(
                    first_name_param text,
                    last_name_param text,
                    postal_code_param integer,
                    reason_of_admission_param text,
                    gender_param text,
                    resident_type_param text,
                    nric_param text,
                    display_name_param text,
                    patient_organization_param text
                )
                RETURNS text
                LANGUAGE plpgsql
                AS $$
                DECLARE
                    gender_id_fk integer;
                    resident_type_id_fk integer;
                    patient_id_result integer;
                    patient_org_id_fk integer;
                    case_id_no integer;
                    case_id_result text;
                    patient_profile_id_result integer;
                    english_code_id integer;
                    invoice_mode_id integer;
                    patient_type_id integer;
                    birth_date timestamp;
                BEGIN
                    -- Check for duplicate NRIC
                    IF EXISTS (
                        SELECT 1 
                        FROM "Patient" 
                        WHERE "IdentificationNumber" = nric_param
                    ) THEN
                        RETURN CONCAT('Duplicate NRIC ', nric_param);
                    END IF;
                
                    -- Get configuration and code values
                    SELECT CAST("ConfigValue" AS INTEGER) + 1 
                    INTO case_id_no 
                    FROM "SysConfig" 
                    WHERE "ConfigName" = 'CaseIdNo';
                
                    -- Update case ID counter
                    UPDATE "SysConfig" 
                    SET "ConfigValue" = case_id_no 
                    WHERE "ConfigName" = 'CaseIdNo';
                
                    -- Set calculated values
                    birth_date := CURRENT_TIMESTAMP - INTERVAL '60 years';
                    case_id_result := CONCAT('THC', case_id_no);
                
                    -- Get required code IDs
                    SELECT "CodeId" INTO gender_id_fk 
                    FROM "Code" 
                    WHERE "CodeTypeId_FK" = 10 
                    AND "CodeName" ILIKE gender_param 
                    AND NOT "IsDeleted";
                
                    SELECT "CodeId" INTO resident_type_id_fk 
                    FROM "Code" 
                    WHERE "CodeTypeId_FK" = 8 
                    AND "CodeName" ILIKE resident_type_param 
                    AND NOT "IsDeleted";
                
                    SELECT "CodeId" INTO patient_org_id_fk 
                    FROM "Code" 
                    WHERE "CodeTypeId_FK" = 68 
                    AND "CodeName" ILIKE patient_organization_param 
                    AND NOT "IsDeleted";
                
                    SELECT "CodeId" INTO invoice_mode_id 
                    FROM "Code" 
                    WHERE "CodeTypeId_FK" = 64 
                    AND "CodeName" ILIKE 'By Visit' 
                    AND NOT "IsDeleted";
                
                    SELECT "CodeId" INTO patient_type_id 
                    FROM "Code" 
                    WHERE "CodeTypeId_FK" = 3 
                    AND "CodeName" ILIKE 'Private Long Term' 
                    AND NOT "IsDeleted";
                
                    SELECT "CodeId" INTO english_code_id 
                    FROM "Code" 
                    WHERE "CodeTypeId_FK" = 7 
                    AND "CodeName" ILIKE 'ENGLISH' 
                    AND NOT "IsDeleted";
                
                    -- Insert patient profile
                    INSERT INTO "PatientProfile" (
                        "CreatedDate",
                        "CreatedBy_FK",
                        "MobilePhone",
                        "HomePhone",
                        "Email",
                        "BillingAddress1",
                        "BillingAddress2",
                        "BillingAddress3",
                        "BillingPostalCode"
                    ) 
                    VALUES (
                        CURRENT_TIMESTAMP,
                        1,
                        88888888,
                        88888888,
                        '',
                        'BillingAddress1',
                        'BillingAddress2',
                        'BillingAddress3',
                        409051
                    )
                    RETURNING "PatientProfileID" INTO patient_profile_id_result;
                
                    -- Insert patient
                    INSERT INTO "Patient" (
                        "NRIC",
                        "Firstname",
                        "Lastname",
                        "DateOfBirth",
                        "PostalCode",
                        "CaseID",
                        "Status",
                        "AdmittedDate",
                        "ReasonOfAdmission",
                        "CreatedDate",
                        "CreatedBy_FK",
                        "GenderID_FK",
                        "ResidentTypeID_FK",
                        "MaritalStatusID_FK",
                        "PatientReferralByID_FK",
                        "IdentificationNumber",
                        "PaymentMode",
                        "DisplayName",
                        "Accepted",
                        "PatientProfileID_FK",
                        "PatientTypeID_FK",
                        "InvoiceModeID_FK",
                        "MailingAddress1",
                        "MailingAddress2",
                        "MailingAddress3"
                    ) 
                    VALUES (
                        '',
                        first_name_param,
                        last_name_param,
                        birth_date,
                        postal_code_param,
                        case_id_result,
                        'Active',
                        CURRENT_TIMESTAMP,
                        reason_of_admission_param,
                        CURRENT_TIMESTAMP,
                        1,
                        gender_id_fk,
                        resident_type_id_fk,
                        48,
                        10023,
                        nric_param,
                        'By Visit',
                        display_name_param,
                        TRUE,
                        patient_profile_id_result,
                        patient_type_id,
                        invoice_mode_id,
                        'MailingAddress1',
                        'MailingAddress2',
                        'MailingAddress3'
                    )
                    RETURNING "PatientID" INTO patient_id_result;
                
                    -- Insert patient package
                    INSERT INTO "PatientPackage" (
                        "PatientID_FK",
                        "PackageID_FK"
                    ) 
                    VALUES (
                        patient_id_result,
                        1
                    );
                
                    -- Insert patient language
                    INSERT INTO "PatientLanguage" (
                        "PatientID_FK",
                        "CodeID_FK"
                    ) 
                    VALUES (
                        patient_id_result,
                        english_code_id
                    );
                
                    RETURN CONCAT('New Patient Created with ', nric_param, ', PatientID = ', patient_id_result);
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_SpCreatePatient";
                """);
        }
    }
}
