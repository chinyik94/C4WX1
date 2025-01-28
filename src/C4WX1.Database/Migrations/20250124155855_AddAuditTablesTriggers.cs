using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditTablesTriggers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION "tr_Activity_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_Activity"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_Activity"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_Activity"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_Activity"
                AFTER INSERT OR UPDATE OR DELETE ON "Activity"
                FOR EACH ROW EXECUTE FUNCTION "tr_Activity_func"();
                
                CREATE OR REPLACE FUNCTION "tr_AMTQuestion_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_AMTQuestion"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_AMTQuestion"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_AMTQuestion"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_AMTQuestion"
                AFTER INSERT OR UPDATE OR DELETE ON "AMTQuestion"
                FOR EACH ROW EXECUTE FUNCTION "tr_AMTQuestion_func"();
                
                CREATE OR REPLACE FUNCTION "tr_APIAccessKey_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_APIAccessKey"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_APIAccessKey"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_APIAccessKey"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_APIAccessKey"
                AFTER INSERT OR UPDATE OR DELETE ON "APIAccessKey"
                FOR EACH ROW EXECUTE FUNCTION "tr_APIAccessKey_func"();
                
                CREATE OR REPLACE FUNCTION "tr_APIMonitor_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_APIMonitor"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_APIMonitor"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_APIMonitor"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_APIMonitor"
                AFTER INSERT OR UPDATE OR DELETE ON "APIMonitor"
                FOR EACH ROW EXECUTE FUNCTION "tr_APIMonitor_func"();
                
                CREATE OR REPLACE FUNCTION "tr_APIOrder_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_APIOrder"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_APIOrder"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_APIOrder"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_APIOrder"
                AFTER INSERT OR UPDATE OR DELETE ON "APIOrder"
                FOR EACH ROW EXECUTE FUNCTION "tr_APIOrder_func"();
                
                CREATE OR REPLACE FUNCTION "tr_APIOrderAllergy_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_APIOrderAllergy"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_APIOrderAllergy"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_APIOrderAllergy"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_APIOrderAllergy"
                AFTER INSERT OR UPDATE OR DELETE ON "APIOrderAllergy"
                FOR EACH ROW EXECUTE FUNCTION "tr_APIOrderAllergy_func"();
                
                CREATE OR REPLACE FUNCTION "tr_APIOrderDiagnosis_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_APIOrderDiagnosis"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_APIOrderDiagnosis"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_APIOrderDiagnosis"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_APIOrderDiagnosis"
                AFTER INSERT OR UPDATE OR DELETE ON "APIOrderDiagnosis"
                FOR EACH ROW EXECUTE FUNCTION "tr_APIOrderDiagnosis_func"();
                
                CREATE OR REPLACE FUNCTION "tr_APIOrderMedication_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_APIOrderMedication"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_APIOrderMedication"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_APIOrderMedication"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_APIOrderMedication"
                AFTER INSERT OR UPDATE OR DELETE ON "APIOrderMedication"
                FOR EACH ROW EXECUTE FUNCTION "tr_APIOrderMedication_func"();
                
                CREATE OR REPLACE FUNCTION "tr_APIOrderTask_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_APIOrderTask"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_APIOrderTask"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_APIOrderTask"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_APIOrderTask"
                AFTER INSERT OR UPDATE OR DELETE ON "APIOrderTask"
                FOR EACH ROW EXECUTE FUNCTION "tr_APIOrderTask_func"();
                
                CREATE OR REPLACE FUNCTION "tr_APNSNotification_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_APNSNotification"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_APNSNotification"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_APNSNotification"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_APNSNotification"
                AFTER INSERT OR UPDATE OR DELETE ON "APNSNotification"
                FOR EACH ROW EXECUTE FUNCTION "tr_APNSNotification_func"();
                
                CREATE OR REPLACE FUNCTION "tr_BillingInvoice_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_BillingInvoice"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_BillingInvoice"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_BillingInvoice"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_BillingInvoice"
                AFTER INSERT OR UPDATE OR DELETE ON "BillingInvoice"
                FOR EACH ROW EXECUTE FUNCTION "tr_BillingInvoice_func"();
                
                CREATE OR REPLACE FUNCTION "tr_BillingInvoiceConsumable_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_BillingInvoiceConsumable"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_BillingInvoiceConsumable"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_BillingInvoiceConsumable"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_BillingInvoiceConsumable"
                AFTER INSERT OR UPDATE OR DELETE ON "BillingInvoiceConsumable"
                FOR EACH ROW EXECUTE FUNCTION "tr_BillingInvoiceConsumable_func"();
                
                CREATE OR REPLACE FUNCTION "tr_BillingInvoiceService_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_BillingInvoiceService"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_BillingInvoiceService"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_BillingInvoiceService"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_BillingInvoiceService"
                AFTER INSERT OR UPDATE OR DELETE ON "BillingInvoiceService"
                FOR EACH ROW EXECUTE FUNCTION "tr_BillingInvoiceService_func"();
                
                CREATE OR REPLACE FUNCTION "tr_BillingPackage_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_BillingPackage"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_BillingPackage"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_BillingPackage"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_BillingPackage"
                AFTER INSERT OR UPDATE OR DELETE ON "BillingPackage"
                FOR EACH ROW EXECUTE FUNCTION "tr_BillingPackage_func"();
                
                CREATE OR REPLACE FUNCTION "tr_BillingPackageInformation_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_BillingPackageInformation"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_BillingPackageInformation"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_BillingPackageInformation"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_BillingPackageInformation"
                AFTER INSERT OR UPDATE OR DELETE ON "BillingPackageInformation"
                FOR EACH ROW EXECUTE FUNCTION "tr_BillingPackageInformation_func"();
                
                CREATE OR REPLACE FUNCTION "tr_BillingPackageRequest_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_BillingPackageRequest"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_BillingPackageRequest"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_BillingPackageRequest"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_BillingPackageRequest"
                AFTER INSERT OR UPDATE OR DELETE ON "BillingPackageRequest"
                FOR EACH ROW EXECUTE FUNCTION "tr_BillingPackageRequest_func"();
                
                CREATE OR REPLACE FUNCTION "tr_BillingProposal_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_BillingProposal"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_BillingProposal"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_BillingProposal"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_BillingProposal"
                AFTER INSERT OR UPDATE OR DELETE ON "BillingProposal"
                FOR EACH ROW EXECUTE FUNCTION "tr_BillingProposal_func"();
                
                CREATE OR REPLACE FUNCTION "tr_BillingProposalService_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_BillingProposalService"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_BillingProposalService"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_BillingProposalService"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_BillingProposalService"
                AFTER INSERT OR UPDATE OR DELETE ON "BillingProposalService"
                FOR EACH ROW EXECUTE FUNCTION "tr_BillingProposalService_func"();
                
                CREATE OR REPLACE FUNCTION "tr_BillingService_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_BillingService"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_BillingService"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_BillingService"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_BillingService"
                AFTER INSERT OR UPDATE OR DELETE ON "BillingService"
                FOR EACH ROW EXECUTE FUNCTION "tr_BillingService_func"();
                
                CREATE OR REPLACE FUNCTION "tr_Branch_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_Branch"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_Branch"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_Branch"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_Branch"
                AFTER INSERT OR UPDATE OR DELETE ON "Branch"
                FOR EACH ROW EXECUTE FUNCTION "tr_Branch_func"();
                
                CREATE OR REPLACE FUNCTION "tr_C4WDeviceToken_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_C4WDeviceToken"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_C4WDeviceToken"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_C4WDeviceToken"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_C4WDeviceToken"
                AFTER INSERT OR UPDATE OR DELETE ON "C4WDeviceToken"
                FOR EACH ROW EXECUTE FUNCTION "tr_C4WDeviceToken_func"();
                
                CREATE OR REPLACE FUNCTION "tr_CarePlan_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_CarePlan"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_CarePlan"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_CarePlan"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_CarePlan"
                AFTER INSERT OR UPDATE OR DELETE ON "CarePlan"
                FOR EACH ROW EXECUTE FUNCTION "tr_CarePlan_func"();
                
                CREATE OR REPLACE FUNCTION "tr_CarePlanDetail_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_CarePlanDetail"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_CarePlanDetail"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_CarePlanDetail"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_CarePlanDetail"
                AFTER INSERT OR UPDATE OR DELETE ON "CarePlanDetail"
                FOR EACH ROW EXECUTE FUNCTION "tr_CarePlanDetail_func"();
                
                CREATE OR REPLACE FUNCTION "tr_CarePlanStatus_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_CarePlanStatus"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_CarePlanStatus"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_CarePlanStatus"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_CarePlanStatus"
                AFTER INSERT OR UPDATE OR DELETE ON "CarePlanStatus"
                FOR EACH ROW EXECUTE FUNCTION "tr_CarePlanStatus_func"();
                
                CREATE OR REPLACE FUNCTION "tr_CarePlanSub_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_CarePlanSub"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_CarePlanSub"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_CarePlanSub"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_CarePlanSub"
                AFTER INSERT OR UPDATE OR DELETE ON "CarePlanSub"
                FOR EACH ROW EXECUTE FUNCTION "tr_CarePlanSub_func"();
                
                CREATE OR REPLACE FUNCTION "tr_CarePlanSubActivity_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_CarePlanSubActivity"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_CarePlanSubActivity"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_CarePlanSubActivity"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_CarePlanSubActivity"
                AFTER INSERT OR UPDATE OR DELETE ON "CarePlanSubActivity"
                FOR EACH ROW EXECUTE FUNCTION "tr_CarePlanSubActivity_func"();
                
                CREATE OR REPLACE FUNCTION "tr_CarePlanSubCPGoals_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_CarePlanSubCPGoals"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_CarePlanSubCPGoals"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_CarePlanSubCPGoals"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_CarePlanSubCPGoals"
                AFTER INSERT OR UPDATE OR DELETE ON "CarePlanSubCPGoals"
                FOR EACH ROW EXECUTE FUNCTION "tr_CarePlanSubCPGoals_func"();
                
                CREATE OR REPLACE FUNCTION "tr_CarePlanSubGoal_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_CarePlanSubGoal"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_CarePlanSubGoal"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_CarePlanSubGoal"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_CarePlanSubGoal"
                AFTER INSERT OR UPDATE OR DELETE ON "CarePlanSubGoal"
                FOR EACH ROW EXECUTE FUNCTION "tr_CarePlanSubGoal_func"();
                
                CREATE OR REPLACE FUNCTION "tr_CarePlanSubIntervention_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_CarePlanSubIntervention"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_CarePlanSubIntervention"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_CarePlanSubIntervention"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_CarePlanSubIntervention"
                AFTER INSERT OR UPDATE OR DELETE ON "CarePlanSubIntervention"
                FOR EACH ROW EXECUTE FUNCTION "tr_CarePlanSubIntervention_func"();
                
                CREATE OR REPLACE FUNCTION "tr_CarePlanSubProblemList_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_CarePlanSubProblemList"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_CarePlanSubProblemList"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_CarePlanSubProblemList"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_CarePlanSubProblemList"
                AFTER INSERT OR UPDATE OR DELETE ON "CarePlanSubProblemList"
                FOR EACH ROW EXECUTE FUNCTION "tr_CarePlanSubProblemList_func"();
                
                CREATE OR REPLACE FUNCTION "tr_CarePlanSubProblemListGoal_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_CarePlanSubProblemListGoal"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_CarePlanSubProblemListGoal"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_CarePlanSubProblemListGoal"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_CarePlanSubProblemListGoal"
                AFTER INSERT OR UPDATE OR DELETE ON "CarePlanSubProblemListGoal"
                FOR EACH ROW EXECUTE FUNCTION "tr_CarePlanSubProblemListGoal_func"();
                
                CREATE OR REPLACE FUNCTION "tr_CareReport_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_CareReport"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_CareReport"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_CareReport"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_CareReport"
                AFTER INSERT OR UPDATE OR DELETE ON "CareReport"
                FOR EACH ROW EXECUTE FUNCTION "tr_CareReport_func"();
                
                CREATE OR REPLACE FUNCTION "tr_CareReportConfig_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_CareReportConfig"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_CareReportConfig"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_CareReportConfig"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_CareReportConfig"
                AFTER INSERT OR UPDATE OR DELETE ON "CareReportConfig"
                FOR EACH ROW EXECUTE FUNCTION "tr_CareReportConfig_func"();
                
                CREATE OR REPLACE FUNCTION "tr_CareReportRehabilitation_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_CareReportRehabilitation"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_CareReportRehabilitation"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_CareReportRehabilitation"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_CareReportRehabilitation"
                AFTER INSERT OR UPDATE OR DELETE ON "CareReportRehabilitation"
                FOR EACH ROW EXECUTE FUNCTION "tr_CareReportRehabilitation_func"();
                
                CREATE OR REPLACE FUNCTION "tr_CareReportSocialSupport_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_CareReportSocialSupport"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_CareReportSocialSupport"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_CareReportSocialSupport"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_CareReportSocialSupport"
                AFTER INSERT OR UPDATE OR DELETE ON "CareReportSocialSupport"
                FOR EACH ROW EXECUTE FUNCTION "tr_CareReportSocialSupport_func"();
                
                CREATE OR REPLACE FUNCTION "tr_CareReportSystemInfo_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_CareReportSystemInfo"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_CareReportSystemInfo"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_CareReportSystemInfo"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_CareReportSystemInfo"
                AFTER INSERT OR UPDATE OR DELETE ON "CareReportSystemInfo"
                FOR EACH ROW EXECUTE FUNCTION "tr_CareReportSystemInfo_func"();
                
                CREATE OR REPLACE FUNCTION "tr_Chat_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_Chat"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_Chat"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_Chat"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_Chat"
                AFTER INSERT OR UPDATE OR DELETE ON "Chat"
                FOR EACH ROW EXECUTE FUNCTION "tr_Chat_func"();
                
                CREATE OR REPLACE FUNCTION "tr_Code_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_Code"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_Code"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_Code"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_Code"
                AFTER INSERT OR UPDATE OR DELETE ON "Code"
                FOR EACH ROW EXECUTE FUNCTION "tr_Code_func"();
                
                CREATE OR REPLACE FUNCTION "tr_CodeType_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_CodeType"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_CodeType"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_CodeType"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_CodeType"
                AFTER INSERT OR UPDATE OR DELETE ON "CodeType"
                FOR EACH ROW EXECUTE FUNCTION "tr_CodeType_func"();
                
                CREATE OR REPLACE FUNCTION "tr_CPGoals_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_CPGoals"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_CPGoals"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_CPGoals"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_CPGoals"
                AFTER INSERT OR UPDATE OR DELETE ON "CPGoals"
                FOR EACH ROW EXECUTE FUNCTION "tr_CPGoals_func"();
                
                CREATE OR REPLACE FUNCTION "tr_Diagnosis_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_Diagnosis"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_Diagnosis"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_Diagnosis"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_Diagnosis"
                AFTER INSERT OR UPDATE OR DELETE ON "Diagnosis"
                FOR EACH ROW EXECUTE FUNCTION "tr_Diagnosis_func"();
                
                CREATE OR REPLACE FUNCTION "tr_DischargeSummaryReport_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_DischargeSummaryReport"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_DischargeSummaryReport"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_DischargeSummaryReport"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_DischargeSummaryReport"
                AFTER INSERT OR UPDATE OR DELETE ON "DischargeSummaryReport"
                FOR EACH ROW EXECUTE FUNCTION "tr_DischargeSummaryReport_func"();
                
                CREATE OR REPLACE FUNCTION "tr_DischargeSummaryReportAttachment_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_DischargeSummaryReportAttachment"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_DischargeSummaryReportAttachment"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_DischargeSummaryReportAttachment"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_DischargeSummaryReportAttachment"
                AFTER INSERT OR UPDATE OR DELETE ON "DischargeSummaryReportAttachment"
                FOR EACH ROW EXECUTE FUNCTION "tr_DischargeSummaryReportAttachment_func"();
                
                CREATE OR REPLACE FUNCTION "tr_Disease_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_Disease"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_Disease"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_Disease"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_Disease"
                AFTER INSERT OR UPDATE OR DELETE ON "Disease"
                FOR EACH ROW EXECUTE FUNCTION "tr_Disease_func"();
                
                CREATE OR REPLACE FUNCTION "tr_DiseaseInfo_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_DiseaseInfo"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_DiseaseInfo"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_DiseaseInfo"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_DiseaseInfo"
                AFTER INSERT OR UPDATE OR DELETE ON "DiseaseInfo"
                FOR EACH ROW EXECUTE FUNCTION "tr_DiseaseInfo_func"();
                
                CREATE OR REPLACE FUNCTION "tr_DiseaseSubInfo_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_DiseaseSubInfo"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_DiseaseSubInfo"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_DiseaseSubInfo"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_DiseaseSubInfo"
                AFTER INSERT OR UPDATE OR DELETE ON "DiseaseSubInfo"
                FOR EACH ROW EXECUTE FUNCTION "tr_DiseaseSubInfo_func"();
                
                CREATE OR REPLACE FUNCTION "tr_DiseaseVitalSignType_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_DiseaseVitalSignType"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_DiseaseVitalSignType"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_DiseaseVitalSignType"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_DiseaseVitalSignType"
                AFTER INSERT OR UPDATE OR DELETE ON "DiseaseVitalSignType"
                FOR EACH ROW EXECUTE FUNCTION "tr_DiseaseVitalSignType_func"();
                
                CREATE OR REPLACE FUNCTION "tr_EBASDEPQuestion_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_EBASDEPQuestion"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_EBASDEPQuestion"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_EBASDEPQuestion"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_EBASDEPQuestion"
                AFTER INSERT OR UPDATE OR DELETE ON "EBASDEPQuestion"
                FOR EACH ROW EXECUTE FUNCTION "tr_EBASDEPQuestion_func"();
                
                CREATE OR REPLACE FUNCTION "tr_Enquiry_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_Enquiry"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_Enquiry"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_Enquiry"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_Enquiry"
                AFTER INSERT OR UPDATE OR DELETE ON "Enquiry"
                FOR EACH ROW EXECUTE FUNCTION "tr_Enquiry_func"();
                
                CREATE OR REPLACE FUNCTION "tr_EnquiryAttachment_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_EnquiryAttachment"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_EnquiryAttachment"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_EnquiryAttachment"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_EnquiryAttachment"
                AFTER INSERT OR UPDATE OR DELETE ON "EnquiryAttachment"
                FOR EACH ROW EXECUTE FUNCTION "tr_EnquiryAttachment_func"();
                
                CREATE OR REPLACE FUNCTION "tr_EnquiryConfig_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_EnquiryConfig"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_EnquiryConfig"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_EnquiryConfig"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_EnquiryConfig"
                AFTER INSERT OR UPDATE OR DELETE ON "EnquiryConfig"
                FOR EACH ROW EXECUTE FUNCTION "tr_EnquiryConfig_func"();
                
                CREATE OR REPLACE FUNCTION "tr_EnquiryEscPerson_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_EnquiryEscPerson"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_EnquiryEscPerson"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_EnquiryEscPerson"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_EnquiryEscPerson"
                AFTER INSERT OR UPDATE OR DELETE ON "EnquiryEscPerson"
                FOR EACH ROW EXECUTE FUNCTION "tr_EnquiryEscPerson_func"();
                
                CREATE OR REPLACE FUNCTION "tr_EnquiryLanguage_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_EnquiryLanguage"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_EnquiryLanguage"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_EnquiryLanguage"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_EnquiryLanguage"
                AFTER INSERT OR UPDATE OR DELETE ON "EnquiryLanguage"
                FOR EACH ROW EXECUTE FUNCTION "tr_EnquiryLanguage_func"();
                
                CREATE OR REPLACE FUNCTION "tr_EnquirySCM_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_EnquirySCM"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_EnquirySCM"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_EnquirySCM"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_EnquirySCM"
                AFTER INSERT OR UPDATE OR DELETE ON "EnquirySCM"
                FOR EACH ROW EXECUTE FUNCTION "tr_EnquirySCM_func"();
                
                CREATE OR REPLACE FUNCTION "tr_EnquiryServicesRequired_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_EnquiryServicesRequired"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_EnquiryServicesRequired"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_EnquiryServicesRequired"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_EnquiryServicesRequired"
                AFTER INSERT OR UPDATE OR DELETE ON "EnquiryServicesRequired"
                FOR EACH ROW EXECUTE FUNCTION "tr_EnquiryServicesRequired_func"();
                
                CREATE OR REPLACE FUNCTION "tr_Event_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_Event"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_Event"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_Event"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_Event"
                AFTER INSERT OR UPDATE OR DELETE ON "Event"
                FOR EACH ROW EXECUTE FUNCTION "tr_Event_func"();
                
                CREATE OR REPLACE FUNCTION "tr_EventUser_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_EventUser"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_EventUser"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_EventUser"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_EventUser"
                AFTER INSERT OR UPDATE OR DELETE ON "EventUser"
                FOR EACH ROW EXECUTE FUNCTION "tr_EventUser_func"();
                
                CREATE OR REPLACE FUNCTION "tr_EventUserLog_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_EventUserLog"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_EventUserLog"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_EventUserLog"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_EventUserLog"
                AFTER INSERT OR UPDATE OR DELETE ON "EventUserLog"
                FOR EACH ROW EXECUTE FUNCTION "tr_EventUserLog_func"();
                
                CREATE OR REPLACE FUNCTION "tr_ExternalDoctor_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_ExternalDoctor"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_ExternalDoctor"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_ExternalDoctor"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_ExternalDoctor"
                AFTER INSERT OR UPDATE OR DELETE ON "ExternalDoctor"
                FOR EACH ROW EXECUTE FUNCTION "tr_ExternalDoctor_func"();
                
                CREATE OR REPLACE FUNCTION "tr_GeoFencing_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_GeoFencing"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_GeoFencing"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_GeoFencing"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_GeoFencing"
                AFTER INSERT OR UPDATE OR DELETE ON "GeoFencing"
                FOR EACH ROW EXECUTE FUNCTION "tr_GeoFencing_func"();
                
                CREATE OR REPLACE FUNCTION "tr_Group_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_Group"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_Group"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_Group"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_Group"
                AFTER INSERT OR UPDATE OR DELETE ON "Group"
                FOR EACH ROW EXECUTE FUNCTION "tr_Group_func"();
                
                CREATE OR REPLACE FUNCTION "tr_GroupRole_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_GroupRole"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_GroupRole"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_GroupRole"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_GroupRole"
                AFTER INSERT OR UPDATE OR DELETE ON "GroupRole"
                FOR EACH ROW EXECUTE FUNCTION "tr_GroupRole_func"();
                
                CREATE OR REPLACE FUNCTION "tr_ICAWoundCare_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_ICAWoundCare"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_ICAWoundCare"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_ICAWoundCare"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_ICAWoundCare"
                AFTER INSERT OR UPDATE OR DELETE ON "ICAWoundCare"
                FOR EACH ROW EXECUTE FUNCTION "tr_ICAWoundCare_func"();
                
                CREATE OR REPLACE FUNCTION "tr_InitialCareAssessment_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_InitialCareAssessment"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_InitialCareAssessment"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_InitialCareAssessment"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_InitialCareAssessment"
                AFTER INSERT OR UPDATE OR DELETE ON "InitialCareAssessment"
                FOR EACH ROW EXECUTE FUNCTION "tr_InitialCareAssessment_func"();
                
                CREATE OR REPLACE FUNCTION "tr_InitialCareAssessmentAttachment_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_InitialCareAssessmentAttachment"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_InitialCareAssessmentAttachment"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_InitialCareAssessmentAttachment"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_InitialCareAssessmentAttachment"
                AFTER INSERT OR UPDATE OR DELETE ON "InitialCareAssessmentAttachment"
                FOR EACH ROW EXECUTE FUNCTION "tr_InitialCareAssessmentAttachment_func"();
                
                CREATE OR REPLACE FUNCTION "tr_InitialCareAssessmentSpecialInstruction_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_InitialCareAssessmentSpecialInstruction"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_InitialCareAssessmentSpecialInstruction"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_InitialCareAssessmentSpecialInstruction"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_InitialCareAssessmentSpecialInstruction"
                AFTER INSERT OR UPDATE OR DELETE ON "InitialCareAssessmentSpecialInstruction"
                FOR EACH ROW EXECUTE FUNCTION "tr_InitialCareAssessmentSpecialInstruction_func"();
                
                CREATE OR REPLACE FUNCTION "tr_InitialCareAssessmentVitalSign_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_InitialCareAssessmentVitalSign"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_InitialCareAssessmentVitalSign"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_InitialCareAssessmentVitalSign"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_InitialCareAssessmentVitalSign"
                AFTER INSERT OR UPDATE OR DELETE ON "InitialCareAssessmentVitalSign"
                FOR EACH ROW EXECUTE FUNCTION "tr_InitialCareAssessmentVitalSign_func"();
                
                CREATE OR REPLACE FUNCTION "tr_Intervention_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_Intervention"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_Intervention"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_Intervention"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_Intervention"
                AFTER INSERT OR UPDATE OR DELETE ON "Intervention"
                FOR EACH ROW EXECUTE FUNCTION "tr_Intervention_func"();
                
                CREATE OR REPLACE FUNCTION "tr_Item_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_Item"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_Item"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_Item"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_Item"
                AFTER INSERT OR UPDATE OR DELETE ON "Item"
                FOR EACH ROW EXECUTE FUNCTION "tr_Item_func"();
                
                CREATE OR REPLACE FUNCTION "tr_ItemStock_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_ItemStock"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_ItemStock"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_ItemStock"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_ItemStock"
                AFTER INSERT OR UPDATE OR DELETE ON "ItemStock"
                FOR EACH ROW EXECUTE FUNCTION "tr_ItemStock_func"();
                
                CREATE OR REPLACE FUNCTION "tr_LoginDevice_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_LoginDevice"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_LoginDevice"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_LoginDevice"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_LoginDevice"
                AFTER INSERT OR UPDATE OR DELETE ON "LoginDevice"
                FOR EACH ROW EXECUTE FUNCTION "tr_LoginDevice_func"();
                
                CREATE OR REPLACE FUNCTION "tr_MailSettings_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_MailSettings"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_MailSettings"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_MailSettings"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_MailSettings"
                AFTER INSERT OR UPDATE OR DELETE ON "MailSettings"
                FOR EACH ROW EXECUTE FUNCTION "tr_MailSettings_func"();
                
                CREATE OR REPLACE FUNCTION "tr_MedicationVitalSignType_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_MedicationVitalSignType"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_MedicationVitalSignType"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_MedicationVitalSignType"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_MedicationVitalSignType"
                AFTER INSERT OR UPDATE OR DELETE ON "MedicationVitalSignType"
                FOR EACH ROW EXECUTE FUNCTION "tr_MedicationVitalSignType_func"();
                
                CREATE OR REPLACE FUNCTION "tr_MobileAppVersioning_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_MobileAppVersioning"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_MobileAppVersioning"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_MobileAppVersioning"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_MobileAppVersioning"
                AFTER INSERT OR UPDATE OR DELETE ON "MobileAppVersioning"
                FOR EACH ROW EXECUTE FUNCTION "tr_MobileAppVersioning_func"();
                
                CREATE OR REPLACE FUNCTION "tr_MultiDisciplinaryMeeting_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_MultiDisciplinaryMeeting"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_MultiDisciplinaryMeeting"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_MultiDisciplinaryMeeting"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_MultiDisciplinaryMeeting"
                AFTER INSERT OR UPDATE OR DELETE ON "MultiDisciplinaryMeeting"
                FOR EACH ROW EXECUTE FUNCTION "tr_MultiDisciplinaryMeeting_func"();
                
                CREATE OR REPLACE FUNCTION "tr_MultiDisciplinaryMeetingDetail_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_MultiDisciplinaryMeetingDetail"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_MultiDisciplinaryMeetingDetail"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_MultiDisciplinaryMeetingDetail"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_MultiDisciplinaryMeetingDetail"
                AFTER INSERT OR UPDATE OR DELETE ON "MultiDisciplinaryMeetingDetail"
                FOR EACH ROW EXECUTE FUNCTION "tr_MultiDisciplinaryMeetingDetail_func"();
                
                CREATE OR REPLACE FUNCTION "tr_NotificationChat_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_NotificationChat"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_NotificationChat"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_NotificationChat"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_NotificationChat"
                AFTER INSERT OR UPDATE OR DELETE ON "NotificationChat"
                FOR EACH ROW EXECUTE FUNCTION "tr_NotificationChat_func"();
                
                CREATE OR REPLACE FUNCTION "tr_NotificationEvent_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_NotificationEvent"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_NotificationEvent"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_NotificationEvent"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_NotificationEvent"
                AFTER INSERT OR UPDATE OR DELETE ON "NotificationEvent"
                FOR EACH ROW EXECUTE FUNCTION "tr_NotificationEvent_func"();
                
                CREATE OR REPLACE FUNCTION "tr_NotificationMessageTemplates_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_NotificationMessageTemplates"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_NotificationMessageTemplates"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_NotificationMessageTemplates"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_NotificationMessageTemplates"
                AFTER INSERT OR UPDATE OR DELETE ON "NotificationMessageTemplates"
                FOR EACH ROW EXECUTE FUNCTION "tr_NotificationMessageTemplates_func"();
                
                CREATE OR REPLACE FUNCTION "tr_Notifications_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_Notifications"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_Notifications"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_Notifications"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_Notifications"
                AFTER INSERT OR UPDATE OR DELETE ON "Notifications"
                FOR EACH ROW EXECUTE FUNCTION "tr_Notifications_func"();
                
                CREATE OR REPLACE FUNCTION "tr_NotificationTask_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_NotificationTask"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_NotificationTask"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_NotificationTask"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_NotificationTask"
                AFTER INSERT OR UPDATE OR DELETE ON "NotificationTask"
                FOR EACH ROW EXECUTE FUNCTION "tr_NotificationTask_func"();
                
                CREATE OR REPLACE FUNCTION "tr_NotificationVitalSignDetails_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_NotificationVitalSignDetails"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_NotificationVitalSignDetails"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_NotificationVitalSignDetails"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_NotificationVitalSignDetails"
                AFTER INSERT OR UPDATE OR DELETE ON "NotificationVitalSignDetails"
                FOR EACH ROW EXECUTE FUNCTION "tr_NotificationVitalSignDetails_func"();
                
                CREATE OR REPLACE FUNCTION "tr_NutritionTask_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_NutritionTask"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_NutritionTask"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_NutritionTask"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_NutritionTask"
                AFTER INSERT OR UPDATE OR DELETE ON "NutritionTask"
                FOR EACH ROW EXECUTE FUNCTION "tr_NutritionTask_func"();
                
                CREATE OR REPLACE FUNCTION "tr_NutritionTaskReference_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_NutritionTaskReference"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_NutritionTaskReference"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_NutritionTaskReference"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_NutritionTaskReference"
                AFTER INSERT OR UPDATE OR DELETE ON "NutritionTaskReference"
                FOR EACH ROW EXECUTE FUNCTION "tr_NutritionTaskReference_func"();
                
                CREATE OR REPLACE FUNCTION "tr_Otp_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_Otp"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_Otp"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_Otp"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_Otp"
                AFTER INSERT OR UPDATE OR DELETE ON "Otp"
                FOR EACH ROW EXECUTE FUNCTION "tr_Otp_func"();
                
                CREATE OR REPLACE FUNCTION "tr_Package_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_Package"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_Package"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_Package"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_Package"
                AFTER INSERT OR UPDATE OR DELETE ON "Package"
                FOR EACH ROW EXECUTE FUNCTION "tr_Package_func"();
                
                CREATE OR REPLACE FUNCTION "tr_Patient_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_Patient"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_Patient"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_Patient"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_Patient"
                AFTER INSERT OR UPDATE OR DELETE ON "Patient"
                FOR EACH ROW EXECUTE FUNCTION "tr_Patient_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientAccessLine_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientAccessLine"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientAccessLine"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientAccessLine"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientAccessLine"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientAccessLine"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientAccessLine_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientAdditionalInfo_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientAdditionalInfo"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientAdditionalInfo"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientAdditionalInfo"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientAdditionalInfo"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientAdditionalInfo"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientAdditionalInfo_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientAMT_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientAMT"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientAMT"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientAMT"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientAMT"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientAMT"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientAMT_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientAMTAnswer_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientAMTAnswer"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientAMTAnswer"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientAMTAnswer"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientAMTAnswer"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientAMTAnswer"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientAMTAnswer_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientAttachment_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientAttachment"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientAttachment"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientAttachment"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientAttachment"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientAttachment"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientAttachment_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientBradenScale_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientBradenScale"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientBradenScale"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientBradenScale"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientBradenScale"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientBradenScale"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientBradenScale_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientClinician_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientClinician"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientClinician"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientClinician"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientClinician"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientClinician"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientClinician_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientDrugAllergy_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientDrugAllergy"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientDrugAllergy"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientDrugAllergy"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientDrugAllergy"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientDrugAllergy"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientDrugAllergy_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientEBASDEP_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientEBASDEP"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientEBASDEP"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientEBASDEP"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientEBASDEP"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientEBASDEP"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientEBASDEP_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientEBASDEPAnswer_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientEBASDEPAnswer"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientEBASDEPAnswer"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientEBASDEPAnswer"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientEBASDEPAnswer"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientEBASDEPAnswer"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientEBASDEPAnswer_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientFamilyHistory_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientFamilyHistory"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientFamilyHistory"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientFamilyHistory"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientFamilyHistory"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientFamilyHistory"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientFamilyHistory_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientGCS_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientGCS"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientGCS"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientGCS"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientGCS"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientGCS"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientGCS_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientImmunisation_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientImmunisation"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientImmunisation"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientImmunisation"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientImmunisation"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientImmunisation"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientImmunisation_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientLanguage_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientLanguage"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientLanguage"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientLanguage"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientLanguage"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientLanguage"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientLanguage_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientMBI_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientMBI"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientMBI"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientMBI"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientMBI"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientMBI"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientMBI_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientMedicalHistory_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientMedicalHistory"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientMedicalHistory"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientMedicalHistory"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientMedicalHistory"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientMedicalHistory"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientMedicalHistory_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientMedication_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientMedication"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientMedication"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientMedication"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientMedication"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientMedication"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientMedication_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientMedicationConsume_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientMedicationConsume"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientMedicationConsume"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientMedicationConsume"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientMedicationConsume"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientMedicationConsume"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientMedicationConsume_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientMedicationConsumeAttachment_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientMedicationConsumeAttachment"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientMedicationConsumeAttachment"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientMedicationConsumeAttachment"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientMedicationConsumeAttachment"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientMedicationConsumeAttachment"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientMedicationConsumeAttachment_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientMedicationSupply_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientMedicationSupply"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientMedicationSupply"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientMedicationSupply"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientMedicationSupply"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientMedicationSupply"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientMedicationSupply_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientMFS_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientMFS"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientMFS"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientMFS"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientMFS"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientMFS"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientMFS_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientMMSE_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientMMSE"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientMMSE"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientMMSE"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientMMSE"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientMMSE"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientMMSE_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientNutrition_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientNutrition"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientNutrition"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientNutrition"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientNutrition"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientNutrition"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientNutrition_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientOtherAllergy_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientOtherAllergy"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientOtherAllergy"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientOtherAllergy"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientOtherAllergy"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientOtherAllergy"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientOtherAllergy_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientPackage_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientPackage"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientPackage"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientPackage"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientPackage"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientPackage"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientPackage_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientProfile_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientProfile"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientProfile"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientProfile"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientProfile"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientProfile"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientProfile_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientRAF_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientRAF"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientRAF"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientRAF"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientRAF"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientRAF"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientRAF_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientReferral_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientReferral"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientReferral"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientReferral"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientReferral"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientReferral"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientReferral_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientReferralService_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientReferralService"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientReferralService"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientReferralService"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientReferralService"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientReferralService"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientReferralService_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientSocialSupport_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientSocialSupport"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientSocialSupport"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientSocialSupport"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientSocialSupport"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientSocialSupport"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientSocialSupport_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientSpecialIndicator_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientSpecialIndicator"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientSpecialIndicator"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientSpecialIndicator"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientSpecialIndicator"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientSpecialIndicator"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientSpecialIndicator_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientWound_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientWound"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientWound"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientWound"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientWound"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientWound"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientWound_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientWoundDraft_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientWoundDraft"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientWoundDraft"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientWoundDraft"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientWoundDraft"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientWoundDraft"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientWoundDraft_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientWoundReviewBy_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientWoundReviewBy"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientWoundReviewBy"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientWoundReviewBy"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientWoundReviewBy"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientWoundReviewBy"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientWoundReviewBy_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientWoundVisit_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientWoundVisit"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientWoundVisit"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientWoundVisit"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientWoundVisit"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientWoundVisit"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientWoundVisit_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientWoundVisitAppearance_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientWoundVisitAppearance"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientWoundVisitAppearance"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientWoundVisitAppearance"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientWoundVisitAppearance"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientWoundVisitAppearance"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientWoundVisitAppearance_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientWoundVisitCleansingItem_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientWoundVisitCleansingItem"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientWoundVisitCleansingItem"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientWoundVisitCleansingItem"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientWoundVisitCleansingItem"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientWoundVisitCleansingItem"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientWoundVisitCleansingItem_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientWoundVisitClinician_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientWoundVisitClinician"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientWoundVisitClinician"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientWoundVisitClinician"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientWoundVisitClinician"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientWoundVisitClinician"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientWoundVisitClinician_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientWoundVisitTreatment_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientWoundVisitTreatment"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientWoundVisitTreatment"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientWoundVisitTreatment"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientWoundVisitTreatment"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientWoundVisitTreatment"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientWoundVisitTreatment_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientWoundVisitTreatmentList_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientWoundVisitTreatmentList"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientWoundVisitTreatmentList"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientWoundVisitTreatmentList"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientWoundVisitTreatmentList"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientWoundVisitTreatmentList"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientWoundVisitTreatmentList_func"();
                
                CREATE OR REPLACE FUNCTION "tr_PatientWoundVisitTreatmentObjectives_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_PatientWoundVisitTreatmentObjectives"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_PatientWoundVisitTreatmentObjectives"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_PatientWoundVisitTreatmentObjectives"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_PatientWoundVisitTreatmentObjectives"
                AFTER INSERT OR UPDATE OR DELETE ON "PatientWoundVisitTreatmentObjectives"
                FOR EACH ROW EXECUTE FUNCTION "tr_PatientWoundVisitTreatmentObjectives_func"();
                
                CREATE OR REPLACE FUNCTION "tr_ProblemList_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_ProblemList"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_ProblemList"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_ProblemList"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_ProblemList"
                AFTER INSERT OR UPDATE OR DELETE ON "ProblemList"
                FOR EACH ROW EXECUTE FUNCTION "tr_ProblemList_func"();
                
                CREATE OR REPLACE FUNCTION "tr_ProblemListGoal_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_ProblemListGoal"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_ProblemListGoal"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_ProblemListGoal"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_ProblemListGoal"
                AFTER INSERT OR UPDATE OR DELETE ON "ProblemListGoal"
                FOR EACH ROW EXECUTE FUNCTION "tr_ProblemListGoal_func"();
                
                CREATE OR REPLACE FUNCTION "tr_Receipt_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_Receipt"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_Receipt"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_Receipt"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_Receipt"
                AFTER INSERT OR UPDATE OR DELETE ON "Receipt"
                FOR EACH ROW EXECUTE FUNCTION "tr_Receipt_func"();
                
                CREATE OR REPLACE FUNCTION "tr_ReceiptForInvoice_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_ReceiptForInvoice"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_ReceiptForInvoice"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_ReceiptForInvoice"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_ReceiptForInvoice"
                AFTER INSERT OR UPDATE OR DELETE ON "ReceiptForInvoice"
                FOR EACH ROW EXECUTE FUNCTION "tr_ReceiptForInvoice_func"();
                
                CREATE OR REPLACE FUNCTION "tr_RegisteredDevice_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_RegisteredDevice"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_RegisteredDevice"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_RegisteredDevice"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_RegisteredDevice"
                AFTER INSERT OR UPDATE OR DELETE ON "RegisteredDevice"
                FOR EACH ROW EXECUTE FUNCTION "tr_RegisteredDevice_func"();
                
                CREATE OR REPLACE FUNCTION "tr_RegisteredDeviceV2_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_RegisteredDeviceV2"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_RegisteredDeviceV2"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_RegisteredDeviceV2"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_RegisteredDeviceV2"
                AFTER INSERT OR UPDATE OR DELETE ON "RegisteredDeviceV2"
                FOR EACH ROW EXECUTE FUNCTION "tr_RegisteredDeviceV2_func"();
                
                CREATE OR REPLACE FUNCTION "tr_ResidentAssessmentCategory_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_ResidentAssessmentCategory"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_ResidentAssessmentCategory"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_ResidentAssessmentCategory"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_ResidentAssessmentCategory"
                AFTER INSERT OR UPDATE OR DELETE ON "ResidentAssessmentCategory"
                FOR EACH ROW EXECUTE FUNCTION "tr_ResidentAssessmentCategory_func"();
                
                CREATE OR REPLACE FUNCTION "tr_Role_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_Role"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_Role"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_Role"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_Role"
                AFTER INSERT OR UPDATE OR DELETE ON "Role"
                FOR EACH ROW EXECUTE FUNCTION "tr_Role_func"();
                
                CREATE OR REPLACE FUNCTION "tr_ScheduledTasks_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_ScheduledTasks"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_ScheduledTasks"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_ScheduledTasks"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_ScheduledTasks"
                AFTER INSERT OR UPDATE OR DELETE ON "ScheduledTasks"
                FOR EACH ROW EXECUTE FUNCTION "tr_ScheduledTasks_func"();
                
                CREATE OR REPLACE FUNCTION "tr_ServiceForBilling_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_ServiceForBilling"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_ServiceForBilling"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_ServiceForBilling"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_ServiceForBilling"
                AFTER INSERT OR UPDATE OR DELETE ON "ServiceForBilling"
                FOR EACH ROW EXECUTE FUNCTION "tr_ServiceForBilling_func"();
                
                CREATE OR REPLACE FUNCTION "tr_ServiceForBillingCost_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_ServiceForBillingCost"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_ServiceForBillingCost"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_ServiceForBillingCost"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_ServiceForBillingCost"
                AFTER INSERT OR UPDATE OR DELETE ON "ServiceForBillingCost"
                FOR EACH ROW EXECUTE FUNCTION "tr_ServiceForBillingCost_func"();
                
                CREATE OR REPLACE FUNCTION "tr_ServiceSkillset_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_ServiceSkillset"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_ServiceSkillset"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_ServiceSkillset"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_ServiceSkillset"
                AFTER INSERT OR UPDATE OR DELETE ON "ServiceSkillset"
                FOR EACH ROW EXECUTE FUNCTION "tr_ServiceSkillset_func"();
                
                CREATE OR REPLACE FUNCTION "tr_SyncPatientLog_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_SyncPatientLog"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_SyncPatientLog"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_SyncPatientLog"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_SyncPatientLog"
                AFTER INSERT OR UPDATE OR DELETE ON "SyncPatientLog"
                FOR EACH ROW EXECUTE FUNCTION "tr_SyncPatientLog_func"();
                
                CREATE OR REPLACE FUNCTION "tr_SyncWoundLog_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_SyncWoundLog"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_SyncWoundLog"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_SyncWoundLog"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_SyncWoundLog"
                AFTER INSERT OR UPDATE OR DELETE ON "SyncWoundLog"
                FOR EACH ROW EXECUTE FUNCTION "tr_SyncWoundLog_func"();
                
                CREATE OR REPLACE FUNCTION "tr_SyncWoundVisitLog_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_SyncWoundVisitLog"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_SyncWoundVisitLog"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_SyncWoundVisitLog"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_SyncWoundVisitLog"
                AFTER INSERT OR UPDATE OR DELETE ON "SyncWoundVisitLog"
                FOR EACH ROW EXECUTE FUNCTION "tr_SyncWoundVisitLog_func"();
                
                CREATE OR REPLACE FUNCTION "tr_SysConfig_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_SysConfig"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_SysConfig"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_SysConfig"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_SysConfig"
                AFTER INSERT OR UPDATE OR DELETE ON "SysConfig"
                FOR EACH ROW EXECUTE FUNCTION "tr_SysConfig_func"();
                
                CREATE OR REPLACE FUNCTION "tr_SystemForDisease_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_SystemForDisease"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_SystemForDisease"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_SystemForDisease"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_SystemForDisease"
                AFTER INSERT OR UPDATE OR DELETE ON "SystemForDisease"
                FOR EACH ROW EXECUTE FUNCTION "tr_SystemForDisease_func"();
                
                CREATE OR REPLACE FUNCTION "tr_Task_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_Task"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_Task"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_Task"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_Task"
                AFTER INSERT OR UPDATE OR DELETE ON "Task"
                FOR EACH ROW EXECUTE FUNCTION "tr_Task_func"();
                
                CREATE OR REPLACE FUNCTION "tr_TaskFileAttachment_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_TaskFileAttachment"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_TaskFileAttachment"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_TaskFileAttachment"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_TaskFileAttachment"
                AFTER INSERT OR UPDATE OR DELETE ON "TaskFileAttachment"
                FOR EACH ROW EXECUTE FUNCTION "tr_TaskFileAttachment_func"();
                
                CREATE OR REPLACE FUNCTION "tr_TaskServicesRequired_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_TaskServicesRequired"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_TaskServicesRequired"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_TaskServicesRequired"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_TaskServicesRequired"
                AFTER INSERT OR UPDATE OR DELETE ON "TaskServicesRequired"
                FOR EACH ROW EXECUTE FUNCTION "tr_TaskServicesRequired_func"();
                
                CREATE OR REPLACE FUNCTION "tr_TaskSpecificDate_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_TaskSpecificDate"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_TaskSpecificDate"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_TaskSpecificDate"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_TaskSpecificDate"
                AFTER INSERT OR UPDATE OR DELETE ON "TaskSpecificDate"
                FOR EACH ROW EXECUTE FUNCTION "tr_TaskSpecificDate_func"();
                
                CREATE OR REPLACE FUNCTION "tr_TaskUser_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_TaskUser"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_TaskUser"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_TaskUser"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_TaskUser"
                AFTER INSERT OR UPDATE OR DELETE ON "TaskUser"
                FOR EACH ROW EXECUTE FUNCTION "tr_TaskUser_func"();
                
                CREATE OR REPLACE FUNCTION "tr_TaskUserLog_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_TaskUserLog"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_TaskUserLog"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_TaskUserLog"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_TaskUserLog"
                AFTER INSERT OR UPDATE OR DELETE ON "TaskUserLog"
                FOR EACH ROW EXECUTE FUNCTION "tr_TaskUserLog_func"();
                
                CREATE OR REPLACE FUNCTION "tr_TaskUserLogAttachment_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_TaskUserLogAttachment"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_TaskUserLogAttachment"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_TaskUserLogAttachment"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_TaskUserLogAttachment"
                AFTER INSERT OR UPDATE OR DELETE ON "TaskUserLogAttachment"
                FOR EACH ROW EXECUTE FUNCTION "tr_TaskUserLogAttachment_func"();
                
                CREATE OR REPLACE FUNCTION "tr_TD_WoundAssessmentFactor_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_TD_WoundAssessmentFactor"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_TD_WoundAssessmentFactor"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_TD_WoundAssessmentFactor"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_TD_WoundAssessmentFactor"
                AFTER INSERT OR UPDATE OR DELETE ON "TD_WoundAssessmentFactor"
                FOR EACH ROW EXECUTE FUNCTION "tr_TD_WoundAssessmentFactor_func"();
                
                CREATE OR REPLACE FUNCTION "tr_TeleconsultationRecording_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_TeleconsultationRecording"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_TeleconsultationRecording"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_TeleconsultationRecording"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_TeleconsultationRecording"
                AFTER INSERT OR UPDATE OR DELETE ON "TeleconsultationRecording"
                FOR EACH ROW EXECUTE FUNCTION "tr_TeleconsultationRecording_func"();
                
                CREATE OR REPLACE FUNCTION "tr_TeleconsultationReport_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_TeleconsultationReport"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_TeleconsultationReport"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_TeleconsultationReport"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_TeleconsultationReport"
                AFTER INSERT OR UPDATE OR DELETE ON "TeleconsultationReport"
                FOR EACH ROW EXECUTE FUNCTION "tr_TeleconsultationReport_func"();
                
                CREATE OR REPLACE FUNCTION "tr_Thresholds_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_Thresholds"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_Thresholds"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_Thresholds"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_Thresholds"
                AFTER INSERT OR UPDATE OR DELETE ON "Thresholds"
                FOR EACH ROW EXECUTE FUNCTION "tr_Thresholds_func"();
                
                CREATE OR REPLACE FUNCTION "tr_TreatmentListItem_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_TreatmentListItem"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_TreatmentListItem"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_TreatmentListItem"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_TreatmentListItem"
                AFTER INSERT OR UPDATE OR DELETE ON "TreatmentListItem"
                FOR EACH ROW EXECUTE FUNCTION "tr_TreatmentListItem_func"();
                
                CREATE OR REPLACE FUNCTION "tr_TreatmentTOL_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_TreatmentTOL"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_TreatmentTOL"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_TreatmentTOL"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_TreatmentTOL"
                AFTER INSERT OR UPDATE OR DELETE ON "TreatmentTOL"
                FOR EACH ROW EXECUTE FUNCTION "tr_TreatmentTOL_func"();
                
                CREATE OR REPLACE FUNCTION "tr_Types_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_Types"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_Types"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_Types"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_Types"
                AFTER INSERT OR UPDATE OR DELETE ON "Types"
                FOR EACH ROW EXECUTE FUNCTION "tr_Types_func"();
                
                CREATE OR REPLACE FUNCTION "tr_UploadFile_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_UploadFile"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_UploadFile"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_UploadFile"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_UploadFile"
                AFTER INSERT OR UPDATE OR DELETE ON "UploadFile"
                FOR EACH ROW EXECUTE FUNCTION "tr_UploadFile_func"();
                
                CREATE OR REPLACE FUNCTION "tr_UserAddress_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_UserAddress"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_UserAddress"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_UserAddress"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_UserAddress"
                AFTER INSERT OR UPDATE OR DELETE ON "UserAddress"
                FOR EACH ROW EXECUTE FUNCTION "tr_UserAddress_func"();
                
                CREATE OR REPLACE FUNCTION "tr_UserBranch_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_UserBranch"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_UserBranch"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_UserBranch"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_UserBranch"
                AFTER INSERT OR UPDATE OR DELETE ON "UserBranch"
                FOR EACH ROW EXECUTE FUNCTION "tr_UserBranch_func"();
                
                CREATE OR REPLACE FUNCTION "tr_UserCategory_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_UserCategory"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_UserCategory"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_UserCategory"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_UserCategory"
                AFTER INSERT OR UPDATE OR DELETE ON "UserCategory"
                FOR EACH ROW EXECUTE FUNCTION "tr_UserCategory_func"();
                
                CREATE OR REPLACE FUNCTION "tr_UserCategoryRole_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_UserCategoryRole"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_UserCategoryRole"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_UserCategoryRole"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_UserCategoryRole"
                AFTER INSERT OR UPDATE OR DELETE ON "UserCategoryRole"
                FOR EACH ROW EXECUTE FUNCTION "tr_UserCategoryRole_func"();
                
                CREATE OR REPLACE FUNCTION "tr_UserLanguage_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_UserLanguage"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_UserLanguage"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_UserLanguage"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_UserLanguage"
                AFTER INSERT OR UPDATE OR DELETE ON "UserLanguage"
                FOR EACH ROW EXECUTE FUNCTION "tr_UserLanguage_func"();
                
                CREATE OR REPLACE FUNCTION "tr_UserOrganization_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_UserOrganization"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_UserOrganization"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_UserOrganization"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_UserOrganization"
                AFTER INSERT OR UPDATE OR DELETE ON "UserOrganization"
                FOR EACH ROW EXECUTE FUNCTION "tr_UserOrganization_func"();
                
                CREATE OR REPLACE FUNCTION "tr_UserRole_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_UserRole"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_UserRole"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_UserRole"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_UserRole"
                AFTER INSERT OR UPDATE OR DELETE ON "UserRole"
                FOR EACH ROW EXECUTE FUNCTION "tr_UserRole_func"();
                
                CREATE OR REPLACE FUNCTION "tr_Users_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_Users"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_Users"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_Users"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_Users"
                AFTER INSERT OR UPDATE OR DELETE ON "Users"
                FOR EACH ROW EXECUTE FUNCTION "tr_Users_func"();
                
                CREATE OR REPLACE FUNCTION "tr_UserSkillset_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_UserSkillset"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_UserSkillset"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_UserSkillset"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_UserSkillset"
                AFTER INSERT OR UPDATE OR DELETE ON "UserSkillset"
                FOR EACH ROW EXECUTE FUNCTION "tr_UserSkillset_func"();
                
                CREATE OR REPLACE FUNCTION "tr_UserType_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_UserType"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_UserType"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_UserType"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_UserType"
                AFTER INSERT OR UPDATE OR DELETE ON "UserType"
                FOR EACH ROW EXECUTE FUNCTION "tr_UserType_func"();
                
                CREATE OR REPLACE FUNCTION "tr_UserUserType_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_UserUserType"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_UserUserType"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_UserUserType"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_UserUserType"
                AFTER INSERT OR UPDATE OR DELETE ON "UserUserType"
                FOR EACH ROW EXECUTE FUNCTION "tr_UserUserType_func"();
                
                CREATE OR REPLACE FUNCTION "tr_VitalSignDetails_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_VitalSignDetails"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_VitalSignDetails"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_VitalSignDetails"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_VitalSignDetails"
                AFTER INSERT OR UPDATE OR DELETE ON "VitalSignDetails"
                FOR EACH ROW EXECUTE FUNCTION "tr_VitalSignDetails_func"();
                
                CREATE OR REPLACE FUNCTION "tr_VitalSignRelationships_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_VitalSignRelationships"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_VitalSignRelationships"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_VitalSignRelationships"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_VitalSignRelationships"
                AFTER INSERT OR UPDATE OR DELETE ON "VitalSignRelationships"
                FOR EACH ROW EXECUTE FUNCTION "tr_VitalSignRelationships_func"();
                
                CREATE OR REPLACE FUNCTION "tr_VitalSigns_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_VitalSigns"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_VitalSigns"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_VitalSigns"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_VitalSigns"
                AFTER INSERT OR UPDATE OR DELETE ON "VitalSigns"
                FOR EACH ROW EXECUTE FUNCTION "tr_VitalSigns_func"();
                
                CREATE OR REPLACE FUNCTION "tr_VitalSignTypes_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_VitalSignTypes"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_VitalSignTypes"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_VitalSignTypes"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_VitalSignTypes"
                AFTER INSERT OR UPDATE OR DELETE ON "VitalSignTypes"
                FOR EACH ROW EXECUTE FUNCTION "tr_VitalSignTypes_func"();
                
                CREATE OR REPLACE FUNCTION "tr_VitalSignTypeThreshold_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_VitalSignTypeThreshold"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_VitalSignTypeThreshold"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_VitalSignTypeThreshold"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_VitalSignTypeThreshold"
                AFTER INSERT OR UPDATE OR DELETE ON "VitalSignTypeThreshold"
                FOR EACH ROW EXECUTE FUNCTION "tr_VitalSignTypeThreshold_func"();
                
                CREATE OR REPLACE FUNCTION "tr_WoundConsolidatedEmail_func"()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF TG_OP = 'INSERT' THEN
                        INSERT INTO "Audit_WoundConsolidatedEmail"
                        SELECT 'I', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'UPDATE' THEN
                        INSERT INTO "Audit_WoundConsolidatedEmail"
                        SELECT 'U', CURRENT_TIMESTAMP, NEW.*;
                    ELSIF TG_OP = 'DELETE' THEN
                        INSERT INTO "Audit_WoundConsolidatedEmail"
                        SELECT 'D', CURRENT_TIMESTAMP, OLD.*;
                    END IF;
                
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                
                CREATE TRIGGER "tr_WoundConsolidatedEmail"
                AFTER INSERT OR UPDATE OR DELETE ON "WoundConsolidatedEmail"
                FOR EACH ROW EXECUTE FUNCTION "tr_WoundConsolidatedEmail_func"();
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP TRIGGER IF EXISTS "tr_Activity" ON "Activity";
                DROP FUNCTION IF EXISTS "tr_Activity_func"();
                
                DROP TRIGGER IF EXISTS "tr_AMTQuestion" ON "AMTQuestion";
                DROP FUNCTION IF EXISTS "tr_AMTQuestion_func"();
                
                DROP TRIGGER IF EXISTS "tr_APIAccessKey" ON "APIAccessKey";
                DROP FUNCTION IF EXISTS "tr_APIAccessKey_func"();
                
                DROP TRIGGER IF EXISTS "tr_APIMonitor" ON "APIMonitor";
                DROP FUNCTION IF EXISTS "tr_APIMonitor_func"();
                
                DROP TRIGGER IF EXISTS "tr_APIOrder" ON "APIOrder";
                DROP FUNCTION IF EXISTS "tr_APIOrder_func"();
                
                DROP TRIGGER IF EXISTS "tr_APIOrderAllergy" ON "APIOrderAllergy";
                DROP FUNCTION IF EXISTS "tr_APIOrderAllergy_func"();
                
                DROP TRIGGER IF EXISTS "tr_APIOrderDiagnosis" ON "APIOrderDiagnosis";
                DROP FUNCTION IF EXISTS "tr_APIOrderDiagnosis_func"();
                
                DROP TRIGGER IF EXISTS "tr_APIOrderMedication" ON "APIOrderMedication";
                DROP FUNCTION IF EXISTS "tr_APIOrderMedication_func"();
                
                DROP TRIGGER IF EXISTS "tr_APIOrderTask" ON "APIOrderTask";
                DROP FUNCTION IF EXISTS "tr_APIOrderTask_func"();
                
                DROP TRIGGER IF EXISTS "tr_APNSNotification" ON "APNSNotification";
                DROP FUNCTION IF EXISTS "tr_APNSNotification_func"();
                
                DROP TRIGGER IF EXISTS "tr_BillingInvoice" ON "BillingInvoice";
                DROP FUNCTION IF EXISTS "tr_BillingInvoice_func"();
                
                DROP TRIGGER IF EXISTS "tr_BillingInvoiceConsumable" ON "BillingInvoiceConsumable";
                DROP FUNCTION IF EXISTS "tr_BillingInvoiceConsumable_func"();
                
                DROP TRIGGER IF EXISTS "tr_BillingInvoiceService" ON "BillingInvoiceService";
                DROP FUNCTION IF EXISTS "tr_BillingInvoiceService_func"();
                
                DROP TRIGGER IF EXISTS "tr_BillingPackage" ON "BillingPackage";
                DROP FUNCTION IF EXISTS "tr_BillingPackage_func"();
                
                DROP TRIGGER IF EXISTS "tr_BillingPackageInformation" ON "BillingPackageInformation";
                DROP FUNCTION IF EXISTS "tr_BillingPackageInformation_func"();
                
                DROP TRIGGER IF EXISTS "tr_BillingPackageRequest" ON "BillingPackageRequest";
                DROP FUNCTION IF EXISTS "tr_BillingPackageRequest_func"();
                
                DROP TRIGGER IF EXISTS "tr_BillingProposal" ON "BillingProposal";
                DROP FUNCTION IF EXISTS "tr_BillingProposal_func"();
                
                DROP TRIGGER IF EXISTS "tr_BillingProposalService" ON "BillingProposalService";
                DROP FUNCTION IF EXISTS "tr_BillingProposalService_func"();
                
                DROP TRIGGER IF EXISTS "tr_BillingService" ON "BillingService";
                DROP FUNCTION IF EXISTS "tr_BillingService_func"();
                
                DROP TRIGGER IF EXISTS "tr_Branch" ON "Branch";
                DROP FUNCTION IF EXISTS "tr_Branch_func"();
                
                DROP TRIGGER IF EXISTS "tr_C4WDeviceToken" ON "C4WDeviceToken";
                DROP FUNCTION IF EXISTS "tr_C4WDeviceToken_func"();
                
                DROP TRIGGER IF EXISTS "tr_CarePlan" ON "CarePlan";
                DROP FUNCTION IF EXISTS "tr_CarePlan_func"();
                
                DROP TRIGGER IF EXISTS "tr_CarePlanDetail" ON "CarePlanDetail";
                DROP FUNCTION IF EXISTS "tr_CarePlanDetail_func"();
                
                DROP TRIGGER IF EXISTS "tr_CarePlanStatus" ON "CarePlanStatus";
                DROP FUNCTION IF EXISTS "tr_CarePlanStatus_func"();
                
                DROP TRIGGER IF EXISTS "tr_CarePlanSub" ON "CarePlanSub";
                DROP FUNCTION IF EXISTS "tr_CarePlanSub_func"();
                
                DROP TRIGGER IF EXISTS "tr_CarePlanSubActivity" ON "CarePlanSubActivity";
                DROP FUNCTION IF EXISTS "tr_CarePlanSubActivity_func"();
                
                DROP TRIGGER IF EXISTS "tr_CarePlanSubCPGoals" ON "CarePlanSubCPGoals";
                DROP FUNCTION IF EXISTS "tr_CarePlanSubCPGoals_func"();
                
                DROP TRIGGER IF EXISTS "tr_CarePlanSubGoal" ON "CarePlanSubGoal";
                DROP FUNCTION IF EXISTS "tr_CarePlanSubGoal_func"();
                
                DROP TRIGGER IF EXISTS "tr_CarePlanSubIntervention" ON "CarePlanSubIntervention";
                DROP FUNCTION IF EXISTS "tr_CarePlanSubIntervention_func"();
                
                DROP TRIGGER IF EXISTS "tr_CarePlanSubProblemList" ON "CarePlanSubProblemList";
                DROP FUNCTION IF EXISTS "tr_CarePlanSubProblemList_func"();
                
                DROP TRIGGER IF EXISTS "tr_CarePlanSubProblemListGoal" ON "CarePlanSubProblemListGoal";
                DROP FUNCTION IF EXISTS "tr_CarePlanSubProblemListGoal_func"();
                
                DROP TRIGGER IF EXISTS "tr_CareReport" ON "CareReport";
                DROP FUNCTION IF EXISTS "tr_CareReport_func"();
                
                DROP TRIGGER IF EXISTS "tr_CareReportConfig" ON "CareReportConfig";
                DROP FUNCTION IF EXISTS "tr_CareReportConfig_func"();
                
                DROP TRIGGER IF EXISTS "tr_CareReportRehabilitation" ON "CareReportRehabilitation";
                DROP FUNCTION IF EXISTS "tr_CareReportRehabilitation_func"();
                
                DROP TRIGGER IF EXISTS "tr_CareReportSocialSupport" ON "CareReportSocialSupport";
                DROP FUNCTION IF EXISTS "tr_CareReportSocialSupport_func"();
                
                DROP TRIGGER IF EXISTS "tr_CareReportSystemInfo" ON "CareReportSystemInfo";
                DROP FUNCTION IF EXISTS "tr_CareReportSystemInfo_func"();
                
                DROP TRIGGER IF EXISTS "tr_Chat" ON "Chat";
                DROP FUNCTION IF EXISTS "tr_Chat_func"();
                
                DROP TRIGGER IF EXISTS "tr_Code" ON "Code";
                DROP FUNCTION IF EXISTS "tr_Code_func"();
                
                DROP TRIGGER IF EXISTS "tr_CodeType" ON "CodeType";
                DROP FUNCTION IF EXISTS "tr_CodeType_func"();
                
                DROP TRIGGER IF EXISTS "tr_CPGoals" ON "CPGoals";
                DROP FUNCTION IF EXISTS "tr_CPGoals_func"();
                
                DROP TRIGGER IF EXISTS "tr_Diagnosis" ON "Diagnosis";
                DROP FUNCTION IF EXISTS "tr_Diagnosis_func"();
                
                DROP TRIGGER IF EXISTS "tr_DischargeSummaryReport" ON "DischargeSummaryReport";
                DROP FUNCTION IF EXISTS "tr_DischargeSummaryReport_func"();
                
                DROP TRIGGER IF EXISTS "tr_DischargeSummaryReportAttachment" ON "DischargeSummaryReportAttachment";
                DROP FUNCTION IF EXISTS "tr_DischargeSummaryReportAttachment_func"();
                
                DROP TRIGGER IF EXISTS "tr_Disease" ON "Disease";
                DROP FUNCTION IF EXISTS "tr_Disease_func"();
                
                DROP TRIGGER IF EXISTS "tr_DiseaseInfo" ON "DiseaseInfo";
                DROP FUNCTION IF EXISTS "tr_DiseaseInfo_func"();
                
                DROP TRIGGER IF EXISTS "tr_DiseaseSubInfo" ON "DiseaseSubInfo";
                DROP FUNCTION IF EXISTS "tr_DiseaseSubInfo_func"();
                
                DROP TRIGGER IF EXISTS "tr_DiseaseVitalSignType" ON "DiseaseVitalSignType";
                DROP FUNCTION IF EXISTS "tr_DiseaseVitalSignType_func"();
                
                DROP TRIGGER IF EXISTS "tr_EBASDEPQuestion" ON "EBASDEPQuestion";
                DROP FUNCTION IF EXISTS "tr_EBASDEPQuestion_func"();
                
                DROP TRIGGER IF EXISTS "tr_Enquiry" ON "Enquiry";
                DROP FUNCTION IF EXISTS "tr_Enquiry_func"();
                
                DROP TRIGGER IF EXISTS "tr_EnquiryAttachment" ON "EnquiryAttachment";
                DROP FUNCTION IF EXISTS "tr_EnquiryAttachment_func"();
                
                DROP TRIGGER IF EXISTS "tr_EnquiryConfig" ON "EnquiryConfig";
                DROP FUNCTION IF EXISTS "tr_EnquiryConfig_func"();
                
                DROP TRIGGER IF EXISTS "tr_EnquiryEscPerson" ON "EnquiryEscPerson";
                DROP FUNCTION IF EXISTS "tr_EnquiryEscPerson_func"();
                
                DROP TRIGGER IF EXISTS "tr_EnquiryLanguage" ON "EnquiryLanguage";
                DROP FUNCTION IF EXISTS "tr_EnquiryLanguage_func"();
                
                DROP TRIGGER IF EXISTS "tr_EnquirySCM" ON "EnquirySCM";
                DROP FUNCTION IF EXISTS "tr_EnquirySCM_func"();
                
                DROP TRIGGER IF EXISTS "tr_EnquiryServicesRequired" ON "EnquiryServicesRequired";
                DROP FUNCTION IF EXISTS "tr_EnquiryServicesRequired_func"();
                
                DROP TRIGGER IF EXISTS "tr_Event" ON "Event";
                DROP FUNCTION IF EXISTS "tr_Event_func"();
                
                DROP TRIGGER IF EXISTS "tr_EventUser" ON "EventUser";
                DROP FUNCTION IF EXISTS "tr_EventUser_func"();
                
                DROP TRIGGER IF EXISTS "tr_EventUserLog" ON "EventUserLog";
                DROP FUNCTION IF EXISTS "tr_EventUserLog_func"();
                
                DROP TRIGGER IF EXISTS "tr_ExternalDoctor" ON "ExternalDoctor";
                DROP FUNCTION IF EXISTS "tr_ExternalDoctor_func"();
                
                DROP TRIGGER IF EXISTS "tr_GeoFencing" ON "GeoFencing";
                DROP FUNCTION IF EXISTS "tr_GeoFencing_func"();
                
                DROP TRIGGER IF EXISTS "tr_Group" ON "Group";
                DROP FUNCTION IF EXISTS "tr_Group_func"();
                
                DROP TRIGGER IF EXISTS "tr_GroupRole" ON "GroupRole";
                DROP FUNCTION IF EXISTS "tr_GroupRole_func"();
                
                DROP TRIGGER IF EXISTS "tr_ICAWoundCare" ON "ICAWoundCare";
                DROP FUNCTION IF EXISTS "tr_ICAWoundCare_func"();
                
                DROP TRIGGER IF EXISTS "tr_InitialCareAssessment" ON "InitialCareAssessment";
                DROP FUNCTION IF EXISTS "tr_InitialCareAssessment_func"();
                
                DROP TRIGGER IF EXISTS "tr_InitialCareAssessmentAttachment" ON "InitialCareAssessmentAttachment";
                DROP FUNCTION IF EXISTS "tr_InitialCareAssessmentAttachment_func"();
                
                DROP TRIGGER IF EXISTS "tr_InitialCareAssessmentSpecialInstruction" ON "InitialCareAssessmentSpecialInstruction";
                DROP FUNCTION IF EXISTS "tr_InitialCareAssessmentSpecialInstruction_func"();
                
                DROP TRIGGER IF EXISTS "tr_InitialCareAssessmentVitalSign" ON "InitialCareAssessmentVitalSign";
                DROP FUNCTION IF EXISTS "tr_InitialCareAssessmentVitalSign_func"();
                
                DROP TRIGGER IF EXISTS "tr_Intervention" ON "Intervention";
                DROP FUNCTION IF EXISTS "tr_Intervention_func"();
                
                DROP TRIGGER IF EXISTS "tr_Item" ON "Item";
                DROP FUNCTION IF EXISTS "tr_Item_func"();
                
                DROP TRIGGER IF EXISTS "tr_ItemStock" ON "ItemStock";
                DROP FUNCTION IF EXISTS "tr_ItemStock_func"();
                
                DROP TRIGGER IF EXISTS "tr_LoginDevice" ON "LoginDevice";
                DROP FUNCTION IF EXISTS "tr_LoginDevice_func"();
                
                DROP TRIGGER IF EXISTS "tr_MailSettings" ON "MailSettings";
                DROP FUNCTION IF EXISTS "tr_MailSettings_func"();
                
                DROP TRIGGER IF EXISTS "tr_MedicationVitalSignType" ON "MedicationVitalSignType";
                DROP FUNCTION IF EXISTS "tr_MedicationVitalSignType_func"();
                
                DROP TRIGGER IF EXISTS "tr_MobileAppVersioning" ON "MobileAppVersioning";
                DROP FUNCTION IF EXISTS "tr_MobileAppVersioning_func"();
                
                DROP TRIGGER IF EXISTS "tr_MultiDisciplinaryMeeting" ON "MultiDisciplinaryMeeting";
                DROP FUNCTION IF EXISTS "tr_MultiDisciplinaryMeeting_func"();
                
                DROP TRIGGER IF EXISTS "tr_MultiDisciplinaryMeetingDetail" ON "MultiDisciplinaryMeetingDetail";
                DROP FUNCTION IF EXISTS "tr_MultiDisciplinaryMeetingDetail_func"();
                
                DROP TRIGGER IF EXISTS "tr_NotificationChat" ON "NotificationChat";
                DROP FUNCTION IF EXISTS "tr_NotificationChat_func"();
                
                DROP TRIGGER IF EXISTS "tr_NotificationEvent" ON "NotificationEvent";
                DROP FUNCTION IF EXISTS "tr_NotificationEvent_func"();
                
                DROP TRIGGER IF EXISTS "tr_NotificationMessageTemplates" ON "NotificationMessageTemplates";
                DROP FUNCTION IF EXISTS "tr_NotificationMessageTemplates_func"();
                
                DROP TRIGGER IF EXISTS "tr_Notifications" ON "Notifications";
                DROP FUNCTION IF EXISTS "tr_Notifications_func"();
                
                DROP TRIGGER IF EXISTS "tr_NotificationTask" ON "NotificationTask";
                DROP FUNCTION IF EXISTS "tr_NotificationTask_func"();
                
                DROP TRIGGER IF EXISTS "tr_NotificationVitalSignDetails" ON "NotificationVitalSignDetails";
                DROP FUNCTION IF EXISTS "tr_NotificationVitalSignDetails_func"();
                
                DROP TRIGGER IF EXISTS "tr_NutritionTask" ON "NutritionTask";
                DROP FUNCTION IF EXISTS "tr_NutritionTask_func"();
                
                DROP TRIGGER IF EXISTS "tr_NutritionTaskReference" ON "NutritionTaskReference";
                DROP FUNCTION IF EXISTS "tr_NutritionTaskReference_func"();
                
                DROP TRIGGER IF EXISTS "tr_Otp" ON "Otp";
                DROP FUNCTION IF EXISTS "tr_Otp_func"();
                
                DROP TRIGGER IF EXISTS "tr_Package" ON "Package";
                DROP FUNCTION IF EXISTS "tr_Package_func"();
                
                DROP TRIGGER IF EXISTS "tr_Patient" ON "Patient";
                DROP FUNCTION IF EXISTS "tr_Patient_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientAccessLine" ON "PatientAccessLine";
                DROP FUNCTION IF EXISTS "tr_PatientAccessLine_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientAdditionalInfo" ON "PatientAdditionalInfo";
                DROP FUNCTION IF EXISTS "tr_PatientAdditionalInfo_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientAMT" ON "PatientAMT";
                DROP FUNCTION IF EXISTS "tr_PatientAMT_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientAMTAnswer" ON "PatientAMTAnswer";
                DROP FUNCTION IF EXISTS "tr_PatientAMTAnswer_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientAttachment" ON "PatientAttachment";
                DROP FUNCTION IF EXISTS "tr_PatientAttachment_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientBradenScale" ON "PatientBradenScale";
                DROP FUNCTION IF EXISTS "tr_PatientBradenScale_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientClinician" ON "PatientClinician";
                DROP FUNCTION IF EXISTS "tr_PatientClinician_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientDrugAllergy" ON "PatientDrugAllergy";
                DROP FUNCTION IF EXISTS "tr_PatientDrugAllergy_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientEBASDEP" ON "PatientEBASDEP";
                DROP FUNCTION IF EXISTS "tr_PatientEBASDEP_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientEBASDEPAnswer" ON "PatientEBASDEPAnswer";
                DROP FUNCTION IF EXISTS "tr_PatientEBASDEPAnswer_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientFamilyHistory" ON "PatientFamilyHistory";
                DROP FUNCTION IF EXISTS "tr_PatientFamilyHistory_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientGCS" ON "PatientGCS";
                DROP FUNCTION IF EXISTS "tr_PatientGCS_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientImmunisation" ON "PatientImmunisation";
                DROP FUNCTION IF EXISTS "tr_PatientImmunisation_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientLanguage" ON "PatientLanguage";
                DROP FUNCTION IF EXISTS "tr_PatientLanguage_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientMBI" ON "PatientMBI";
                DROP FUNCTION IF EXISTS "tr_PatientMBI_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientMedicalHistory" ON "PatientMedicalHistory";
                DROP FUNCTION IF EXISTS "tr_PatientMedicalHistory_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientMedication" ON "PatientMedication";
                DROP FUNCTION IF EXISTS "tr_PatientMedication_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientMedicationConsume" ON "PatientMedicationConsume";
                DROP FUNCTION IF EXISTS "tr_PatientMedicationConsume_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientMedicationConsumeAttachment" ON "PatientMedicationConsumeAttachment";
                DROP FUNCTION IF EXISTS "tr_PatientMedicationConsumeAttachment_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientMedicationSupply" ON "PatientMedicationSupply";
                DROP FUNCTION IF EXISTS "tr_PatientMedicationSupply_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientMFS" ON "PatientMFS";
                DROP FUNCTION IF EXISTS "tr_PatientMFS_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientMMSE" ON "PatientMMSE";
                DROP FUNCTION IF EXISTS "tr_PatientMMSE_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientNutrition" ON "PatientNutrition";
                DROP FUNCTION IF EXISTS "tr_PatientNutrition_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientOtherAllergy" ON "PatientOtherAllergy";
                DROP FUNCTION IF EXISTS "tr_PatientOtherAllergy_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientPackage" ON "PatientPackage";
                DROP FUNCTION IF EXISTS "tr_PatientPackage_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientProfile" ON "PatientProfile";
                DROP FUNCTION IF EXISTS "tr_PatientProfile_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientRAF" ON "PatientRAF";
                DROP FUNCTION IF EXISTS "tr_PatientRAF_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientReferral" ON "PatientReferral";
                DROP FUNCTION IF EXISTS "tr_PatientReferral_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientReferralService" ON "PatientReferralService";
                DROP FUNCTION IF EXISTS "tr_PatientReferralService_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientSocialSupport" ON "PatientSocialSupport";
                DROP FUNCTION IF EXISTS "tr_PatientSocialSupport_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientSpecialIndicator" ON "PatientSpecialIndicator";
                DROP FUNCTION IF EXISTS "tr_PatientSpecialIndicator_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientWound" ON "PatientWound";
                DROP FUNCTION IF EXISTS "tr_PatientWound_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientWoundDraft" ON "PatientWoundDraft";
                DROP FUNCTION IF EXISTS "tr_PatientWoundDraft_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientWoundReviewBy" ON "PatientWoundReviewBy";
                DROP FUNCTION IF EXISTS "tr_PatientWoundReviewBy_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientWoundVisit" ON "PatientWoundVisit";
                DROP FUNCTION IF EXISTS "tr_PatientWoundVisit_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientWoundVisitAppearance" ON "PatientWoundVisitAppearance";
                DROP FUNCTION IF EXISTS "tr_PatientWoundVisitAppearance_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientWoundVisitCleansingItem" ON "PatientWoundVisitCleansingItem";
                DROP FUNCTION IF EXISTS "tr_PatientWoundVisitCleansingItem_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientWoundVisitClinician" ON "PatientWoundVisitClinician";
                DROP FUNCTION IF EXISTS "tr_PatientWoundVisitClinician_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientWoundVisitTreatment" ON "PatientWoundVisitTreatment";
                DROP FUNCTION IF EXISTS "tr_PatientWoundVisitTreatment_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientWoundVisitTreatmentList" ON "PatientWoundVisitTreatmentList";
                DROP FUNCTION IF EXISTS "tr_PatientWoundVisitTreatmentList_func"();
                
                DROP TRIGGER IF EXISTS "tr_PatientWoundVisitTreatmentObjectives" ON "PatientWoundVisitTreatmentObjectives";
                DROP FUNCTION IF EXISTS "tr_PatientWoundVisitTreatmentObjectives_func"();
                
                DROP TRIGGER IF EXISTS "tr_ProblemList" ON "ProblemList";
                DROP FUNCTION IF EXISTS "tr_ProblemList_func"();
                
                DROP TRIGGER IF EXISTS "tr_ProblemListGoal" ON "ProblemListGoal";
                DROP FUNCTION IF EXISTS "tr_ProblemListGoal_func"();
                
                DROP TRIGGER IF EXISTS "tr_Receipt" ON "Receipt";
                DROP FUNCTION IF EXISTS "tr_Receipt_func"();
                
                DROP TRIGGER IF EXISTS "tr_ReceiptForInvoice" ON "ReceiptForInvoice";
                DROP FUNCTION IF EXISTS "tr_ReceiptForInvoice_func"();
                
                DROP TRIGGER IF EXISTS "tr_RegisteredDevice" ON "RegisteredDevice";
                DROP FUNCTION IF EXISTS "tr_RegisteredDevice_func"();
                
                DROP TRIGGER IF EXISTS "tr_RegisteredDeviceV2" ON "RegisteredDeviceV2";
                DROP FUNCTION IF EXISTS "tr_RegisteredDeviceV2_func"();
                
                DROP TRIGGER IF EXISTS "tr_ResidentAssessmentCategory" ON "ResidentAssessmentCategory";
                DROP FUNCTION IF EXISTS "tr_ResidentAssessmentCategory_func"();
                
                DROP TRIGGER IF EXISTS "tr_Role" ON "Role";
                DROP FUNCTION IF EXISTS "tr_Role_func"();
                
                DROP TRIGGER IF EXISTS "tr_ScheduledTasks" ON "ScheduledTasks";
                DROP FUNCTION IF EXISTS "tr_ScheduledTasks_func"();
                
                DROP TRIGGER IF EXISTS "tr_ServiceForBilling" ON "ServiceForBilling";
                DROP FUNCTION IF EXISTS "tr_ServiceForBilling_func"();
                
                DROP TRIGGER IF EXISTS "tr_ServiceForBillingCost" ON "ServiceForBillingCost";
                DROP FUNCTION IF EXISTS "tr_ServiceForBillingCost_func"();
                
                DROP TRIGGER IF EXISTS "tr_ServiceSkillset" ON "ServiceSkillset";
                DROP FUNCTION IF EXISTS "tr_ServiceSkillset_func"();
                
                DROP TRIGGER IF EXISTS "tr_SyncPatientLog" ON "SyncPatientLog";
                DROP FUNCTION IF EXISTS "tr_SyncPatientLog_func"();
                
                DROP TRIGGER IF EXISTS "tr_SyncWoundLog" ON "SyncWoundLog";
                DROP FUNCTION IF EXISTS "tr_SyncWoundLog_func"();
                
                DROP TRIGGER IF EXISTS "tr_SyncWoundVisitLog" ON "SyncWoundVisitLog";
                DROP FUNCTION IF EXISTS "tr_SyncWoundVisitLog_func"();
                
                DROP TRIGGER IF EXISTS "tr_SysConfig" ON "SysConfig";
                DROP FUNCTION IF EXISTS "tr_SysConfig_func"();
                
                DROP TRIGGER IF EXISTS "tr_SystemForDisease" ON "SystemForDisease";
                DROP FUNCTION IF EXISTS "tr_SystemForDisease_func"();
                
                DROP TRIGGER IF EXISTS "tr_Task" ON "Task";
                DROP FUNCTION IF EXISTS "tr_Task_func"();
                
                DROP TRIGGER IF EXISTS "tr_TaskFileAttachment" ON "TaskFileAttachment";
                DROP FUNCTION IF EXISTS "tr_TaskFileAttachment_func"();
                
                DROP TRIGGER IF EXISTS "tr_TaskServicesRequired" ON "TaskServicesRequired";
                DROP FUNCTION IF EXISTS "tr_TaskServicesRequired_func"();
                
                DROP TRIGGER IF EXISTS "tr_TaskSpecificDate" ON "TaskSpecificDate";
                DROP FUNCTION IF EXISTS "tr_TaskSpecificDate_func"();
                
                DROP TRIGGER IF EXISTS "tr_TaskUser" ON "TaskUser";
                DROP FUNCTION IF EXISTS "tr_TaskUser_func"();
                
                DROP TRIGGER IF EXISTS "tr_TaskUserLog" ON "TaskUserLog";
                DROP FUNCTION IF EXISTS "tr_TaskUserLog_func"();
                
                DROP TRIGGER IF EXISTS "tr_TaskUserLogAttachment" ON "TaskUserLogAttachment";
                DROP FUNCTION IF EXISTS "tr_TaskUserLogAttachment_func"();
                
                DROP TRIGGER IF EXISTS "tr_TD_WoundAssessmentFactor" ON "TD_WoundAssessmentFactor";
                DROP FUNCTION IF EXISTS "tr_TD_WoundAssessmentFactor_func"();
                
                DROP TRIGGER IF EXISTS "tr_TeleconsultationRecording" ON "TeleconsultationRecording";
                DROP FUNCTION IF EXISTS "tr_TeleconsultationRecording_func"();
                
                DROP TRIGGER IF EXISTS "tr_TeleconsultationReport" ON "TeleconsultationReport";
                DROP FUNCTION IF EXISTS "tr_TeleconsultationReport_func"();
                
                DROP TRIGGER IF EXISTS "tr_Thresholds" ON "Thresholds";
                DROP FUNCTION IF EXISTS "tr_Thresholds_func"();
                
                DROP TRIGGER IF EXISTS "tr_TreatmentListItem" ON "TreatmentListItem";
                DROP FUNCTION IF EXISTS "tr_TreatmentListItem_func"();
                
                DROP TRIGGER IF EXISTS "tr_TreatmentTOL" ON "TreatmentTOL";
                DROP FUNCTION IF EXISTS "tr_TreatmentTOL_func"();
                
                DROP TRIGGER IF EXISTS "tr_Types" ON "Types";
                DROP FUNCTION IF EXISTS "tr_Types_func"();
                
                DROP TRIGGER IF EXISTS "tr_UploadFile" ON "UploadFile";
                DROP FUNCTION IF EXISTS "tr_UploadFile_func"();
                
                DROP TRIGGER IF EXISTS "tr_UserAddress" ON "UserAddress";
                DROP FUNCTION IF EXISTS "tr_UserAddress_func"();
                
                DROP TRIGGER IF EXISTS "tr_UserBranch" ON "UserBranch";
                DROP FUNCTION IF EXISTS "tr_UserBranch_func"();
                
                DROP TRIGGER IF EXISTS "tr_UserCategory" ON "UserCategory";
                DROP FUNCTION IF EXISTS "tr_UserCategory_func"();
                
                DROP TRIGGER IF EXISTS "tr_UserCategoryRole" ON "UserCategoryRole";
                DROP FUNCTION IF EXISTS "tr_UserCategoryRole_func"();
                
                DROP TRIGGER IF EXISTS "tr_UserLanguage" ON "UserLanguage";
                DROP FUNCTION IF EXISTS "tr_UserLanguage_func"();
                
                DROP TRIGGER IF EXISTS "tr_UserOrganization" ON "UserOrganization";
                DROP FUNCTION IF EXISTS "tr_UserOrganization_func"();
                
                DROP TRIGGER IF EXISTS "tr_UserRole" ON "UserRole";
                DROP FUNCTION IF EXISTS "tr_UserRole_func"();
                
                DROP TRIGGER IF EXISTS "tr_Users" ON "Users";
                DROP FUNCTION IF EXISTS "tr_Users_func"();
                
                DROP TRIGGER IF EXISTS "tr_UserSkillset" ON "UserSkillset";
                DROP FUNCTION IF EXISTS "tr_UserSkillset_func"();
                
                DROP TRIGGER IF EXISTS "tr_UserType" ON "UserType";
                DROP FUNCTION IF EXISTS "tr_UserType_func"();
                
                DROP TRIGGER IF EXISTS "tr_UserUserType" ON "UserUserType";
                DROP FUNCTION IF EXISTS "tr_UserUserType_func"();
                
                DROP TRIGGER IF EXISTS "tr_VitalSignDetails" ON "VitalSignDetails";
                DROP FUNCTION IF EXISTS "tr_VitalSignDetails_func"();
                
                DROP TRIGGER IF EXISTS "tr_VitalSignRelationships" ON "VitalSignRelationships";
                DROP FUNCTION IF EXISTS "tr_VitalSignRelationships_func"();
                
                DROP TRIGGER IF EXISTS "tr_VitalSigns" ON "VitalSigns";
                DROP FUNCTION IF EXISTS "tr_VitalSigns_func"();
                
                DROP TRIGGER IF EXISTS "tr_VitalSignTypes" ON "VitalSignTypes";
                DROP FUNCTION IF EXISTS "tr_VitalSignTypes_func"();
                
                DROP TRIGGER IF EXISTS "tr_VitalSignTypeThreshold" ON "VitalSignTypeThreshold";
                DROP FUNCTION IF EXISTS "tr_VitalSignTypeThreshold_func"();
                
                DROP TRIGGER IF EXISTS "tr_WoundConsolidatedEmail" ON "WoundConsolidatedEmail";
                DROP FUNCTION IF EXISTS "tr_WoundConsolidatedEmail_func"();
                """);
        }
    }
}
