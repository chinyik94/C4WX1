using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFnCanDeleteCodetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "fn_CanDeleteCodetable"(
                    code_id INTEGER
                )
                RETURNS BOOLEAN
                LANGUAGE plpgsql
                AS $$
                DECLARE
                    code_type_id INTEGER;
                    is_system_used BOOLEAN;
                BEGIN
                    -- Fetch the CodeTypeId_FK and IsSystemUsed values for the given CodeID
                    SELECT "CodeTypeId_FK", "IsSystemUsed"
                    INTO code_type_id, is_system_used
                    FROM "Code"
                    WHERE "CodeId" = code_id;
                
                    -- Check if the code is system used
                    IF is_system_used THEN
                        RETURN FALSE;
                    END IF;
                
                    -- Check conditions based on the CodeTypeId_FK
                    CASE code_type_id
                        WHEN 2 THEN
                            IF EXISTS (
                                SELECT 1
                                FROM "Users" u
                                INNER JOIN "UserSkillset" us ON u."UserId" = us."UserID_FK"
                                INNER JOIN "Code" c ON us."CodeID_FK" = c."CodeId"
                                WHERE u."IsDeleted" = FALSE AND c."IsDeleted" = FALSE AND us."CodeID_FK" = code_id
                            ) THEN
                                RETURN FALSE;
                            END IF;
                        WHEN 6 THEN
                            IF EXISTS (
                                SELECT 1
                                FROM "Enquiry"
                                WHERE "IsDeleted" = FALSE AND "EnquirySourceID_FK" = code_id
                            ) THEN
                                RETURN FALSE;
                            END IF;
                        WHEN 7 THEN
                            IF EXISTS (
                                SELECT 1
                                FROM "Enquiry" e
                                INNER JOIN "EnquiryLanguage" el ON e."EnquiryID" = el."EnquiryID_FK"
                                WHERE e."IsDeleted" = FALSE AND el."CodeID_FK" = code_id
                            ) OR EXISTS (
                                SELECT 1
                                FROM "Patient" p
                                INNER JOIN "PatientLanguage" pl ON p."PatientID" = pl."PatientID_FK"
                                WHERE pl."CodeID_FK" = code_id
                            ) OR EXISTS (
                                SELECT 1
                                FROM "Users" u
                                INNER JOIN "UserLanguage" ul ON u."UserId" = ul."UserID_FK"
                                WHERE u."IsDeleted" = FALSE AND ul."LanguageID_FK" = code_id
                            ) THEN
                                RETURN FALSE;
                            END IF;
                        WHEN 8 THEN
                            IF EXISTS (
                                SELECT 1
                                FROM "Patient"
                                WHERE "ResidentTypeID_FK" = code_id
                            ) THEN
                                RETURN FALSE;
                            END IF;
                        WHEN 9 THEN
                            IF EXISTS (
                                SELECT 1
                                FROM "Patient"
                                WHERE "MaritalStatusID_FK" = code_id
                            ) OR EXISTS (
                                SELECT 1
                                FROM "PatientSocialSupport"
                                WHERE "MaritalStatusID_FK" = code_id
                            ) THEN
                                RETURN FALSE;
                            END IF;
                        WHEN 10 THEN 
                		    IF EXISTS (
                		        SELECT 1
                		        FROM "Enquiry" e
                		        WHERE e."IsDeleted" = FALSE AND e."GenderID_FK" = gender_id
                		    ) OR EXISTS (
                		        SELECT 1
                		        FROM "Patient"
                		        WHERE "GenderID_FK" = gender_id
                		    ) OR EXISTS (
                		        SELECT 1
                		        FROM "PatientSocialSupport"
                		        WHERE "GenderID_FK" = gender_id
                		    ) THEN
                		        RETURN FALSE;
                		    END IF;
                		WHEN 11 THEN
                		    IF EXISTS (
                		        SELECT 1
                		        FROM "Enquiry" e
                		        WHERE e."IsDeleted" = FALSE AND e."CaregiverAtHomeID_FK" = caregiver_at_home_id
                		    ) THEN
                		        RETURN FALSE;
                		    END IF;
                		WHEN 12 THEN
                		    IF EXISTS (
                		        SELECT 1
                		        FROM "PatientProfile"
                		        WHERE "BloodTypeID_FK" = blood_type_id
                		    ) THEN
                		        RETURN FALSE;
                		    END IF;
                		WHEN 13 THEN
                		    IF EXISTS (
                		        SELECT 1
                		        FROM "Enquiry" e
                		        INNER JOIN "EnquiryServicesRequired" s ON e."EnquiryID" = s."EnquiryID_FK"
                		        WHERE e."IsDeleted" = FALSE AND s."CodeID_FK" = code_id
                		    )
                		    OR EXISTS (
                		        SELECT 1
                		        FROM "PatientReferral" pr
                		        INNER JOIN "PatientReferralService" prs ON pr."PatientReferralID" = prs."PatientReferralID_FK"
                		        WHERE prs."ServiceID_FK" = code_id
                		    )
                		    OR EXISTS (
                		        SELECT 1
                		        FROM "Code" c
                		        INNER JOIN "ServiceSkillset" s ON c."CodeId" = s."SkillsetID_FK"
                		        WHERE c."IsDeleted" = FALSE AND s."ServiceID_FK" = code_id
                		    )
                		    OR EXISTS (
                		        SELECT 1
                		        FROM "Task" t
                		        INNER JOIN "TaskServicesRequired" s ON t."TaskID" = s."TaskID_FK"
                		        WHERE t."IsDeleted" = FALSE AND s."CodeID_FK" = code_id
                		    ) THEN
                		        RETURN FALSE;
                		    END IF;
                		WHEN 14 THEN
                		    IF EXISTS (
                		        SELECT 1
                		        FROM "PatientMedicationConsume" pmc
                		        INNER JOIN "PatientMedication" pm ON pmc."PatientMedicationID_FK" = pm."PatientMedicationID"
                		        WHERE pmc."IsDeleted" = FALSE 
                		          AND pmc."RouteID_FK" = route_id
                		          AND EXISTS (
                		              SELECT 1 
                		              FROM "Patient" p 
                		              WHERE p."PatientMedicationID_FK" = pm."PatientMedicationID"
                		          )
                		    ) THEN
                		        RETURN FALSE;
                		    END IF;
                		WHEN 15 THEN
                		    IF EXISTS (
                		        SELECT 1
                		        FROM "PatientMedicationConsume" pmc
                		        INNER JOIN "PatientMedication" pm ON pmc."PatientMedicationID_FK" = pm."PatientMedicationID"
                		        WHERE pmc."IsDeleted" = FALSE
                		          AND pmc."DosageID_FK" = dosage_id
                		          AND EXISTS (
                		              SELECT 1 
                		              FROM "Patient" p 
                		              WHERE p."PatientMedicationID_FK" = pm."PatientMedicationID"
                		          )
                		    ) THEN
                		        RETURN FALSE;
                		    END IF;
                		WHEN 16 THEN
                		    IF EXISTS (
                		        SELECT 1
                		        FROM "PatientMedicationConsume" pmc
                		        INNER JOIN "PatientMedication" pm ON pmc."PatientMedicationID_FK" = pm."PatientMedicationID"
                		        WHERE pmc."IsDeleted" = FALSE
                		          AND pmc."FrequencyID_FK" = frequency_id
                		          AND EXISTS (
                		              SELECT 1 
                		              FROM "Patient" p 
                		              WHERE p."PatientMedicationID_FK" = pm."PatientMedicationID"
                		          )
                		    ) THEN
                		        RETURN FALSE;
                		    END IF;
                		WHEN 17 THEN
                		    IF EXISTS (
                		        SELECT 1
                		        FROM "PatientMedication" pm
                		        INNER JOIN "PatientMedicationSupply" pms ON pms."PatientMedicationID_FK" = pm."PatientMedicationID"
                		        WHERE pms."SupplyID_FK" = frequency_id
                		          AND EXISTS (
                		              SELECT 1 
                		              FROM "Patient" p 
                		              WHERE p."PatientMedicationID_FK" = pm."PatientMedicationID"
                		          )
                		    ) THEN
                		        RETURN FALSE;
                		    END IF;
                		WHEN 18 THEN
                		    IF EXISTS (
                		        SELECT 1
                		        FROM "Patient" p
                		        INNER JOIN "PatientSocialSupport" ps ON p."PatientID" = ps."PatientID_FK"
                		        WHERE ps."IsDeleted" = FALSE
                		          AND ps."RelationshipID_FK" = relationship_id
                		    ) OR EXISTS (
                		        SELECT 1
                		        FROM "InitialCareAssessment" i
                		        INNER JOIN "PatientSocialSupport" ps ON i."InitialCareAssessmentID" = ps."InitialCareAssessmentID_FK"
                		        WHERE i."IsDeleted" = FALSE
                		          AND ps."IsDeleted" = FALSE
                		          AND ps."RelationshipID_FK" = relationship_id
                		    ) THEN
                		        RETURN FALSE;
                		    END IF;
                		WHEN 19 THEN
                		    IF EXISTS (
                		        SELECT 1
                		        FROM "Patient" p
                		        INNER JOIN "PatientSocialSupport" ps ON p."PatientID" = ps."PatientID_FK"
                		        WHERE ps."IsDeleted" = FALSE
                		          AND ps."NationalityID_FK" = nationality_id
                		    ) OR EXISTS (
                		        SELECT 1
                		        FROM "InitialCareAssessment" i
                		        INNER JOIN "PatientSocialSupport" ps ON i."InitialCareAssessmentID" = ps."InitialCareAssessmentID_FK"
                		        WHERE i."IsDeleted" = FALSE
                		          AND ps."IsDeleted" = FALSE
                		          AND ps."NationalityID_FK" = nationality_id
                		    ) THEN
                		        RETURN FALSE;
                		    END IF;
                		WHEN 20 THEN
                	        IF EXISTS (
                	            SELECT 1
                	            FROM "Patient"
                	            WHERE "PatientReferralByID_FK" = id
                	        ) THEN
                	            RETURN FALSE;
                	        END IF;
                		WHEN 21 THEN
                	        IF EXISTS (
                	            SELECT 1
                	            FROM "PatientDrugAllergy" pda
                	            WHERE pda."IsDeleted" = FALSE
                	              AND pda."ReactionID_FK" = id
                	              AND (
                	                (pda."PatientID_FK" IS NOT NULL AND EXISTS (
                	                    SELECT 1
                	                    FROM "Patient" p
                	                    WHERE pda."PatientID_FK" = p."PatientID"
                	                )) 
                	                OR 
                	                (pda."InitialCareAssessmentID_FK" IS NOT NULL AND EXISTS (
                	                    SELECT 1
                	                    FROM "InitialCareAssessment" i
                	                    WHERE pda."InitialCareAssessmentID_FK" = i."InitialCareAssessmentID"
                	                ))
                	              )
                	        ) THEN
                	            RETURN FALSE;
                	        END IF;
                		WHEN 22 THEN
                	        IF EXISTS (
                	            SELECT 1
                	            FROM "PatientMedicationConsume" pmc
                	            INNER JOIN "PatientMedication" pm ON pmc."PatientMedicationID_FK" = pm."PatientMedicationID"
                	            WHERE pmc."IsDeleted" = FALSE
                	              AND pmc."AcutePRNIndicationID_FK" = id
                	              AND EXISTS (
                	                SELECT 1
                	                FROM "Patient" p
                	                WHERE p."PatientMedicationID_FK" = pm."PatientMedicationID"
                	              )
                	        ) THEN
                	            RETURN FALSE;
                	        END IF;
                		WHEN 23 THEN
                	        IF EXISTS (
                	            SELECT 1
                	            FROM "PatientOtherAllergy" poa
                	            WHERE poa."IsDeleted" = FALSE
                	              AND poa."DescriptionID_FK" = id
                	              AND (
                	                (poa."PatientID_FK" IS NOT NULL AND EXISTS (
                	                    SELECT 1
                	                    FROM "Patient" p
                	                    WHERE poa."PatientID_FK" = p."PatientID"
                	                ))
                	                OR
                	                (poa."InitialCareAssessmentID_FK" IS NOT NULL AND EXISTS (
                	                    SELECT 1
                	                    FROM "InitialCareAssessment" i
                	                    WHERE poa."InitialCareAssessmentID_FK" = i."InitialCareAssessmentID"
                	                ))
                	              )
                	        ) THEN
                	            RETURN FALSE;
                	        END IF;
                		WHEN 24 THEN
                	        IF EXISTS (
                	            SELECT 1
                	            FROM "Code"
                	            WHERE "CodeTypeId_FK" = 25
                	              AND "IsDeleted" = FALSE
                	              AND "MedicationGroupID_FK" = id
                	        ) THEN
                	            RETURN FALSE;
                	        END IF;
                		WHEN 25 THEN
                	        IF EXISTS (
                	            SELECT 1
                	            FROM "Patient" p
                	            INNER JOIN "PatientDrugAllergy" pd ON p."PatientID" = pd."PatientID_FK"
                	            WHERE pd."IsDeleted" = FALSE
                	              AND pd."MedicationID_FK" = id
                	        ) OR EXISTS (
                	            SELECT 1
                	            FROM "InitialCareAssessment" i
                	            INNER JOIN "PatientDrugAllergy" pd ON i."InitialCareAssessmentID" = pd."InitialCareAssessmentID_FK"
                	            WHERE i."IsDeleted" = FALSE
                	              AND pd."IsDeleted" = FALSE
                	              AND pd."MedicationID_FK" = id
                	        ) OR EXISTS (
                	            SELECT 1
                	            FROM "PatientMedicationConsume" pmc
                	            INNER JOIN "PatientMedication" pm ON pmc."PatientMedicationID_FK" = pm."PatientMedicationID"
                	            WHERE pmc."IsDeleted" = FALSE
                	              AND pmc."MedicationID_FK" = id
                	              AND EXISTS (
                	                SELECT 1
                	                FROM "Patient" p
                	                WHERE p."PatientMedicationID_FK" = pm."PatientMedicationID"
                	              )
                	        ) THEN
                	            RETURN FALSE;
                	        END IF;
                		WHEN 33 THEN
                	        IF EXISTS (
                	            SELECT 1
                	            FROM "Item"
                	            WHERE "CategoryID_FK" = id
                	              AND "IsDeleted" = FALSE
                	        ) THEN
                	            RETURN FALSE;
                	        END IF;
                		WHEN 34 THEN
                	        IF EXISTS (
                	            SELECT 1
                	            FROM "Item"
                	            WHERE "ItemUnitID_FK" = id
                	              AND "IsDeleted" = FALSE
                	        ) THEN
                	            RETURN FALSE;
                	        END IF;
                		ELSE
                			RETURN TRUE;
                	END CASE;
                
                    -- Return TRUE if no conditions matched
                    RETURN TRUE;
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP FUNCTION IF EXISTS "fn_CanDeleteCodetable";
                """);
        }
    }
}
