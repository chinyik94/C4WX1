﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.Database.Models;

public partial class THCC_C4WDEVContext : DbContext
{
    public THCC_C4WDEVContext(DbContextOptions<THCC_C4WDEVContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AMTQuestion> AMTQuestion { get; set; }

    public virtual DbSet<APIAccessKey> APIAccessKey { get; set; }

    public virtual DbSet<APIMonitor> APIMonitor { get; set; }

    public virtual DbSet<APIOrder> APIOrder { get; set; }

    public virtual DbSet<APIOrderAllergy> APIOrderAllergy { get; set; }

    public virtual DbSet<APIOrderDiagnosis> APIOrderDiagnosis { get; set; }

    public virtual DbSet<APIOrderMedication> APIOrderMedication { get; set; }

    public virtual DbSet<APIOrderTask> APIOrderTask { get; set; }

    public virtual DbSet<APNSNotification> APNSNotification { get; set; }

    public virtual DbSet<Activity> Activity { get; set; }

    public virtual DbSet<AuditTrail> AuditTrail { get; set; }

    public virtual DbSet<Audit_AMTQuestion> Audit_AMTQuestion { get; set; }

    public virtual DbSet<Audit_APIAccessKey> Audit_APIAccessKey { get; set; }

    public virtual DbSet<Audit_APIMonitor> Audit_APIMonitor { get; set; }

    public virtual DbSet<Audit_APIOrder> Audit_APIOrder { get; set; }

    public virtual DbSet<Audit_APIOrderAllergy> Audit_APIOrderAllergy { get; set; }

    public virtual DbSet<Audit_APIOrderDiagnosis> Audit_APIOrderDiagnosis { get; set; }

    public virtual DbSet<Audit_APIOrderMedication> Audit_APIOrderMedication { get; set; }

    public virtual DbSet<Audit_APIOrderTask> Audit_APIOrderTask { get; set; }

    public virtual DbSet<Audit_APNSNotification> Audit_APNSNotification { get; set; }

    public virtual DbSet<Audit_Activity> Audit_Activity { get; set; }

    public virtual DbSet<Audit_BillingInvoice> Audit_BillingInvoice { get; set; }

    public virtual DbSet<Audit_BillingInvoiceConsumable> Audit_BillingInvoiceConsumable { get; set; }

    public virtual DbSet<Audit_BillingInvoiceService> Audit_BillingInvoiceService { get; set; }

    public virtual DbSet<Audit_BillingPackage> Audit_BillingPackage { get; set; }

    public virtual DbSet<Audit_BillingPackageInformation> Audit_BillingPackageInformation { get; set; }

    public virtual DbSet<Audit_BillingPackageRequest> Audit_BillingPackageRequest { get; set; }

    public virtual DbSet<Audit_BillingProposal> Audit_BillingProposal { get; set; }

    public virtual DbSet<Audit_BillingProposalService> Audit_BillingProposalService { get; set; }

    public virtual DbSet<Audit_BillingService> Audit_BillingService { get; set; }

    public virtual DbSet<Audit_Branch> Audit_Branch { get; set; }

    public virtual DbSet<Audit_C4WDeviceToken> Audit_C4WDeviceToken { get; set; }

    public virtual DbSet<Audit_CPGoals> Audit_CPGoals { get; set; }

    public virtual DbSet<Audit_CarePlan> Audit_CarePlan { get; set; }

    public virtual DbSet<Audit_CarePlanDetail> Audit_CarePlanDetail { get; set; }

    public virtual DbSet<Audit_CarePlanStatus> Audit_CarePlanStatus { get; set; }

    public virtual DbSet<Audit_CarePlanSub> Audit_CarePlanSub { get; set; }

    public virtual DbSet<Audit_CarePlanSubActivity> Audit_CarePlanSubActivity { get; set; }

    public virtual DbSet<Audit_CarePlanSubCPGoals> Audit_CarePlanSubCPGoals { get; set; }

    public virtual DbSet<Audit_CarePlanSubGoal> Audit_CarePlanSubGoal { get; set; }

    public virtual DbSet<Audit_CarePlanSubIntervention> Audit_CarePlanSubIntervention { get; set; }

    public virtual DbSet<Audit_CarePlanSubProblemList> Audit_CarePlanSubProblemList { get; set; }

    public virtual DbSet<Audit_CarePlanSubProblemListGoal> Audit_CarePlanSubProblemListGoal { get; set; }

    public virtual DbSet<Audit_CareReport> Audit_CareReport { get; set; }

    public virtual DbSet<Audit_CareReportConfig> Audit_CareReportConfig { get; set; }

    public virtual DbSet<Audit_CareReportRehabilitation> Audit_CareReportRehabilitation { get; set; }

    public virtual DbSet<Audit_CareReportSocialSupport> Audit_CareReportSocialSupport { get; set; }

    public virtual DbSet<Audit_CareReportSystemInfo> Audit_CareReportSystemInfo { get; set; }

    public virtual DbSet<Audit_Chat> Audit_Chat { get; set; }

    public virtual DbSet<Audit_Code> Audit_Code { get; set; }

    public virtual DbSet<Audit_CodeType> Audit_CodeType { get; set; }

    public virtual DbSet<Audit_Diagnosis> Audit_Diagnosis { get; set; }

    public virtual DbSet<Audit_DischargeSummaryReport> Audit_DischargeSummaryReport { get; set; }

    public virtual DbSet<Audit_DischargeSummaryReportAttachment> Audit_DischargeSummaryReportAttachment { get; set; }

    public virtual DbSet<Audit_Disease> Audit_Disease { get; set; }

    public virtual DbSet<Audit_DiseaseInfo> Audit_DiseaseInfo { get; set; }

    public virtual DbSet<Audit_DiseaseSubInfo> Audit_DiseaseSubInfo { get; set; }

    public virtual DbSet<Audit_DiseaseVitalSignType> Audit_DiseaseVitalSignType { get; set; }

    public virtual DbSet<Audit_EBASDEPQuestion> Audit_EBASDEPQuestion { get; set; }

    public virtual DbSet<Audit_Enquiry> Audit_Enquiry { get; set; }

    public virtual DbSet<Audit_EnquiryAttachment> Audit_EnquiryAttachment { get; set; }

    public virtual DbSet<Audit_EnquiryConfig> Audit_EnquiryConfig { get; set; }

    public virtual DbSet<Audit_EnquiryEscPerson> Audit_EnquiryEscPerson { get; set; }

    public virtual DbSet<Audit_EnquiryLanguage> Audit_EnquiryLanguage { get; set; }

    public virtual DbSet<Audit_EnquirySCM> Audit_EnquirySCM { get; set; }

    public virtual DbSet<Audit_EnquiryServicesRequired> Audit_EnquiryServicesRequired { get; set; }

    public virtual DbSet<Audit_Event> Audit_Event { get; set; }

    public virtual DbSet<Audit_EventUser> Audit_EventUser { get; set; }

    public virtual DbSet<Audit_EventUserLog> Audit_EventUserLog { get; set; }

    public virtual DbSet<Audit_ExternalDoctor> Audit_ExternalDoctor { get; set; }

    public virtual DbSet<Audit_GeoFencing> Audit_GeoFencing { get; set; }

    public virtual DbSet<Audit_Group> Audit_Group { get; set; }

    public virtual DbSet<Audit_GroupRole> Audit_GroupRole { get; set; }

    public virtual DbSet<Audit_ICAWoundCare> Audit_ICAWoundCare { get; set; }

    public virtual DbSet<Audit_InitialCareAssessment> Audit_InitialCareAssessment { get; set; }

    public virtual DbSet<Audit_InitialCareAssessmentAttachment> Audit_InitialCareAssessmentAttachment { get; set; }

    public virtual DbSet<Audit_InitialCareAssessmentSpecialInstruction> Audit_InitialCareAssessmentSpecialInstruction { get; set; }

    public virtual DbSet<Audit_InitialCareAssessmentVitalSign> Audit_InitialCareAssessmentVitalSign { get; set; }

    public virtual DbSet<Audit_Intervention> Audit_Intervention { get; set; }

    public virtual DbSet<Audit_Item> Audit_Item { get; set; }

    public virtual DbSet<Audit_ItemStock> Audit_ItemStock { get; set; }

    public virtual DbSet<Audit_LoginDevice> Audit_LoginDevice { get; set; }

    public virtual DbSet<Audit_MailSettings> Audit_MailSettings { get; set; }

    public virtual DbSet<Audit_MedicationVitalSignType> Audit_MedicationVitalSignType { get; set; }

    public virtual DbSet<Audit_MobileAppVersioning> Audit_MobileAppVersioning { get; set; }

    public virtual DbSet<Audit_MultiDisciplinaryMeeting> Audit_MultiDisciplinaryMeeting { get; set; }

    public virtual DbSet<Audit_MultiDisciplinaryMeetingDetail> Audit_MultiDisciplinaryMeetingDetail { get; set; }

    public virtual DbSet<Audit_NotificationChat> Audit_NotificationChat { get; set; }

    public virtual DbSet<Audit_NotificationEvent> Audit_NotificationEvent { get; set; }

    public virtual DbSet<Audit_NotificationMessageTemplates> Audit_NotificationMessageTemplates { get; set; }

    public virtual DbSet<Audit_NotificationTask> Audit_NotificationTask { get; set; }

    public virtual DbSet<Audit_NotificationVitalSignDetails> Audit_NotificationVitalSignDetails { get; set; }

    public virtual DbSet<Audit_Notifications> Audit_Notifications { get; set; }

    public virtual DbSet<Audit_NutritionTask> Audit_NutritionTask { get; set; }

    public virtual DbSet<Audit_NutritionTaskReference> Audit_NutritionTaskReference { get; set; }

    public virtual DbSet<Audit_Otp> Audit_Otp { get; set; }

    public virtual DbSet<Audit_Package> Audit_Package { get; set; }

    public virtual DbSet<Audit_Patient> Audit_Patient { get; set; }

    public virtual DbSet<Audit_PatientAMT> Audit_PatientAMT { get; set; }

    public virtual DbSet<Audit_PatientAMTAnswer> Audit_PatientAMTAnswer { get; set; }

    public virtual DbSet<Audit_PatientAccessLine> Audit_PatientAccessLine { get; set; }

    public virtual DbSet<Audit_PatientAdditionalInfo> Audit_PatientAdditionalInfo { get; set; }

    public virtual DbSet<Audit_PatientAttachment> Audit_PatientAttachment { get; set; }

    public virtual DbSet<Audit_PatientBradenScale> Audit_PatientBradenScale { get; set; }

    public virtual DbSet<Audit_PatientClinician> Audit_PatientClinician { get; set; }

    public virtual DbSet<Audit_PatientDrugAllergy> Audit_PatientDrugAllergy { get; set; }

    public virtual DbSet<Audit_PatientEBASDEP> Audit_PatientEBASDEP { get; set; }

    public virtual DbSet<Audit_PatientEBASDEPAnswer> Audit_PatientEBASDEPAnswer { get; set; }

    public virtual DbSet<Audit_PatientFamilyHistory> Audit_PatientFamilyHistory { get; set; }

    public virtual DbSet<Audit_PatientGCS> Audit_PatientGCS { get; set; }

    public virtual DbSet<Audit_PatientImmunisation> Audit_PatientImmunisation { get; set; }

    public virtual DbSet<Audit_PatientLanguage> Audit_PatientLanguage { get; set; }

    public virtual DbSet<Audit_PatientMBI> Audit_PatientMBI { get; set; }

    public virtual DbSet<Audit_PatientMFS> Audit_PatientMFS { get; set; }

    public virtual DbSet<Audit_PatientMMSE> Audit_PatientMMSE { get; set; }

    public virtual DbSet<Audit_PatientMedicalHistory> Audit_PatientMedicalHistory { get; set; }

    public virtual DbSet<Audit_PatientMedication> Audit_PatientMedication { get; set; }

    public virtual DbSet<Audit_PatientMedicationConsume> Audit_PatientMedicationConsume { get; set; }

    public virtual DbSet<Audit_PatientMedicationConsumeAttachment> Audit_PatientMedicationConsumeAttachment { get; set; }

    public virtual DbSet<Audit_PatientMedicationSupply> Audit_PatientMedicationSupply { get; set; }

    public virtual DbSet<Audit_PatientNutrition> Audit_PatientNutrition { get; set; }

    public virtual DbSet<Audit_PatientOtherAllergy> Audit_PatientOtherAllergy { get; set; }

    public virtual DbSet<Audit_PatientPackage> Audit_PatientPackage { get; set; }

    public virtual DbSet<Audit_PatientProfile> Audit_PatientProfile { get; set; }

    public virtual DbSet<Audit_PatientRAF> Audit_PatientRAF { get; set; }

    public virtual DbSet<Audit_PatientReferral> Audit_PatientReferral { get; set; }

    public virtual DbSet<Audit_PatientReferralService> Audit_PatientReferralService { get; set; }

    public virtual DbSet<Audit_PatientSocialSupport> Audit_PatientSocialSupport { get; set; }

    public virtual DbSet<Audit_PatientSpecialIndicator> Audit_PatientSpecialIndicator { get; set; }

    public virtual DbSet<Audit_PatientWound> Audit_PatientWound { get; set; }

    public virtual DbSet<Audit_PatientWoundDraft> Audit_PatientWoundDraft { get; set; }

    public virtual DbSet<Audit_PatientWoundReviewBy> Audit_PatientWoundReviewBy { get; set; }

    public virtual DbSet<Audit_PatientWoundVisit> Audit_PatientWoundVisit { get; set; }

    public virtual DbSet<Audit_PatientWoundVisitAppearance> Audit_PatientWoundVisitAppearance { get; set; }

    public virtual DbSet<Audit_PatientWoundVisitCleansingItem> Audit_PatientWoundVisitCleansingItem { get; set; }

    public virtual DbSet<Audit_PatientWoundVisitClinician> Audit_PatientWoundVisitClinician { get; set; }

    public virtual DbSet<Audit_PatientWoundVisitTreatment> Audit_PatientWoundVisitTreatment { get; set; }

    public virtual DbSet<Audit_PatientWoundVisitTreatmentList> Audit_PatientWoundVisitTreatmentList { get; set; }

    public virtual DbSet<Audit_PatientWoundVisitTreatmentObjectives> Audit_PatientWoundVisitTreatmentObjectives { get; set; }

    public virtual DbSet<Audit_ProblemList> Audit_ProblemList { get; set; }

    public virtual DbSet<Audit_ProblemListGoal> Audit_ProblemListGoal { get; set; }

    public virtual DbSet<Audit_Receipt> Audit_Receipt { get; set; }

    public virtual DbSet<Audit_ReceiptForInvoice> Audit_ReceiptForInvoice { get; set; }

    public virtual DbSet<Audit_RegisteredDevice> Audit_RegisteredDevice { get; set; }

    public virtual DbSet<Audit_RegisteredDeviceV2> Audit_RegisteredDeviceV2 { get; set; }

    public virtual DbSet<Audit_ResidentAssessmentCategory> Audit_ResidentAssessmentCategory { get; set; }

    public virtual DbSet<Audit_Role> Audit_Role { get; set; }

    public virtual DbSet<Audit_ScheduledTasks> Audit_ScheduledTasks { get; set; }

    public virtual DbSet<Audit_ServiceForBilling> Audit_ServiceForBilling { get; set; }

    public virtual DbSet<Audit_ServiceForBillingCost> Audit_ServiceForBillingCost { get; set; }

    public virtual DbSet<Audit_ServiceSkillset> Audit_ServiceSkillset { get; set; }

    public virtual DbSet<Audit_SyncPatientLog> Audit_SyncPatientLog { get; set; }

    public virtual DbSet<Audit_SyncWoundLog> Audit_SyncWoundLog { get; set; }

    public virtual DbSet<Audit_SyncWoundVisitLog> Audit_SyncWoundVisitLog { get; set; }

    public virtual DbSet<Audit_SysConfig> Audit_SysConfig { get; set; }

    public virtual DbSet<Audit_SystemForDisease> Audit_SystemForDisease { get; set; }

    public virtual DbSet<Audit_TD_WoundAssessmentFactor> Audit_TD_WoundAssessmentFactor { get; set; }

    public virtual DbSet<Audit_Task> Audit_Task { get; set; }

    public virtual DbSet<Audit_TaskFileAttachment> Audit_TaskFileAttachment { get; set; }

    public virtual DbSet<Audit_TaskServicesRequired> Audit_TaskServicesRequired { get; set; }

    public virtual DbSet<Audit_TaskSpecificDate> Audit_TaskSpecificDate { get; set; }

    public virtual DbSet<Audit_TaskUser> Audit_TaskUser { get; set; }

    public virtual DbSet<Audit_TaskUserLog> Audit_TaskUserLog { get; set; }

    public virtual DbSet<Audit_TaskUserLogAttachment> Audit_TaskUserLogAttachment { get; set; }

    public virtual DbSet<Audit_TeleconsultationRecording> Audit_TeleconsultationRecording { get; set; }

    public virtual DbSet<Audit_TeleconsultationReport> Audit_TeleconsultationReport { get; set; }

    public virtual DbSet<Audit_Thresholds> Audit_Thresholds { get; set; }

    public virtual DbSet<Audit_TreatmentListItem> Audit_TreatmentListItem { get; set; }

    public virtual DbSet<Audit_TreatmentTOL> Audit_TreatmentTOL { get; set; }

    public virtual DbSet<Audit_Types> Audit_Types { get; set; }

    public virtual DbSet<Audit_UploadFile> Audit_UploadFile { get; set; }

    public virtual DbSet<Audit_UserAddress> Audit_UserAddress { get; set; }

    public virtual DbSet<Audit_UserBranch> Audit_UserBranch { get; set; }

    public virtual DbSet<Audit_UserCategory> Audit_UserCategory { get; set; }

    public virtual DbSet<Audit_UserCategoryRole> Audit_UserCategoryRole { get; set; }

    public virtual DbSet<Audit_UserLanguage> Audit_UserLanguage { get; set; }

    public virtual DbSet<Audit_UserOrganization> Audit_UserOrganization { get; set; }

    public virtual DbSet<Audit_UserRole> Audit_UserRole { get; set; }

    public virtual DbSet<Audit_UserSkillset> Audit_UserSkillset { get; set; }

    public virtual DbSet<Audit_UserType> Audit_UserType { get; set; }

    public virtual DbSet<Audit_UserUserType> Audit_UserUserType { get; set; }

    public virtual DbSet<Audit_Users> Audit_Users { get; set; }

    public virtual DbSet<Audit_VitalSignDetails> Audit_VitalSignDetails { get; set; }

    public virtual DbSet<Audit_VitalSignRelationships> Audit_VitalSignRelationships { get; set; }

    public virtual DbSet<Audit_VitalSignTypeThreshold> Audit_VitalSignTypeThreshold { get; set; }

    public virtual DbSet<Audit_VitalSignTypes> Audit_VitalSignTypes { get; set; }

    public virtual DbSet<Audit_VitalSigns> Audit_VitalSigns { get; set; }

    public virtual DbSet<Audit_WoundConsolidatedEmail> Audit_WoundConsolidatedEmail { get; set; }

    public virtual DbSet<BillingInvoice> BillingInvoice { get; set; }

    public virtual DbSet<BillingInvoiceConsumable> BillingInvoiceConsumable { get; set; }

    public virtual DbSet<BillingInvoiceService> BillingInvoiceService { get; set; }

    public virtual DbSet<BillingPackage> BillingPackage { get; set; }

    public virtual DbSet<BillingPackageInformation> BillingPackageInformation { get; set; }

    public virtual DbSet<BillingPackageRequest> BillingPackageRequest { get; set; }

    public virtual DbSet<BillingProposal> BillingProposal { get; set; }

    public virtual DbSet<BillingProposalService> BillingProposalService { get; set; }

    public virtual DbSet<BillingService> BillingService { get; set; }

    public virtual DbSet<Branch> Branch { get; set; }

    public virtual DbSet<C4WDeviceToken> C4WDeviceToken { get; set; }

    public virtual DbSet<C4WImage> C4WImage { get; set; }

    public virtual DbSet<CPGoals> CPGoals { get; set; }

    public virtual DbSet<CarePlan> CarePlan { get; set; }

    public virtual DbSet<CarePlanDetail> CarePlanDetail { get; set; }

    public virtual DbSet<CarePlanStatus> CarePlanStatus { get; set; }

    public virtual DbSet<CarePlanSub> CarePlanSub { get; set; }

    public virtual DbSet<CarePlanSubActivity> CarePlanSubActivity { get; set; }

    public virtual DbSet<CarePlanSubCPGoals> CarePlanSubCPGoals { get; set; }

    public virtual DbSet<CarePlanSubGoal> CarePlanSubGoal { get; set; }

    public virtual DbSet<CarePlanSubIntervention> CarePlanSubIntervention { get; set; }

    public virtual DbSet<CarePlanSubProblemList> CarePlanSubProblemList { get; set; }

    public virtual DbSet<CarePlanSubProblemListGoal> CarePlanSubProblemListGoal { get; set; }

    public virtual DbSet<CareReport> CareReport { get; set; }

    public virtual DbSet<CareReportConfig> CareReportConfig { get; set; }

    public virtual DbSet<CareReportRehabilitation> CareReportRehabilitation { get; set; }

    public virtual DbSet<CareReportSocialSupport> CareReportSocialSupport { get; set; }

    public virtual DbSet<CareReportSystemInfo> CareReportSystemInfo { get; set; }

    public virtual DbSet<Chat> Chat { get; set; }

    public virtual DbSet<Code> Code { get; set; }

    public virtual DbSet<CodeType> CodeType { get; set; }

    public virtual DbSet<Diagnosis> Diagnosis { get; set; }

    public virtual DbSet<DischargeSummaryReport> DischargeSummaryReport { get; set; }

    public virtual DbSet<DischargeSummaryReportAttachment> DischargeSummaryReportAttachment { get; set; }

    public virtual DbSet<Disease> Disease { get; set; }

    public virtual DbSet<DiseaseInfo> DiseaseInfo { get; set; }

    public virtual DbSet<DiseaseSubInfo> DiseaseSubInfo { get; set; }

    public virtual DbSet<DiseaseVitalSignType> DiseaseVitalSignType { get; set; }

    public virtual DbSet<EBASDEPQuestion> EBASDEPQuestion { get; set; }

    public virtual DbSet<EmailLog> EmailLog { get; set; }

    public virtual DbSet<Enquiry> Enquiry { get; set; }

    public virtual DbSet<EnquiryAttachment> EnquiryAttachment { get; set; }

    public virtual DbSet<EnquiryConfig> EnquiryConfig { get; set; }

    public virtual DbSet<EnquiryEscPerson> EnquiryEscPerson { get; set; }

    public virtual DbSet<EnquiryLanguage> EnquiryLanguage { get; set; }

    public virtual DbSet<EnquirySCM> EnquirySCM { get; set; }

    public virtual DbSet<EnquiryServicesRequired> EnquiryServicesRequired { get; set; }

    public virtual DbSet<ErrorLog> ErrorLog { get; set; }

    public virtual DbSet<Event> Event { get; set; }

    public virtual DbSet<EventUser> EventUser { get; set; }

    public virtual DbSet<EventUserLog> EventUserLog { get; set; }

    public virtual DbSet<ExternalDoctor> ExternalDoctor { get; set; }

    public virtual DbSet<Facility> Facility { get; set; }

    public virtual DbSet<GeoFencing> GeoFencing { get; set; }

    public virtual DbSet<Group> Group { get; set; }

    public virtual DbSet<GroupRole> GroupRole { get; set; }

    public virtual DbSet<ICAWoundCare> ICAWoundCare { get; set; }

    public virtual DbSet<InitialCareAssessment> InitialCareAssessment { get; set; }

    public virtual DbSet<InitialCareAssessmentAttachment> InitialCareAssessmentAttachment { get; set; }

    public virtual DbSet<InitialCareAssessmentSpecialInstruction> InitialCareAssessmentSpecialInstruction { get; set; }

    public virtual DbSet<InitialCareAssessmentVitalSign> InitialCareAssessmentVitalSign { get; set; }

    public virtual DbSet<IntegrationApiRequestLog> IntegrationApiRequestLog { get; set; }

    public virtual DbSet<Intervention> Intervention { get; set; }

    public virtual DbSet<Item> Item { get; set; }

    public virtual DbSet<ItemStock> ItemStock { get; set; }

    public virtual DbSet<Language> Language { get; set; }

    public virtual DbSet<LoginDevice> LoginDevice { get; set; }

    public virtual DbSet<MailSettings> MailSettings { get; set; }

    public virtual DbSet<MailSettingsMsgToUserType> MailSettingsMsgToUserType { get; set; }

    public virtual DbSet<MedicationVitalSignType> MedicationVitalSignType { get; set; }

    public virtual DbSet<MobileAppVersioning> MobileAppVersioning { get; set; }

    public virtual DbSet<MultiDisciplinaryMeeting> MultiDisciplinaryMeeting { get; set; }

    public virtual DbSet<MultiDisciplinaryMeetingDetail> MultiDisciplinaryMeetingDetail { get; set; }

    public virtual DbSet<NotificationChat> NotificationChat { get; set; }

    public virtual DbSet<NotificationEvent> NotificationEvent { get; set; }

    public virtual DbSet<NotificationMessageTemplates> NotificationMessageTemplates { get; set; }

    public virtual DbSet<NotificationTask> NotificationTask { get; set; }

    public virtual DbSet<NotificationVitalSignDetails> NotificationVitalSignDetails { get; set; }

    public virtual DbSet<Notifications> Notifications { get; set; }

    public virtual DbSet<NutritionTask> NutritionTask { get; set; }

    public virtual DbSet<NutritionTaskReference> NutritionTaskReference { get; set; }

    public virtual DbSet<Otp> Otp { get; set; }

    public virtual DbSet<Package> Package { get; set; }

    public virtual DbSet<Patient> Patient { get; set; }

    public virtual DbSet<PatientAMT> PatientAMT { get; set; }

    public virtual DbSet<PatientAMTAnswer> PatientAMTAnswer { get; set; }

    public virtual DbSet<PatientAccessLine> PatientAccessLine { get; set; }

    public virtual DbSet<PatientAdditionalInfo> PatientAdditionalInfo { get; set; }

    public virtual DbSet<PatientAttachment> PatientAttachment { get; set; }

    public virtual DbSet<PatientBradenScale> PatientBradenScale { get; set; }

    public virtual DbSet<PatientClinician> PatientClinician { get; set; }

    public virtual DbSet<PatientDrugAllergy> PatientDrugAllergy { get; set; }

    public virtual DbSet<PatientEBASDEP> PatientEBASDEP { get; set; }

    public virtual DbSet<PatientEBASDEPAnswer> PatientEBASDEPAnswer { get; set; }

    public virtual DbSet<PatientFacility> PatientFacility { get; set; }

    public virtual DbSet<PatientFamilyHistory> PatientFamilyHistory { get; set; }

    public virtual DbSet<PatientGCS> PatientGCS { get; set; }

    public virtual DbSet<PatientImmunisation> PatientImmunisation { get; set; }

    public virtual DbSet<PatientLanguage> PatientLanguage { get; set; }

    public virtual DbSet<PatientMBI> PatientMBI { get; set; }

    public virtual DbSet<PatientMFS> PatientMFS { get; set; }

    public virtual DbSet<PatientMMSE> PatientMMSE { get; set; }

    public virtual DbSet<PatientMedicalHistory> PatientMedicalHistory { get; set; }

    public virtual DbSet<PatientMedication> PatientMedication { get; set; }

    public virtual DbSet<PatientMedicationConsume> PatientMedicationConsume { get; set; }

    public virtual DbSet<PatientMedicationConsumeAttachment> PatientMedicationConsumeAttachment { get; set; }

    public virtual DbSet<PatientMedicationSupply> PatientMedicationSupply { get; set; }

    public virtual DbSet<PatientNutrition> PatientNutrition { get; set; }

    public virtual DbSet<PatientOtherAllergy> PatientOtherAllergy { get; set; }

    public virtual DbSet<PatientPackage> PatientPackage { get; set; }

    public virtual DbSet<PatientProfile> PatientProfile { get; set; }

    public virtual DbSet<PatientRAF> PatientRAF { get; set; }

    public virtual DbSet<PatientReferral> PatientReferral { get; set; }

    public virtual DbSet<PatientReferralService> PatientReferralService { get; set; }

    public virtual DbSet<PatientSocialSupport> PatientSocialSupport { get; set; }

    public virtual DbSet<PatientSpecialIndicator> PatientSpecialIndicator { get; set; }

    public virtual DbSet<PatientWound> PatientWound { get; set; }

    public virtual DbSet<PatientWoundDraft> PatientWoundDraft { get; set; }

    public virtual DbSet<PatientWoundDraftTreatmentList> PatientWoundDraftTreatmentList { get; set; }

    public virtual DbSet<PatientWoundDraftTreatmentObjectives> PatientWoundDraftTreatmentObjectives { get; set; }

    public virtual DbSet<PatientWoundReviewBy> PatientWoundReviewBy { get; set; }

    public virtual DbSet<PatientWoundVisit> PatientWoundVisit { get; set; }

    public virtual DbSet<PatientWoundVisitAppearance> PatientWoundVisitAppearance { get; set; }

    public virtual DbSet<PatientWoundVisitCleansingItem> PatientWoundVisitCleansingItem { get; set; }

    public virtual DbSet<PatientWoundVisitClinician> PatientWoundVisitClinician { get; set; }

    public virtual DbSet<PatientWoundVisitTreatment> PatientWoundVisitTreatment { get; set; }

    public virtual DbSet<PatientWoundVisitTreatmentList> PatientWoundVisitTreatmentList { get; set; }

    public virtual DbSet<PatientWoundVisitTreatmentObjectives> PatientWoundVisitTreatmentObjectives { get; set; }

    public virtual DbSet<ProblemList> ProblemList { get; set; }

    public virtual DbSet<ProblemListGoal> ProblemListGoal { get; set; }

    public virtual DbSet<Receipt> Receipt { get; set; }

    public virtual DbSet<ReceiptForInvoice> ReceiptForInvoice { get; set; }

    public virtual DbSet<RecentView> RecentView { get; set; }

    public virtual DbSet<RegisteredDevice> RegisteredDevice { get; set; }

    public virtual DbSet<RegisteredDeviceV2> RegisteredDeviceV2 { get; set; }

    public virtual DbSet<ResidentAssessmentCategory> ResidentAssessmentCategory { get; set; }

    public virtual DbSet<Resource> Resource { get; set; }

    public virtual DbSet<Role> Role { get; set; }

    public virtual DbSet<ScheduledTasks> ScheduledTasks { get; set; }

    public virtual DbSet<ServiceForBilling> ServiceForBilling { get; set; }

    public virtual DbSet<ServiceForBillingCost> ServiceForBillingCost { get; set; }

    public virtual DbSet<ServiceSkillset> ServiceSkillset { get; set; }

    public virtual DbSet<SyncPatientLog> SyncPatientLog { get; set; }

    public virtual DbSet<SyncWoundLog> SyncWoundLog { get; set; }

    public virtual DbSet<SyncWoundVisitLog> SyncWoundVisitLog { get; set; }

    public virtual DbSet<SysConfig> SysConfig { get; set; }

    public virtual DbSet<SystemForDisease> SystemForDisease { get; set; }

    public virtual DbSet<TD_WoundAssessmentFactor> TD_WoundAssessmentFactor { get; set; }

    public virtual DbSet<Task> Task { get; set; }

    public virtual DbSet<TaskFileAttachment> TaskFileAttachment { get; set; }

    public virtual DbSet<TaskServicesRequired> TaskServicesRequired { get; set; }

    public virtual DbSet<TaskSpecificDate> TaskSpecificDate { get; set; }

    public virtual DbSet<TaskUser> TaskUser { get; set; }

    public virtual DbSet<TaskUserLog> TaskUserLog { get; set; }

    public virtual DbSet<TaskUserLogAttachment> TaskUserLogAttachment { get; set; }

    public virtual DbSet<TeleconsultationRecording> TeleconsultationRecording { get; set; }

    public virtual DbSet<TeleconsultationReport> TeleconsultationReport { get; set; }

    public virtual DbSet<Thresholds> Thresholds { get; set; }

    public virtual DbSet<TreatmentListItem> TreatmentListItem { get; set; }

    public virtual DbSet<TreatmentTOL> TreatmentTOL { get; set; }

    public virtual DbSet<Types> Types { get; set; }

    public virtual DbSet<UUIDLog> UUIDLog { get; set; }

    public virtual DbSet<UploadFile> UploadFile { get; set; }

    public virtual DbSet<UserAddress> UserAddress { get; set; }

    public virtual DbSet<UserBranch> UserBranch { get; set; }

    public virtual DbSet<UserCategory> UserCategory { get; set; }

    public virtual DbSet<UserCategoryFacility> UserCategoryFacility { get; set; }

    public virtual DbSet<UserCategoryParentChild> UserCategoryParentChild { get; set; }

    public virtual DbSet<UserCategoryRole> UserCategoryRole { get; set; }

    public virtual DbSet<UserLanguage> UserLanguage { get; set; }

    public virtual DbSet<UserOrganization> UserOrganization { get; set; }

    public virtual DbSet<UserRole> UserRole { get; set; }

    public virtual DbSet<UserSkillset> UserSkillset { get; set; }

    public virtual DbSet<UserType> UserType { get; set; }

    public virtual DbSet<UserUserType> UserUserType { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    public virtual DbSet<VitalSignDetails> VitalSignDetails { get; set; }

    public virtual DbSet<VitalSignRelationships> VitalSignRelationships { get; set; }

    public virtual DbSet<VitalSignTypeThreshold> VitalSignTypeThreshold { get; set; }

    public virtual DbSet<VitalSignTypes> VitalSignTypes { get; set; }

    public virtual DbSet<VitalSigns> VitalSigns { get; set; }

    public virtual DbSet<WoundConsolidatedEmail> WoundConsolidatedEmail { get; set; }

    public virtual DbSet<WoundUserCategoryParentChild> WoundUserCategoryParentChild { get; set; }

    public virtual DbSet<vw_AmtAssessmentDue> vw_AmtAssessmentDue { get; set; }

    public virtual DbSet<vw_AmtCarePlanSetup> vw_AmtCarePlanSetup { get; set; }

    public virtual DbSet<vw_AssessmentDue> vw_AssessmentDue { get; set; }

    public virtual DbSet<vw_BradenScaleAssessmentDue> vw_BradenScaleAssessmentDue { get; set; }

    public virtual DbSet<vw_BradenScaleCarePlanSetup> vw_BradenScaleCarePlanSetup { get; set; }

    public virtual DbSet<vw_CarePlanSetup> vw_CarePlanSetup { get; set; }

    public virtual DbSet<vw_CarePlanSystemDisease> vw_CarePlanSystemDisease { get; set; }

    public virtual DbSet<vw_DiseaseCarePlanSetup> vw_DiseaseCarePlanSetup { get; set; }

    public virtual DbSet<vw_Doctors> vw_Doctors { get; set; }

    public virtual DbSet<vw_EbasDepAssessmentDue> vw_EbasDepAssessmentDue { get; set; }

    public virtual DbSet<vw_FalangaScores> vw_FalangaScores { get; set; }

    public virtual DbSet<vw_FalangaScores_WoundDraft> vw_FalangaScores_WoundDraft { get; set; }

    public virtual DbSet<vw_GcsAssessmentDue> vw_GcsAssessmentDue { get; set; }

    public virtual DbSet<vw_MbiAssessmentDue> vw_MbiAssessmentDue { get; set; }

    public virtual DbSet<vw_MedicalHistoryCarePlanSetup> vw_MedicalHistoryCarePlanSetup { get; set; }

    public virtual DbSet<vw_MfsAssessmentDue> vw_MfsAssessmentDue { get; set; }

    public virtual DbSet<vw_MmseAssessmentDue> vw_MmseAssessmentDue { get; set; }

    public virtual DbSet<vw_NursingDiagnosesCarePlanSetup> vw_NursingDiagnosesCarePlanSetup { get; set; }

    public virtual DbSet<vw_OralCarePlanSetup> vw_OralCarePlanSetup { get; set; }

    public virtual DbSet<vw_PatientAllLatestVitalSigns> vw_PatientAllLatestVitalSigns { get; set; }

    public virtual DbSet<vw_PatientBilling> vw_PatientBilling { get; set; }

    public virtual DbSet<vw_PatientDisease> vw_PatientDisease { get; set; }

    public virtual DbSet<vw_PatientLatestVitalSigns> vw_PatientLatestVitalSigns { get; set; }

    public virtual DbSet<vw_PatientWound> vw_PatientWound { get; set; }

    public virtual DbSet<vw_PatientWoundImageDownload> vw_PatientWoundImageDownload { get; set; }

    public virtual DbSet<vw_PushScores> vw_PushScores { get; set; }

    public virtual DbSet<vw_RafAssessmentDue> vw_RafAssessmentDue { get; set; }

    public virtual DbSet<vw_RafCarePlanSetup> vw_RafCarePlanSetup { get; set; }

    public virtual DbSet<vw_Teleconsultation> vw_Teleconsultation { get; set; }

    public virtual DbSet<vw_UserRoles> vw_UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AMTQuestion>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Question).HasMaxLength(255);
        });

        modelBuilder.Entity<APIAccessKey>(entity =>
        {
            entity.HasKey(e => e.APIAccessKeyID).HasName("PK__APIAcces__79CAEB20D6CC8EEA");

            entity.HasIndex(e => new { e.TokenCode, e.ExpiryDate }, "idx_APIAccessKey1");

            entity.HasIndex(e => e.TokenCode, "idx_APIAccessKey2");

            entity.HasIndex(e => new { e.TokenCode, e.ExpiryDate, e.CreatedDate }, "idx_APIAccessKey3");

            entity.Property(e => e.AccessKey).HasMaxLength(200);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ExpiryDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.TokenCode).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.TokenCodeNavigation).WithMany(p => p.APIAccessKey)
                .HasForeignKey(d => d.TokenCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_APIAccessKey_TokenCode");
        });

        modelBuilder.Entity<APIMonitor>(entity =>
        {
            entity.HasKey(e => e.MonitorID).HasName("PK_MonitorID");

            entity.Property(e => e.APIName).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UUID)
                .HasMaxLength(36)
                .IsFixedLength();
        });

        modelBuilder.Entity<APIOrder>(entity =>
        {
            entity.Property(e => e.AcceptedByName).HasMaxLength(255);
            entity.Property(e => e.AcceptedInstitutionName).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DoctorMCR).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.OrderID).HasMaxLength(60);
            entity.Property(e => e.OrderedByInstitution).HasMaxLength(255);
            entity.Property(e => e.OrderedByName).HasMaxLength(255);
            entity.Property(e => e.PatientFirstName).HasMaxLength(60);
            entity.Property(e => e.PatientLastName).HasMaxLength(60);
            entity.Property(e => e.PatientNRIC).HasMaxLength(60);
            entity.Property(e => e.ResourceType).HasMaxLength(255);
        });

        modelBuilder.Entity<APIOrderAllergy>(entity =>
        {
            entity.HasIndex(e => e.APIOrderID_FK, "IX_APIOrderAllergy_APIOrderID_FK");

            entity.Property(e => e.AllergyAgent).HasMaxLength(255);
            entity.Property(e => e.AllergyReaction).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.APIOrderID_FKNavigation).WithMany(p => p.APIOrderAllergy)
                .HasForeignKey(d => d.APIOrderID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_APIOrderAllergy_APIOrder");
        });

        modelBuilder.Entity<APIOrderDiagnosis>(entity =>
        {
            entity.HasIndex(e => e.APIOrderID_FK, "IX_APIOrderDiagnosis_APIOrderID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DiagnosisDesc).HasMaxLength(255);
            entity.Property(e => e.DiagnosisType).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.APIOrderID_FKNavigation).WithMany(p => p.APIOrderDiagnosis)
                .HasForeignKey(d => d.APIOrderID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_APIOrderDiagnosis_APIOrder");
        });

        modelBuilder.Entity<APIOrderMedication>(entity =>
        {
            entity.HasIndex(e => e.APIOrderID_FK, "IX_APIOrderMedication_APIOrderID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EndDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.MedicationDisplay).HasMaxLength(255);
            entity.Property(e => e.MedicationName).HasMaxLength(255);
            entity.Property(e => e.MedicationPeriodUnit).HasMaxLength(60);
            entity.Property(e => e.MedicationQuantityUnit).HasMaxLength(60);
            entity.Property(e => e.MedicationStatus).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.APIOrderID_FKNavigation).WithMany(p => p.APIOrderMedication)
                .HasForeignKey(d => d.APIOrderID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_APIOrderMedication_APIOrder");
        });

        modelBuilder.Entity<APIOrderTask>(entity =>
        {
            entity.HasIndex(e => e.APIOrderID_FK, "IX_APIOrderTask_APIOrderID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Remark).HasMaxLength(255);
            entity.Property(e => e.TaskDisplay).HasMaxLength(255);
            entity.Property(e => e.TaskEndDateTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.TaskName).HasMaxLength(255);
            entity.Property(e => e.TaskPeriodUnit).HasMaxLength(60);
            entity.Property(e => e.TaskStartDateTime).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.APIOrderID_FKNavigation).WithMany(p => p.APIOrderTask)
                .HasForeignKey(d => d.APIOrderID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_APIOrderTask_APIOrder");
        });

        modelBuilder.Entity<APNSNotification>(entity =>
        {
            entity.Property(e => e.NotificationMessage).HasMaxLength(1000);
            entity.Property(e => e.NotificationTitle).HasMaxLength(300);
        });

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasIndex(e => e.DiseaseID_FK, "IX_Activity_DiseaseID_FK");

            entity.HasIndex(e => e.ProblemListID_FK, "IX_Activity_ProblemListID_FK");

            entity.Property(e => e.ActivityDetail).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.DiseaseID_FKNavigation).WithMany(p => p.Activity)
                .HasForeignKey(d => d.DiseaseID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Activity_Disease");

            entity.HasOne(d => d.ProblemListID_FKNavigation).WithMany(p => p.Activity)
                .HasForeignKey(d => d.ProblemListID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Activity_ProblemList");
        });

        modelBuilder.Entity<AuditTrail>(entity =>
        {
            entity.HasIndex(e => e.CreatedBy_FK, "IX_AuditTrail_CreatedBy_FK");

            entity.Property(e => e.AuditAction).HasDefaultValueSql("''::text");
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Event).HasMaxLength(50);
            entity.Property(e => e.IPAddress).HasMaxLength(100);
            entity.Property(e => e.Module).HasMaxLength(255);

            entity.HasOne(d => d.CreatedBy_FKNavigation).WithMany(p => p.AuditTrail)
                .HasForeignKey(d => d.CreatedBy_FK)
                .HasConstraintName("FK_AuditTrail_Users");
        });

        modelBuilder.Entity<Audit_AMTQuestion>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Question).HasMaxLength(255);
        });

        modelBuilder.Entity<Audit_APIAccessKey>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AccessKey).HasMaxLength(200);
            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ExpiryDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.TokenCode).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_APIMonitor>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.APIName).HasMaxLength(50);
            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UUID)
                .HasMaxLength(36)
                .IsFixedLength();
        });

        modelBuilder.Entity<Audit_APIOrder>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AcceptedByName).HasMaxLength(255);
            entity.Property(e => e.AcceptedInstitutionName).HasMaxLength(255);
            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DoctorMCR).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.OrderID).HasMaxLength(60);
            entity.Property(e => e.OrderedByInstitution).HasMaxLength(255);
            entity.Property(e => e.OrderedByName).HasMaxLength(255);
            entity.Property(e => e.PatientFirstName).HasMaxLength(60);
            entity.Property(e => e.PatientLastName).HasMaxLength(60);
            entity.Property(e => e.PatientNRIC).HasMaxLength(60);
            entity.Property(e => e.ResourceType).HasMaxLength(255);
        });

        modelBuilder.Entity<Audit_APIOrderAllergy>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AllergyAgent).HasMaxLength(255);
            entity.Property(e => e.AllergyReaction).HasMaxLength(255);
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_APIOrderDiagnosis>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DiagnosisDesc).HasMaxLength(255);
            entity.Property(e => e.DiagnosisType).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_APIOrderMedication>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EndDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.MedicationDisplay).HasMaxLength(255);
            entity.Property(e => e.MedicationName).HasMaxLength(255);
            entity.Property(e => e.MedicationPeriodUnit).HasMaxLength(60);
            entity.Property(e => e.MedicationQuantityUnit).HasMaxLength(60);
            entity.Property(e => e.MedicationStatus).HasMaxLength(60);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_APIOrderTask>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Remark).HasMaxLength(255);
            entity.Property(e => e.TaskDisplay).HasMaxLength(255);
            entity.Property(e => e.TaskEndDateTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.TaskName).HasMaxLength(255);
            entity.Property(e => e.TaskPeriodUnit).HasMaxLength(60);
            entity.Property(e => e.TaskStartDateTime).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_APNSNotification>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.NotificationMessage).HasMaxLength(1000);
            entity.Property(e => e.NotificationTitle).HasMaxLength(300);
        });

        modelBuilder.Entity<Audit_Activity>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ActivityDetail).HasMaxLength(255);
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_BillingInvoice>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CaseNumber).HasMaxLength(20);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.GroupNumber).HasMaxLength(10);
            entity.Property(e => e.InvoiceDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.InvoiceDueDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.InvoiceNumber).HasMaxLength(20);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status).HasMaxLength(15);
            entity.Property(e => e.TotalCost).HasPrecision(18, 2);
        });

        modelBuilder.Entity<Audit_BillingInvoiceConsumable>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UnitPrice).HasPrecision(18, 2);
        });

        modelBuilder.Entity<Audit_BillingInvoiceService>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Discount).HasPrecision(18, 2);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UnitCost).HasPrecision(18, 2);
        });

        modelBuilder.Entity<Audit_BillingPackage>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.TotalPrice).HasPrecision(18);
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.UnitPrice).HasPrecision(18);
        });

        modelBuilder.Entity<Audit_BillingPackageInformation>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_BillingPackageRequest>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.BillingAddress1).HasMaxLength(255);
            entity.Property(e => e.BillingAddress2).HasMaxLength(255);
            entity.Property(e => e.BillingAddress3).HasMaxLength(255);
            entity.Property(e => e.BillingPostalCode)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DiscountAmt).HasPrecision(18, 2);
            entity.Property(e => e.DiscountPercentage).HasPrecision(18, 2);
            entity.Property(e => e.DiscountType).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.EndDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PackageList).HasMaxLength(50);
            entity.Property(e => e.PackageRequestNo).HasMaxLength(255);
            entity.Property(e => e.PatientName).HasMaxLength(100);
            entity.Property(e => e.SendBillTo).HasMaxLength(10);
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.TotalPackageAmount).HasPrecision(18, 2);
        });

        modelBuilder.Entity<Audit_BillingProposal>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.GroupNumber).HasMaxLength(10);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ProposalNumber).HasMaxLength(20);
            entity.Property(e => e.ProposalType).HasMaxLength(15);
            entity.Property(e => e.Status).HasMaxLength(15);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.TotalCost).HasPrecision(18, 2);
        });

        modelBuilder.Entity<Audit_BillingProposalService>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Discount).HasPrecision(18, 2);
            entity.Property(e => e.Duration1).HasMaxLength(50);
            entity.Property(e => e.Duration2).HasMaxLength(50);
            entity.Property(e => e.EndDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UnitCost).HasPrecision(18, 2);
        });

        modelBuilder.Entity<Audit_BillingService>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CostPerSession).HasPrecision(18, 2);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status).HasMaxLength(15);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Audit_Branch>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Address1).HasMaxLength(255);
            entity.Property(e => e.Address2).HasMaxLength(255);
            entity.Property(e => e.Address3).HasMaxLength(255);
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.BranchName).HasMaxLength(255);
            entity.Property(e => e.Contact).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status).HasMaxLength(10);
        });

        modelBuilder.Entity<Audit_C4WDeviceToken>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_CPGoals>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CPGoalsInfo).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_CarePlan>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CarePlanName).HasMaxLength(50);
            entity.Property(e => e.CarePlanType).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Remark).HasMaxLength(500);
        });

        modelBuilder.Entity<Audit_CarePlanDetail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_CarePlanStatus>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CarePlanStatus).HasMaxLength(50);
            entity.Property(e => e.CareReviewFrequency).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_CarePlanSub>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ApprovedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CarePlanGroupName).HasMaxLength(100);
            entity.Property(e => e.Goal).HasMaxLength(500);
            entity.Property(e => e.GoalStatus).HasMaxLength(100);
            entity.Property(e => e.InterventionStatus).HasMaxLength(100);
            entity.Property(e => e.ReviewDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_CarePlanSubActivity>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_CarePlanSubCPGoals>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_CarePlanSubGoal>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CarePlanSubGoalName).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Score1).HasPrecision(18);
            entity.Property(e => e.Score2).HasPrecision(18);
        });

        modelBuilder.Entity<Audit_CarePlanSubIntervention>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_CarePlanSubProblemList>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.Goal).HasMaxLength(500);
            entity.Property(e => e.PLReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PLStatus).HasMaxLength(250);
        });

        modelBuilder.Entity<Audit_CarePlanSubProblemListGoal>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.Goal).HasMaxLength(500);
            entity.Property(e => e.Score1).HasPrecision(18);
            entity.Property(e => e.Score2).HasPrecision(18);
        });

        modelBuilder.Entity<Audit_CareReport>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ACP_DoneDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ACP_ReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AggravatingFactor).HasMaxLength(255);
            entity.Property(e => e.AirwayBreathingRemarks).HasMaxLength(500);
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.BladderCareRemarks).HasMaxLength(500);
            entity.Property(e => e.BowelInterventions).HasMaxLength(500);
            entity.Property(e => e.BowelRemarks).HasMaxLength(500);
            entity.Property(e => e.BowelSounds).HasMaxLength(100);
            entity.Property(e => e.BreathSounds).HasMaxLength(100);
            entity.Property(e => e.CareReportType).HasMaxLength(30);
            entity.Property(e => e.CharacteristicOfUrine).HasMaxLength(500);
            entity.Property(e => e.CirculationRemarks).HasMaxLength(500);
            entity.Property(e => e.Color).HasMaxLength(30);
            entity.Property(e => e.ColorOthers).HasMaxLength(30);
            entity.Property(e => e.Consistency).HasMaxLength(30);
            entity.Property(e => e.CoughAmount).HasMaxLength(30);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DayNightReversal).HasMaxLength(5);
            entity.Property(e => e.Dysuria).HasMaxLength(5);
            entity.Property(e => e.Environment).HasMaxLength(2000);
            entity.Property(e => e.EnvironmentRemarks).HasMaxLength(500);
            entity.Property(e => e.Frequency).HasMaxLength(30);
            entity.Property(e => e.HeartSounds).HasMaxLength(100);
            entity.Property(e => e.LeftEyeReaction).HasMaxLength(30);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Nebuliser).HasMaxLength(1000);
            entity.Property(e => e.NeuroRemarks).HasMaxLength(500);
            entity.Property(e => e.O2Litres).HasPrecision(4, 1);
            entity.Property(e => e.O2LitresPercent).HasPrecision(3);
            entity.Property(e => e.OtherTreatment).HasMaxLength(2000);
            entity.Property(e => e.OtherTreatmentOther).HasMaxLength(255);
            entity.Property(e => e.OtherTreatmentRemarks).HasMaxLength(500);
            entity.Property(e => e.Pain).HasMaxLength(10);
            entity.Property(e => e.PainRemarks).HasMaxLength(500);
            entity.Property(e => e.PainScaleType).HasMaxLength(30);
            entity.Property(e => e.PersonalHygiene).HasMaxLength(2000);
            entity.Property(e => e.PersonalHygieneRemarks).HasMaxLength(500);
            entity.Property(e => e.PsychoEmotionalSpiritual).HasMaxLength(1000);
            entity.Property(e => e.PsychoRemarks).HasMaxLength(500);
            entity.Property(e => e.RelievingFactor).HasMaxLength(255);
            entity.Property(e => e.RightEyeReaction).HasMaxLength(30);
            entity.Property(e => e.SectionRequireInput).HasMaxLength(30);
            entity.Property(e => e.SectionRequired).HasMaxLength(30);
            entity.Property(e => e.SectionStatus).HasMaxLength(30);
            entity.Property(e => e.SiteOfPain).HasMaxLength(255);
            entity.Property(e => e.SkinAndWoundCare).HasMaxLength(2000);
            entity.Property(e => e.SleepRestRemarks).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.Stoma).HasMaxLength(5);
            entity.Property(e => e.StomaAmountOfOutput).HasMaxLength(50);
            entity.Property(e => e.StomaAppearance).HasMaxLength(20);
            entity.Property(e => e.StomaColour).HasMaxLength(20);
            entity.Property(e => e.StomaCreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StomaEffluent).HasMaxLength(50);
            entity.Property(e => e.StomaOstomyProductUsed).HasMaxLength(500);
            entity.Property(e => e.StomaPeristomalSkin).HasMaxLength(20);
            entity.Property(e => e.StomaProtrusion).HasMaxLength(50);
            entity.Property(e => e.StomaReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StomaSizeBreath).HasPrecision(4, 2);
            entity.Property(e => e.StomaSizeLength).HasPrecision(4, 2);
            entity.Property(e => e.Subject).HasMaxLength(50);
            entity.Property(e => e.Sunction).HasMaxLength(5);
            entity.Property(e => e.TemperatureInterventions).HasMaxLength(100);
            entity.Property(e => e.TemperatureRemarks).HasMaxLength(500);
            entity.Property(e => e.TypeOfPain).HasMaxLength(30);
            entity.Property(e => e.TypeOfUrine).HasMaxLength(30);
            entity.Property(e => e.VisitEndDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.VisitStartDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_CareReportConfig>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.SectionAccess).HasMaxLength(30);
        });

        modelBuilder.Entity<Audit_CareReportRehabilitation>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ADLAssistanceType).HasMaxLength(30);
            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.Bounded).HasMaxLength(30);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DVTType).HasMaxLength(300);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.RehabilitationRemarks).HasMaxLength(500);
            entity.Property(e => e.WalkingAidType).HasMaxLength(30);
        });

        modelBuilder.Entity<Audit_CareReportSocialSupport>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_CareReportSystemInfo>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PrimaryDoctorName).HasMaxLength(255);
            entity.Property(e => e.SecondaryDoctorName).HasMaxLength(255);
        });

        modelBuilder.Entity<Audit_Chat>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Attachment).HasMaxLength(255);
            entity.Property(e => e.Attachment_Physical).HasMaxLength(50);
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_Code>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CodeName).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CurrencyCodeA).HasMaxLength(3);
            entity.Property(e => e.CurrencyCodeN).HasMaxLength(3);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Referral_Code).HasMaxLength(3);
            entity.Property(e => e.Status).HasMaxLength(15);
        });

        modelBuilder.Entity<Audit_CodeType>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CodeTypeName).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_Diagnosis>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Diagnosis).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_DischargeSummaryReport>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DischargeDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.VisitDateEnd).HasColumnType("timestamp without time zone");
            entity.Property(e => e.VisitDateStart).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_DischargeSummaryReportAttachment>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Filename).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Physical).HasMaxLength(50);
        });

        modelBuilder.Entity<Audit_Disease>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DiseaseCode).HasMaxLength(60);
            entity.Property(e => e.DiseaseName).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_DiseaseInfo>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DiseaseInfo).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_DiseaseSubInfo>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DiseaseSubInfo).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_DiseaseVitalSignType>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_EBASDEPQuestion>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Question).HasMaxLength(255);
        });

        modelBuilder.Entity<Audit_Enquiry>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CaseNumber).HasMaxLength(50);
            entity.Property(e => e.ContactNumberOfCaller).HasMaxLength(20);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DateOfBirth).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EmailOfCaller).HasMaxLength(200);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.IdentificationNumber).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.MedicalHistory).HasMaxLength(500);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.NameOfCaller).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.OrderID).HasMaxLength(60);
            entity.Property(e => e.OtherPreferredLanguage).HasMaxLength(50);
            entity.Property(e => e.OtherRace).HasMaxLength(255);
            entity.Property(e => e.PatientAddress1).HasMaxLength(255);
            entity.Property(e => e.PatientAddress2).HasMaxLength(255);
            entity.Property(e => e.PatientAddress3).HasMaxLength(255);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.PreferredAppointmentDateTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<Audit_EnquiryAttachment>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Filename).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Physical).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<Audit_EnquiryConfig>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EscalationPeriod).HasPrecision(2);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_EnquiryEscPerson>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_EnquiryLanguage>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_EnquirySCM>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_EnquiryServicesRequired>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_Event>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EventName).HasMaxLength(50);
            entity.Property(e => e.FromDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ToDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_EventUser>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UserType).HasMaxLength(20);
        });

        modelBuilder.Entity<Audit_EventUserLog>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EndDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_ExternalDoctor>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.Contact).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Audit_GeoFencing>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.IP).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_Group>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.GroupName).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_GroupRole>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        modelBuilder.Entity<Audit_ICAWoundCare>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_InitialCareAssessment>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AddressIssue).HasMaxLength(255);
            entity.Property(e => e.AssistiveAids).HasMaxLength(100);
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.BeliefInfluenced).HasMaxLength(255);
            entity.Property(e => e.BowelHabitsDays).HasMaxLength(5);
            entity.Property(e => e.BowelHabitsTimes).HasMaxLength(5);
            entity.Property(e => e.BowelSounds).HasMaxLength(100);
            entity.Property(e => e.BowelType).HasMaxLength(20);
            entity.Property(e => e.BreathSounds).HasMaxLength(100);
            entity.Property(e => e.Breathing).HasMaxLength(20);
            entity.Property(e => e.CAAlertness).HasMaxLength(50);
            entity.Property(e => e.CACommunication).HasMaxLength(50);
            entity.Property(e => e.Catheter).HasMaxLength(5);
            entity.Property(e => e.CatheterDateInserted).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CatheterNextReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CatheterSize).HasMaxLength(10);
            entity.Property(e => e.CatheterType).HasMaxLength(50);
            entity.Property(e => e.Concern).HasMaxLength(255);
            entity.Property(e => e.ConsciousLevel).HasMaxLength(40);
            entity.Property(e => e.Cough).HasMaxLength(20);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DifficultyCopingYes).HasMaxLength(255);
            entity.Property(e => e.EmotionalState).HasMaxLength(20);
            entity.Property(e => e.EmotionalYes).HasMaxLength(255);
            entity.Property(e => e.Faith).HasMaxLength(255);
            entity.Property(e => e.GeneralCondition).HasMaxLength(20);
            entity.Property(e => e.GetSupport).HasMaxLength(255);
            entity.Property(e => e.GiveMeaningToLife).HasMaxLength(255);
            entity.Property(e => e.Hearing).HasMaxLength(50);
            entity.Property(e => e.HearingImpairedRemarks).HasMaxLength(500);
            entity.Property(e => e.HearingImpairedWithHearingAidRemarks).HasMaxLength(500);
            entity.Property(e => e.HomeFacilityRemarks).HasMaxLength(500);
            entity.Property(e => e.HowCanIHelp).HasMaxLength(255);
            entity.Property(e => e.HowDoYouScope).HasMaxLength(255);
            entity.Property(e => e.IncontinenceType).HasMaxLength(20);
            entity.Property(e => e.InfluenceTakeCare).HasMaxLength(255);
            entity.Property(e => e.LMP).HasColumnType("timestamp without time zone");
            entity.Property(e => e.LostInterestYes).HasMaxLength(255);
            entity.Property(e => e.MakeSense).HasMaxLength(255);
            entity.Property(e => e.MedicalHistory).HasMaxLength(1000);
            entity.Property(e => e.MilkFeedRx).HasMaxLength(255);
            entity.Property(e => e.MobilityStatus).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.O2Litres).HasPrecision(3, 1);
            entity.Property(e => e.O2LitresVia).HasMaxLength(40);
            entity.Property(e => e.Oralhealth).HasMaxLength(100);
            entity.Property(e => e.OtherBreathing).HasMaxLength(255);
            entity.Property(e => e.OtherEmotionalState).HasMaxLength(255);
            entity.Property(e => e.OxygenLMin).HasPrecision(5, 2);
            entity.Property(e => e.OxygenRemark).HasMaxLength(255);
            entity.Property(e => e.OxygenType).HasMaxLength(100);
            entity.Property(e => e.Palpation).HasMaxLength(100);
            entity.Property(e => e.Percussion).HasMaxLength(100);
            entity.Property(e => e.PersonalConcern).HasMaxLength(255);
            entity.Property(e => e.Physique).HasMaxLength(20);
            entity.Property(e => e.Remark).HasMaxLength(255);
            entity.Property(e => e.RoleOfBeliefForCommunity).HasMaxLength(255);
            entity.Property(e => e.RoleOfBeliefForInfluence).HasMaxLength(255);
            entity.Property(e => e.SectionStatus).HasMaxLength(30);
            entity.Property(e => e.SkinIssue).HasMaxLength(100);
            entity.Property(e => e.SkinTurgor).HasMaxLength(100);
            entity.Property(e => e.SkinType).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.Stoma).HasMaxLength(5);
            entity.Property(e => e.StomaAmountOfOutput).HasMaxLength(50);
            entity.Property(e => e.StomaAppearance).HasMaxLength(20);
            entity.Property(e => e.StomaColour).HasMaxLength(20);
            entity.Property(e => e.StomaCreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StomaEffluent).HasMaxLength(50);
            entity.Property(e => e.StomaOstomyProductUsed).HasMaxLength(500);
            entity.Property(e => e.StomaPeristomalSkin).HasMaxLength(20);
            entity.Property(e => e.StomaProtrusion).HasMaxLength(50);
            entity.Property(e => e.StomaReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StomaSizeBreath).HasPrecision(4, 2);
            entity.Property(e => e.StomaSizeLength).HasPrecision(4, 2);
            entity.Property(e => e.StoolsType).HasMaxLength(20);
            entity.Property(e => e.SupportTo).HasMaxLength(255);
            entity.Property(e => e.TalkToSomeone).HasMaxLength(255);
            entity.Property(e => e.Teeth).HasMaxLength(100);
            entity.Property(e => e.TenderNGuarding).HasMaxLength(100);
            entity.Property(e => e.TracheostomyDateInserted).HasColumnType("timestamp without time zone");
            entity.Property(e => e.TracheostomyNextReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.TracheostomySize).HasMaxLength(10);
            entity.Property(e => e.TracheostomyType).HasMaxLength(50);
            entity.Property(e => e.UrinaryFrequencyDay).HasMaxLength(5);
            entity.Property(e => e.UrinaryFrequencyTimes).HasMaxLength(5);
            entity.Property(e => e.UrinaryTypes).HasMaxLength(500);
            entity.Property(e => e.UrineColour).HasMaxLength(20);
            entity.Property(e => e.UrineConsistency).HasMaxLength(20);
            entity.Property(e => e.UseOfDrugExplain).HasMaxLength(1000);
            entity.Property(e => e.VSIntermittent).HasMaxLength(20);
            entity.Property(e => e.VSLocation).HasMaxLength(255);
            entity.Property(e => e.VSOnSetDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.VSPainFrequency).HasMaxLength(20);
            entity.Property(e => e.VSPrecipitatingFactors).HasMaxLength(255);
            entity.Property(e => e.VSQuality).HasMaxLength(20);
            entity.Property(e => e.VSRelievingFactors).HasMaxLength(255);
            entity.Property(e => e.Vision).HasMaxLength(20);
            entity.Property(e => e.VisionImpairedCataractRemarks).HasMaxLength(500);
            entity.Property(e => e.VisionImpairedGlaucomaRemarks).HasMaxLength(500);
            entity.Property(e => e.VisionImpairedRemarks).HasMaxLength(500);
            entity.Property(e => e.VisitDateTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.painOnSetDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_InitialCareAssessmentAttachment>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Filename).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Physical).HasMaxLength(50);
        });

        modelBuilder.Entity<Audit_InitialCareAssessmentSpecialInstruction>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EndDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Instructions).HasMaxLength(500);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_InitialCareAssessmentVitalSign>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.TimeOfRecord).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_Intervention>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.InterventionInfo).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_Item>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ItemName).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UnitPrice).HasPrecision(18, 2);
        });

        modelBuilder.Entity<Audit_ItemStock>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_LoginDevice>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DeviceID).HasMaxLength(200);
            entity.Property(e => e.DeviceType).HasMaxLength(8);
        });

        modelBuilder.Entity<Audit_MailSettings>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.description).HasMaxLength(255);
            entity.Property(e => e.msgBCC).HasMaxLength(255);
            entity.Property(e => e.msgCC).HasMaxLength(255);
            entity.Property(e => e.msgTo).HasMaxLength(255);
        });

        modelBuilder.Entity<Audit_MedicationVitalSignType>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_MobileAppVersioning>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AppName).HasMaxLength(50);
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DeviceType).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Version).HasMaxLength(50);
        });

        modelBuilder.Entity<Audit_MultiDisciplinaryMeeting>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_MultiDisciplinaryMeetingDetail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_NotificationChat>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_NotificationEvent>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_NotificationMessageTemplates>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.createdDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.notificationMessage).HasMaxLength(500);
            entity.Property(e => e.notificationSubject).HasMaxLength(200);
            entity.Property(e => e.notificationgroupCode).HasMaxLength(100);
            entity.Property(e => e.updatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_NotificationTask>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_NotificationVitalSignDetails>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.createdDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.updatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_Notifications>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.createdDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.notificationTypeCode).HasMaxLength(100);
            entity.Property(e => e.updatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_NutritionTask>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AfterImage).HasMaxLength(50);
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.BeforeImage).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EndTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Food).HasMaxLength(255);
            entity.Property(e => e.Liquid).HasMaxLength(50);
            entity.Property(e => e.Method).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.StartTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Unit).HasMaxLength(10);
        });

        modelBuilder.Entity<Audit_NutritionTaskReference>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ReferenceImage).HasMaxLength(50);
        });

        modelBuilder.Entity<Audit_Otp>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Password).HasMaxLength(10);
        });

        modelBuilder.Entity<Audit_Package>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PackageDetails).HasMaxLength(255);
            entity.Property(e => e.PackageName).HasMaxLength(255);
        });

        modelBuilder.Entity<Audit_Patient>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionDescription).HasMaxLength(255);
            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AdmittedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CareReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CaseID).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DateOfBirth).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DisplayName).HasMaxLength(255);
            entity.Property(e => e.DrugAllergy).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.GenogramPicture).HasMaxLength(50);
            entity.Property(e => e.HomePhone).HasMaxLength(100);
            entity.Property(e => e.IdentificationAttachmentFilename).HasMaxLength(255);
            entity.Property(e => e.IdentificationAttachmentPhysical).HasMaxLength(50);
            entity.Property(e => e.IdentificationNumber).HasMaxLength(255);
            entity.Property(e => e.IntegrationSourceID).HasMaxLength(100);
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.MailForFamilyNotification1).HasMaxLength(50);
            entity.Property(e => e.MailForFamilyNotification2).HasMaxLength(50);
            entity.Property(e => e.MailForVitalAlert1).HasMaxLength(50);
            entity.Property(e => e.MailForVitalAlert2).HasMaxLength(50);
            entity.Property(e => e.MailForVitalAlert3).HasMaxLength(50);
            entity.Property(e => e.MailingAddress1).HasMaxLength(255);
            entity.Property(e => e.MailingAddress2).HasMaxLength(255);
            entity.Property(e => e.MailingAddress3).HasMaxLength(255);
            entity.Property(e => e.MobilePhone).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.NRIC).HasMaxLength(20);
            entity.Property(e => e.NursingStation).HasMaxLength(255);
            entity.Property(e => e.Occupation).HasMaxLength(500);
            entity.Property(e => e.OrderID).HasMaxLength(60);
            entity.Property(e => e.OtherLanguage).HasMaxLength(255);
            entity.Property(e => e.OtherRace).HasMaxLength(255);
            entity.Property(e => e.PaymentMode).HasMaxLength(10);
            entity.Property(e => e.Photo).HasMaxLength(50);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.ReasonOfAdmission).HasMaxLength(500);
            entity.Property(e => e.ReferringDiagnosis).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(15);
            entity.Property(e => e.VisitingFrequency).HasMaxLength(500);
        });

        modelBuilder.Entity<Audit_PatientAMT>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Alertness).HasMaxLength(50);
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_PatientAMTAnswer>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_PatientAccessLine>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AccessLine).HasMaxLength(30);
            entity.Property(e => e.AccessLineRemarks).HasMaxLength(500);
            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DateDueForChange).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DateOfInsertion).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Patent).HasMaxLength(5);
            entity.Property(e => e.PatentReSited).HasMaxLength(5);
            entity.Property(e => e.PatentReSitedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PatentSite).HasMaxLength(1000);
        });

        modelBuilder.Entity<Audit_PatientAdditionalInfo>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ACP_DoneDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ACP_ReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AICD_InsertDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AICD_InsertedBy).HasMaxLength(255);
            entity.Property(e => e.AICD_ReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CVCLine_InsertDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CVCLine_InsertedBy).HasMaxLength(255);
            entity.Property(e => e.CVCLine_ReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DNR_DateInitiated).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DNR_DateTerminated).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DNR_InitiatedBy).HasMaxLength(255);
            entity.Property(e => e.DNR_TerminatedBy).HasMaxLength(255);
            entity.Property(e => e.IVLine_InsertDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.IVLine_InsertedBy).HasMaxLength(255);
            entity.Property(e => e.IVLine_ReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PICCLine_InsertDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PICCLine_InsertedBy).HasMaxLength(255);
            entity.Property(e => e.PICCLine_ReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Pacemaker_InsertDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Pacemaker_InsertedBy).HasMaxLength(255);
            entity.Property(e => e.Pacemaker_ReviewDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_PatientAttachment>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Filename).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Physical).HasMaxLength(50);
        });

        modelBuilder.Entity<Audit_PatientBradenScale>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Type).HasMaxLength(20);
        });

        modelBuilder.Entity<Audit_PatientClinician>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_PatientDrugAllergy>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_PatientEBASDEP>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Alertness).HasMaxLength(50);
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_PatientEBASDEPAnswer>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_PatientFamilyHistory>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Relationship).HasMaxLength(50);
        });

        modelBuilder.Entity<Audit_PatientGCS>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Type).HasMaxLength(20);
        });

        modelBuilder.Entity<Audit_PatientImmunisation>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Date).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.NextDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Place).HasMaxLength(255);
        });

        modelBuilder.Entity<Audit_PatientLanguage>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_PatientMBI>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Type).HasMaxLength(20);
        });

        modelBuilder.Entity<Audit_PatientMFS>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Type).HasMaxLength(20);
        });

        modelBuilder.Entity<Audit_PatientMMSE>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Type).HasMaxLength(20);
        });

        modelBuilder.Entity<Audit_PatientMedicalHistory>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_PatientMedication>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Allergies).HasMaxLength(255);
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_PatientMedicationConsume>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.ClinicHosp).HasMaxLength(50);
            entity.Property(e => e.ClinicHospED).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DrContact).HasMaxLength(50);
            entity.Property(e => e.DrContactED).HasMaxLength(50);
            entity.Property(e => e.DrName).HasMaxLength(50);
            entity.Property(e => e.DrNameED).HasMaxLength(50);
            entity.Property(e => e.EndDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Indication).HasMaxLength(255);
            entity.Property(e => e.MCRNo).HasMaxLength(50);
            entity.Property(e => e.MCRNoED).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ReasonOfDiscontinue).HasMaxLength(200);
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_PatientMedicationConsumeAttachment>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Filename).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Physical).HasMaxLength(50);
        });

        modelBuilder.Entity<Audit_PatientMedicationSupply>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_PatientNutrition>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Appetite).HasMaxLength(20);
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DiagnosedDysphasiaLastReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Diet).HasMaxLength(20);
            entity.Property(e => e.EatingAndSwallowing).HasMaxLength(20);
            entity.Property(e => e.EatingAndSwallowingDateDue).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EatingAndSwallowingDateInserted).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EatingAndSwallowingSize).HasMaxLength(20);
            entity.Property(e => e.EatingAndSwallowingTypeOfTube).HasMaxLength(20);
            entity.Property(e => e.EatingAndSwallowingTypeOfTubeFeeding).HasMaxLength(20);
            entity.Property(e => e.Enteralfeeding).HasMaxLength(20);
            entity.Property(e => e.FluidConsistency).HasMaxLength(20);
            entity.Property(e => e.FluidRestrictionMLSPerDay).HasPrecision(4);
            entity.Property(e => e.IVtherapyMLSPerDay).HasPrecision(4);
            entity.Property(e => e.IVtherapyStateType).HasMaxLength(255);
            entity.Property(e => e.MilkFeedAmt).HasPrecision(4);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.SizeofPEGJtube).HasMaxLength(20);
            entity.Property(e => e.WaterPerDay).HasPrecision(4);
        });

        modelBuilder.Entity<Audit_PatientOtherAllergy>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_PatientPackage>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_PatientProfile>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.Bed).HasMaxLength(255);
            entity.Property(e => e.BillingAddress1).HasMaxLength(255);
            entity.Property(e => e.BillingAddress2).HasMaxLength(255);
            entity.Property(e => e.BillingAddress3).HasMaxLength(255);
            entity.Property(e => e.BillingPostalCode).HasMaxLength(10);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.HomePhone).HasMaxLength(20);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.MobilePhone).HasMaxLength(20);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.Organization).HasMaxLength(255);
            entity.Property(e => e.OtherReligion).HasMaxLength(255);
            entity.Property(e => e.Ward).HasMaxLength(255);
        });

        modelBuilder.Entity<Audit_PatientRAF>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Type).HasMaxLength(20);
        });

        modelBuilder.Entity<Audit_PatientReferral>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.FamilyAwareDiagnoseReason).HasMaxLength(255);
            entity.Property(e => e.FamilyAwarePrognosisReason).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PatientAwareDiagnoseReason).HasMaxLength(255);
            entity.Property(e => e.PatientAwarePrognosisReason).HasMaxLength(255);
        });

        modelBuilder.Entity<Audit_PatientReferralService>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_PatientSocialSupport>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.Contact).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Firstname).HasMaxLength(255);
            entity.Property(e => e.Lastname).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UserType).HasMaxLength(255);
        });

        modelBuilder.Entity<Audit_PatientSpecialIndicator>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_PatientWound>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionDescription).HasMaxLength(255);
            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.LocationRemark).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.OccurDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.SeenDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(15);
        });

        modelBuilder.Entity<Audit_PatientWoundDraft>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AnnotatedImage).HasMaxLength(50);
            entity.Property(e => e.AnnotatedImageMeasurement).HasMaxLength(50);
            entity.Property(e => e.AssignDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.AverageDepth).HasPrecision(5, 2);
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DepthEighty).HasPrecision(5, 2);
            entity.Property(e => e.DepthForty).HasPrecision(5, 2);
            entity.Property(e => e.DepthImage).HasMaxLength(50);
            entity.Property(e => e.DepthImageMeasurement).HasMaxLength(50);
            entity.Property(e => e.DepthMax).HasPrecision(5, 2);
            entity.Property(e => e.DepthNans).HasPrecision(5, 2);
            entity.Property(e => e.DepthNegative).HasPrecision(5, 2);
            entity.Property(e => e.DepthSixty).HasPrecision(5, 2);
            entity.Property(e => e.DepthTwenty).HasPrecision(5, 2);
            entity.Property(e => e.Edges).HasMaxLength(50);
            entity.Property(e => e.Epithelizing).HasPrecision(5, 2);
            entity.Property(e => e.Exudate).HasMaxLength(50);
            entity.Property(e => e.ExudateNature).HasMaxLength(50);
            entity.Property(e => e.ExudatedConsistency).HasMaxLength(50);
            entity.Property(e => e.Granulation).HasPrecision(5, 2);
            entity.Property(e => e.ImageUpload).HasMaxLength(50);
            entity.Property(e => e.MaximumDepth).HasPrecision(5, 2);
            entity.Property(e => e.MeasurementUpdateRemark).HasMaxLength(255);
            entity.Property(e => e.MinimumDepth).HasPrecision(5, 2);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Necrosis).HasPrecision(5, 2);
            entity.Property(e => e.NextReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.NextTreatmentDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.OccurDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.OriginalImage).HasMaxLength(50);
            entity.Property(e => e.OriginalImageMeasurement).HasMaxLength(50);
            entity.Property(e => e.Others).HasPrecision(5, 2);
            entity.Property(e => e.PeriWound).HasMaxLength(50);
            entity.Property(e => e.Perimeter).HasPrecision(5, 2);
            entity.Property(e => e.Rotation).HasPrecision(5, 2);
            entity.Property(e => e.SeenDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Site).HasMaxLength(50);
            entity.Property(e => e.Size).HasPrecision(5, 2);
            entity.Property(e => e.SizeDepth).HasPrecision(5, 2);
            entity.Property(e => e.SizeDepth_Auto).HasPrecision(5, 2);
            entity.Property(e => e.SizeLength).HasPrecision(5, 2);
            entity.Property(e => e.SizeLength_Auto).HasPrecision(5, 2);
            entity.Property(e => e.SizeWidth).HasPrecision(5, 2);
            entity.Property(e => e.SizeWidth_Auto).HasPrecision(5, 2);
            entity.Property(e => e.Slough).HasPrecision(5, 2);
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.SurfaceArea).HasPrecision(5, 2);
            entity.Property(e => e.TCUpdateRemark).HasMaxLength(255);
            entity.Property(e => e.UnderMining).HasMaxLength(255);
            entity.Property(e => e.VisitDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Volume).HasPrecision(5, 2);
            entity.Property(e => e.WoundBedImage).HasMaxLength(50);
            entity.Property(e => e.WoundBedImageMeasurement).HasMaxLength(50);
            entity.Property(e => e.woundOverlaysImage).HasMaxLength(50);
            entity.Property(e => e.woundOverlaysImageDistance).HasPrecision(5, 2);
        });

        modelBuilder.Entity<Audit_PatientWoundReviewBy>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ReviewDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_PatientWoundVisit>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AnnotatedImageMeasurement).HasMaxLength(50);
            entity.Property(e => e.Appearance).HasMaxLength(50);
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.AverageDepth).HasPrecision(8, 2);
            entity.Property(e => e.CleansingSolutionUsed).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DESIGN_R_Depth).HasMaxLength(50);
            entity.Property(e => e.Debridement).HasMaxLength(50);
            entity.Property(e => e.DepthEighty).HasPrecision(5, 2);
            entity.Property(e => e.DepthForty).HasPrecision(5, 2);
            entity.Property(e => e.DepthImage).HasMaxLength(255);
            entity.Property(e => e.DepthImageMeasurement).HasMaxLength(50);
            entity.Property(e => e.DepthMax).HasPrecision(5, 2);
            entity.Property(e => e.DepthNans).HasPrecision(5, 2);
            entity.Property(e => e.DepthNegative).HasPrecision(5, 2);
            entity.Property(e => e.DepthSixty).HasPrecision(5, 2);
            entity.Property(e => e.DepthTwenty).HasPrecision(5, 2);
            entity.Property(e => e.Edges).HasMaxLength(50);
            entity.Property(e => e.Exudate).HasMaxLength(50);
            entity.Property(e => e.ExudateSubInfo).HasMaxLength(50);
            entity.Property(e => e.ExudateSubInfo2).HasMaxLength(50);
            entity.Property(e => e.ImageUpload).HasMaxLength(50);
            entity.Property(e => e.IsDraft).HasDefaultValue(false);
            entity.Property(e => e.MaximumDepth).HasPrecision(5, 2);
            entity.Property(e => e.MeasurementUpdateRemark).HasMaxLength(255);
            entity.Property(e => e.MinimumDepth).HasPrecision(5, 2);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.NextReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.NextTreatmentDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.OriginalImageMeasurement).HasMaxLength(50);
            entity.Property(e => e.PeriWound).HasMaxLength(50);
            entity.Property(e => e.Perimeter).HasPrecision(5, 2);
            entity.Property(e => e.ProgressiveWoundStage).HasMaxLength(50);
            entity.Property(e => e.Rotation).HasPrecision(5, 2);
            entity.Property(e => e.Size).HasPrecision(5, 2);
            entity.Property(e => e.SizeDepth).HasPrecision(5, 2);
            entity.Property(e => e.SizeDepth_Auto).HasPrecision(5, 2);
            entity.Property(e => e.SizeLength).HasPrecision(5, 2);
            entity.Property(e => e.SizeLength_Auto).HasPrecision(5, 2);
            entity.Property(e => e.SizeWidth).HasPrecision(5, 2);
            entity.Property(e => e.SizeWidth_Auto).HasPrecision(5, 2);
            entity.Property(e => e.Smell).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(15);
            entity.Property(e => e.SurfaceArea).HasPrecision(5, 2);
            entity.Property(e => e.TCUpdateRemark).HasMaxLength(255);
            entity.Property(e => e.TC_Auto_Epithelizing).HasPrecision(5, 2);
            entity.Property(e => e.TC_Auto_Granulation).HasPrecision(5, 2);
            entity.Property(e => e.TC_Auto_Necrosis).HasPrecision(5, 2);
            entity.Property(e => e.TC_Auto_Others).HasPrecision(5, 2);
            entity.Property(e => e.TC_Auto_Slough).HasPrecision(5, 2);
            entity.Property(e => e.TC_Epithelizing).HasPrecision(5, 2);
            entity.Property(e => e.TC_Granulation).HasPrecision(5, 2);
            entity.Property(e => e.TC_Necrosis).HasPrecision(5, 2);
            entity.Property(e => e.TC_Others).HasPrecision(5, 2);
            entity.Property(e => e.TC_Slough).HasPrecision(5, 2);
            entity.Property(e => e.Title).HasMaxLength(30);
            entity.Property(e => e.UnderMining).HasMaxLength(255);
            entity.Property(e => e.UnderMiningDepth).HasPrecision(4, 1);
            entity.Property(e => e.VisitDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Volume).HasPrecision(5, 2);
            entity.Property(e => e.WoundBedImageMeasurement).HasMaxLength(50);
            entity.Property(e => e.WoundSubType).HasMaxLength(50);
            entity.Property(e => e.WoundType).HasMaxLength(50);
            entity.Property(e => e.WoundTypeOther).HasMaxLength(50);
            entity.Property(e => e.temperature).HasPrecision(5, 2);
            entity.Property(e => e.woundOverlaysImage).HasMaxLength(50);
            entity.Property(e => e.woundOverlaysImageDistance).HasPrecision(5, 2);
        });

        modelBuilder.Entity<Audit_PatientWoundVisitAppearance>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_PatientWoundVisitCleansingItem>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_PatientWoundVisitClinician>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_PatientWoundVisitTreatment>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_PatientWoundVisitTreatmentList>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Remarks).HasMaxLength(500);
        });

        modelBuilder.Entity<Audit_PatientWoundVisitTreatmentObjectives>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_ProblemList>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ProblemInfo).HasMaxLength(255);
        });

        modelBuilder.Entity<Audit_ProblemListGoal>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.Goal).HasMaxLength(500);
        });

        modelBuilder.Entity<Audit_Receipt>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.GroupNumber).HasMaxLength(10);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ReceiptDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ReceiptNumber).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalAmt).HasPrecision(18, 2);
        });

        modelBuilder.Entity<Audit_ReceiptForInvoice>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Amt).HasPrecision(18, 2);
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_RegisteredDevice>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.DeviceToken).HasMaxLength(300);
        });

        modelBuilder.Entity<Audit_RegisteredDeviceV2>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AppName).HasMaxLength(50);
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DeviceId).HasMaxLength(255);
            entity.Property(e => e.DeviceName).HasMaxLength(255);
            entity.Property(e => e.DeviceToken).HasMaxLength(255);
            entity.Property(e => e.DeviceType).HasMaxLength(255);
            entity.Property(e => e.FirstRegisterIpAddress).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Version).HasMaxLength(50);
        });

        modelBuilder.Entity<Audit_ResidentAssessmentCategory>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.Category1Description).HasMaxLength(500);
            entity.Property(e => e.Category1Recommendation).HasMaxLength(500);
            entity.Property(e => e.Category2Description).HasMaxLength(500);
            entity.Property(e => e.Category2Recommendation).HasMaxLength(500);
            entity.Property(e => e.Category3Description).HasMaxLength(500);
            entity.Property(e => e.Category3Recommendation).HasMaxLength(500);
            entity.Property(e => e.Category4Description).HasMaxLength(500);
            entity.Property(e => e.Category4Recommendation).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_Role>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.DateCreated).HasColumnType("timestamp without time zone");
            entity.Property(e => e.OptionText).HasMaxLength(250);
            entity.Property(e => e.OptionType).HasMaxLength(1);
            entity.Property(e => e.OptionValue).HasMaxLength(250);
            entity.Property(e => e.RoleDescription).HasMaxLength(250);
        });

        modelBuilder.Entity<Audit_ScheduledTasks>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.IntervalType).HasMaxLength(1);
            entity.Property(e => e.LastRun).HasColumnType("timestamp without time zone");
            entity.Property(e => e.NextRun).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PerformTask).HasMaxLength(1);
            entity.Property(e => e.ScheduleDescription).HasMaxLength(200);
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status).HasMaxLength(1);
            entity.Property(e => e.TimeEnd).HasColumnType("timestamp without time zone");
            entity.Property(e => e.TimeStart).HasColumnType("timestamp without time zone");
            entity.Property(e => e.WeekDays).HasMaxLength(10);
        });

        modelBuilder.Entity<Audit_ServiceForBilling>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Duration1).HasMaxLength(50);
            entity.Property(e => e.Duration2).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Audit_ServiceForBillingCost>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UnitCost).HasPrecision(18, 2);
        });

        modelBuilder.Entity<Audit_ServiceSkillset>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_SyncPatientLog>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_SyncWoundLog>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_SyncWoundVisitLog>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_SysConfig>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.ConfigName).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_SystemForDisease>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.System).HasMaxLength(255);
        });

        modelBuilder.Entity<Audit_TD_WoundAssessmentFactor>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_Task>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.EndDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.H2OFlushingMLS).HasPrecision(4);
            entity.Property(e => e.Location).HasMaxLength(800);
            entity.Property(e => e.MedicationInstructions).HasMaxLength(255);
            entity.Property(e => e.MilkFeedVolumeMLS).HasPrecision(4);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.OtherLocation).HasMaxLength(800);
            entity.Property(e => e.ReferenceType).HasMaxLength(30);
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Supplement).HasMaxLength(255);
        });

        modelBuilder.Entity<Audit_TaskFileAttachment>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.FileName).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_TaskServicesRequired>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_TaskSpecificDate>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.TaskDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_TaskUser>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UserType).HasMaxLength(20);
        });

        modelBuilder.Entity<Audit_TaskUserLog>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EndDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.StatusDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_TaskUserLogAttachment>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.FileName).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_TeleconsultationRecording>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EndTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Sid)
                .HasMaxLength(36)
                .IsFixedLength();
            entity.Property(e => e.StartTime).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_TeleconsultationReport>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status).HasMaxLength(15);
        });

        modelBuilder.Entity<Audit_Thresholds>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.createdDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ews_max_1).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_2).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_3).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_4).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_5).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_6).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_7).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_1).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_2).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_3).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_4).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_5).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_6).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_7).HasPrecision(18, 2);
            entity.Property(e => e.maxValue).HasPrecision(18, 2);
            entity.Property(e => e.minValue).HasPrecision(18, 2);
            entity.Property(e => e.name).HasMaxLength(200);
            entity.Property(e => e.updatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_TreatmentListItem>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.Cost).HasPrecision(18, 2);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EndDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ItemBrand).HasMaxLength(255);
            entity.Property(e => e.ItemName).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_TreatmentTOL>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_Types>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.code).HasMaxLength(100);
            entity.Property(e => e.codeValue).HasMaxLength(200);
            entity.Property(e => e.created).HasColumnType("timestamp without time zone");
            entity.Property(e => e.parentCode).HasMaxLength(100);
            entity.Property(e => e.updated).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_UploadFile>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.FileName).HasMaxLength(100);
            entity.Property(e => e.FileType).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_UserAddress>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Address1).HasMaxLength(255);
            entity.Property(e => e.Address2).HasMaxLength(255);
            entity.Property(e => e.Address3).HasMaxLength(255);
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PostalCode).HasMaxLength(255);
        });

        modelBuilder.Entity<Audit_UserBranch>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_UserCategory>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UserCategory).HasMaxLength(50);
        });

        modelBuilder.Entity<Audit_UserCategoryRole>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_UserLanguage>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_UserOrganization>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_UserRole>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        modelBuilder.Entity<Audit_UserSkillset>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_UserType>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ManpowerRate).HasPrecision(18, 2);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UserType).HasMaxLength(50);
        });

        modelBuilder.Entity<Audit_UserUserType>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_Users>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.Contact).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Designation).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.HasValidEmail).HasDefaultValue(true);
            entity.Property(e => e.LastActivityDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.LastLockoutDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.LastLoginDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.LastLogoutDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.LastPasswordChangedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.LocationNow1).HasMaxLength(255);
            entity.Property(e => e.LocationNow2).HasMaxLength(255);
            entity.Property(e => e.LocationNow3).HasMaxLength(255);
            entity.Property(e => e.LocationNowModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Photo).HasMaxLength(50);
            entity.Property(e => e.PostalCodeNow).HasMaxLength(10);
            entity.Property(e => e.PreviousPasswords).HasMaxLength(1000);
            entity.Property(e => e.PreviousPasswords2).HasMaxLength(100);
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.SessionKey).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(15);
            entity.Property(e => e.TokenID).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(60);
        });

        modelBuilder.Entity<Audit_VitalSignDetails>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.detailValue).HasPrecision(18, 2);
        });

        modelBuilder.Entity<Audit_VitalSignRelationships>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
        });

        modelBuilder.Entity<Audit_VitalSignTypeThreshold>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ews_max_1).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_2).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_3).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_4).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_5).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_6).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_7).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_1).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_2).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_3).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_4).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_5).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_6).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_7).HasPrecision(18, 2);
        });

        modelBuilder.Entity<Audit_VitalSignTypes>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.createdDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.name).HasMaxLength(200);
            entity.Property(e => e.updatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_VitalSigns>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.createdDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.source).HasMaxLength(200);
            entity.Property(e => e.updatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Audit_WoundConsolidatedEmail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ActionTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AuditAction).HasMaxLength(5);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<BillingInvoice>(entity =>
        {
            entity.HasIndex(e => e.CareReportID_FK, "IX_BillingInvoice_CareReportID_FK");

            entity.HasIndex(e => e.CreatedBy_FK, "IX_BillingInvoice_CreatedBy_FK");

            entity.HasIndex(e => e.CurrencyID_FK, "IX_BillingInvoice_CurrencyID_FK");

            entity.HasIndex(e => e.ModifiedBy_FK, "IX_BillingInvoice_ModifiedBy_FK");

            entity.HasIndex(e => e.PatientID_FK, "IX_BillingInvoice_PatientID_FK");

            entity.Property(e => e.CaseNumber).HasMaxLength(20);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.GroupNumber).HasMaxLength(10);
            entity.Property(e => e.InvoiceDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.InvoiceDueDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.InvoiceNumber).HasMaxLength(20);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status).HasMaxLength(15);
            entity.Property(e => e.TotalCost).HasPrecision(18, 2);

            entity.HasOne(d => d.CareReportID_FKNavigation).WithMany(p => p.BillingInvoice)
                .HasForeignKey(d => d.CareReportID_FK)
                .HasConstraintName("FK_BillingInvoice_CareReport");

            entity.HasOne(d => d.CreatedBy_FKNavigation).WithMany(p => p.BillingInvoiceCreatedBy_FKNavigation)
                .HasForeignKey(d => d.CreatedBy_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingInvoice_Users");

            entity.HasOne(d => d.CurrencyID_FKNavigation).WithMany(p => p.BillingInvoice)
                .HasForeignKey(d => d.CurrencyID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingInvoice_Code");

            entity.HasOne(d => d.ModifiedBy_FKNavigation).WithMany(p => p.BillingInvoiceModifiedBy_FKNavigation)
                .HasForeignKey(d => d.ModifiedBy_FK)
                .HasConstraintName("FK_BillingInvoice_Users1");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.BillingInvoice)
                .HasForeignKey(d => d.PatientID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingInvoice_Patient");
        });

        modelBuilder.Entity<BillingInvoiceConsumable>(entity =>
        {
            entity.HasIndex(e => e.BillingInvoiceID_FK, "IX_BillingInvoiceConsumable_BillingInvoiceID_FK");

            entity.HasIndex(e => e.ItemID_FK, "IX_BillingInvoiceConsumable_ItemID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UnitPrice).HasPrecision(18, 2);

            entity.HasOne(d => d.BillingInvoiceID_FKNavigation).WithMany(p => p.BillingInvoiceConsumable)
                .HasForeignKey(d => d.BillingInvoiceID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingInvoiceConsumable_BillingInvoice");

            entity.HasOne(d => d.ItemID_FKNavigation).WithMany(p => p.BillingInvoiceConsumable)
                .HasForeignKey(d => d.ItemID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingInvoiceConsumable_Item");
        });

        modelBuilder.Entity<BillingInvoiceService>(entity =>
        {
            entity.HasIndex(e => e.BillingInvoiceID_FK, "IX_BillingInvoiceService_BillingInvoiceID_FK");

            entity.HasIndex(e => e.ProposalID_FK, "IX_BillingInvoiceService_ProposalID_FK");

            entity.HasIndex(e => e.ServiceID_FK, "IX_BillingInvoiceService_ServiceID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Discount).HasPrecision(18, 2);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UnitCost).HasPrecision(18, 2);

            entity.HasOne(d => d.BillingInvoiceID_FKNavigation).WithMany(p => p.BillingInvoiceService)
                .HasForeignKey(d => d.BillingInvoiceID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingInvoiceService_BillingInvoice");

            entity.HasOne(d => d.ProposalID_FKNavigation).WithMany(p => p.BillingInvoiceService)
                .HasForeignKey(d => d.ProposalID_FK)
                .HasConstraintName("FK_BillingInvoiceService_BillingProposal");

            entity.HasOne(d => d.ServiceID_FKNavigation).WithMany(p => p.BillingInvoiceService)
                .HasForeignKey(d => d.ServiceID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingInvoiceService_ServiceForBilling");
        });

        modelBuilder.Entity<BillingPackage>(entity =>
        {
            entity.HasIndex(e => e.BillingServiceID, "IX_BillingPackage_BillingServiceID");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.TotalPrice).HasPrecision(18);
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.UnitPrice).HasPrecision(18);

            entity.HasOne(d => d.BillingService).WithMany(p => p.BillingPackage)
                .HasForeignKey(d => d.BillingServiceID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingPackage_BillingService");
        });

        modelBuilder.Entity<BillingPackageInformation>(entity =>
        {
            entity.HasKey(e => new { e.BillingPackageID, e.BillingServiceID });

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<BillingPackageRequest>(entity =>
        {
            entity.HasKey(e => e.PackageRequestID).HasName("PK_PackageRequestID");

            entity.Property(e => e.BillingAddress1).HasMaxLength(255);
            entity.Property(e => e.BillingAddress2).HasMaxLength(255);
            entity.Property(e => e.BillingAddress3).HasMaxLength(255);
            entity.Property(e => e.BillingPostalCode)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DiscountAmt).HasPrecision(18, 2);
            entity.Property(e => e.DiscountPercentage).HasPrecision(18, 2);
            entity.Property(e => e.DiscountType).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PackageList).HasMaxLength(50);
            entity.Property(e => e.PackageRequestNo).HasMaxLength(255);
            entity.Property(e => e.PatientName).HasMaxLength(100);
            entity.Property(e => e.SendBillTo).HasMaxLength(10);
            entity.Property(e => e.TotalPackageAmount).HasPrecision(18, 2);
        });

        modelBuilder.Entity<BillingProposal>(entity =>
        {
            entity.HasIndex(e => e.CreatedBy_FK, "IX_BillingProposal_CreatedBy_FK");

            entity.HasIndex(e => e.CurrencyID_FK, "IX_BillingProposal_CurrencyID_FK");

            entity.HasIndex(e => e.ModifiedBy_FK, "IX_BillingProposal_ModifiedBy_FK");

            entity.HasIndex(e => e.PatientID_FK, "IX_BillingProposal_PatientID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.GroupNumber).HasMaxLength(10);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ProposalNumber).HasMaxLength(20);
            entity.Property(e => e.ProposalType).HasMaxLength(15);
            entity.Property(e => e.Status).HasMaxLength(15);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.TotalCost).HasPrecision(18, 2);

            entity.HasOne(d => d.CreatedBy_FKNavigation).WithMany(p => p.BillingProposalCreatedBy_FKNavigation)
                .HasForeignKey(d => d.CreatedBy_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingProposal_Users");

            entity.HasOne(d => d.CurrencyID_FKNavigation).WithMany(p => p.BillingProposal)
                .HasForeignKey(d => d.CurrencyID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingProposal_Code");

            entity.HasOne(d => d.ModifiedBy_FKNavigation).WithMany(p => p.BillingProposalModifiedBy_FKNavigation)
                .HasForeignKey(d => d.ModifiedBy_FK)
                .HasConstraintName("FK_BillingProposal_Users1");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.BillingProposal)
                .HasForeignKey(d => d.PatientID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingProposal_Patient");
        });

        modelBuilder.Entity<BillingProposalService>(entity =>
        {
            entity.HasIndex(e => e.BillingProposalID_FK, "IX_BillingProposalService_BillingProposalID_FK");

            entity.HasIndex(e => e.ServiceID_FK, "IX_BillingProposalService_ServiceID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Discount).HasPrecision(18, 2);
            entity.Property(e => e.Duration1).HasMaxLength(50);
            entity.Property(e => e.Duration2).HasMaxLength(50);
            entity.Property(e => e.EndDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UnitCost).HasPrecision(18, 2);

            entity.HasOne(d => d.BillingProposalID_FKNavigation).WithMany(p => p.BillingProposalService)
                .HasForeignKey(d => d.BillingProposalID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingProposalService_BillingProposal");

            entity.HasOne(d => d.ServiceID_FKNavigation).WithMany(p => p.BillingProposalService)
                .HasForeignKey(d => d.ServiceID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingProposalService_ServiceForBilling");
        });

        modelBuilder.Entity<BillingService>(entity =>
        {
            entity.HasKey(e => e.ServiceID).HasName("PK_ServiceID");

            entity.HasIndex(e => e.CategoryID_FK, "IX_BillingService_CategoryID_FK");

            entity.Property(e => e.CostPerSession).HasPrecision(18, 2);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status).HasMaxLength(15);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.CategoryID_FKNavigation).WithMany(p => p.BillingService)
                .HasForeignKey(d => d.CategoryID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingService_Code");
        });

        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasIndex(e => e.CurrencyID_FK, "IX_Branch_CurrencyID_FK");

            entity.Property(e => e.Address1).HasMaxLength(255);
            entity.Property(e => e.Address2).HasMaxLength(255);
            entity.Property(e => e.Address3).HasMaxLength(255);
            entity.Property(e => e.BranchName).HasMaxLength(255);
            entity.Property(e => e.Contact).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status).HasMaxLength(10);

            entity.HasOne(d => d.CurrencyID_FKNavigation).WithMany(p => p.Branch)
                .HasForeignKey(d => d.CurrencyID_FK)
                .HasConstraintName("FK_Branch_Code");
        });

        modelBuilder.Entity<C4WDeviceToken>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<C4WImage>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<CPGoals>(entity =>
        {
            entity.HasIndex(e => e.DiseaseID_FK, "IX_CPGoals_DiseaseID_FK");

            entity.Property(e => e.CPGoalsInfo).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.DiseaseID_FKNavigation).WithMany(p => p.CPGoals)
                .HasForeignKey(d => d.DiseaseID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CPGoals_Disease");
        });

        modelBuilder.Entity<CarePlan>(entity =>
        {
            entity.HasIndex(e => e.CarePlanStatusID_FK, "IX_CarePlan_CarePlanStatusID_FK");

            entity.HasIndex(e => e.DiagnosisID_FK, "IX_CarePlan_DiagnosisID_FK");

            entity.HasIndex(e => e.PatientID_FK, "IX_CarePlan_PatientID_FK");

            entity.Property(e => e.CarePlanName).HasMaxLength(50);
            entity.Property(e => e.CarePlanType).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Remark).HasMaxLength(500);

            entity.HasOne(d => d.CarePlanStatusID_FKNavigation).WithMany(p => p.CarePlan)
                .HasForeignKey(d => d.CarePlanStatusID_FK)
                .HasConstraintName("FK_CarePlan_CarePlanStatus");

            entity.HasOne(d => d.DiagnosisID_FKNavigation).WithMany(p => p.CarePlan)
                .HasForeignKey(d => d.DiagnosisID_FK)
                .HasConstraintName("FK_CarePlan_Diagnosis");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.CarePlan)
                .HasForeignKey(d => d.PatientID_FK)
                .HasConstraintName("FK_CarePlan_Patient");
        });

        modelBuilder.Entity<CarePlanDetail>(entity =>
        {
            entity.HasKey(e => e.CarePlanDetailID).HasName("PK_CarePlanDetail_");

            entity.HasIndex(e => e.CarePlanSubID_FK, "IX_CarePlanDetail_CarePlanSubID_FK");

            entity.HasIndex(e => e.DiseaseID_FK, "IX_CarePlanDetail_DiseaseID_FK");

            entity.HasIndex(e => e.SystemID_FK, "IX_CarePlanDetail_SystemID_FK");

            entity.HasOne(d => d.CarePlanSubID_FKNavigation).WithMany(p => p.CarePlanDetail)
                .HasForeignKey(d => d.CarePlanSubID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarePlanDetail_CarePlanSub");

            entity.HasOne(d => d.DiseaseID_FKNavigation).WithMany(p => p.CarePlanDetail)
                .HasForeignKey(d => d.DiseaseID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarePlanDetail_DiseaseForDisease");

            entity.HasOne(d => d.SystemID_FKNavigation).WithMany(p => p.CarePlanDetail)
                .HasForeignKey(d => d.SystemID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarePlanDetail_SystemForDisease");
        });

        modelBuilder.Entity<CarePlanStatus>(entity =>
        {
            entity.Property(e => e.CarePlanStatusID).ValueGeneratedNever();
            entity.Property(e => e.CarePlanStatus1)
                .HasMaxLength(50)
                .HasColumnName("CarePlanStatus");
            entity.Property(e => e.CareReviewFrequency).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<CarePlanSub>(entity =>
        {
            entity.HasKey(e => e.CarePlanSubID).HasName("PK_CarePlanDetail");

            entity.HasIndex(e => e.CarePlanID_FK, "IX_CarePlanSub_CarePlanID_FK");

            entity.Property(e => e.ApprovedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CarePlanGroupName).HasMaxLength(100);
            entity.Property(e => e.Goal).HasMaxLength(500);
            entity.Property(e => e.GoalStatus).HasMaxLength(100);
            entity.Property(e => e.InterventionStatus).HasMaxLength(100);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ReviewDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.CarePlanID_FKNavigation).WithMany(p => p.CarePlanSub)
                .HasForeignKey(d => d.CarePlanID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarePlanSub_CarePlan");
        });

        modelBuilder.Entity<CarePlanSubActivity>(entity =>
        {
            entity.HasKey(e => new { e.CarePlanSubID_FK, e.ActivityID_FK });

            entity.HasIndex(e => e.ActivityID_FK, "IX_CarePlanSubActivity_ActivityID_FK");

            entity.HasOne(d => d.ActivityID_FKNavigation).WithMany(p => p.CarePlanSubActivity)
                .HasForeignKey(d => d.ActivityID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarePlanSubActivity_Activity");

            entity.HasOne(d => d.CarePlanSubID_FKNavigation).WithMany(p => p.CarePlanSubActivity)
                .HasForeignKey(d => d.CarePlanSubID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarePlanSubActivity_CarePlanSub");
        });

        modelBuilder.Entity<CarePlanSubCPGoals>(entity =>
        {
            entity.HasKey(e => new { e.CarePlanSubID_FK, e.CPGoalsID_FK });

            entity.HasIndex(e => e.CPGoalsID_FK, "IX_CarePlanSubCPGoals_CPGoalsID_FK");

            entity.HasOne(d => d.CPGoalsID_FKNavigation).WithMany(p => p.CarePlanSubCPGoals)
                .HasForeignKey(d => d.CPGoalsID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarePlanSubCPGoals_CPGoals");

            entity.HasOne(d => d.CarePlanSubID_FKNavigation).WithMany(p => p.CarePlanSubCPGoals)
                .HasForeignKey(d => d.CarePlanSubID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarePlanSubCPGoals_CarePlanSub");
        });

        modelBuilder.Entity<CarePlanSubGoal>(entity =>
        {
            entity.HasIndex(e => e.CarePlanSubID_FK, "IX_CarePlanSubGoal_CarePlanSubID_FK");

            entity.HasIndex(e => e.DiseaseID_FK, "IX_CarePlanSubGoal_DiseaseID_FK");

            entity.Property(e => e.CarePlanSubGoalName).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Score1).HasPrecision(3);
            entity.Property(e => e.Score2).HasPrecision(3);

            entity.HasOne(d => d.CarePlanSubID_FKNavigation).WithMany(p => p.CarePlanSubGoal)
                .HasForeignKey(d => d.CarePlanSubID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarePlanSubGoal_CarePlanSub");

            entity.HasOne(d => d.DiseaseID_FKNavigation).WithMany(p => p.CarePlanSubGoal)
                .HasForeignKey(d => d.DiseaseID_FK)
                .HasConstraintName("FK_CarePlanSubGoal_Disease");
        });

        modelBuilder.Entity<CarePlanSubIntervention>(entity =>
        {
            entity.HasKey(e => new { e.CarePlanSubID_FK, e.InterventionID_FK });

            entity.HasIndex(e => e.InterventionID_FK, "IX_CarePlanSubIntervention_InterventionID_FK");

            entity.HasOne(d => d.CarePlanSubID_FKNavigation).WithMany(p => p.CarePlanSubIntervention)
                .HasForeignKey(d => d.CarePlanSubID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarePlanSubIntervention_CarePlanSub");

            entity.HasOne(d => d.InterventionID_FKNavigation).WithMany(p => p.CarePlanSubIntervention)
                .HasForeignKey(d => d.InterventionID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarePlanSubIntervention_Intervention");
        });

        modelBuilder.Entity<CarePlanSubProblemList>(entity =>
        {
            entity.HasIndex(e => e.CarePlanSubID_FK, "IX_CarePlanSubProblemList_CarePlanSubID_FK");

            entity.HasIndex(e => e.ProblemListID_FK, "IX_CarePlanSubProblemList_ProblemListID_FK");

            entity.Property(e => e.Goal).HasMaxLength(500);
            entity.Property(e => e.PLReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PLStatus).HasMaxLength(250);

            entity.HasOne(d => d.CarePlanSubID_FKNavigation).WithMany(p => p.CarePlanSubProblemList)
                .HasForeignKey(d => d.CarePlanSubID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarePlanSubProblemList_CarePlanSub");

            entity.HasOne(d => d.ProblemListID_FKNavigation).WithMany(p => p.CarePlanSubProblemList)
                .HasForeignKey(d => d.ProblemListID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarePlanSubProblemList_ProblemList");
        });

        modelBuilder.Entity<CarePlanSubProblemListGoal>(entity =>
        {
            entity.HasIndex(e => e.CarePlanSubProblemListID_FK, "IX_CarePlanSubProblemListGoal_CarePlanSubProblemListID_FK");

            entity.HasIndex(e => e.OperatorID, "IX_CarePlanSubProblemListGoal_OperatorID");

            entity.HasIndex(e => e.ProblemListGoalID_FK, "IX_CarePlanSubProblemListGoal_ProblemListGoalID_FK");

            entity.HasIndex(e => e.ScoreTypeID, "IX_CarePlanSubProblemListGoal_ScoreTypeID");

            entity.Property(e => e.Goal).HasMaxLength(500);
            entity.Property(e => e.Score1).HasPrecision(3);
            entity.Property(e => e.Score2).HasPrecision(3);

            entity.HasOne(d => d.CarePlanSubProblemListID_FKNavigation).WithMany(p => p.CarePlanSubProblemListGoal)
                .HasForeignKey(d => d.CarePlanSubProblemListID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarePlanSubProblemListGoal_CarePlanSubProblemList");

            entity.HasOne(d => d.Operator).WithMany(p => p.CarePlanSubProblemListGoalOperator)
                .HasForeignKey(d => d.OperatorID)
                .HasConstraintName("FK_CarePlanSubProblemListGoal_Operator");

            entity.HasOne(d => d.ProblemListGoalID_FKNavigation).WithMany(p => p.CarePlanSubProblemListGoal)
                .HasForeignKey(d => d.ProblemListGoalID_FK)
                .HasConstraintName("FK_CarePlanSubProblemListGoal_ProblemListGoal");

            entity.HasOne(d => d.ScoreType).WithMany(p => p.CarePlanSubProblemListGoalScoreType)
                .HasForeignKey(d => d.ScoreTypeID)
                .HasConstraintName("FK_CarePlanSubProblemListGoal_ScoreType");
        });

        modelBuilder.Entity<CareReport>(entity =>
        {
            entity.HasIndex(e => e.AirwayBreathingID_FK, "IX_CareReport_AirwayBreathingID_FK");

            entity.HasIndex(e => e.BladderCareID_FK, "IX_CareReport_BladderCareID_FK");

            entity.HasIndex(e => e.BowelCareID_FK, "IX_CareReport_BowelCareID_FK");

            entity.HasIndex(e => e.CapillaryRefillID_FK, "IX_CareReport_CapillaryRefillID_FK");

            entity.HasIndex(e => e.CarePlanID_FK, "IX_CareReport_CarePlanID_FK");

            entity.HasIndex(e => e.CareReportID_FK, "IX_CareReport_CareReportID_FK");

            entity.HasIndex(e => e.CareReportRehabilitationID_FK, "IX_CareReport_CareReportRehabilitationID_FK");

            entity.HasIndex(e => e.CareReportSystemInfoID_FK, "IX_CareReport_CareReportSystemInfoID_FK");

            entity.HasIndex(e => e.CirculationID_FK, "IX_CareReport_CirculationID_FK");

            entity.HasIndex(e => e.CoughID_FK, "IX_CareReport_CoughID_FK");

            entity.HasIndex(e => e.DiapersID_FK, "IX_CareReport_DiapersID_FK");

            entity.HasIndex(e => e.LipsID_FK, "IX_CareReport_LipsID_FK");

            entity.HasIndex(e => e.LowerEyelidsID_FK, "IX_CareReport_LowerEyelidsID_FK");

            entity.HasIndex(e => e.O2AidID_FK, "IX_CareReport_O2AidID_FK");

            entity.HasIndex(e => e.PainDescriptionID_FK, "IX_CareReport_PainDescriptionID_FK");

            entity.HasIndex(e => e.PatientID_FK, "IX_CareReport_PatientID_FK");

            entity.HasIndex(e => e.PatientNutritionID_FK, "IX_CareReport_PatientNutritionID_FK");

            entity.HasIndex(e => e.PeripheralPulsesPedalID_FK, "IX_CareReport_PeripheralPulsesPedalID_FK");

            entity.HasIndex(e => e.PeripheralPulsesRadialID_FK, "IX_CareReport_PeripheralPulsesRadialID_FK");

            entity.HasIndex(e => e.SleepRestID_FK, "IX_CareReport_SleepRestID_FK");

            entity.HasIndex(e => e.TemperatureID_FK, "IX_CareReport_TemperatureID_FK");

            entity.HasIndex(e => e.VisitedBy_FK, "IX_CareReport_VisitedBy_FK");

            entity.HasIndex(e => e.VitalSignID_FK, "IX_CareReport_VitalSignID_FK");

            entity.Property(e => e.ACP_DoneDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ACP_ReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AggravatingFactor).HasMaxLength(255);
            entity.Property(e => e.AirwayBreathingRemarks).HasMaxLength(500);
            entity.Property(e => e.BladderCareRemarks).HasMaxLength(500);
            entity.Property(e => e.BowelInterventions).HasMaxLength(500);
            entity.Property(e => e.BowelRemarks).HasMaxLength(500);
            entity.Property(e => e.BowelSounds).HasMaxLength(100);
            entity.Property(e => e.BreathSounds).HasMaxLength(100);
            entity.Property(e => e.CareReportType).HasMaxLength(30);
            entity.Property(e => e.CharacteristicOfUrine).HasMaxLength(500);
            entity.Property(e => e.CirculationRemarks).HasMaxLength(500);
            entity.Property(e => e.Color).HasMaxLength(30);
            entity.Property(e => e.ColorOthers).HasMaxLength(30);
            entity.Property(e => e.Consistency).HasMaxLength(30);
            entity.Property(e => e.CoughAmount).HasMaxLength(30);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DayNightReversal).HasMaxLength(5);
            entity.Property(e => e.Dysuria).HasMaxLength(5);
            entity.Property(e => e.Environment).HasMaxLength(2000);
            entity.Property(e => e.EnvironmentRemarks).HasMaxLength(500);
            entity.Property(e => e.Frequency).HasMaxLength(30);
            entity.Property(e => e.HeartSounds).HasMaxLength(100);
            entity.Property(e => e.LeftEyeReaction).HasMaxLength(30);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Nebuliser).HasMaxLength(1000);
            entity.Property(e => e.NeuroRemarks).HasMaxLength(500);
            entity.Property(e => e.O2Litres).HasPrecision(4, 1);
            entity.Property(e => e.O2LitresPercent).HasPrecision(3);
            entity.Property(e => e.OtherTreatment).HasMaxLength(2000);
            entity.Property(e => e.OtherTreatmentOther).HasMaxLength(255);
            entity.Property(e => e.OtherTreatmentRemarks).HasMaxLength(500);
            entity.Property(e => e.Pain).HasMaxLength(10);
            entity.Property(e => e.PainRemarks).HasMaxLength(500);
            entity.Property(e => e.PainScaleType).HasMaxLength(30);
            entity.Property(e => e.PersonalHygiene).HasMaxLength(2000);
            entity.Property(e => e.PersonalHygieneRemarks).HasMaxLength(500);
            entity.Property(e => e.PsychoEmotionalSpiritual).HasMaxLength(1000);
            entity.Property(e => e.PsychoRemarks).HasMaxLength(500);
            entity.Property(e => e.RelievingFactor).HasMaxLength(255);
            entity.Property(e => e.RightEyeReaction).HasMaxLength(30);
            entity.Property(e => e.SectionRequireInput).HasMaxLength(30);
            entity.Property(e => e.SectionRequired).HasMaxLength(30);
            entity.Property(e => e.SectionStatus).HasMaxLength(30);
            entity.Property(e => e.SiteOfPain).HasMaxLength(255);
            entity.Property(e => e.SkinAndWoundCare).HasMaxLength(2000);
            entity.Property(e => e.SleepRestRemarks).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.Stoma).HasMaxLength(5);
            entity.Property(e => e.StomaAmountOfOutput).HasMaxLength(50);
            entity.Property(e => e.StomaAppearance).HasMaxLength(20);
            entity.Property(e => e.StomaColour).HasMaxLength(20);
            entity.Property(e => e.StomaCreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StomaEffluent).HasMaxLength(50);
            entity.Property(e => e.StomaOstomyProductUsed).HasMaxLength(500);
            entity.Property(e => e.StomaPeristomalSkin).HasMaxLength(20);
            entity.Property(e => e.StomaProtrusion).HasMaxLength(50);
            entity.Property(e => e.StomaReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StomaSizeBreath).HasPrecision(4, 2);
            entity.Property(e => e.StomaSizeLength).HasPrecision(4, 2);
            entity.Property(e => e.Subject).HasMaxLength(50);
            entity.Property(e => e.Sunction).HasMaxLength(5);
            entity.Property(e => e.TemperatureInterventions).HasMaxLength(100);
            entity.Property(e => e.TemperatureRemarks).HasMaxLength(500);
            entity.Property(e => e.TypeOfPain).HasMaxLength(30);
            entity.Property(e => e.TypeOfUrine).HasMaxLength(30);
            entity.Property(e => e.VisitEndDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.VisitStartDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.AirwayBreathingID_FKNavigation).WithMany(p => p.CareReportAirwayBreathingID_FKNavigation)
                .HasForeignKey(d => d.AirwayBreathingID_FK)
                .HasConstraintName("FK_CareReport_Code1");

            entity.HasOne(d => d.BladderCareID_FKNavigation).WithMany(p => p.CareReportBladderCareID_FKNavigation)
                .HasForeignKey(d => d.BladderCareID_FK)
                .HasConstraintName("FK_CareReport_Code15");

            entity.HasOne(d => d.BowelCareID_FKNavigation).WithMany(p => p.CareReportBowelCareID_FKNavigation)
                .HasForeignKey(d => d.BowelCareID_FK)
                .HasConstraintName("FK_CareReport_Code14");

            entity.HasOne(d => d.CapillaryRefillID_FKNavigation).WithMany(p => p.CareReportCapillaryRefillID_FKNavigation)
                .HasForeignKey(d => d.CapillaryRefillID_FK)
                .HasConstraintName("FK_CareReport_Code7");

            entity.HasOne(d => d.CarePlanID_FKNavigation).WithMany(p => p.CareReport)
                .HasForeignKey(d => d.CarePlanID_FK)
                .HasConstraintName("FK_CareReport_CarePlan");

            entity.HasOne(d => d.CareReportID_FKNavigation).WithMany(p => p.InverseCareReportID_FKNavigation)
                .HasForeignKey(d => d.CareReportID_FK)
                .HasConstraintName("FK_CareReport_CareReport");

            entity.HasOne(d => d.CareReportRehabilitationID_FKNavigation).WithMany(p => p.CareReport)
                .HasForeignKey(d => d.CareReportRehabilitationID_FK)
                .HasConstraintName("FK_CareReport_CareReportRehabilitation");

            entity.HasOne(d => d.CareReportSystemInfoID_FKNavigation).WithMany(p => p.CareReport)
                .HasForeignKey(d => d.CareReportSystemInfoID_FK)
                .HasConstraintName("FK_CareReport_CareReportSystemInfo");

            entity.HasOne(d => d.CirculationID_FKNavigation).WithMany(p => p.CareReportCirculationID_FKNavigation)
                .HasForeignKey(d => d.CirculationID_FK)
                .HasConstraintName("FK_CareReport_Code4");

            entity.HasOne(d => d.CoughID_FKNavigation).WithMany(p => p.CareReportCoughID_FKNavigation)
                .HasForeignKey(d => d.CoughID_FK)
                .HasConstraintName("FK_CareReport_Code2");

            entity.HasOne(d => d.DiapersID_FKNavigation).WithMany(p => p.CareReportDiapersID_FKNavigation)
                .HasForeignKey(d => d.DiapersID_FK)
                .HasConstraintName("FK_CareReport_Code16");

            entity.HasOne(d => d.LipsID_FKNavigation).WithMany(p => p.CareReportLipsID_FKNavigation)
                .HasForeignKey(d => d.LipsID_FK)
                .HasConstraintName("FK_CareReport_Code6");

            entity.HasOne(d => d.LowerEyelidsID_FKNavigation).WithMany(p => p.CareReportLowerEyelidsID_FKNavigation)
                .HasForeignKey(d => d.LowerEyelidsID_FK)
                .HasConstraintName("FK_CareReport_Code5");

            entity.HasOne(d => d.O2AidID_FKNavigation).WithMany(p => p.CareReportO2AidID_FKNavigation)
                .HasForeignKey(d => d.O2AidID_FK)
                .HasConstraintName("FK_CareReport_Code3");

            entity.HasOne(d => d.PainDescriptionID_FKNavigation).WithMany(p => p.CareReportPainDescriptionID_FKNavigation)
                .HasForeignKey(d => d.PainDescriptionID_FK)
                .HasConstraintName("FK_CareReport_Code");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.CareReport)
                .HasForeignKey(d => d.PatientID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CareReport_Patient");

            entity.HasOne(d => d.PatientNutritionID_FKNavigation).WithMany(p => p.CareReport)
                .HasForeignKey(d => d.PatientNutritionID_FK)
                .HasConstraintName("FK_CareReport_PatientNutrition");

            entity.HasOne(d => d.PeripheralPulsesPedalID_FKNavigation).WithMany(p => p.CareReportPeripheralPulsesPedalID_FKNavigation)
                .HasForeignKey(d => d.PeripheralPulsesPedalID_FK)
                .HasConstraintName("FK_CareReport_Code9");

            entity.HasOne(d => d.PeripheralPulsesRadialID_FKNavigation).WithMany(p => p.CareReportPeripheralPulsesRadialID_FKNavigation)
                .HasForeignKey(d => d.PeripheralPulsesRadialID_FK)
                .HasConstraintName("FK_CareReport_Code8");

            entity.HasOne(d => d.SleepRestID_FKNavigation).WithMany(p => p.CareReportSleepRestID_FKNavigation)
                .HasForeignKey(d => d.SleepRestID_FK)
                .HasConstraintName("FK_CareReport_Code10");

            entity.HasOne(d => d.TemperatureID_FKNavigation).WithMany(p => p.CareReportTemperatureID_FKNavigation)
                .HasForeignKey(d => d.TemperatureID_FK)
                .HasConstraintName("FK_CareReport_Code11");

            entity.HasOne(d => d.VisitedBy_FKNavigation).WithMany(p => p.CareReport)
                .HasForeignKey(d => d.VisitedBy_FK)
                .HasConstraintName("FK_CareReport_Users");

            entity.HasOne(d => d.VitalSignID_FKNavigation).WithMany(p => p.CareReport)
                .HasForeignKey(d => d.VitalSignID_FK)
                .HasConstraintName("FK_CareReport_VitalSigns");
        });

        modelBuilder.Entity<CareReportConfig>(entity =>
        {
            entity.HasIndex(e => e.UserTypeID_FK, "IX_CareReportConfig_UserTypeID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.SectionAccess).HasMaxLength(30);

            entity.HasOne(d => d.UserTypeID_FKNavigation).WithMany(p => p.CareReportConfig)
                .HasForeignKey(d => d.UserTypeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CareReportConfig_UserType");
        });

        modelBuilder.Entity<CareReportRehabilitation>(entity =>
        {
            entity.Property(e => e.ADLAssistanceType).HasMaxLength(30);
            entity.Property(e => e.Bounded).HasMaxLength(30);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DVTType).HasMaxLength(300);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.RehabilitationRemarks).HasMaxLength(500);
            entity.Property(e => e.WalkingAidType).HasMaxLength(30);
        });

        modelBuilder.Entity<CareReportSocialSupport>(entity =>
        {
            entity.HasIndex(e => e.CareReportID_FK, "IX_CareReportSocialSupport_CareReportID_FK");

            entity.HasIndex(e => e.PatientSocialSupportID_FK, "IX_CareReportSocialSupport_PatientSocialSupportID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.CareReportID_FKNavigation).WithMany(p => p.CareReportSocialSupport)
                .HasForeignKey(d => d.CareReportID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CareReportSocialSupport_CareReport");

            entity.HasOne(d => d.PatientSocialSupportID_FKNavigation).WithMany(p => p.CareReportSocialSupport)
                .HasForeignKey(d => d.PatientSocialSupportID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CareReportSocialSupport_PatientSocialSupport");
        });

        modelBuilder.Entity<CareReportSystemInfo>(entity =>
        {
            entity.HasIndex(e => e.KeyPerson1UserID_FK, "IX_CareReportSystemInfo_KeyPerson1UserID_FK");

            entity.HasIndex(e => e.KeyPerson2UserID_FK, "IX_CareReportSystemInfo_KeyPerson2UserID_FK");

            entity.HasIndex(e => e.PrimaryDoctorUserID_FK, "IX_CareReportSystemInfo_PrimaryDoctorUserID_FK");

            entity.HasIndex(e => e.SecondaryDoctorUserID_FK, "IX_CareReportSystemInfo_SecondaryDoctorUserID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PrimaryDoctorName).HasMaxLength(255);
            entity.Property(e => e.SecondaryDoctorName).HasMaxLength(255);

            entity.HasOne(d => d.KeyPerson1UserID_FKNavigation).WithMany(p => p.CareReportSystemInfoKeyPerson1UserID_FKNavigation)
                .HasForeignKey(d => d.KeyPerson1UserID_FK)
                .HasConstraintName("FK_CareReportSystemInfo_Users1");

            entity.HasOne(d => d.KeyPerson2UserID_FKNavigation).WithMany(p => p.CareReportSystemInfoKeyPerson2UserID_FKNavigation)
                .HasForeignKey(d => d.KeyPerson2UserID_FK)
                .HasConstraintName("FK_CareReportSystemInfo_Users2");

            entity.HasOne(d => d.PrimaryDoctorUserID_FKNavigation).WithMany(p => p.CareReportSystemInfoPrimaryDoctorUserID_FKNavigation)
                .HasForeignKey(d => d.PrimaryDoctorUserID_FK)
                .HasConstraintName("FK_CareReportSystemInfo_PatientClinician1");

            entity.HasOne(d => d.SecondaryDoctorUserID_FKNavigation).WithMany(p => p.CareReportSystemInfoSecondaryDoctorUserID_FKNavigation)
                .HasForeignKey(d => d.SecondaryDoctorUserID_FK)
                .HasConstraintName("FK_CareReportSystemInfo_PatientClinician2");
        });

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasIndex(e => e.CreatedBy_FK, "IX_Chat_CreatedBy_FK");

            entity.HasIndex(e => e.ParentID_FK, "IX_Chat_ParentID_FK");

            entity.HasIndex(e => e.PatientID_FK, "IX_Chat_PatientID_FK");

            entity.Property(e => e.Attachment).HasMaxLength(255);
            entity.Property(e => e.Attachment_Physical).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.CreatedBy_FKNavigation).WithMany(p => p.Chat)
                .HasForeignKey(d => d.CreatedBy_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chat_Users");

            entity.HasOne(d => d.ParentID_FKNavigation).WithMany(p => p.InverseParentID_FKNavigation)
                .HasForeignKey(d => d.ParentID_FK)
                .HasConstraintName("FK_Chat_Chat1");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.Chat)
                .HasForeignKey(d => d.PatientID_FK)
                .HasConstraintName("FK_Chat_Patient1");
        });

        modelBuilder.Entity<Code>(entity =>
        {
            entity.HasIndex(e => e.CodeTypeId_FK, "IX_Code_CodeTypeId_FK");

            entity.HasIndex(e => e.MedicationGroupID_FK, "IX_Code_MedicationGroupID_FK");

            entity.Property(e => e.CodeName).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CurrencyCodeA).HasMaxLength(3);
            entity.Property(e => e.CurrencyCodeN).HasMaxLength(3);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Referral_Code).HasMaxLength(3);
            entity.Property(e => e.Status).HasMaxLength(15);

            entity.HasOne(d => d.CodeTypeId_FKNavigation).WithMany(p => p.Code)
                .HasForeignKey(d => d.CodeTypeId_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Code_CodeType");

            entity.HasOne(d => d.MedicationGroupID_FKNavigation).WithMany(p => p.InverseMedicationGroupID_FKNavigation)
                .HasForeignKey(d => d.MedicationGroupID_FK)
                .HasConstraintName("FK_Code_Code");
        });

        modelBuilder.Entity<CodeType>(entity =>
        {
            entity.Property(e => e.CodeTypeName).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Diagnosis>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Diagnosis1)
                .HasMaxLength(255)
                .HasColumnName("Diagnosis");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<DischargeSummaryReport>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DischargeDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.VisitDateEnd).HasColumnType("timestamp without time zone");
            entity.Property(e => e.VisitDateStart).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<DischargeSummaryReportAttachment>(entity =>
        {
            entity.HasIndex(e => e.DischargeSummaryReportID_FK, "IX_DischargeSummaryReportAttachment_DischargeSummaryReportID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Filename).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Physical).HasMaxLength(50);

            entity.HasOne(d => d.DischargeSummaryReportID_FKNavigation).WithMany(p => p.DischargeSummaryReportAttachment)
                .HasForeignKey(d => d.DischargeSummaryReportID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DischargeSummaryReportAttachment_DischargeSummaryReport");
        });

        modelBuilder.Entity<Disease>(entity =>
        {
            entity.HasIndex(e => e.SystemID_FK, "IX_Disease_SystemID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DiseaseCode).HasMaxLength(60);
            entity.Property(e => e.DiseaseName).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.SystemID_FKNavigation).WithMany(p => p.Disease)
                .HasForeignKey(d => d.SystemID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Disease_SystemForDisease");
        });

        modelBuilder.Entity<DiseaseInfo>(entity =>
        {
            entity.HasIndex(e => e.DiseaseID_FK, "IX_DiseaseInfo_DiseaseID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DiseaseInfo1)
                .HasMaxLength(50)
                .HasColumnName("DiseaseInfo");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.DiseaseID_FKNavigation).WithMany(p => p.DiseaseInfo)
                .HasForeignKey(d => d.DiseaseID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiseaseInfo_Disease");
        });

        modelBuilder.Entity<DiseaseSubInfo>(entity =>
        {
            entity.HasIndex(e => e.DiseaseID_FK, "IX_DiseaseSubInfo_DiseaseID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DiseaseSubInfo1)
                .HasMaxLength(50)
                .HasColumnName("DiseaseSubInfo");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.DiseaseID_FKNavigation).WithMany(p => p.DiseaseSubInfo)
                .HasForeignKey(d => d.DiseaseID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiseaseSubInfo_Disease");
        });

        modelBuilder.Entity<DiseaseVitalSignType>(entity =>
        {
            entity.HasIndex(e => e.DiseaseID_FK, "IX_DiseaseVitalSignType_DiseaseID_FK");

            entity.HasIndex(e => e.VitalSignTypeID_FK, "IX_DiseaseVitalSignType_VitalSignTypeID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.DiseaseID_FKNavigation).WithMany(p => p.DiseaseVitalSignType)
                .HasForeignKey(d => d.DiseaseID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiseaseVitalSignType_Disease");

            entity.HasOne(d => d.VitalSignTypeID_FKNavigation).WithMany(p => p.DiseaseVitalSignType)
                .HasForeignKey(d => d.VitalSignTypeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiseaseVitalSignType_VitalSignTypes");
        });

        modelBuilder.Entity<EBASDEPQuestion>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Question).HasMaxLength(255);
        });

        modelBuilder.Entity<EmailLog>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.attachmentName).HasMaxLength(255);
            entity.Property(e => e.description).HasMaxLength(255);
            entity.Property(e => e.msgFrom).HasMaxLength(255);
            entity.Property(e => e.msgFromName).HasMaxLength(255);
            entity.Property(e => e.smtpLogin).HasMaxLength(255);
            entity.Property(e => e.smtpPassword).HasMaxLength(255);
            entity.Property(e => e.smtpPort).HasMaxLength(255);
            entity.Property(e => e.smtpServerAddress).HasMaxLength(255);
        });

        modelBuilder.Entity<Enquiry>(entity =>
        {
            entity.HasIndex(e => e.CareManagerAssignedID_FK, "IX_Enquiry_CareManagerAssignedID_FK");

            entity.HasIndex(e => e.CaregiverAtHomeID_FK, "IX_Enquiry_CaregiverAtHomeID_FK");

            entity.HasIndex(e => e.EnquirySourceID_FK, "IX_Enquiry_EnquirySourceID_FK");

            entity.HasIndex(e => e.GenderID_FK, "IX_Enquiry_GenderID_FK");

            entity.HasIndex(e => e.PreferredLanguageID_FK, "IX_Enquiry_PreferredLanguageID_FK");

            entity.HasIndex(e => e.RaceID_FK, "IX_Enquiry_RaceID_FK");

            entity.HasIndex(e => e.ServicesRequiredID_FK, "IX_Enquiry_ServicesRequiredID_FK");

            entity.HasIndex(e => e.UserOrganizationID_FK, "IX_Enquiry_UserOrganizationID_FK");

            entity.Property(e => e.CaseNumber).HasMaxLength(50);
            entity.Property(e => e.ContactNumberOfCaller).HasMaxLength(20);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DateOfBirth).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EmailOfCaller).HasMaxLength(200);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.IdentificationNumber).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.MedicalHistory).HasMaxLength(500);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.NameOfCaller).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.OrderID).HasMaxLength(60);
            entity.Property(e => e.OtherPreferredLanguage).HasMaxLength(50);
            entity.Property(e => e.OtherRace).HasMaxLength(255);
            entity.Property(e => e.PatientAddress1).HasMaxLength(255);
            entity.Property(e => e.PatientAddress2).HasMaxLength(255);
            entity.Property(e => e.PatientAddress3).HasMaxLength(255);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.PreferredAppointmentDateTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.CareManagerAssignedID_FKNavigation).WithMany(p => p.Enquiry)
                .HasForeignKey(d => d.CareManagerAssignedID_FK)
                .HasConstraintName("FK_Enquiry_Users");

            entity.HasOne(d => d.CaregiverAtHomeID_FKNavigation).WithMany(p => p.EnquiryCaregiverAtHomeID_FKNavigation)
                .HasForeignKey(d => d.CaregiverAtHomeID_FK)
                .HasConstraintName("FK_Enquiry_CaregiverAtHome");

            entity.HasOne(d => d.EnquirySourceID_FKNavigation).WithMany(p => p.EnquiryEnquirySourceID_FKNavigation)
                .HasForeignKey(d => d.EnquirySourceID_FK)
                .HasConstraintName("FK_Enquiry_Source");

            entity.HasOne(d => d.GenderID_FKNavigation).WithMany(p => p.EnquiryGenderID_FKNavigation)
                .HasForeignKey(d => d.GenderID_FK)
                .HasConstraintName("FK_Enquiry_Gender");

            entity.HasOne(d => d.PreferredLanguageID_FKNavigation).WithMany(p => p.EnquiryPreferredLanguageID_FKNavigation)
                .HasForeignKey(d => d.PreferredLanguageID_FK)
                .HasConstraintName("FK_Enquiry_PreferredLanguage");

            entity.HasOne(d => d.RaceID_FKNavigation).WithMany(p => p.EnquiryRaceID_FKNavigation)
                .HasForeignKey(d => d.RaceID_FK)
                .HasConstraintName("FK_Enquiry_Race");

            entity.HasOne(d => d.ServicesRequiredID_FKNavigation).WithMany(p => p.EnquiryServicesRequiredID_FKNavigation)
                .HasForeignKey(d => d.ServicesRequiredID_FK)
                .HasConstraintName("FK_Enquiry_ServicesRequired");

            entity.HasOne(d => d.UserOrganizationID_FKNavigation).WithMany(p => p.EnquiryUserOrganizationID_FKNavigation)
                .HasForeignKey(d => d.UserOrganizationID_FK)
                .HasConstraintName("FK_Enquiry_Organization");
        });

        modelBuilder.Entity<EnquiryAttachment>(entity =>
        {
            entity.HasIndex(e => e.EnquiryID_FK, "IX_EnquiryAttachment_EnquiryID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Filename).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Physical).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.EnquiryID_FKNavigation).WithMany(p => p.EnquiryAttachment)
                .HasForeignKey(d => d.EnquiryID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnquiryAttachment_Enquiry");
        });

        modelBuilder.Entity<EnquiryConfig>(entity =>
        {
            entity.HasIndex(e => e.EscalatingPersonID_FK, "IX_EnquiryConfig_EscalatingPersonID_FK");

            entity.HasIndex(e => e.SCMID_FK, "IX_EnquiryConfig_SCMID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EscalationPeriod).HasPrecision(2);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.EscalatingPersonID_FKNavigation).WithMany(p => p.EnquiryConfigEscalatingPersonID_FKNavigation)
                .HasForeignKey(d => d.EscalatingPersonID_FK)
                .HasConstraintName("FK_EnquiryConfig_Users_EscPersonID");

            entity.HasOne(d => d.SCMID_FKNavigation).WithMany(p => p.EnquiryConfigSCMID_FKNavigation)
                .HasForeignKey(d => d.SCMID_FK)
                .HasConstraintName("FK_EnquiryConfig_Users_SCMID");
        });

        modelBuilder.Entity<EnquiryEscPerson>(entity =>
        {
            entity.HasKey(e => new { e.EnquiryConfigID, e.UserID_FK });

            entity.HasIndex(e => e.UserID_FK, "IX_EnquiryEscPerson_UserID_FK");

            entity.HasOne(d => d.EnquiryConfig).WithMany(p => p.EnquiryEscPerson)
                .HasForeignKey(d => d.EnquiryConfigID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnquiryEscPerson_EnquiryConfig");

            entity.HasOne(d => d.UserID_FKNavigation).WithMany(p => p.EnquiryEscPerson)
                .HasForeignKey(d => d.UserID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnquiryEscPerson_Users");
        });

        modelBuilder.Entity<EnquiryLanguage>(entity =>
        {
            entity.HasKey(e => new { e.EnquiryID_FK, e.CodeID_FK });

            entity.HasIndex(e => e.CodeID_FK, "IX_EnquiryLanguage_CodeID_FK");

            entity.HasOne(d => d.CodeID_FKNavigation).WithMany(p => p.EnquiryLanguage)
                .HasForeignKey(d => d.CodeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnquiryLanguage_Code");

            entity.HasOne(d => d.EnquiryID_FKNavigation).WithMany(p => p.EnquiryLanguage)
                .HasForeignKey(d => d.EnquiryID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnquiryLanguage_Enquiry");
        });

        modelBuilder.Entity<EnquirySCM>(entity =>
        {
            entity.HasKey(e => new { e.EnquiryConfigID_FK, e.UserID_FK });

            entity.HasIndex(e => e.UserID_FK, "IX_EnquirySCM_UserID_FK");

            entity.HasOne(d => d.EnquiryConfigID_FKNavigation).WithMany(p => p.EnquirySCM)
                .HasForeignKey(d => d.EnquiryConfigID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnquirySCM_EnquiryConfig");

            entity.HasOne(d => d.UserID_FKNavigation).WithMany(p => p.EnquirySCM)
                .HasForeignKey(d => d.UserID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnquirySCM_Users");
        });

        modelBuilder.Entity<EnquiryServicesRequired>(entity =>
        {
            entity.HasKey(e => new { e.EnquiryID_FK, e.CodeID_FK });

            entity.HasIndex(e => e.CodeID_FK, "IX_EnquiryServicesRequired_CodeID_FK");

            entity.HasOne(d => d.CodeID_FKNavigation).WithMany(p => p.EnquiryServicesRequired)
                .HasForeignKey(d => d.CodeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnquiryServicesRequired_Code");

            entity.HasOne(d => d.EnquiryID_FKNavigation).WithMany(p => p.EnquiryServicesRequired)
                .HasForeignKey(d => d.EnquiryID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnquiryServicesRequired_Enquiry");
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.Property(e => e.DateCreated).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasIndex(e => e.CreatedBy_FK, "IX_Event_CreatedBy_FK");

            entity.HasIndex(e => e.EventTypeID_FK, "IX_Event_EventTypeID_FK");

            entity.HasIndex(e => e.PeriodTypeID_FK, "IX_Event_PeriodTypeID_FK");

            entity.HasIndex(e => e.UserCategory_FK, "IX_Event_UserCategory_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EventName).HasMaxLength(50);
            entity.Property(e => e.FromDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ToDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.CreatedBy_FKNavigation).WithMany(p => p.Event)
                .HasForeignKey(d => d.CreatedBy_FK)
                .HasConstraintName("FK_Event_Users");

            entity.HasOne(d => d.EventTypeID_FKNavigation).WithMany(p => p.EventEventTypeID_FKNavigation)
                .HasForeignKey(d => d.EventTypeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Event_Code1");

            entity.HasOne(d => d.PeriodTypeID_FKNavigation).WithMany(p => p.EventPeriodTypeID_FKNavigation)
                .HasForeignKey(d => d.PeriodTypeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Event_Code2");

            entity.HasOne(d => d.UserCategory_FKNavigation).WithMany(p => p.Event)
                .HasForeignKey(d => d.UserCategory_FK)
                .HasConstraintName("FK_Event_UserCategory");
        });

        modelBuilder.Entity<EventUser>(entity =>
        {
            entity.HasIndex(e => e.EventID_FK, "IX_EventUser_EventID_FK");

            entity.HasIndex(e => e.UserID_FK, "IX_EventUser_UserID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UserType).HasMaxLength(20);

            entity.HasOne(d => d.EventID_FKNavigation).WithMany(p => p.EventUser)
                .HasForeignKey(d => d.EventID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventUser_Event");

            entity.HasOne(d => d.UserID_FKNavigation).WithMany(p => p.EventUser)
                .HasForeignKey(d => d.UserID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventUser_Users");
        });

        modelBuilder.Entity<EventUserLog>(entity =>
        {
            entity.HasIndex(e => e.EventID_FK, "IX_EventUserLog_EventID_FK");

            entity.HasIndex(e => e.UserID_FK, "IX_EventUserLog_UserID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EndDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.EventID_FKNavigation).WithMany(p => p.EventUserLog)
                .HasForeignKey(d => d.EventID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventUserLog_Event");

            entity.HasOne(d => d.UserID_FKNavigation).WithMany(p => p.EventUserLog)
                .HasForeignKey(d => d.UserID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventUserLog_Users");
        });

        modelBuilder.Entity<ExternalDoctor>(entity =>
        {
            entity.HasIndex(e => e.ClinicianTypeID_FK, "IX_ExternalDoctor_ClinicianTypeID_FK");

            entity.Property(e => e.Contact).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.ClinicianTypeID_FKNavigation).WithMany(p => p.ExternalDoctor)
                .HasForeignKey(d => d.ClinicianTypeID_FK)
                .HasConstraintName("FK_ExternalDoctor_UserType");
        });

        modelBuilder.Entity<Facility>(entity =>
        {
            entity.HasIndex(e => e.OrganizationID_FK, "IX_Facility_OrganizationID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.FacilityName).HasMaxLength(255);
            entity.Property(e => e.IntegrationSource).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e._id).HasMaxLength(100);

            entity.HasOne(d => d.OrganizationID_FKNavigation).WithMany(p => p.Facility)
                .HasForeignKey(d => d.OrganizationID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Facility_Code");
        });

        modelBuilder.Entity<GeoFencing>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.IP).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK_GroupUser");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.GroupName).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<GroupRole>(entity =>
        {
            entity.HasKey(e => new { e.GroupId_FK, e.RoleId_FK });

            entity.HasIndex(e => e.RoleId_FK, "IX_GroupRole_RoleId_FK");

            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValueSql("''::character varying");

            entity.HasOne(d => d.GroupId_FKNavigation).WithMany(p => p.GroupRole)
                .HasForeignKey(d => d.GroupId_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupRole_Group");

            entity.HasOne(d => d.RoleId_FKNavigation).WithMany(p => p.GroupRole)
                .HasForeignKey(d => d.RoleId_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupRole_Role");
        });

        modelBuilder.Entity<ICAWoundCare>(entity =>
        {
            entity.HasKey(e => new { e.InitialCareAssessmentID_FK, e.CodeID_FK });

            entity.HasIndex(e => e.CodeID_FK, "IX_ICAWoundCare_CodeID_FK");

            entity.HasOne(d => d.CodeID_FKNavigation).WithMany(p => p.ICAWoundCare)
                .HasForeignKey(d => d.CodeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ICAWoundCare_Code");

            entity.HasOne(d => d.InitialCareAssessmentID_FKNavigation).WithMany(p => p.ICAWoundCare)
                .HasForeignKey(d => d.InitialCareAssessmentID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ICAWoundCare_InitialCareAssessment");
        });

        modelBuilder.Entity<InitialCareAssessment>(entity =>
        {
            entity.HasIndex(e => e.PatientAdditionalInfoID_FK, "IX_InitialCareAssessment_PatientAdditionalInfoID_FK");

            entity.HasIndex(e => e.PatientMBIID_FK, "IX_InitialCareAssessment_PatientMBIID_FK");

            entity.HasIndex(e => e.PatientMFSID_FK, "IX_InitialCareAssessment_PatientMFSID_FK");

            entity.HasIndex(e => e.PatientMedicationID_FK, "IX_InitialCareAssessment_PatientMedicationID_FK");

            entity.HasIndex(e => e.PatientNutritionID_FK, "IX_InitialCareAssessment_PatientNutritionID_FK");

            entity.HasIndex(e => e.PatientProfileID_FK, "IX_InitialCareAssessment_PatientProfileID_FK");

            entity.HasIndex(e => e.PatientRAFID_FK, "IX_InitialCareAssessment_PatientRAFID_FK");

            entity.HasIndex(e => e.PatientReferralID_FK, "IX_InitialCareAssessment_PatientReferralID_FK");

            entity.HasIndex(e => e.VitalSignID_FK, "IX_InitialCareAssessment_VitalSignID_FK");

            entity.Property(e => e.AddressIssue).HasMaxLength(255);
            entity.Property(e => e.AssistiveAids).HasMaxLength(100);
            entity.Property(e => e.BeliefInfluenced).HasMaxLength(255);
            entity.Property(e => e.BowelHabitsDays).HasMaxLength(5);
            entity.Property(e => e.BowelHabitsTimes).HasMaxLength(5);
            entity.Property(e => e.BowelSounds).HasMaxLength(100);
            entity.Property(e => e.BowelType).HasMaxLength(20);
            entity.Property(e => e.BreathSounds).HasMaxLength(100);
            entity.Property(e => e.Breathing).HasMaxLength(20);
            entity.Property(e => e.CAAlertness).HasMaxLength(50);
            entity.Property(e => e.CACommunication).HasMaxLength(50);
            entity.Property(e => e.Catheter).HasMaxLength(5);
            entity.Property(e => e.CatheterDateInserted).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CatheterNextReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CatheterSize).HasMaxLength(10);
            entity.Property(e => e.CatheterType).HasMaxLength(50);
            entity.Property(e => e.Concern).HasMaxLength(255);
            entity.Property(e => e.ConsciousLevel).HasMaxLength(40);
            entity.Property(e => e.Cough).HasMaxLength(20);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DifficultyCopingYes).HasMaxLength(255);
            entity.Property(e => e.EmotionalState).HasMaxLength(20);
            entity.Property(e => e.EmotionalYes).HasMaxLength(255);
            entity.Property(e => e.Faith).HasMaxLength(255);
            entity.Property(e => e.GeneralCondition).HasMaxLength(20);
            entity.Property(e => e.GetSupport).HasMaxLength(255);
            entity.Property(e => e.GiveMeaningToLife).HasMaxLength(255);
            entity.Property(e => e.Hearing).HasMaxLength(50);
            entity.Property(e => e.HearingImpairedRemarks).HasMaxLength(500);
            entity.Property(e => e.HearingImpairedWithHearingAidRemarks).HasMaxLength(500);
            entity.Property(e => e.HomeFacilityRemarks).HasMaxLength(500);
            entity.Property(e => e.HowCanIHelp).HasMaxLength(255);
            entity.Property(e => e.HowDoYouScope).HasMaxLength(255);
            entity.Property(e => e.IncontinenceType).HasMaxLength(20);
            entity.Property(e => e.InfluenceTakeCare).HasMaxLength(255);
            entity.Property(e => e.LMP).HasColumnType("timestamp without time zone");
            entity.Property(e => e.LostInterestYes).HasMaxLength(255);
            entity.Property(e => e.MakeSense).HasMaxLength(255);
            entity.Property(e => e.MedicalHistory).HasMaxLength(1000);
            entity.Property(e => e.MilkFeedRx).HasMaxLength(255);
            entity.Property(e => e.MobilityStatus).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.O2Litres).HasPrecision(3, 1);
            entity.Property(e => e.O2LitresVia).HasMaxLength(40);
            entity.Property(e => e.Oralhealth).HasMaxLength(100);
            entity.Property(e => e.OtherBreathing).HasMaxLength(255);
            entity.Property(e => e.OtherEmotionalState).HasMaxLength(255);
            entity.Property(e => e.OxygenLMin).HasPrecision(5, 2);
            entity.Property(e => e.OxygenRemark).HasMaxLength(255);
            entity.Property(e => e.OxygenType).HasMaxLength(100);
            entity.Property(e => e.Palpation).HasMaxLength(100);
            entity.Property(e => e.Percussion).HasMaxLength(100);
            entity.Property(e => e.PersonalConcern).HasMaxLength(255);
            entity.Property(e => e.Physique).HasMaxLength(20);
            entity.Property(e => e.Remark).HasMaxLength(255);
            entity.Property(e => e.RoleOfBeliefForCommunity).HasMaxLength(255);
            entity.Property(e => e.RoleOfBeliefForInfluence).HasMaxLength(255);
            entity.Property(e => e.SectionStatus).HasMaxLength(30);
            entity.Property(e => e.SkinIssue).HasMaxLength(100);
            entity.Property(e => e.SkinTurgor).HasMaxLength(100);
            entity.Property(e => e.SkinType).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.Stoma).HasMaxLength(5);
            entity.Property(e => e.StomaAmountOfOutput).HasMaxLength(50);
            entity.Property(e => e.StomaAppearance).HasMaxLength(20);
            entity.Property(e => e.StomaColour).HasMaxLength(20);
            entity.Property(e => e.StomaCreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StomaEffluent).HasMaxLength(50);
            entity.Property(e => e.StomaOstomyProductUsed).HasMaxLength(500);
            entity.Property(e => e.StomaPeristomalSkin).HasMaxLength(20);
            entity.Property(e => e.StomaProtrusion).HasMaxLength(50);
            entity.Property(e => e.StomaReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StomaSizeBreath).HasPrecision(4, 2);
            entity.Property(e => e.StomaSizeLength).HasPrecision(4, 2);
            entity.Property(e => e.StoolsType).HasMaxLength(20);
            entity.Property(e => e.SupportTo).HasMaxLength(255);
            entity.Property(e => e.TalkToSomeone).HasMaxLength(255);
            entity.Property(e => e.Teeth).HasMaxLength(100);
            entity.Property(e => e.TenderNGuarding).HasMaxLength(100);
            entity.Property(e => e.TracheostomyDateInserted).HasColumnType("timestamp without time zone");
            entity.Property(e => e.TracheostomyNextReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.TracheostomySize).HasMaxLength(10);
            entity.Property(e => e.TracheostomyType).HasMaxLength(50);
            entity.Property(e => e.UrinaryFrequencyDay).HasMaxLength(5);
            entity.Property(e => e.UrinaryFrequencyTimes).HasMaxLength(5);
            entity.Property(e => e.UrinaryTypes).HasMaxLength(500);
            entity.Property(e => e.UrineColour).HasMaxLength(20);
            entity.Property(e => e.UrineConsistency).HasMaxLength(20);
            entity.Property(e => e.UseOfDrugExplain).HasMaxLength(1000);
            entity.Property(e => e.VSIntermittent).HasMaxLength(20);
            entity.Property(e => e.VSLocation).HasMaxLength(255);
            entity.Property(e => e.VSOnSetDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.VSPainFrequency).HasMaxLength(20);
            entity.Property(e => e.VSPrecipitatingFactors).HasMaxLength(255);
            entity.Property(e => e.VSQuality).HasMaxLength(20);
            entity.Property(e => e.VSRelievingFactors).HasMaxLength(255);
            entity.Property(e => e.Vision).HasMaxLength(20);
            entity.Property(e => e.VisionImpairedCataractRemarks).HasMaxLength(500);
            entity.Property(e => e.VisionImpairedGlaucomaRemarks).HasMaxLength(500);
            entity.Property(e => e.VisionImpairedRemarks).HasMaxLength(500);
            entity.Property(e => e.VisitDateTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.painOnSetDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.PatientAdditionalInfoID_FKNavigation).WithMany(p => p.InitialCareAssessment)
                .HasForeignKey(d => d.PatientAdditionalInfoID_FK)
                .HasConstraintName("FK_InitialCareAssessment_PatientAdditionalInfo");

            entity.HasOne(d => d.PatientMBIID_FKNavigation).WithMany(p => p.InitialCareAssessment)
                .HasForeignKey(d => d.PatientMBIID_FK)
                .HasConstraintName("FK_InitialCareAssessment_PatientMBI");

            entity.HasOne(d => d.PatientMFSID_FKNavigation).WithMany(p => p.InitialCareAssessment)
                .HasForeignKey(d => d.PatientMFSID_FK)
                .HasConstraintName("FK_InitialCareAssessment_PatientMFS");

            entity.HasOne(d => d.PatientMedicationID_FKNavigation).WithMany(p => p.InitialCareAssessment)
                .HasForeignKey(d => d.PatientMedicationID_FK)
                .HasConstraintName("FK_InitialCareAssessment_PatientMedication");

            entity.HasOne(d => d.PatientNutritionID_FKNavigation).WithMany(p => p.InitialCareAssessment)
                .HasForeignKey(d => d.PatientNutritionID_FK)
                .HasConstraintName("FK_InitialCareAssessment_PatientNutrition");

            entity.HasOne(d => d.PatientProfileID_FKNavigation).WithMany(p => p.InitialCareAssessment)
                .HasForeignKey(d => d.PatientProfileID_FK)
                .HasConstraintName("FK_InitialCareAssessment_PatientProfile");

            entity.HasOne(d => d.PatientRAFID_FKNavigation).WithMany(p => p.InitialCareAssessment)
                .HasForeignKey(d => d.PatientRAFID_FK)
                .HasConstraintName("FK_InitialCareAssessment_PatientRAF");

            entity.HasOne(d => d.PatientReferralID_FKNavigation).WithMany(p => p.InitialCareAssessment)
                .HasForeignKey(d => d.PatientReferralID_FK)
                .HasConstraintName("FK_InitialCareAssessment_PatientReferral");

            entity.HasOne(d => d.VitalSignID_FKNavigation).WithMany(p => p.InitialCareAssessment)
                .HasForeignKey(d => d.VitalSignID_FK)
                .HasConstraintName("FK_InitialCareAssessment_VitalSigns");
        });

        modelBuilder.Entity<InitialCareAssessmentAttachment>(entity =>
        {
            entity.HasIndex(e => e.InitialCareAssessmentID_FK, "IX_InitialCareAssessmentAttachment_InitialCareAssessmentID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Filename).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Physical).HasMaxLength(50);

            entity.HasOne(d => d.InitialCareAssessmentID_FKNavigation).WithMany(p => p.InitialCareAssessmentAttachment)
                .HasForeignKey(d => d.InitialCareAssessmentID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InitialCareAssessmentAttachment_InitialCareAssessment");
        });

        modelBuilder.Entity<InitialCareAssessmentSpecialInstruction>(entity =>
        {
            entity.HasIndex(e => e.InitialCareAssessmentID_FK, "IX_InitialCareAssessmentSpecialInstruction_InitialCareAssessme~");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EndDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Instructions).HasMaxLength(500);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.InitialCareAssessmentID_FKNavigation).WithMany(p => p.InitialCareAssessmentSpecialInstruction)
                .HasForeignKey(d => d.InitialCareAssessmentID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InitialCareAssessmentSpecialInstruction_InitialCareAssessmen");
        });

        modelBuilder.Entity<InitialCareAssessmentVitalSign>(entity =>
        {
            entity.HasKey(e => new { e.InitialCareAssessmentID_FK, e.VitalSignID_FK });

            entity.Property(e => e.TimeOfRecord).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<IntegrationApiRequestLog>(entity =>
        {
            entity.HasKey(e => e.IntegrationApiRequestLogID).HasName("PK__Integrat__5749CA7CC431EC3C");

            entity.Property(e => e.FacilityId).HasMaxLength(50);
            entity.Property(e => e.IntegrationSource).HasMaxLength(100);
            entity.Property(e => e.ResidentId).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.Url).HasMaxLength(500);
        });

        modelBuilder.Entity<Intervention>(entity =>
        {
            entity.HasIndex(e => e.DiseaseID_FK, "IX_Intervention_DiseaseID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.InterventionInfo).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.DiseaseID_FKNavigation).WithMany(p => p.Intervention)
                .HasForeignKey(d => d.DiseaseID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Intervention_Disease");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasIndex(e => e.CategoryID_FK, "IX_Item_CategoryID_FK");

            entity.HasIndex(e => e.ItemUnitID_FK, "IX_Item_ItemUnitID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ItemName).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UnitPrice).HasPrecision(18, 2);

            entity.HasOne(d => d.CategoryID_FKNavigation).WithMany(p => p.ItemCategoryID_FKNavigation)
                .HasForeignKey(d => d.CategoryID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_Code");

            entity.HasOne(d => d.ItemUnitID_FKNavigation).WithMany(p => p.ItemItemUnitID_FKNavigation)
                .HasForeignKey(d => d.ItemUnitID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_Code1");
        });

        modelBuilder.Entity<ItemStock>(entity =>
        {
            entity.HasIndex(e => e.ItemID_FK, "IX_ItemStock_ItemID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.ItemID_FKNavigation).WithMany(p => p.ItemStock)
                .HasForeignKey(d => d.ItemID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemStock_Item");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.Property(e => e.FullName).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(500);
        });

        modelBuilder.Entity<LoginDevice>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DeviceID).HasMaxLength(200);
            entity.Property(e => e.DeviceType).HasMaxLength(8);
        });

        modelBuilder.Entity<MailSettings>(entity =>
        {
            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.description).HasMaxLength(255);
            entity.Property(e => e.msgBCC).HasMaxLength(255);
            entity.Property(e => e.msgCC).HasMaxLength(255);
            entity.Property(e => e.msgTo).HasMaxLength(255);
        });

        modelBuilder.Entity<MailSettingsMsgToUserType>(entity =>
        {
            entity.HasKey(e => new { e.MailSetting_FK, e.UserTypeID_FK });

            entity.HasIndex(e => e.UserTypeID_FK, "IX_MailSettingsMsgToUserType_UserTypeID_FK");

            entity.HasOne(d => d.MailSetting_FKNavigation).WithMany(p => p.MailSettingsMsgToUserType)
                .HasForeignKey(d => d.MailSetting_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MailSettingsMsgToUserType_id");

            entity.HasOne(d => d.UserTypeID_FKNavigation).WithMany(p => p.MailSettingsMsgToUserType)
                .HasForeignKey(d => d.UserTypeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MailSettingsMsgToUserType_UserType");
        });

        modelBuilder.Entity<MedicationVitalSignType>(entity =>
        {
            entity.HasIndex(e => e.MedicationID_FK, "IX_MedicationVitalSignType_MedicationID_FK");

            entity.HasIndex(e => e.VitalSignTypeID_FK, "IX_MedicationVitalSignType_VitalSignTypeID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.MedicationID_FKNavigation).WithMany(p => p.MedicationVitalSignType)
                .HasForeignKey(d => d.MedicationID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MedicationVitalSignType_Code");

            entity.HasOne(d => d.VitalSignTypeID_FKNavigation).WithMany(p => p.MedicationVitalSignType)
                .HasForeignKey(d => d.VitalSignTypeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MedicationVitalSignType_VitalSignTypes");
        });

        modelBuilder.Entity<MobileAppVersioning>(entity =>
        {
            entity.HasKey(e => e.MobileVersionId);

            entity.HasIndex(e => e.CreatedBy_FK, "IX_MobileAppVersioning_CreatedBy_FK");

            entity.HasIndex(e => e.ModifiedBy_FK, "IX_MobileAppVersioning_ModifiedBy_FK");

            entity.Property(e => e.AppName).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DeviceType).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Version).HasMaxLength(50);

            entity.HasOne(d => d.CreatedBy_FKNavigation).WithMany(p => p.MobileAppVersioningCreatedBy_FKNavigation)
                .HasForeignKey(d => d.CreatedBy_FK)
                .HasConstraintName("FK_MobileAppVersioning_User_CreatedBy");

            entity.HasOne(d => d.ModifiedBy_FKNavigation).WithMany(p => p.MobileAppVersioningModifiedBy_FKNavigation)
                .HasForeignKey(d => d.ModifiedBy_FK)
                .HasConstraintName("FK_MobileAppVersioning_User_ModifiedBy");
        });

        modelBuilder.Entity<MultiDisciplinaryMeeting>(entity =>
        {
            entity.HasIndex(e => e.PatientID_FK, "IX_MultiDisciplinaryMeeting_PatientID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.MultiDisciplinaryMeeting)
                .HasForeignKey(d => d.PatientID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MultiDisciplinaryMeeting_Patient");
        });

        modelBuilder.Entity<MultiDisciplinaryMeetingDetail>(entity =>
        {
            entity.HasIndex(e => e.MultiDisciplinaryMeetingID_FK, "IX_MultiDisciplinaryMeetingDetail_MultiDisciplinaryMeetingID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.MultiDisciplinaryMeetingID_FKNavigation).WithMany(p => p.MultiDisciplinaryMeetingDetail)
                .HasForeignKey(d => d.MultiDisciplinaryMeetingID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MultiDisciplinaryMeetingDetail_MultiDisciplinaryMeeting");
        });

        modelBuilder.Entity<NotificationChat>(entity =>
        {
            entity.HasIndex(e => e.ChatID_FK, "IX_NotificationChat_ChatID_FK");

            entity.HasIndex(e => e.NotificationId_FK, "IX_NotificationChat_NotificationId_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.ChatID_FKNavigation).WithMany(p => p.NotificationChat)
                .HasForeignKey(d => d.ChatID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationChat_Chat");

            entity.HasOne(d => d.NotificationId_FKNavigation).WithMany(p => p.NotificationChat)
                .HasForeignKey(d => d.NotificationId_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationChat_Notifications");
        });

        modelBuilder.Entity<NotificationEvent>(entity =>
        {
            entity.HasIndex(e => e.EventID_FK, "IX_NotificationEvent_EventID_FK");

            entity.HasIndex(e => e.NotificationId_FK, "IX_NotificationEvent_NotificationId_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.EventID_FKNavigation).WithMany(p => p.NotificationEvent)
                .HasForeignKey(d => d.EventID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationEvent_Event");

            entity.HasOne(d => d.NotificationId_FKNavigation).WithMany(p => p.NotificationEvent)
                .HasForeignKey(d => d.NotificationId_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationEvent_Notifications");
        });

        modelBuilder.Entity<NotificationMessageTemplates>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Notifica__3213E83FC46BAAC6");

            entity.HasIndex(e => e.notificationgroupCode, "idx_NotificationMessageTemplates1");

            entity.Property(e => e.createdDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.notificationMessage).HasMaxLength(500);
            entity.Property(e => e.notificationSubject).HasMaxLength(200);
            entity.Property(e => e.notificationgroupCode).HasMaxLength(100);
            entity.Property(e => e.updatedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.notificationgroupCodeNavigation).WithMany(p => p.NotificationMessageTemplates)
                .HasForeignKey(d => d.notificationgroupCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_NotificationMessageTemplates_notificationgroupCode");
        });

        modelBuilder.Entity<NotificationTask>(entity =>
        {
            entity.HasIndex(e => e.NotificationId_FK, "IX_NotificationTask_NotificationId_FK");

            entity.HasIndex(e => e.TaskID_FK, "IX_NotificationTask_TaskID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.NotificationId_FKNavigation).WithMany(p => p.NotificationTask)
                .HasForeignKey(d => d.NotificationId_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationTask_Notifications");

            entity.HasOne(d => d.TaskID_FKNavigation).WithMany(p => p.NotificationTask)
                .HasForeignKey(d => d.TaskID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationTask_Task");
        });

        modelBuilder.Entity<NotificationVitalSignDetails>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Notifica__3213E83F3CF99FFF");

            entity.HasIndex(e => e.VitalSignDetailId, "IX_NotificationVitalSignDetails_VitalSignDetailId");

            entity.HasIndex(e => new { e.notificationId, e.VitalSignDetailId }, "idx_NotificationVitalSignDetails1");

            entity.Property(e => e.createdDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.updatedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.VitalSignDetail).WithMany(p => p.NotificationVitalSignDetails)
                .HasForeignKey(d => d.VitalSignDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationVitalSignDetails_VitalSignDetails");

            entity.HasOne(d => d.notification).WithMany(p => p.NotificationVitalSignDetails)
                .HasForeignKey(d => d.notificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_NotificationVitalSignDetails_notificationId");
        });

        modelBuilder.Entity<Notifications>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Notifica__3213E83F5EF36BEC");

            entity.HasIndex(e => e.FacilityID_FK, "IX_Notifications_FacilityID_FK");

            entity.HasIndex(e => e.notificationTypeCode, "IX_Notifications_notificationTypeCode");

            entity.HasIndex(e => new { e.userId, e.isRead }, "idx_Notifications1");

            entity.HasIndex(e => e.isRead, "idx_Notifications2");

            entity.HasIndex(e => e.userId, "idx_Notifications3");

            entity.Property(e => e.createdDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.notificationTypeCode).HasMaxLength(100);
            entity.Property(e => e.updatedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.FacilityID_FKNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.FacilityID_FK)
                .HasConstraintName("FK_Notifications_Facility");

            entity.HasOne(d => d.notificationTypeCodeNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.notificationTypeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Notifications_notificationTypeCode");

            entity.HasOne(d => d.user).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.userId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Notifications_userId");
        });

        modelBuilder.Entity<NutritionTask>(entity =>
        {
            entity.HasIndex(e => e.ActionTypeID_FK, "IX_NutritionTask_ActionTypeID_FK");

            entity.HasIndex(e => e.AmountReferenceID_FK, "IX_NutritionTask_AmountReferenceID_FK");

            entity.HasIndex(e => e.ColorReferenceID_FK, "IX_NutritionTask_ColorReferenceID_FK");

            entity.HasIndex(e => e.PatientID_FK, "IX_NutritionTask_PatientID_FK");

            entity.HasIndex(e => e.TypeReferenceID_FK, "IX_NutritionTask_TypeReferenceID_FK");

            entity.Property(e => e.AfterImage).HasMaxLength(50);
            entity.Property(e => e.BeforeImage).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EndTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Food).HasMaxLength(255);
            entity.Property(e => e.Liquid).HasMaxLength(50);
            entity.Property(e => e.Method).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.StartTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Unit).HasMaxLength(10);

            entity.HasOne(d => d.ActionTypeID_FKNavigation).WithMany(p => p.NutritionTask)
                .HasForeignKey(d => d.ActionTypeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NutritionTask_Code");

            entity.HasOne(d => d.AmountReferenceID_FKNavigation).WithMany(p => p.NutritionTaskAmountReferenceID_FKNavigation)
                .HasForeignKey(d => d.AmountReferenceID_FK)
                .HasConstraintName("FK_NutritionTask_NutritionTaskReference2");

            entity.HasOne(d => d.ColorReferenceID_FKNavigation).WithMany(p => p.NutritionTaskColorReferenceID_FKNavigation)
                .HasForeignKey(d => d.ColorReferenceID_FK)
                .HasConstraintName("FK_NutritionTask_NutritionTaskReference3");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.NutritionTask)
                .HasForeignKey(d => d.PatientID_FK)
                .HasConstraintName("FK_NutritionTask_Patient");

            entity.HasOne(d => d.TypeReferenceID_FKNavigation).WithMany(p => p.NutritionTaskTypeReferenceID_FKNavigation)
                .HasForeignKey(d => d.TypeReferenceID_FK)
                .HasConstraintName("FK_NutritionTask_NutritionTaskReference1");
        });

        modelBuilder.Entity<NutritionTaskReference>(entity =>
        {
            entity.HasKey(e => e.ReferenceID);

            entity.HasIndex(e => e.CodeId_FK, "IX_NutritionTaskReference_CodeId_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ReferenceImage).HasMaxLength(50);

            entity.HasOne(d => d.CodeId_FKNavigation).WithMany(p => p.NutritionTaskReference)
                .HasForeignKey(d => d.CodeId_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NutritionTaskReference_Code");
        });

        modelBuilder.Entity<Otp>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Password).HasMaxLength(10);
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PackageDetails).HasMaxLength(255);
            entity.Property(e => e.PackageName).HasMaxLength(255);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasIndex(e => e.BloodTypeID_FK, "IX_Patient_BloodTypeID_FK");

            entity.HasIndex(e => e.GenderID_FK, "IX_Patient_GenderID_FK");

            entity.HasIndex(e => e.InvoiceModeID_FK, "IX_Patient_InvoiceModeID_FK");

            entity.HasIndex(e => e.MaritalStatusID_FK, "IX_Patient_MaritalStatusID_FK");

            entity.HasIndex(e => e.PatientAdditionalInfoID_FK, "IX_Patient_PatientAdditionalInfoID_FK");

            entity.HasIndex(e => e.PatientMedicationID_FK, "IX_Patient_PatientMedicationID_FK");

            entity.HasIndex(e => e.PatientProfileID_FK, "IX_Patient_PatientProfileID_FK");

            entity.HasIndex(e => e.PatientReferralByID_FK, "IX_Patient_PatientReferralByID_FK");

            entity.HasIndex(e => e.PatientReferralID_FK, "IX_Patient_PatientReferralID_FK");

            entity.HasIndex(e => e.PatientTypeID_FK, "IX_Patient_PatientTypeID_FK");

            entity.HasIndex(e => e.RaceID_FK, "IX_Patient_RaceID_FK");

            entity.HasIndex(e => e.ReligionID_FK, "IX_Patient_ReligionID_FK");

            entity.HasIndex(e => e.ResidentTypeID_FK, "IX_Patient_ResidentTypeID_FK");

            entity.Property(e => e.ActionDescription).HasMaxLength(255);
            entity.Property(e => e.AdmittedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CareReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CaseID).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DateOfBirth).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DisplayName).HasMaxLength(255);
            entity.Property(e => e.DrugAllergy).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.GenogramPicture).HasMaxLength(50);
            entity.Property(e => e.HomePhone).HasMaxLength(100);
            entity.Property(e => e.IdentificationAttachmentFilename).HasMaxLength(255);
            entity.Property(e => e.IdentificationAttachmentPhysical).HasMaxLength(50);
            entity.Property(e => e.IdentificationNumber).HasMaxLength(255);
            entity.Property(e => e.IntegrationSourceID).HasMaxLength(100);
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.MailForFamilyNotification1).HasMaxLength(50);
            entity.Property(e => e.MailForFamilyNotification2).HasMaxLength(50);
            entity.Property(e => e.MailForVitalAlert1).HasMaxLength(50);
            entity.Property(e => e.MailForVitalAlert2).HasMaxLength(50);
            entity.Property(e => e.MailForVitalAlert3).HasMaxLength(50);
            entity.Property(e => e.MailingAddress1).HasMaxLength(255);
            entity.Property(e => e.MailingAddress2).HasMaxLength(255);
            entity.Property(e => e.MailingAddress3).HasMaxLength(255);
            entity.Property(e => e.MobilePhone).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.NRIC).HasMaxLength(20);
            entity.Property(e => e.NursingStation).HasMaxLength(255);
            entity.Property(e => e.Occupation).HasMaxLength(500);
            entity.Property(e => e.OrderID).HasMaxLength(60);
            entity.Property(e => e.OtherLanguage).HasMaxLength(255);
            entity.Property(e => e.OtherRace).HasMaxLength(255);
            entity.Property(e => e.PaymentMode).HasMaxLength(10);
            entity.Property(e => e.Photo).HasMaxLength(50);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.ReasonOfAdmission).HasMaxLength(500);
            entity.Property(e => e.ReferringDiagnosis).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(15);
            entity.Property(e => e.VisitingFrequency).HasMaxLength(500);

            entity.HasOne(d => d.BloodTypeID_FKNavigation).WithMany(p => p.PatientBloodTypeID_FKNavigation)
                .HasForeignKey(d => d.BloodTypeID_FK)
                .HasConstraintName("FK_Patient_Code2");

            entity.HasOne(d => d.GenderID_FKNavigation).WithMany(p => p.PatientGenderID_FKNavigation)
                .HasForeignKey(d => d.GenderID_FK)
                .HasConstraintName("FK_Patient_Code1");

            entity.HasOne(d => d.InvoiceModeID_FKNavigation).WithMany(p => p.PatientInvoiceModeID_FKNavigation).HasForeignKey(d => d.InvoiceModeID_FK);

            entity.HasOne(d => d.MaritalStatusID_FKNavigation).WithMany(p => p.PatientMaritalStatusID_FKNavigation)
                .HasForeignKey(d => d.MaritalStatusID_FK)
                .HasConstraintName("FK_Patient_Code4");

            entity.HasOne(d => d.PatientAdditionalInfoID_FKNavigation).WithMany(p => p.Patient)
                .HasForeignKey(d => d.PatientAdditionalInfoID_FK)
                .HasConstraintName("FK_Patient_PatientAdditionalInfo");

            entity.HasOne(d => d.PatientMedicationID_FKNavigation).WithMany(p => p.Patient)
                .HasForeignKey(d => d.PatientMedicationID_FK)
                .HasConstraintName("FK_Patient_PatientMedication");

            entity.HasOne(d => d.PatientProfileID_FKNavigation).WithMany(p => p.Patient)
                .HasForeignKey(d => d.PatientProfileID_FK)
                .HasConstraintName("FK_Patient_PatientProfile");

            entity.HasOne(d => d.PatientReferralByID_FKNavigation).WithMany(p => p.PatientPatientReferralByID_FKNavigation)
                .HasForeignKey(d => d.PatientReferralByID_FK)
                .HasConstraintName("FK_Patient_Code7");

            entity.HasOne(d => d.PatientReferralID_FKNavigation).WithMany(p => p.Patient)
                .HasForeignKey(d => d.PatientReferralID_FK)
                .HasConstraintName("FK_Patient_PatientReferral");

            entity.HasOne(d => d.PatientTypeID_FKNavigation).WithMany(p => p.PatientPatientTypeID_FKNavigation)
                .HasForeignKey(d => d.PatientTypeID_FK)
                .HasConstraintName("FK_Patient_Code");

            entity.HasOne(d => d.RaceID_FKNavigation).WithMany(p => p.PatientRaceID_FKNavigation)
                .HasForeignKey(d => d.RaceID_FK)
                .HasConstraintName("FK_Patient_Code6");

            entity.HasOne(d => d.ReligionID_FKNavigation).WithMany(p => p.PatientReligionID_FKNavigation)
                .HasForeignKey(d => d.ReligionID_FK)
                .HasConstraintName("FK_Patient_Code5");

            entity.HasOne(d => d.ResidentTypeID_FKNavigation).WithMany(p => p.PatientResidentTypeID_FKNavigation)
                .HasForeignKey(d => d.ResidentTypeID_FK)
                .HasConstraintName("FK_Patient_Code3");
        });

        modelBuilder.Entity<PatientAMT>(entity =>
        {
            entity.HasIndex(e => e.CareReportID_FK, "IX_PatientAMT_CareReportID_FK");

            entity.HasIndex(e => e.InitialCareAssessmentID_FK, "IX_PatientAMT_InitialCareAssessmentID_FK");

            entity.HasIndex(e => e.PatientID_FK, "IX_PatientAMT_PatientID_FK");

            entity.HasIndex(e => e.VitalSignDetailId_FK, "IX_PatientAMT_VitalSignDetailId_FK");

            entity.Property(e => e.Alertness).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.CareReportID_FKNavigation).WithMany(p => p.PatientAMT)
                .HasForeignKey(d => d.CareReportID_FK)
                .HasConstraintName("FK_PatientAMT_CareReport");

            entity.HasOne(d => d.InitialCareAssessmentID_FKNavigation).WithMany(p => p.PatientAMT)
                .HasForeignKey(d => d.InitialCareAssessmentID_FK)
                .HasConstraintName("FK_PatientAMT_InitialCareAssessment");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.PatientAMT)
                .HasForeignKey(d => d.PatientID_FK)
                .HasConstraintName("FK_PatientAMT_Patient");

            entity.HasOne(d => d.VitalSignDetailId_FKNavigation).WithMany(p => p.PatientAMT)
                .HasForeignKey(d => d.VitalSignDetailId_FK)
                .HasConstraintName("FK_PatientAMT_VitalSignDetails");
        });

        modelBuilder.Entity<PatientAMTAnswer>(entity =>
        {
            entity.HasKey(e => new { e.PatientAMTID_FK, e.AMTQuestionID_FK });

            entity.HasIndex(e => e.AMTQuestionID_FK, "IX_PatientAMTAnswer_AMTQuestionID_FK");

            entity.HasOne(d => d.AMTQuestionID_FKNavigation).WithMany(p => p.PatientAMTAnswer)
                .HasForeignKey(d => d.AMTQuestionID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientAMTAnswer_AMTQuestion");

            entity.HasOne(d => d.PatientAMTID_FKNavigation).WithMany(p => p.PatientAMTAnswer)
                .HasForeignKey(d => d.PatientAMTID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientAMTAnswer_PatientAMT");
        });

        modelBuilder.Entity<PatientAccessLine>(entity =>
        {
            entity.HasIndex(e => e.CareReportID_FK, "IX_PatientAccessLine_CareReportID_FK");

            entity.Property(e => e.AccessLine).HasMaxLength(30);
            entity.Property(e => e.AccessLineRemarks).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DateDueForChange).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DateOfInsertion).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Patent).HasMaxLength(5);
            entity.Property(e => e.PatentReSited).HasMaxLength(5);
            entity.Property(e => e.PatentReSitedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PatentSite).HasMaxLength(1000);

            entity.HasOne(d => d.CareReportID_FKNavigation).WithMany(p => p.PatientAccessLine)
                .HasForeignKey(d => d.CareReportID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientAccessLine_CareReport");
        });

        modelBuilder.Entity<PatientAdditionalInfo>(entity =>
        {
            entity.Property(e => e.ACP_DoneDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ACP_ReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AICD_InsertDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AICD_InsertedBy).HasMaxLength(255);
            entity.Property(e => e.AICD_ReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CVCLine_InsertDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CVCLine_InsertedBy).HasMaxLength(255);
            entity.Property(e => e.CVCLine_ReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DNR_DateInitiated).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DNR_DateTerminated).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DNR_InitiatedBy).HasMaxLength(255);
            entity.Property(e => e.DNR_TerminatedBy).HasMaxLength(255);
            entity.Property(e => e.IVLine_InsertDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.IVLine_InsertedBy).HasMaxLength(255);
            entity.Property(e => e.IVLine_ReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PICCLine_InsertDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PICCLine_InsertedBy).HasMaxLength(255);
            entity.Property(e => e.PICCLine_ReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Pacemaker_InsertDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Pacemaker_InsertedBy).HasMaxLength(255);
            entity.Property(e => e.Pacemaker_ReviewDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<PatientAttachment>(entity =>
        {
            entity.HasIndex(e => e.PatientID_FK, "IX_PatientAttachment_PatientID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Filename).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Physical).HasMaxLength(50);

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.PatientAttachment)
                .HasForeignKey(d => d.PatientID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientAttachment_Patient");
        });

        modelBuilder.Entity<PatientBradenScale>(entity =>
        {
            entity.HasIndex(e => e.VitalSignDetailID_FK, "IX_PatientBradenScale_VitalSignDetailID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Type).HasMaxLength(20);

            entity.HasOne(d => d.VitalSignDetailID_FKNavigation).WithMany(p => p.PatientBradenScale)
                .HasForeignKey(d => d.VitalSignDetailID_FK)
                .HasConstraintName("FK_PatientBradenScale_VitalSignDetails");
        });

        modelBuilder.Entity<PatientClinician>(entity =>
        {
            entity.HasIndex(e => e.DiseaseID_FK, "IX_PatientClinician_DiseaseID_FK");

            entity.HasIndex(e => e.DiseaseSubInfoID_FK, "IX_PatientClinician_DiseaseSubInfoID_FK");

            entity.HasIndex(e => e.ExternalDoctorID_FK, "IX_PatientClinician_ExternalDoctorID_FK");

            entity.HasIndex(e => e.InitialCareAssessmentID_FK, "IX_PatientClinician_InitialCareAssessmentID_FK");

            entity.HasIndex(e => e.PatientID_FK, "IX_PatientClinician_PatientID_FK");

            entity.HasIndex(e => e.UserID_FK, "IX_PatientClinician_UserID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.DiseaseID_FKNavigation).WithMany(p => p.PatientClinician)
                .HasForeignKey(d => d.DiseaseID_FK)
                .HasConstraintName("FK_PatientClinician_Disease");

            entity.HasOne(d => d.DiseaseSubInfoID_FKNavigation).WithMany(p => p.PatientClinician)
                .HasForeignKey(d => d.DiseaseSubInfoID_FK)
                .HasConstraintName("FK_PatientClinician_DiseaseSubInfo");

            entity.HasOne(d => d.ExternalDoctorID_FKNavigation).WithMany(p => p.PatientClinician)
                .HasForeignKey(d => d.ExternalDoctorID_FK)
                .HasConstraintName("FK_PatientClinician_ExternalDoctor");

            entity.HasOne(d => d.InitialCareAssessmentID_FKNavigation).WithMany(p => p.PatientClinician)
                .HasForeignKey(d => d.InitialCareAssessmentID_FK)
                .HasConstraintName("FK_PatientClinician_InitialCareAssessment");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.PatientClinician)
                .HasForeignKey(d => d.PatientID_FK)
                .HasConstraintName("FK_PatientClinician_Patient");

            entity.HasOne(d => d.UserID_FKNavigation).WithMany(p => p.PatientClinician)
                .HasForeignKey(d => d.UserID_FK)
                .HasConstraintName("FK_PatientClinician_Users");
        });

        modelBuilder.Entity<PatientDrugAllergy>(entity =>
        {
            entity.HasKey(e => e.DrugAllergyID).HasName("PK_PatientDrugAllery");

            entity.HasIndex(e => e.InitialCareAssessmentID_FK, "IX_PatientDrugAllergy_InitialCareAssessmentID_FK");

            entity.HasIndex(e => e.MedicationID_FK, "IX_PatientDrugAllergy_MedicationID_FK");

            entity.HasIndex(e => e.PatientID_FK, "IX_PatientDrugAllergy_PatientID_FK");

            entity.HasIndex(e => e.ReactionID_FK, "IX_PatientDrugAllergy_ReactionID_FK");

            entity.HasIndex(e => e.ReferID_FK, "IX_PatientDrugAllergy_ReferID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.InitialCareAssessmentID_FKNavigation).WithMany(p => p.PatientDrugAllergy)
                .HasForeignKey(d => d.InitialCareAssessmentID_FK)
                .HasConstraintName("FK_PatientDrugAllery_InitialCareAssessment");

            entity.HasOne(d => d.MedicationID_FKNavigation).WithMany(p => p.PatientDrugAllergyMedicationID_FKNavigation)
                .HasForeignKey(d => d.MedicationID_FK)
                .HasConstraintName("FK_PatientDrugAllergy_Code1");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.PatientDrugAllergy)
                .HasForeignKey(d => d.PatientID_FK)
                .HasConstraintName("FK_PatientDrugAllery_Patient");

            entity.HasOne(d => d.ReactionID_FKNavigation).WithMany(p => p.PatientDrugAllergyReactionID_FKNavigation)
                .HasForeignKey(d => d.ReactionID_FK)
                .HasConstraintName("FK_PatientDrugAllergy_Code");

            entity.HasOne(d => d.ReferID_FKNavigation).WithMany(p => p.InverseReferID_FKNavigation)
                .HasForeignKey(d => d.ReferID_FK)
                .HasConstraintName("FK_PatientDrugAllergy_PatientDrugAllergy");
        });

        modelBuilder.Entity<PatientEBASDEP>(entity =>
        {
            entity.HasIndex(e => e.CareReportID_FK, "IX_PatientEBASDEP_CareReportID_FK");

            entity.HasIndex(e => e.InitialCareAssessmentID_FK, "IX_PatientEBASDEP_InitialCareAssessmentID_FK");

            entity.HasIndex(e => e.PatientID_FK, "IX_PatientEBASDEP_PatientID_FK");

            entity.HasIndex(e => e.VitalSignDetailId_FK, "IX_PatientEBASDEP_VitalSignDetailId_FK");

            entity.Property(e => e.Alertness).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.CareReportID_FKNavigation).WithMany(p => p.PatientEBASDEP)
                .HasForeignKey(d => d.CareReportID_FK)
                .HasConstraintName("FK_PatientEBASDEP_CareReport");

            entity.HasOne(d => d.InitialCareAssessmentID_FKNavigation).WithMany(p => p.PatientEBASDEP)
                .HasForeignKey(d => d.InitialCareAssessmentID_FK)
                .HasConstraintName("FK_PatientEBASDEP_InitialCareAssessment");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.PatientEBASDEP)
                .HasForeignKey(d => d.PatientID_FK)
                .HasConstraintName("FK_PatientEBASDEP_Patient");

            entity.HasOne(d => d.VitalSignDetailId_FKNavigation).WithMany(p => p.PatientEBASDEP)
                .HasForeignKey(d => d.VitalSignDetailId_FK)
                .HasConstraintName("FK_PatientEBASDEP_VitalSignDetails");
        });

        modelBuilder.Entity<PatientEBASDEPAnswer>(entity =>
        {
            entity.HasKey(e => new { e.PatientEBASDEPID_FK, e.EBASDEPQuestionID_FK });

            entity.HasIndex(e => e.EBASDEPQuestionID_FK, "IX_PatientEBASDEPAnswer_EBASDEPQuestionID_FK");

            entity.HasOne(d => d.EBASDEPQuestionID_FKNavigation).WithMany(p => p.PatientEBASDEPAnswer)
                .HasForeignKey(d => d.EBASDEPQuestionID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientEBASDEPAnswer_EBASDEPQuestion");

            entity.HasOne(d => d.PatientEBASDEPID_FKNavigation).WithMany(p => p.PatientEBASDEPAnswer)
                .HasForeignKey(d => d.PatientEBASDEPID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientEBASDEPAnswer_PatientEBASDEP");
        });

        modelBuilder.Entity<PatientFacility>(entity =>
        {
            entity.HasKey(e => new { e.PatientID_FK, e.FacilityID_FK });

            entity.HasIndex(e => e.FacilityID_FK, "IX_PatientFacility_FacilityID_FK");

            entity.HasOne(d => d.FacilityID_FKNavigation).WithMany(p => p.PatientFacility)
                .HasForeignKey(d => d.FacilityID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientFacility_Facility");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.PatientFacility)
                .HasForeignKey(d => d.PatientID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientFacility_Patient");
        });

        modelBuilder.Entity<PatientFamilyHistory>(entity =>
        {
            entity.HasIndex(e => e.DiseaseID_FK, "IX_PatientFamilyHistory_DiseaseID_FK");

            entity.HasIndex(e => e.DiseaseSubInfoID_FK, "IX_PatientFamilyHistory_DiseaseSubInfoID_FK");

            entity.HasIndex(e => e.InitialCareAssessmentID_FK, "IX_PatientFamilyHistory_InitialCareAssessmentID_FK");

            entity.HasIndex(e => e.PatientID_FK, "IX_PatientFamilyHistory_PatientID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Relationship).HasMaxLength(50);

            entity.HasOne(d => d.DiseaseID_FKNavigation).WithMany(p => p.PatientFamilyHistory)
                .HasForeignKey(d => d.DiseaseID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientFamilyHistory_Disease");

            entity.HasOne(d => d.DiseaseSubInfoID_FKNavigation).WithMany(p => p.PatientFamilyHistory)
                .HasForeignKey(d => d.DiseaseSubInfoID_FK)
                .HasConstraintName("FK_PatientFamilyHistory_DiseaseSubInfo");

            entity.HasOne(d => d.InitialCareAssessmentID_FKNavigation).WithMany(p => p.PatientFamilyHistory)
                .HasForeignKey(d => d.InitialCareAssessmentID_FK)
                .HasConstraintName("FK_PatientFamilyHistory_InitialCareAssessment");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.PatientFamilyHistory)
                .HasForeignKey(d => d.PatientID_FK)
                .HasConstraintName("FK_PatientFamilyHistory_Patient");
        });

        modelBuilder.Entity<PatientGCS>(entity =>
        {
            entity.HasIndex(e => e.VitalSignDetailID_FK, "IX_PatientGCS_VitalSignDetailID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Type).HasMaxLength(20);

            entity.HasOne(d => d.VitalSignDetailID_FKNavigation).WithMany(p => p.PatientGCS)
                .HasForeignKey(d => d.VitalSignDetailID_FK)
                .HasConstraintName("FK_PatientGCS_VitalSignDetails");
        });

        modelBuilder.Entity<PatientImmunisation>(entity =>
        {
            entity.HasKey(e => e.ImmunisationID);

            entity.HasIndex(e => e.PatientID_FK, "IX_PatientImmunisation_PatientID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Date).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.NextDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Place).HasMaxLength(255);

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.PatientImmunisation)
                .HasForeignKey(d => d.PatientID_FK)
                .HasConstraintName("FK_PatientImmunisation_Patient");
        });

        modelBuilder.Entity<PatientLanguage>(entity =>
        {
            entity.HasKey(e => new { e.PatientID_FK, e.CodeID_FK });

            entity.HasIndex(e => e.CodeID_FK, "IX_PatientLanguage_CodeID_FK");

            entity.HasOne(d => d.CodeID_FKNavigation).WithMany(p => p.PatientLanguage)
                .HasForeignKey(d => d.CodeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientLanguage_Code");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.PatientLanguage)
                .HasForeignKey(d => d.PatientID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientLanguage_Patient");
        });

        modelBuilder.Entity<PatientMBI>(entity =>
        {
            entity.HasIndex(e => e.VitalSignDetailID_FK, "IX_PatientMBI_VitalSignDetailID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Type).HasMaxLength(20);

            entity.HasOne(d => d.VitalSignDetailID_FKNavigation).WithMany(p => p.PatientMBI)
                .HasForeignKey(d => d.VitalSignDetailID_FK)
                .HasConstraintName("FK_PatientMBI_VitalSignDetails");
        });

        modelBuilder.Entity<PatientMFS>(entity =>
        {
            entity.HasIndex(e => e.VitalSignDetailID_FK, "IX_PatientMFS_VitalSignDetailID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Type).HasMaxLength(20);

            entity.HasOne(d => d.VitalSignDetailID_FKNavigation).WithMany(p => p.PatientMFS)
                .HasForeignKey(d => d.VitalSignDetailID_FK)
                .HasConstraintName("FK_PatientMFS_VitalSignDetails");
        });

        modelBuilder.Entity<PatientMMSE>(entity =>
        {
            entity.HasIndex(e => e.VitalSignDetailID_FK, "IX_PatientMMSE_VitalSignDetailID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Type).HasMaxLength(20);

            entity.HasOne(d => d.VitalSignDetailID_FKNavigation).WithMany(p => p.PatientMMSE)
                .HasForeignKey(d => d.VitalSignDetailID_FK)
                .HasConstraintName("FK_PatientMMSE_VitalSignDetails");
        });

        modelBuilder.Entity<PatientMedicalHistory>(entity =>
        {
            entity.HasIndex(e => e.ClinicianID_FK, "IX_PatientMedicalHistory_ClinicianID_FK");

            entity.HasIndex(e => e.MedicalStatusID_FK, "IX_PatientMedicalHistory_MedicalStatusID_FK");

            entity.HasIndex(e => e.PatientID_FK, "IX_PatientMedicalHistory_PatientID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.ClinicianID_FKNavigation).WithMany(p => p.PatientMedicalHistory)
                .HasForeignKey(d => d.ClinicianID_FK)
                .HasConstraintName("FK_PatientMedicalHistory_PatientClinician");

            entity.HasOne(d => d.MedicalStatusID_FKNavigation).WithMany(p => p.PatientMedicalHistory)
                .HasForeignKey(d => d.MedicalStatusID_FK)
                .HasConstraintName("FK_PatientMedicalHistory_Status");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.PatientMedicalHistory)
                .HasForeignKey(d => d.PatientID_FK)
                .HasConstraintName("FK_PatientMedicalHistory_Patient");
        });

        modelBuilder.Entity<PatientMedication>(entity =>
        {
            entity.HasKey(e => e.PatientMedicationID).HasName("PK_PatientMedication_1");

            entity.Property(e => e.Allergies).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<PatientMedicationConsume>(entity =>
        {
            entity.HasIndex(e => e.AcutePRNIndicationID_FK, "IX_PatientMedicationConsume_AcutePRNIndicationID_FK");

            entity.HasIndex(e => e.ChronicDiseaseID_FK, "IX_PatientMedicationConsume_ChronicDiseaseID_FK");

            entity.HasIndex(e => e.ChronicDiseaseSubInfoID_FK, "IX_PatientMedicationConsume_ChronicDiseaseSubInfoID_FK");

            entity.HasIndex(e => e.DosageID_FK, "IX_PatientMedicationConsume_DosageID_FK");

            entity.HasIndex(e => e.FrequencyID_FK, "IX_PatientMedicationConsume_FrequencyID_FK");

            entity.HasIndex(e => e.InstructedBy2ID_FK, "IX_PatientMedicationConsume_InstructedBy2ID_FK");

            entity.HasIndex(e => e.InstructedByID_FK, "IX_PatientMedicationConsume_InstructedByID_FK");

            entity.HasIndex(e => e.MedicationID_FK, "IX_PatientMedicationConsume_MedicationID_FK");

            entity.HasIndex(e => e.PatientMedicationID_FK, "IX_PatientMedicationConsume_PatientMedicationID_FK");

            entity.HasIndex(e => e.ReferID_FK, "IX_PatientMedicationConsume_ReferID_FK");

            entity.HasIndex(e => e.RouteID_FK, "IX_PatientMedicationConsume_RouteID_FK");

            entity.Property(e => e.ClinicHosp).HasMaxLength(50);
            entity.Property(e => e.ClinicHospED).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DrContact).HasMaxLength(50);
            entity.Property(e => e.DrContactED).HasMaxLength(50);
            entity.Property(e => e.DrName).HasMaxLength(50);
            entity.Property(e => e.DrNameED).HasMaxLength(50);
            entity.Property(e => e.EndDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Indication).HasMaxLength(255);
            entity.Property(e => e.MCRNo).HasMaxLength(50);
            entity.Property(e => e.MCRNoED).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ReasonOfDiscontinue).HasMaxLength(200);
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.AcutePRNIndicationID_FKNavigation).WithMany(p => p.PatientMedicationConsumeAcutePRNIndicationID_FKNavigation)
                .HasForeignKey(d => d.AcutePRNIndicationID_FK)
                .HasConstraintName("FK_PatientMedicationConsume_Code3");

            entity.HasOne(d => d.ChronicDiseaseID_FKNavigation).WithMany(p => p.PatientMedicationConsume)
                .HasForeignKey(d => d.ChronicDiseaseID_FK)
                .HasConstraintName("FK_PatientMedicationConsume_Disease");

            entity.HasOne(d => d.ChronicDiseaseSubInfoID_FKNavigation).WithMany(p => p.PatientMedicationConsume)
                .HasForeignKey(d => d.ChronicDiseaseSubInfoID_FK)
                .HasConstraintName("FK_PatientMedicationConsume_DiseaseSubInfo");

            entity.HasOne(d => d.DosageID_FKNavigation).WithMany(p => p.PatientMedicationConsumeDosageID_FKNavigation)
                .HasForeignKey(d => d.DosageID_FK)
                .HasConstraintName("FK_PatientMedicationConsume_Code1");

            entity.HasOne(d => d.FrequencyID_FKNavigation).WithMany(p => p.PatientMedicationConsumeFrequencyID_FKNavigation)
                .HasForeignKey(d => d.FrequencyID_FK)
                .HasConstraintName("FK_PatientMedicationConsume_Code2");

            entity.HasOne(d => d.InstructedBy2ID_FKNavigation).WithMany(p => p.PatientMedicationConsumeInstructedBy2ID_FKNavigation)
                .HasForeignKey(d => d.InstructedBy2ID_FK)
                .HasConstraintName("FK_PatientMedicationConsume_InstructedBy2ID_FK");

            entity.HasOne(d => d.InstructedByID_FKNavigation).WithMany(p => p.PatientMedicationConsumeInstructedByID_FKNavigation)
                .HasForeignKey(d => d.InstructedByID_FK)
                .HasConstraintName("FK_PatientMedicationConsume_InstructedByID_FK");

            entity.HasOne(d => d.MedicationID_FKNavigation).WithMany(p => p.PatientMedicationConsumeMedicationID_FKNavigation)
                .HasForeignKey(d => d.MedicationID_FK)
                .HasConstraintName("FK_PatientMedicationConsume_Code4");

            entity.HasOne(d => d.PatientMedicationID_FKNavigation).WithMany(p => p.PatientMedicationConsume)
                .HasForeignKey(d => d.PatientMedicationID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientMedicationConsume_PatientMedication");

            entity.HasOne(d => d.ReferID_FKNavigation).WithMany(p => p.InverseReferID_FKNavigation)
                .HasForeignKey(d => d.ReferID_FK)
                .HasConstraintName("FK_PatientMedicationConsume_PatientMedicationConsume");

            entity.HasOne(d => d.RouteID_FKNavigation).WithMany(p => p.PatientMedicationConsumeRouteID_FKNavigation)
                .HasForeignKey(d => d.RouteID_FK)
                .HasConstraintName("FK_PatientMedicationConsume_Code");
        });

        modelBuilder.Entity<PatientMedicationConsumeAttachment>(entity =>
        {
            entity.HasIndex(e => e.PatientMedicationConsumeID_FK, "IX_PatientMedicationConsumeAttachment_PatientMedicationConsume~");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Filename).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Physical).HasMaxLength(50);

            entity.HasOne(d => d.PatientMedicationConsumeID_FKNavigation).WithMany(p => p.PatientMedicationConsumeAttachment)
                .HasForeignKey(d => d.PatientMedicationConsumeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientMedicationConsumeAttachment_PatientMedicationConsume");
        });

        modelBuilder.Entity<PatientMedicationSupply>(entity =>
        {
            entity.HasKey(e => new { e.PatientMedicationID_FK, e.SupplyID_FK });

            entity.HasIndex(e => e.SupplyID_FK, "IX_PatientMedicationSupply_SupplyID_FK");

            entity.HasOne(d => d.PatientMedicationID_FKNavigation).WithMany(p => p.PatientMedicationSupply)
                .HasForeignKey(d => d.PatientMedicationID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientMedicationSupply_PatientMedication");

            entity.HasOne(d => d.SupplyID_FKNavigation).WithMany(p => p.PatientMedicationSupply)
                .HasForeignKey(d => d.SupplyID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientMedicationSupply_Code");
        });

        modelBuilder.Entity<PatientNutrition>(entity =>
        {
            entity.Property(e => e.Appetite).HasMaxLength(20);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DiagnosedDysphasiaLastReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Diet).HasMaxLength(20);
            entity.Property(e => e.EatingAndSwallowing).HasMaxLength(20);
            entity.Property(e => e.EatingAndSwallowingDateDue).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EatingAndSwallowingDateInserted).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EatingAndSwallowingSize).HasMaxLength(20);
            entity.Property(e => e.EatingAndSwallowingTypeOfTube).HasMaxLength(20);
            entity.Property(e => e.EatingAndSwallowingTypeOfTubeFeeding).HasMaxLength(20);
            entity.Property(e => e.Enteralfeeding).HasMaxLength(20);
            entity.Property(e => e.FluidConsistency).HasMaxLength(20);
            entity.Property(e => e.FluidRestrictionMLSPerDay).HasPrecision(4);
            entity.Property(e => e.IVtherapyMLSPerDay).HasPrecision(4);
            entity.Property(e => e.IVtherapyStateType).HasMaxLength(255);
            entity.Property(e => e.MilkFeedAmt).HasPrecision(4);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.SizeofPEGJtube).HasMaxLength(20);
            entity.Property(e => e.WaterPerDay).HasPrecision(4);
        });

        modelBuilder.Entity<PatientOtherAllergy>(entity =>
        {
            entity.HasKey(e => e.OtherAllergyID);

            entity.HasIndex(e => e.DescriptionID_FK, "IX_PatientOtherAllergy_DescriptionID_FK");

            entity.HasIndex(e => e.InitialCareAssessmentID_FK, "IX_PatientOtherAllergy_InitialCareAssessmentID_FK");

            entity.HasIndex(e => e.PatientID_FK, "IX_PatientOtherAllergy_PatientID_FK");

            entity.HasIndex(e => e.ReactionID_FK, "IX_PatientOtherAllergy_ReactionID_FK");

            entity.HasIndex(e => e.ReferID_FK, "IX_PatientOtherAllergy_ReferID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.DescriptionID_FKNavigation).WithMany(p => p.PatientOtherAllergyDescriptionID_FKNavigation)
                .HasForeignKey(d => d.DescriptionID_FK)
                .HasConstraintName("FK_PatientOtherAllergy_Code1");

            entity.HasOne(d => d.InitialCareAssessmentID_FKNavigation).WithMany(p => p.PatientOtherAllergy)
                .HasForeignKey(d => d.InitialCareAssessmentID_FK)
                .HasConstraintName("FK_PatientOtherAllergy_InitialCareAssessment");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.PatientOtherAllergy)
                .HasForeignKey(d => d.PatientID_FK)
                .HasConstraintName("FK_PatientOtherAllergy_Patient");

            entity.HasOne(d => d.ReactionID_FKNavigation).WithMany(p => p.PatientOtherAllergyReactionID_FKNavigation)
                .HasForeignKey(d => d.ReactionID_FK)
                .HasConstraintName("FK_PatientOtherAllergy_Code");

            entity.HasOne(d => d.ReferID_FKNavigation).WithMany(p => p.InverseReferID_FKNavigation)
                .HasForeignKey(d => d.ReferID_FK)
                .HasConstraintName("FK_PatientOtherAllergy_PatientDrugAllergy");
        });

        modelBuilder.Entity<PatientPackage>(entity =>
        {
            entity.HasKey(e => new { e.PackageID_FK, e.PatientID_FK });

            entity.HasIndex(e => e.PatientID_FK, "IX_PatientPackage_PatientID_FK");

            entity.HasOne(d => d.PackageID_FKNavigation).WithMany(p => p.PatientPackage)
                .HasForeignKey(d => d.PackageID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientPackage_Package");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.PatientPackage)
                .HasForeignKey(d => d.PatientID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientPackage_Patient");
        });

        modelBuilder.Entity<PatientProfile>(entity =>
        {
            entity.HasIndex(e => e.BloodTypeID_FK, "IX_PatientProfile_BloodTypeID_FK");

            entity.HasIndex(e => e.PatientOrganizationID_FK, "IX_PatientProfile_PatientOrganizationID_FK");

            entity.HasIndex(e => e.ReligionID_FK, "IX_PatientProfile_ReligionID_FK");

            entity.Property(e => e.Bed).HasMaxLength(255);
            entity.Property(e => e.BillingAddress1).HasMaxLength(255);
            entity.Property(e => e.BillingAddress2).HasMaxLength(255);
            entity.Property(e => e.BillingAddress3).HasMaxLength(255);
            entity.Property(e => e.BillingPostalCode).HasMaxLength(10);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.HomePhone).HasMaxLength(20);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.MobilePhone).HasMaxLength(20);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.Organization).HasMaxLength(255);
            entity.Property(e => e.OtherReligion).HasMaxLength(255);
            entity.Property(e => e.Ward).HasMaxLength(255);

            entity.HasOne(d => d.BloodTypeID_FKNavigation).WithMany(p => p.PatientProfileBloodTypeID_FKNavigation)
                .HasForeignKey(d => d.BloodTypeID_FK)
                .HasConstraintName("FK_PatientProfile_Code");

            entity.HasOne(d => d.PatientOrganizationID_FKNavigation).WithMany(p => p.PatientProfilePatientOrganizationID_FKNavigation)
                .HasForeignKey(d => d.PatientOrganizationID_FK)
                .HasConstraintName("FK_PatientProfile_PatientOrganizationID_FK");

            entity.HasOne(d => d.ReligionID_FKNavigation).WithMany(p => p.PatientProfileReligionID_FKNavigation)
                .HasForeignKey(d => d.ReligionID_FK)
                .HasConstraintName("FK_PatientProfile_Code1");
        });

        modelBuilder.Entity<PatientRAF>(entity =>
        {
            entity.HasIndex(e => e.VitalSignDetailID_FK, "IX_PatientRAF_VitalSignDetailID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Type).HasMaxLength(20);

            entity.HasOne(d => d.VitalSignDetailID_FKNavigation).WithMany(p => p.PatientRAF)
                .HasForeignKey(d => d.VitalSignDetailID_FK)
                .HasConstraintName("FK_PatientRAF_VitalSignDetails");
        });

        modelBuilder.Entity<PatientReferral>(entity =>
        {
            entity.HasIndex(e => e.PrimaryClinicianID_FK, "IX_PatientReferral_PrimaryClinicianID_FK");

            entity.HasIndex(e => e.PrimaryNurseID_FK, "IX_PatientReferral_PrimaryNurseID_FK");

            entity.HasIndex(e => e.SecondaryClinicianID_FK, "IX_PatientReferral_SecondaryClinicianID_FK");

            entity.HasIndex(e => e.SecondaryNurseID_FK, "IX_PatientReferral_SecondaryNurseID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.FamilyAwareDiagnoseReason).HasMaxLength(255);
            entity.Property(e => e.FamilyAwarePrognosisReason).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PatientAwareDiagnoseReason).HasMaxLength(255);
            entity.Property(e => e.PatientAwarePrognosisReason).HasMaxLength(255);

            entity.HasOne(d => d.PrimaryClinicianID_FKNavigation).WithMany(p => p.PatientReferralPrimaryClinicianID_FKNavigation)
                .HasForeignKey(d => d.PrimaryClinicianID_FK)
                .HasConstraintName("FK_PatientReferral_PatientClinician2");

            entity.HasOne(d => d.PrimaryNurseID_FKNavigation).WithMany(p => p.PatientReferralPrimaryNurseID_FKNavigation)
                .HasForeignKey(d => d.PrimaryNurseID_FK)
                .HasConstraintName("FK_PatientReferral_PatientClinician4");

            entity.HasOne(d => d.SecondaryClinicianID_FKNavigation).WithMany(p => p.PatientReferralSecondaryClinicianID_FKNavigation)
                .HasForeignKey(d => d.SecondaryClinicianID_FK)
                .HasConstraintName("FK_PatientReferral_PatientClinician3");

            entity.HasOne(d => d.SecondaryNurseID_FKNavigation).WithMany(p => p.PatientReferralSecondaryNurseID_FKNavigation)
                .HasForeignKey(d => d.SecondaryNurseID_FK)
                .HasConstraintName("FK_PatientReferral_PatientClinician5");
        });

        modelBuilder.Entity<PatientReferralService>(entity =>
        {
            entity.HasKey(e => new { e.PatientReferralID_FK, e.ServiceID_FK });

            entity.HasIndex(e => e.ServiceID_FK, "IX_PatientReferralService_ServiceID_FK");

            entity.HasOne(d => d.PatientReferralID_FKNavigation).WithMany(p => p.PatientReferralService)
                .HasForeignKey(d => d.PatientReferralID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientReferralService_PatientReferral");

            entity.HasOne(d => d.ServiceID_FKNavigation).WithMany(p => p.PatientReferralService)
                .HasForeignKey(d => d.ServiceID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientReferralService_Code");
        });

        modelBuilder.Entity<PatientSocialSupport>(entity =>
        {
            entity.HasIndex(e => e.GenderID_FK, "IX_PatientSocialSupport_GenderID_FK");

            entity.HasIndex(e => e.InitialCareAssessmentID_FK, "IX_PatientSocialSupport_InitialCareAssessmentID_FK");

            entity.HasIndex(e => e.MaritalStatusID_FK, "IX_PatientSocialSupport_MaritalStatusID_FK");

            entity.HasIndex(e => e.NationalityID_FK, "IX_PatientSocialSupport_NationalityID_FK");

            entity.HasIndex(e => e.PatientID_FK, "IX_PatientSocialSupport_PatientID_FK");

            entity.HasIndex(e => e.RelationshipID_FK, "IX_PatientSocialSupport_RelationshipID_FK");

            entity.Property(e => e.Contact).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Firstname).HasMaxLength(255);
            entity.Property(e => e.Lastname).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UserType).HasMaxLength(255);

            entity.HasOne(d => d.GenderID_FKNavigation).WithMany(p => p.PatientSocialSupportGenderID_FKNavigation)
                .HasForeignKey(d => d.GenderID_FK)
                .HasConstraintName("FK_PatientSocialSupport_Code3");

            entity.HasOne(d => d.InitialCareAssessmentID_FKNavigation).WithMany(p => p.PatientSocialSupport)
                .HasForeignKey(d => d.InitialCareAssessmentID_FK)
                .HasConstraintName("FK_PatientSocialSupport_InitialCareAssessment");

            entity.HasOne(d => d.MaritalStatusID_FKNavigation).WithMany(p => p.PatientSocialSupportMaritalStatusID_FKNavigation)
                .HasForeignKey(d => d.MaritalStatusID_FK)
                .HasConstraintName("FK_PatientSocialSupport_Code");

            entity.HasOne(d => d.NationalityID_FKNavigation).WithMany(p => p.PatientSocialSupportNationalityID_FKNavigation)
                .HasForeignKey(d => d.NationalityID_FK)
                .HasConstraintName("FK_PatientSocialSupport_Code2");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.PatientSocialSupport)
                .HasForeignKey(d => d.PatientID_FK)
                .HasConstraintName("FK_PatientSocialSupport_Patient");

            entity.HasOne(d => d.RelationshipID_FKNavigation).WithMany(p => p.PatientSocialSupportRelationshipID_FKNavigation)
                .HasForeignKey(d => d.RelationshipID_FK)
                .HasConstraintName("FK_PatientSocialSupport_Code1");
        });

        modelBuilder.Entity<PatientSpecialIndicator>(entity =>
        {
            entity.HasKey(e => new { e.PatientID_FK, e.CodeID_FK });

            entity.HasIndex(e => e.CodeID_FK, "IX_PatientSpecialIndicator_CodeID_FK");

            entity.HasOne(d => d.CodeID_FKNavigation).WithMany(p => p.PatientSpecialIndicator)
                .HasForeignKey(d => d.CodeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientSpecialIndicator_Code");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.PatientSpecialIndicator)
                .HasForeignKey(d => d.PatientID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientSpecialIndicator_Patient");
        });

        modelBuilder.Entity<PatientWound>(entity =>
        {
            entity.HasIndex(e => e.CareReportID_FK, "IX_PatientWound_CareReportID_FK");

            entity.HasIndex(e => e.InitialCareAssessmentID_FK, "IX_PatientWound_InitialCareAssessmentID_FK");

            entity.HasIndex(e => e.PatientID_FK, "IX_PatientWound_PatientID_FK");

            entity.HasIndex(e => e.WoundStatusID_FK, "IX_PatientWound_WoundStatusID_FK");

            entity.Property(e => e.ActionDescription).HasMaxLength(255);
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.LocationRemark).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.OccurDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.SeenDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(15);

            entity.HasOne(d => d.CareReportID_FKNavigation).WithMany(p => p.PatientWound)
                .HasForeignKey(d => d.CareReportID_FK)
                .HasConstraintName("FK_PatientWound_CareReport");

            entity.HasOne(d => d.InitialCareAssessmentID_FKNavigation).WithMany(p => p.PatientWound)
                .HasForeignKey(d => d.InitialCareAssessmentID_FK)
                .HasConstraintName("FK_PatientWound_InitialCareAssessment");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.PatientWound)
                .HasForeignKey(d => d.PatientID_FK)
                .HasConstraintName("FK_PatientWound_Patient");

            entity.HasOne(d => d.WoundStatusID_FKNavigation).WithMany(p => p.PatientWound)
                .HasForeignKey(d => d.WoundStatusID_FK)
                .HasConstraintName("FK_PatientWound_Code");
        });

        modelBuilder.Entity<PatientWoundDraft>(entity =>
        {
            entity.HasIndex(e => e.PatientID_FK, "IX_PatientWoundDraft_PatientID_FK");

            entity.HasIndex(e => e.PatientWoundID_FK, "IX_PatientWoundDraft_PatientWoundID_FK");

            entity.HasIndex(e => e.PatientWoundVisitID_FK, "IX_PatientWoundDraft_PatientWoundVisitID_FK");

            entity.HasIndex(e => e.WoundStatusID_FK, "IX_PatientWoundDraft_WoundStatusID_FK");

            entity.Property(e => e.AnnotatedImage).HasMaxLength(50);
            entity.Property(e => e.AnnotatedImageMeasurement).HasMaxLength(50);
            entity.Property(e => e.AssignDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.AverageDepth).HasPrecision(5, 2);
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DepthEighty).HasPrecision(5, 2);
            entity.Property(e => e.DepthForty).HasPrecision(5, 2);
            entity.Property(e => e.DepthImage).HasMaxLength(50);
            entity.Property(e => e.DepthImageMeasurement).HasMaxLength(50);
            entity.Property(e => e.DepthMax).HasPrecision(5, 2);
            entity.Property(e => e.DepthNans).HasPrecision(5, 2);
            entity.Property(e => e.DepthNegative).HasPrecision(5, 2);
            entity.Property(e => e.DepthSixty).HasPrecision(5, 2);
            entity.Property(e => e.DepthTwenty).HasPrecision(5, 2);
            entity.Property(e => e.Edges).HasMaxLength(50);
            entity.Property(e => e.Epithelizing).HasPrecision(5, 2);
            entity.Property(e => e.Exudate).HasMaxLength(50);
            entity.Property(e => e.ExudateNature).HasMaxLength(50);
            entity.Property(e => e.ExudatedConsistency).HasMaxLength(50);
            entity.Property(e => e.Granulation).HasPrecision(5, 2);
            entity.Property(e => e.ImageUpload).HasMaxLength(50);
            entity.Property(e => e.MaximumDepth).HasPrecision(5, 2);
            entity.Property(e => e.MeasurementUpdateRemark).HasMaxLength(255);
            entity.Property(e => e.MinimumDepth).HasPrecision(5, 2);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Necrosis).HasPrecision(5, 2);
            entity.Property(e => e.NextReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.NextTreatmentDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.OccurDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.OriginalImage).HasMaxLength(50);
            entity.Property(e => e.OriginalImageMeasurement).HasMaxLength(50);
            entity.Property(e => e.Others).HasPrecision(5, 2);
            entity.Property(e => e.PeriWound).HasMaxLength(50);
            entity.Property(e => e.Perimeter).HasPrecision(5, 2);
            entity.Property(e => e.Rotation).HasPrecision(5, 2);
            entity.Property(e => e.SeenDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Site).HasMaxLength(50);
            entity.Property(e => e.Size).HasPrecision(5, 2);
            entity.Property(e => e.SizeDepth).HasPrecision(5, 2);
            entity.Property(e => e.SizeDepth_Auto).HasPrecision(5, 2);
            entity.Property(e => e.SizeLength).HasPrecision(5, 2);
            entity.Property(e => e.SizeLength_Auto).HasPrecision(5, 2);
            entity.Property(e => e.SizeWidth).HasPrecision(5, 2);
            entity.Property(e => e.SizeWidth_Auto).HasPrecision(5, 2);
            entity.Property(e => e.Slough).HasPrecision(5, 2);
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.SurfaceArea).HasPrecision(5, 2);
            entity.Property(e => e.TCUpdateRemark).HasMaxLength(255);
            entity.Property(e => e.UnderMining).HasMaxLength(255);
            entity.Property(e => e.VisitDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Volume).HasPrecision(5, 2);
            entity.Property(e => e.WoundBedImage).HasMaxLength(50);
            entity.Property(e => e.WoundBedImageMeasurement).HasMaxLength(50);
            entity.Property(e => e.woundOverlaysImage).HasMaxLength(50);
            entity.Property(e => e.woundOverlaysImageDistance).HasPrecision(5, 2);

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.PatientWoundDraft)
                .HasForeignKey(d => d.PatientID_FK)
                .HasConstraintName("FK_PatientWoundDraft_Patient");

            entity.HasOne(d => d.PatientWoundID_FKNavigation).WithMany(p => p.PatientWoundDraft)
                .HasForeignKey(d => d.PatientWoundID_FK)
                .HasConstraintName("FK_PatientWoundDraft_PatientWound");

            entity.HasOne(d => d.PatientWoundVisitID_FKNavigation).WithMany(p => p.PatientWoundDraft)
                .HasForeignKey(d => d.PatientWoundVisitID_FK)
                .HasConstraintName("FK_PatientWoundDraft_PatientWoundVisit");

            entity.HasOne(d => d.WoundStatusID_FKNavigation).WithMany(p => p.PatientWoundDraft)
                .HasForeignKey(d => d.WoundStatusID_FK)
                .HasConstraintName("FK_PatientWoundDraft_Code");
        });

        modelBuilder.Entity<PatientWoundDraftTreatmentList>(entity =>
        {
            entity.HasKey(e => e.PatientWoundDraftTListID);

            entity.HasIndex(e => e.PatientWoundDraftID_FK, "IX_PatientWoundDraftTreatmentList_PatientWoundDraftID_FK");

            entity.HasIndex(e => e.TListItemID_FK, "IX_PatientWoundDraftTreatmentList_TListItemID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Remarks).HasMaxLength(500);

            entity.HasOne(d => d.PatientWoundDraftID_FKNavigation).WithMany(p => p.PatientWoundDraftTreatmentList)
                .HasForeignKey(d => d.PatientWoundDraftID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientWoundDraftTreatmentList_PatientWoundDraft");

            entity.HasOne(d => d.TListItemID_FKNavigation).WithMany(p => p.PatientWoundDraftTreatmentList)
                .HasForeignKey(d => d.TListItemID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientWoundDraftTreatmentList_TreatmentListItem");
        });

        modelBuilder.Entity<PatientWoundDraftTreatmentObjectives>(entity =>
        {
            entity.HasKey(e => new { e.PatientWoundDraftID_FK, e.ObjectiveID_FK });

            entity.HasIndex(e => e.ObjectiveID_FK, "IX_PatientWoundDraftTreatmentObjectives_ObjectiveID_FK");

            entity.HasOne(d => d.ObjectiveID_FKNavigation).WithMany(p => p.PatientWoundDraftTreatmentObjectives)
                .HasForeignKey(d => d.ObjectiveID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientWoundDraftTreatmentObjectives_Code");

            entity.HasOne(d => d.PatientWoundDraftID_FKNavigation).WithMany(p => p.PatientWoundDraftTreatmentObjectives)
                .HasForeignKey(d => d.PatientWoundDraftID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientWoundDraftTreatmentObjectives_PatientWoundDraft");
        });

        modelBuilder.Entity<PatientWoundReviewBy>(entity =>
        {
            entity.HasKey(e => e.PatientWoundReviewById).HasName("PK_THK_ICP_InputFrom");

            entity.HasIndex(e => e.PatientWoundVisitID_FK, "IX_PatientWoundReviewBy_PatientWoundVisitID_FK");

            entity.HasIndex(e => e.UserId_FK, "IX_PatientWoundReviewBy_UserId_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ReviewDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.PatientWoundVisitID_FKNavigation).WithMany(p => p.PatientWoundReviewBy)
                .HasForeignKey(d => d.PatientWoundVisitID_FK)
                .HasConstraintName("FK_PatientWoundReviewBy_PatientWoundVisit");

            entity.HasOne(d => d.UserId_FKNavigation).WithMany(p => p.PatientWoundReviewBy)
                .HasForeignKey(d => d.UserId_FK)
                .HasConstraintName("FK_PatientWoundReviewBy_Users");
        });

        modelBuilder.Entity<PatientWoundVisit>(entity =>
        {
            entity.HasIndex(e => e.AssignedToID_FK, "IX_PatientWoundVisit_AssignedToID_FK");

            entity.HasIndex(e => e.CareReportID_FK, "IX_PatientWoundVisit_CareReportID_FK");

            entity.HasIndex(e => e.InitialCareAssessmentID_FK, "IX_PatientWoundVisit_InitialCareAssessmentID_FK");

            entity.HasIndex(e => e.PatientWoundID_FK, "IX_PatientWoundVisit_PatientWoundID_FK");

            entity.HasIndex(e => e.ReferID_FK, "IX_PatientWoundVisit_ReferID_FK");

            entity.HasIndex(e => e.VitalSignID_FK, "IX_PatientWoundVisit_VitalSignID_FK");

            entity.Property(e => e.AnnotatedImageMeasurement).HasMaxLength(50);
            entity.Property(e => e.Appearance).HasMaxLength(50);
            entity.Property(e => e.AverageDepth)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0.0");
            entity.Property(e => e.CleansingSolutionUsed).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DESIGN_R_Depth).HasMaxLength(50);
            entity.Property(e => e.Debridement).HasMaxLength(50);
            entity.Property(e => e.DepthEighty).HasPrecision(5, 2);
            entity.Property(e => e.DepthForty).HasPrecision(5, 2);
            entity.Property(e => e.DepthImage).HasMaxLength(255);
            entity.Property(e => e.DepthImageMeasurement).HasMaxLength(50);
            entity.Property(e => e.DepthMax).HasPrecision(5, 2);
            entity.Property(e => e.DepthNans).HasPrecision(5, 2);
            entity.Property(e => e.DepthNegative).HasPrecision(5, 2);
            entity.Property(e => e.DepthSixty).HasPrecision(5, 2);
            entity.Property(e => e.DepthTwenty).HasPrecision(5, 2);
            entity.Property(e => e.Edges).HasMaxLength(50);
            entity.Property(e => e.Exudate).HasMaxLength(50);
            entity.Property(e => e.ExudateSubInfo).HasMaxLength(50);
            entity.Property(e => e.ExudateSubInfo2).HasMaxLength(50);
            entity.Property(e => e.ImageUpload).HasMaxLength(50);
            entity.Property(e => e.IsDraft).HasDefaultValue(false);
            entity.Property(e => e.IsRedness).HasDefaultValue(false);
            entity.Property(e => e.IsSmell).HasDefaultValue(false);
            entity.Property(e => e.IsSwelling).HasDefaultValue(false);
            entity.Property(e => e.IsWarmToTouch).HasDefaultValue(false);
            entity.Property(e => e.MaximumDepth)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0.0");
            entity.Property(e => e.MeasurementUpdateRemark).HasMaxLength(255);
            entity.Property(e => e.MinimumDepth)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0.0");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.NextReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.NextTreatmentDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.OriginalImageMeasurement).HasMaxLength(50);
            entity.Property(e => e.PeriWound).HasMaxLength(50);
            entity.Property(e => e.Perimeter)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0.0");
            entity.Property(e => e.ProgressiveWoundStage).HasMaxLength(50);
            entity.Property(e => e.Rotation).HasPrecision(5, 2);
            entity.Property(e => e.Size)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0.0");
            entity.Property(e => e.SizeDepth)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0.0");
            entity.Property(e => e.SizeDepth_Auto).HasPrecision(5, 2);
            entity.Property(e => e.SizeLength)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0.0");
            entity.Property(e => e.SizeLength_Auto).HasPrecision(5, 2);
            entity.Property(e => e.SizeWidth)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0.0");
            entity.Property(e => e.SizeWidth_Auto).HasPrecision(5, 2);
            entity.Property(e => e.Smell).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(15);
            entity.Property(e => e.Suffering).HasDefaultValue(0);
            entity.Property(e => e.SurfaceArea)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0.0");
            entity.Property(e => e.TCUpdateRemark).HasMaxLength(255);
            entity.Property(e => e.TC_Auto_Epithelizing)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0.0");
            entity.Property(e => e.TC_Auto_Granulation)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0.0");
            entity.Property(e => e.TC_Auto_Necrosis)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0.0");
            entity.Property(e => e.TC_Auto_Others)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0.0");
            entity.Property(e => e.TC_Auto_Slough)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0.0");
            entity.Property(e => e.TC_Epithelizing)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0.0");
            entity.Property(e => e.TC_Granulation)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0.0");
            entity.Property(e => e.TC_IsAccept).HasDefaultValue(false);
            entity.Property(e => e.TC_Necrosis)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0.0");
            entity.Property(e => e.TC_Others)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0.0");
            entity.Property(e => e.TC_Slough)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0.0");
            entity.Property(e => e.Title).HasMaxLength(30);
            entity.Property(e => e.UnderMining).HasMaxLength(255);
            entity.Property(e => e.UnderMiningDepth)
                .HasPrecision(4, 1)
                .HasDefaultValueSql("0.0");
            entity.Property(e => e.VisitDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Volume)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0.0");
            entity.Property(e => e.WoundBedImageMeasurement).HasMaxLength(50);
            entity.Property(e => e.WoundSubType).HasMaxLength(50);
            entity.Property(e => e.WoundType).HasMaxLength(50);
            entity.Property(e => e.WoundTypeOther).HasMaxLength(50);
            entity.Property(e => e.temperature).HasPrecision(5, 2);
            entity.Property(e => e.woundOverlaysImage).HasMaxLength(50);
            entity.Property(e => e.woundOverlaysImageDistance).HasPrecision(5, 2);

            entity.HasOne(d => d.AssignedToID_FKNavigation).WithMany(p => p.PatientWoundVisit)
                .HasForeignKey(d => d.AssignedToID_FK)
                .HasConstraintName("FK_PatientWoundVisit_Users");

            entity.HasOne(d => d.CareReportID_FKNavigation).WithMany(p => p.PatientWoundVisit)
                .HasForeignKey(d => d.CareReportID_FK)
                .HasConstraintName("FK_PatientWoundVisit_CareReport");

            entity.HasOne(d => d.InitialCareAssessmentID_FKNavigation).WithMany(p => p.PatientWoundVisit)
                .HasForeignKey(d => d.InitialCareAssessmentID_FK)
                .HasConstraintName("FK_PatientWoundVisit_InitialCareAssessment");

            entity.HasOne(d => d.PatientWoundID_FKNavigation).WithMany(p => p.PatientWoundVisit)
                .HasForeignKey(d => d.PatientWoundID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientWoundVisit_PatientWound");

            entity.HasOne(d => d.ReferID_FKNavigation).WithMany(p => p.InverseReferID_FKNavigation)
                .HasForeignKey(d => d.ReferID_FK)
                .HasConstraintName("FK_PatientWoundVisit_PatientWoundVisit");

            entity.HasOne(d => d.VitalSignID_FKNavigation).WithMany(p => p.PatientWoundVisit)
                .HasForeignKey(d => d.VitalSignID_FK)
                .HasConstraintName("FK_PatientWoundVisit_VitalSigns");
        });

        modelBuilder.Entity<PatientWoundVisitAppearance>(entity =>
        {
            entity.HasKey(e => new { e.PatientWoundVisitID_FK, e.CodeID_FK });

            entity.HasIndex(e => e.CodeID_FK, "IX_PatientWoundVisitAppearance_CodeID_FK");

            entity.HasOne(d => d.CodeID_FKNavigation).WithMany(p => p.PatientWoundVisitAppearance)
                .HasForeignKey(d => d.CodeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientWoundVisitAppearance_Code");

            entity.HasOne(d => d.PatientWoundVisitID_FKNavigation).WithMany(p => p.PatientWoundVisitAppearance)
                .HasForeignKey(d => d.PatientWoundVisitID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientWoundVisitAppearance_PatientWoundVisit");
        });

        modelBuilder.Entity<PatientWoundVisitCleansingItem>(entity =>
        {
            entity.HasKey(e => new { e.PatientWoundVisitID_FK, e.CodeID_FK });

            entity.HasIndex(e => e.CodeID_FK, "IX_PatientWoundVisitCleansingItem_CodeID_FK");

            entity.HasOne(d => d.CodeID_FKNavigation).WithMany(p => p.PatientWoundVisitCleansingItem)
                .HasForeignKey(d => d.CodeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientWoundVisitCleansingItem_Code");

            entity.HasOne(d => d.PatientWoundVisitID_FKNavigation).WithMany(p => p.PatientWoundVisitCleansingItem)
                .HasForeignKey(d => d.PatientWoundVisitID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientWoundVisitCleansingItem_PatientWoundVisit");
        });

        modelBuilder.Entity<PatientWoundVisitClinician>(entity =>
        {
            entity.HasIndex(e => e.ExternalDoctorID_FK, "IX_PatientWoundVisitClinician_ExternalDoctorID_FK");

            entity.HasIndex(e => e.PatientWoundVisitID_FK, "IX_PatientWoundVisitClinician_PatientWoundVisitID_FK");

            entity.HasIndex(e => e.UserID_FK, "IX_PatientWoundVisitClinician_UserID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.ExternalDoctorID_FKNavigation).WithMany(p => p.PatientWoundVisitClinician)
                .HasForeignKey(d => d.ExternalDoctorID_FK)
                .HasConstraintName("FK_PatientWoundVisitClinician_ExternalDoctor");

            entity.HasOne(d => d.PatientWoundVisitID_FKNavigation).WithMany(p => p.PatientWoundVisitClinician)
                .HasForeignKey(d => d.PatientWoundVisitID_FK)
                .HasConstraintName("FK_PatientWoundVisitClinician_PatientWoundVisit");

            entity.HasOne(d => d.UserID_FKNavigation).WithMany(p => p.PatientWoundVisitClinician)
                .HasForeignKey(d => d.UserID_FK)
                .HasConstraintName("FK_PatientWoundVisitClinician_Users");
        });

        modelBuilder.Entity<PatientWoundVisitTreatment>(entity =>
        {
            entity.HasIndex(e => e.ItemID_FK, "IX_PatientWoundVisitTreatment_ItemID_FK");

            entity.HasIndex(e => e.PatientWoundVisitID_FK, "IX_PatientWoundVisitTreatment_PatientWoundVisitID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.ItemID_FKNavigation).WithMany(p => p.PatientWoundVisitTreatment)
                .HasForeignKey(d => d.ItemID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientWoundVisitTreatment_Item");

            entity.HasOne(d => d.PatientWoundVisitID_FKNavigation).WithMany(p => p.PatientWoundVisitTreatment)
                .HasForeignKey(d => d.PatientWoundVisitID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientWoundVisitTreatment_PatientWoundVisit");
        });

        modelBuilder.Entity<PatientWoundVisitTreatmentList>(entity =>
        {
            entity.HasKey(e => e.PatientWoundVisitTListID);

            entity.HasIndex(e => e.PatientWoundVisitID_FK, "IX_PatientWoundVisitTreatmentList_PatientWoundVisitID_FK");

            entity.HasIndex(e => e.TListItemID_FK, "IX_PatientWoundVisitTreatmentList_TListItemID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Remarks).HasMaxLength(500);

            entity.HasOne(d => d.PatientWoundVisitID_FKNavigation).WithMany(p => p.PatientWoundVisitTreatmentList)
                .HasForeignKey(d => d.PatientWoundVisitID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientWoundVisitTreatmentList_PatientWoundVisit");

            entity.HasOne(d => d.TListItemID_FKNavigation).WithMany(p => p.PatientWoundVisitTreatmentList)
                .HasForeignKey(d => d.TListItemID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientWoundVisitTreatmentList_TreatmentListItem");
        });

        modelBuilder.Entity<PatientWoundVisitTreatmentObjectives>(entity =>
        {
            entity.HasKey(e => new { e.PatientWoundVisitID_FK, e.ObjectiveID_FK });

            entity.HasIndex(e => e.ObjectiveID_FK, "IX_PatientWoundVisitTreatmentObjectives_ObjectiveID_FK");

            entity.HasOne(d => d.ObjectiveID_FKNavigation).WithMany(p => p.PatientWoundVisitTreatmentObjectives)
                .HasForeignKey(d => d.ObjectiveID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientWoundVisitTreatmentObjectives_Code");

            entity.HasOne(d => d.PatientWoundVisitID_FKNavigation).WithMany(p => p.PatientWoundVisitTreatmentObjectives)
                .HasForeignKey(d => d.PatientWoundVisitID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientWoundVisitTreatmentObjectives_PatientWoundVisit");
        });

        modelBuilder.Entity<ProblemList>(entity =>
        {
            entity.HasIndex(e => e.DiseaseID_FK, "IX_ProblemList_DiseaseID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ProblemInfo).HasMaxLength(255);

            entity.HasOne(d => d.DiseaseID_FKNavigation).WithMany(p => p.ProblemList)
                .HasForeignKey(d => d.DiseaseID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProblemList_Disease");
        });

        modelBuilder.Entity<ProblemListGoal>(entity =>
        {
            entity.HasIndex(e => e.OperatorID, "IX_ProblemListGoal_OperatorID");

            entity.HasIndex(e => e.ProblemListID_FK, "IX_ProblemListGoal_ProblemListID_FK");

            entity.HasIndex(e => e.ScoreTypeID, "IX_ProblemListGoal_ScoreTypeID");

            entity.Property(e => e.Goal).HasMaxLength(500);

            entity.HasOne(d => d.Operator).WithMany(p => p.ProblemListGoalOperator)
                .HasForeignKey(d => d.OperatorID)
                .HasConstraintName("FK_ProblemListGoal_Operator");

            entity.HasOne(d => d.ProblemListID_FKNavigation).WithMany(p => p.ProblemListGoal)
                .HasForeignKey(d => d.ProblemListID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProblemListGoal_ProblemList");

            entity.HasOne(d => d.ScoreType).WithMany(p => p.ProblemListGoalScoreType)
                .HasForeignKey(d => d.ScoreTypeID)
                .HasConstraintName("FK_ProblemListGoal_ScoreType");
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.HasKey(e => e.ReceiptID).HasName("PK__Receipt__CC08C400E8522DFD");

            entity.HasIndex(e => e.CreatedBy_FK, "IX_Receipt_CreatedBy_FK");

            entity.HasIndex(e => e.CurrencyID_FK, "IX_Receipt_CurrencyID_FK");

            entity.HasIndex(e => e.ModifiedBy_FK, "IX_Receipt_ModifiedBy_FK");

            entity.HasIndex(e => e.PatientID_FK, "IX_Receipt_PatientID_FK");

            entity.HasIndex(e => e.PaymentModeID_FK, "IX_Receipt_PaymentModeID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.GroupNumber).HasMaxLength(10);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ReceiptDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ReceiptNumber).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalAmt).HasPrecision(18, 2);

            entity.HasOne(d => d.CreatedBy_FKNavigation).WithMany(p => p.ReceiptCreatedBy_FKNavigation)
                .HasForeignKey(d => d.CreatedBy_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receipt_Users");

            entity.HasOne(d => d.CurrencyID_FKNavigation).WithMany(p => p.ReceiptCurrencyID_FKNavigation)
                .HasForeignKey(d => d.CurrencyID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receipt_Code1");

            entity.HasOne(d => d.ModifiedBy_FKNavigation).WithMany(p => p.ReceiptModifiedBy_FKNavigation)
                .HasForeignKey(d => d.ModifiedBy_FK)
                .HasConstraintName("FK_Receipt_Users1");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.Receipt)
                .HasForeignKey(d => d.PatientID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receipt_Patient");

            entity.HasOne(d => d.PaymentModeID_FKNavigation).WithMany(p => p.ReceiptPaymentModeID_FKNavigation)
                .HasForeignKey(d => d.PaymentModeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receipt_Code");
        });

        modelBuilder.Entity<ReceiptForInvoice>(entity =>
        {
            entity.HasKey(e => e.ReceiptForInvoiceID).HasName("PK__ReceiptF__AAA44B1B702F8EEB");

            entity.HasIndex(e => e.BillingInvoiceID_FK, "IX_ReceiptForInvoice_BillingInvoiceID_FK");

            entity.HasIndex(e => e.ReceiptID_FK, "IX_ReceiptForInvoice_ReceiptID_FK");

            entity.Property(e => e.Amt).HasPrecision(18, 2);

            entity.HasOne(d => d.BillingInvoiceID_FKNavigation).WithMany(p => p.ReceiptForInvoice)
                .HasForeignKey(d => d.BillingInvoiceID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceiptForInv_Inv");

            entity.HasOne(d => d.ReceiptID_FKNavigation).WithMany(p => p.ReceiptForInvoice)
                .HasForeignKey(d => d.ReceiptID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceiptForInv_Receipt");
        });

        modelBuilder.Entity<RecentView>(entity =>
        {
            entity.HasKey(e => new { e.UserID_FK, e.PatientID_FK });

            entity.HasIndex(e => e.PatientID_FK, "IX_RecentView_PatientID_FK");

            entity.Property(e => e.DateView).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.RecentView)
                .HasForeignKey(d => d.PatientID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecentView_Patient");

            entity.HasOne(d => d.UserID_FKNavigation).WithMany(p => p.RecentView)
                .HasForeignKey(d => d.UserID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecentView_Users");
        });

        modelBuilder.Entity<RegisteredDevice>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.DeviceID).ValueGeneratedOnAdd();
            entity.Property(e => e.DeviceToken).HasMaxLength(300);
        });

        modelBuilder.Entity<RegisteredDeviceV2>(entity =>
        {
            entity.HasKey(e => e.RegisteredDeviceID);

            entity.Property(e => e.AppName).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DeviceId).HasMaxLength(255);
            entity.Property(e => e.DeviceName).HasMaxLength(255);
            entity.Property(e => e.DeviceToken).HasMaxLength(255);
            entity.Property(e => e.DeviceType).HasMaxLength(255);
            entity.Property(e => e.FirstRegisterIpAddress).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Version).HasMaxLength(50);
        });

        modelBuilder.Entity<ResidentAssessmentCategory>(entity =>
        {
            entity.Property(e => e.Category1Description).HasMaxLength(500);
            entity.Property(e => e.Category1Recommendation).HasMaxLength(500);
            entity.Property(e => e.Category2Description).HasMaxLength(500);
            entity.Property(e => e.Category2Recommendation).HasMaxLength(500);
            entity.Property(e => e.Category3Description).HasMaxLength(500);
            entity.Property(e => e.Category3Recommendation).HasMaxLength(500);
            entity.Property(e => e.Category4Description).HasMaxLength(500);
            entity.Property(e => e.Category4Recommendation).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasIndex(e => e.CodeId, "IX_Resource_CodeId");

            entity.HasIndex(e => e.LanguageId, "IX_Resource_LanguageId");

            entity.HasOne(d => d.Code).WithMany(p => p.Resource)
                .HasForeignKey(d => d.CodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resource_Code");

            entity.HasOne(d => d.Language).WithMany(p => p.Resource)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resource_Language");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.RoleId).ValueGeneratedNever();
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.OptionText)
                .HasMaxLength(250)
                .HasDefaultValueSql("''::character varying");
            entity.Property(e => e.OptionType)
                .HasMaxLength(1)
                .HasDefaultValueSql("''::character varying");
            entity.Property(e => e.OptionValue)
                .HasMaxLength(250)
                .HasDefaultValueSql("''::character varying");
            entity.Property(e => e.RoleDescription)
                .HasMaxLength(250)
                .HasDefaultValueSql("''::character varying");
        });

        modelBuilder.Entity<ScheduledTasks>(entity =>
        {
            entity.HasKey(e => e.ScheduleId);

            entity.Property(e => e.ScheduleId).ValueGeneratedNever();
            entity.Property(e => e.IntervalType).HasMaxLength(1);
            entity.Property(e => e.LastRun).HasColumnType("timestamp without time zone");
            entity.Property(e => e.NextRun).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PerformTask)
                .HasMaxLength(1)
                .HasDefaultValueSql("'D'::character varying");
            entity.Property(e => e.ScheduleDescription)
                .HasMaxLength(200)
                .HasDefaultValueSql("''::character varying");
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasDefaultValueSql("''::character varying");
            entity.Property(e => e.TimeEnd).HasColumnType("timestamp without time zone");
            entity.Property(e => e.TimeStart).HasColumnType("timestamp without time zone");
            entity.Property(e => e.WeekDays)
                .HasMaxLength(10)
                .HasDefaultValueSql("''::character varying");
        });

        modelBuilder.Entity<ServiceForBilling>(entity =>
        {
            entity.HasIndex(e => e.CategoryID_FK, "IX_ServiceForBilling_CategoryID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Duration1).HasMaxLength(50);
            entity.Property(e => e.Duration2).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.CategoryID_FKNavigation).WithMany(p => p.ServiceForBilling)
                .HasForeignKey(d => d.CategoryID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceForBilling_Code");
        });

        modelBuilder.Entity<ServiceForBillingCost>(entity =>
        {
            entity.HasIndex(e => e.CurrencyID_FK, "IX_ServiceForBillingCost_CurrencyID_FK");

            entity.HasIndex(e => e.ServiceForBillingID_FK, "IX_ServiceForBillingCost_ServiceForBillingID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UnitCost).HasPrecision(18, 2);

            entity.HasOne(d => d.CurrencyID_FKNavigation).WithMany(p => p.ServiceForBillingCost)
                .HasForeignKey(d => d.CurrencyID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceForBillingCost_Code");

            entity.HasOne(d => d.ServiceForBillingID_FKNavigation).WithMany(p => p.ServiceForBillingCost)
                .HasForeignKey(d => d.ServiceForBillingID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceForBillingCost_ServiceForBilling");
        });

        modelBuilder.Entity<ServiceSkillset>(entity =>
        {
            entity.HasKey(e => new { e.ServiceID_FK, e.SkillsetID_FK });

            entity.HasIndex(e => e.SkillsetID_FK, "IX_ServiceSkillset_SkillsetID_FK");

            entity.HasOne(d => d.ServiceID_FKNavigation).WithMany(p => p.ServiceSkillsetServiceID_FKNavigation)
                .HasForeignKey(d => d.ServiceID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceSkillset_Code1");

            entity.HasOne(d => d.SkillsetID_FKNavigation).WithMany(p => p.ServiceSkillsetSkillsetID_FKNavigation)
                .HasForeignKey(d => d.SkillsetID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceSkillset_Code");
        });

        modelBuilder.Entity<SyncPatientLog>(entity =>
        {
            entity.HasKey(e => e.SyncLogId);

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<SyncWoundLog>(entity =>
        {
            entity.HasKey(e => e.SyncLogId);

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<SyncWoundVisitLog>(entity =>
        {
            entity.HasKey(e => e.SyncLogId);

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<SysConfig>(entity =>
        {
            entity.HasKey(e => e.ConfigName);

            entity.Property(e => e.ConfigName).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<SystemForDisease>(entity =>
        {
            entity.HasKey(e => e.SystemID);

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.System).HasMaxLength(255);
        });

        modelBuilder.Entity<TD_WoundAssessmentFactor>(entity =>
        {
            entity.HasKey(e => new { e.TD_WoundAssessmentID_FK, e.CodeID_FK });

            entity.HasIndex(e => e.CodeID_FK, "IX_TD_WoundAssessmentFactor_CodeID_FK");

            entity.HasOne(d => d.CodeID_FKNavigation).WithMany(p => p.TD_WoundAssessmentFactor)
                .HasForeignKey(d => d.CodeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TD_WoundAssessmentFactor_Code");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasIndex(e => e.ActionTypeID_FK, "IX_Task_ActionTypeID_FK");

            entity.HasIndex(e => e.CreatedBy_FK, "IX_Task_CreatedBy_FK");

            entity.HasIndex(e => e.DosageID_FK, "IX_Task_DosageID_FK");

            entity.HasIndex(e => e.FrequencyID_FK, "IX_Task_FrequencyID_FK");

            entity.HasIndex(e => e.InitialCareAssessmentID_FK, "IX_Task_InitialCareAssessmentID_FK");

            entity.HasIndex(e => e.MedicationID_FK, "IX_Task_MedicationID_FK");

            entity.HasIndex(e => e.PatientID_FK, "IX_Task_PatientID_FK");

            entity.HasIndex(e => new { e.ReferenceType, e.ReferenceID }, "IX_Task_Reference");

            entity.HasIndex(e => e.UserCategory_FK, "IX_Task_UserCategory_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.EndDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.H2OFlushingMLS).HasPrecision(4);
            entity.Property(e => e.Location).HasMaxLength(800);
            entity.Property(e => e.MedicationInstructions).HasMaxLength(255);
            entity.Property(e => e.MilkFeedVolumeMLS).HasPrecision(4);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.OtherLocation).HasMaxLength(800);
            entity.Property(e => e.ReferenceType).HasMaxLength(30);
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Supplement).HasMaxLength(255);

            entity.HasOne(d => d.ActionTypeID_FKNavigation).WithMany(p => p.TaskActionTypeID_FKNavigation)
                .HasForeignKey(d => d.ActionTypeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_Code");

            entity.HasOne(d => d.CreatedBy_FKNavigation).WithMany(p => p.Task)
                .HasForeignKey(d => d.CreatedBy_FK)
                .HasConstraintName("FK_Task_Users");

            entity.HasOne(d => d.DosageID_FKNavigation).WithMany(p => p.TaskDosageID_FKNavigation)
                .HasForeignKey(d => d.DosageID_FK)
                .HasConstraintName("FK_Task_Code2");

            entity.HasOne(d => d.FrequencyID_FKNavigation).WithMany(p => p.TaskFrequencyID_FKNavigation)
                .HasForeignKey(d => d.FrequencyID_FK)
                .HasConstraintName("FK_Task_Code1");

            entity.HasOne(d => d.InitialCareAssessmentID_FKNavigation).WithMany(p => p.Task)
                .HasForeignKey(d => d.InitialCareAssessmentID_FK)
                .HasConstraintName("FK_Task_InitialCareAssessment");

            entity.HasOne(d => d.MedicationID_FKNavigation).WithMany(p => p.TaskMedicationID_FKNavigation)
                .HasForeignKey(d => d.MedicationID_FK)
                .HasConstraintName("FK_Task_Code3");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.Task)
                .HasForeignKey(d => d.PatientID_FK)
                .HasConstraintName("FK_Task_Patient");

            entity.HasOne(d => d.UserCategory_FKNavigation).WithMany(p => p.Task)
                .HasForeignKey(d => d.UserCategory_FK)
                .HasConstraintName("FK_Task_UserCategory");
        });

        modelBuilder.Entity<TaskFileAttachment>(entity =>
        {
            entity.HasKey(e => e.FileAttachmentID);

            entity.HasIndex(e => e.TaskID_FK, "IX_TaskFileAttachment_TaskID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.FileName).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.TaskID_FKNavigation).WithMany(p => p.TaskFileAttachment)
                .HasForeignKey(d => d.TaskID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskFileAttachment_Task");
        });

        modelBuilder.Entity<TaskServicesRequired>(entity =>
        {
            entity.HasKey(e => new { e.TaskID_FK, e.CodeID_FK });

            entity.HasIndex(e => e.CodeID_FK, "IX_TaskServicesRequired_CodeID_FK");

            entity.HasOne(d => d.CodeID_FKNavigation).WithMany(p => p.TaskServicesRequired)
                .HasForeignKey(d => d.CodeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskServicesRequired_Code");

            entity.HasOne(d => d.TaskID_FKNavigation).WithMany(p => p.TaskServicesRequired)
                .HasForeignKey(d => d.TaskID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskServicesRequired_Task");
        });

        modelBuilder.Entity<TaskSpecificDate>(entity =>
        {
            entity.HasIndex(e => e.TaskID_FK, "IX_TaskSpecificDate_TaskID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.TaskDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.TaskID_FKNavigation).WithMany(p => p.TaskSpecificDate)
                .HasForeignKey(d => d.TaskID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskSpecificDate_Task");
        });

        modelBuilder.Entity<TaskUser>(entity =>
        {
            entity.HasIndex(e => e.TaskID_FK, "IX_TaskUser_TaskID_FK");

            entity.HasIndex(e => e.UserID_FK, "IX_TaskUser_UserID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UserType).HasMaxLength(20);

            entity.HasOne(d => d.TaskID_FKNavigation).WithMany(p => p.TaskUser)
                .HasForeignKey(d => d.TaskID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskUser_Task");

            entity.HasOne(d => d.UserID_FKNavigation).WithMany(p => p.TaskUser)
                .HasForeignKey(d => d.UserID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskUser_Users");
        });

        modelBuilder.Entity<TaskUserLog>(entity =>
        {
            entity.HasIndex(e => new { e.StartDate, e.EndDate, e.TaskID_FK }, "IX_TaskUserLog");

            entity.HasIndex(e => e.StartDate, "IX_TaskUserLog_1");

            entity.HasIndex(e => e.EndDate, "IX_TaskUserLog_2");

            entity.HasIndex(e => e.TaskID_FK, "IX_TaskUserLog_3");

            entity.HasIndex(e => e.UserID_FK, "IX_TaskUserLog_UserID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EndDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.StatusDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.TaskID_FKNavigation).WithMany(p => p.TaskUserLog)
                .HasForeignKey(d => d.TaskID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskUserLog_Task");

            entity.HasOne(d => d.UserID_FKNavigation).WithMany(p => p.TaskUserLog)
                .HasForeignKey(d => d.UserID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskUserLog_Users");
        });

        modelBuilder.Entity<TaskUserLogAttachment>(entity =>
        {
            entity.HasKey(e => e.FileAttachmentID);

            entity.HasIndex(e => e.TaskUserLogID_FK, "IX_TaskUserLogAttachment_TaskUserLogID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.FileName).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.TaskUserLogID_FKNavigation).WithMany(p => p.TaskUserLogAttachment)
                .HasForeignKey(d => d.TaskUserLogID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskUserLogAttachment_TaskUserLog");
        });

        modelBuilder.Entity<TeleconsultationRecording>(entity =>
        {
            entity.HasKey(e => e.RecordingID);

            entity.HasIndex(e => e.PatientID_FK, "IX_TeleconsultationRecording_PatientID_FK");

            entity.HasIndex(e => e.RecordingType_FK, "IX_TeleconsultationRecording_RecordingType_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EndTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Sid)
                .HasMaxLength(36)
                .IsFixedLength();
            entity.Property(e => e.StartTime).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.TeleconsultationRecording)
                .HasForeignKey(d => d.PatientID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeleconsultationRecording_Patient");

            entity.HasOne(d => d.RecordingType_FKNavigation).WithMany(p => p.TeleconsultationRecording)
                .HasForeignKey(d => d.RecordingType_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeleconsultationRecording_Code");
        });

        modelBuilder.Entity<TeleconsultationReport>(entity =>
        {
            entity.HasKey(e => e.TeleReportID);

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status).HasMaxLength(15);
        });

        modelBuilder.Entity<Thresholds>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Threshol__3213E83F6D225C2D");

            entity.Property(e => e.createdDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ews_max_1).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_2).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_3).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_4).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_5).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_6).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_7).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_1).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_2).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_3).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_4).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_5).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_6).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_7).HasPrecision(18, 2);
            entity.Property(e => e.maxValue).HasPrecision(18, 2);
            entity.Property(e => e.minValue).HasPrecision(18, 2);
            entity.Property(e => e.name).HasMaxLength(200);
            entity.Property(e => e.updatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<TreatmentListItem>(entity =>
        {
            entity.HasKey(e => e.TListItemID);

            entity.HasIndex(e => e.TListTypeID_FK, "IX_TreatmentListItem_TListTypeID_FK");

            entity.Property(e => e.Cost).HasPrecision(18, 2);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EndDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ItemBrand).HasMaxLength(255);
            entity.Property(e => e.ItemName).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.TListTypeID_FKNavigation).WithMany(p => p.TreatmentListItem)
                .HasForeignKey(d => d.TListTypeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TreatmentListItem_Code");
        });

        modelBuilder.Entity<TreatmentTOL>(entity =>
        {
            entity.HasKey(e => new { e.TreatmentTOLID, e.TListItemID_FK });

            entity.HasIndex(e => e.TListItemID_FK, "IX_TreatmentTOL_TListItemID_FK");

            entity.HasOne(d => d.TListItemID_FKNavigation).WithMany(p => p.TreatmentTOL)
                .HasForeignKey(d => d.TListItemID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TreatmentTOL_TreatmentListItem");
        });

        modelBuilder.Entity<Types>(entity =>
        {
            entity.HasKey(e => e.code).HasName("PK__Types__357D4CF8F524A549");

            entity.HasIndex(e => e.parentCode, "IX_Types_parentCode");

            entity.HasIndex(e => new { e.code, e.parentCode }, "idx_Types1");

            entity.Property(e => e.code).HasMaxLength(100);
            entity.Property(e => e.codeValue).HasMaxLength(200);
            entity.Property(e => e.created).HasColumnType("timestamp without time zone");
            entity.Property(e => e.parentCode).HasMaxLength(100);
            entity.Property(e => e.updated).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.parentCodeNavigation).WithMany(p => p.InverseparentCodeNavigation)
                .HasForeignKey(d => d.parentCode)
                .HasConstraintName("fk_Types_parentCode");
        });

        modelBuilder.Entity<UUIDLog>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UUID).HasMaxLength(255);
        });

        modelBuilder.Entity<UploadFile>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.FileName).HasMaxLength(100);
            entity.Property(e => e.FileType).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<UserAddress>(entity =>
        {
            entity.HasKey(e => e.UserLocationID);

            entity.HasIndex(e => e.UserID_FK, "IX_UserAddress_UserID_FK");

            entity.Property(e => e.Address1).HasMaxLength(255);
            entity.Property(e => e.Address2).HasMaxLength(255);
            entity.Property(e => e.Address3).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.PostalCode).HasMaxLength(255);

            entity.HasOne(d => d.UserID_FKNavigation).WithMany(p => p.UserAddress)
                .HasForeignKey(d => d.UserID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAddress_Users");
        });

        modelBuilder.Entity<UserBranch>(entity =>
        {
            entity.HasKey(e => new { e.UserID_FK, e.BranchID_FK });

            entity.HasIndex(e => e.BranchID_FK, "IX_UserBranch_BranchID_FK");

            entity.HasOne(d => d.BranchID_FKNavigation).WithMany(p => p.UserBranch)
                .HasForeignKey(d => d.BranchID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserBranch_Branch");

            entity.HasOne(d => d.UserID_FKNavigation).WithMany(p => p.UserBranch)
                .HasForeignKey(d => d.UserID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserBranch_Users");
        });

        modelBuilder.Entity<UserCategory>(entity =>
        {
            entity.HasIndex(e => e.UserCategoryOrganizationID_FK, "IX_UserCategory_UserCategoryOrganizationID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UserCategory1)
                .HasMaxLength(50)
                .HasColumnName("UserCategory");

            entity.HasOne(d => d.UserCategoryOrganizationID_FKNavigation).WithMany(p => p.UserCategory)
                .HasForeignKey(d => d.UserCategoryOrganizationID_FK)
                .HasConstraintName("FK_UserCategory_UserCategoryOrganizationID_FK");
        });

        modelBuilder.Entity<UserCategoryFacility>(entity =>
        {
            entity.HasKey(e => new { e.UserCategoryID_FK, e.FacilityID_FK });

            entity.HasIndex(e => e.FacilityID_FK, "IX_UserCategoryFacility_FacilityID_FK");

            entity.HasOne(d => d.FacilityID_FKNavigation).WithMany(p => p.UserCategoryFacility)
                .HasForeignKey(d => d.FacilityID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserCategoryFacility_Facility");

            entity.HasOne(d => d.UserCategoryID_FKNavigation).WithMany(p => p.UserCategoryFacility)
                .HasForeignKey(d => d.UserCategoryID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserCategoryFacility_UserCategory");
        });

        modelBuilder.Entity<UserCategoryParentChild>(entity =>
        {
            entity.HasKey(e => new { e.ParentUserCategoryID_FK, e.ChildUserCategoryID_FK });

            entity.HasIndex(e => e.ChildUserCategoryID_FK, "IX_UserCategoryParentChild_ChildUserCategoryID_FK");

            entity.HasOne(d => d.ChildUserCategoryID_FKNavigation).WithMany(p => p.UserCategoryParentChildChildUserCategoryID_FKNavigation)
                .HasForeignKey(d => d.ChildUserCategoryID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserCategoryParentChild_Child");

            entity.HasOne(d => d.ParentUserCategoryID_FKNavigation).WithMany(p => p.UserCategoryParentChildParentUserCategoryID_FKNavigation)
                .HasForeignKey(d => d.ParentUserCategoryID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserCategoryParentChild_Parent");
        });

        modelBuilder.Entity<UserCategoryRole>(entity =>
        {
            entity.HasKey(e => new { e.UserCategoryID_FK, e.RoleID_FK });

            entity.HasIndex(e => e.RoleID_FK, "IX_UserCategoryRole_RoleID_FK");

            entity.HasOne(d => d.RoleID_FKNavigation).WithMany(p => p.UserCategoryRole)
                .HasForeignKey(d => d.RoleID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserCategoryRole_Role");

            entity.HasOne(d => d.UserCategoryID_FKNavigation).WithMany(p => p.UserCategoryRole)
                .HasForeignKey(d => d.UserCategoryID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserCategoryRole_UserCategory");
        });

        modelBuilder.Entity<UserLanguage>(entity =>
        {
            entity.HasKey(e => new { e.UserID_FK, e.LanguageID_FK });

            entity.HasIndex(e => e.LanguageID_FK, "IX_UserLanguage_LanguageID_FK");

            entity.HasOne(d => d.LanguageID_FKNavigation).WithMany(p => p.UserLanguage)
                .HasForeignKey(d => d.LanguageID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserLanguage_Code");

            entity.HasOne(d => d.UserID_FKNavigation).WithMany(p => p.UserLanguage)
                .HasForeignKey(d => d.UserID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserLanguage_Users");
        });

        modelBuilder.Entity<UserOrganization>(entity =>
        {
            entity.HasKey(e => new { e.UserId_FK, e.CodeID_FK });

            entity.HasIndex(e => e.CodeID_FK, "IX_UserOrganization_CodeID_FK");

            entity.HasOne(d => d.CodeID_FKNavigation).WithMany(p => p.UserOrganization)
                .HasForeignKey(d => d.CodeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserOrganization_Code");

            entity.HasOne(d => d.UserId_FKNavigation).WithMany(p => p.UserOrganization)
                .HasForeignKey(d => d.UserId_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserOrganization_Users");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId_FK, e.RoleId_FK });

            entity.HasIndex(e => e.RoleId_FK, "IX_UserRole_RoleId_FK");

            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValueSql("''::character varying");

            entity.HasOne(d => d.RoleId_FKNavigation).WithMany(p => p.UserRole)
                .HasForeignKey(d => d.RoleId_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRole_Role");

            entity.HasOne(d => d.UserId_FKNavigation).WithMany(p => p.UserRole)
                .HasForeignKey(d => d.UserId_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRole_Users");
        });

        modelBuilder.Entity<UserSkillset>(entity =>
        {
            entity.HasKey(e => new { e.UserID_FK, e.CodeID_FK });

            entity.HasIndex(e => e.CodeID_FK, "IX_UserSkillset_CodeID_FK");

            entity.HasOne(d => d.CodeID_FKNavigation).WithMany(p => p.UserSkillset)
                .HasForeignKey(d => d.CodeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserSkillset_Code");

            entity.HasOne(d => d.UserID_FKNavigation).WithMany(p => p.UserSkillset)
                .HasForeignKey(d => d.UserID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserSkillset_Users");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasIndex(e => e.UserCategoryID_FK, "IX_UserType_UserCategoryID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ManpowerRate).HasPrecision(18, 2);
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.UserType1)
                .HasMaxLength(50)
                .HasColumnName("UserType");

            entity.HasOne(d => d.UserCategoryID_FKNavigation).WithMany(p => p.UserType)
                .HasForeignKey(d => d.UserCategoryID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserType_UserCategory");
        });

        modelBuilder.Entity<UserUserType>(entity =>
        {
            entity.HasKey(e => new { e.UserID_FK, e.UserTypeID_FK });

            entity.HasIndex(e => e.UserTypeID_FK, "IX_UserUserType_UserTypeID_FK");

            entity.HasOne(d => d.UserID_FKNavigation).WithMany(p => p.UserUserType)
                .HasForeignKey(d => d.UserID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserUserType_Users");

            entity.HasOne(d => d.UserTypeID_FKNavigation).WithMany(p => p.UserUserType)
                .HasForeignKey(d => d.UserTypeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserUserType_UserType");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.HasIndex(e => e.PatientID_FK, "IX_Users_PatientID_FK");

            entity.Property(e => e.Contact).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Designation).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.HasValidEmail).HasDefaultValue(true);
            entity.Property(e => e.LastActivityDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.LastLockoutDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.LastLoginDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.LastLogoutDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.LastPasswordChangedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.LocationNow1).HasMaxLength(255);
            entity.Property(e => e.LocationNow2).HasMaxLength(255);
            entity.Property(e => e.LocationNow3).HasMaxLength(255);
            entity.Property(e => e.LocationNowModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Photo).HasMaxLength(50);
            entity.Property(e => e.PostalCodeNow).HasMaxLength(10);
            entity.Property(e => e.PreviousPasswords).HasMaxLength(1000);
            entity.Property(e => e.PreviousPasswords2).HasMaxLength(100);
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.SessionKey).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(15);
            entity.Property(e => e.TokenID).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(60);

            entity.HasOne(d => d.PatientID_FKNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.PatientID_FK)
                .HasConstraintName("FK_Users_Patient");
        });

        modelBuilder.Entity<VitalSignDetails>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__VitalSig__3213E83FE42362D2");

            entity.HasIndex(e => e.vitalSignId, "IX_VitalSignDetails_vitalSignId");

            entity.HasIndex(e => e.vitalSignTypeId, "IX_VitalSignDetails_vitalSignTypeId");

            entity.Property(e => e.detailValue).HasPrecision(18, 2);

            entity.HasOne(d => d.vitalSign).WithMany(p => p.VitalSignDetails)
                .HasForeignKey(d => d.vitalSignId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_VitalSignDetails_vitalSignId");

            entity.HasOne(d => d.vitalSignType).WithMany(p => p.VitalSignDetails)
                .HasForeignKey(d => d.vitalSignTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_VitalSignDetails_vitalSignTypeId");
        });

        modelBuilder.Entity<VitalSignRelationships>(entity =>
        {
            entity.HasIndex(e => e.patientId, "IX_VitalSignRelationships_patientId");

            entity.HasIndex(e => e.thresholdId, "IX_VitalSignRelationships_thresholdId");

            entity.HasIndex(e => e.vitalSignTypeId, "IX_VitalSignRelationships_vitalSignTypeId");

            entity.HasOne(d => d.patient).WithMany(p => p.VitalSignRelationships)
                .HasForeignKey(d => d.patientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_VitalSignRelationship_patientId");

            entity.HasOne(d => d.threshold).WithMany(p => p.VitalSignRelationships)
                .HasForeignKey(d => d.thresholdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_VitalSignRelationship_thresholdId");

            entity.HasOne(d => d.vitalSignType).WithMany(p => p.VitalSignRelationships)
                .HasForeignKey(d => d.vitalSignTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_VitalSignRelationship_vitalSignTypeId");
        });

        modelBuilder.Entity<VitalSignTypeThreshold>(entity =>
        {
            entity.HasKey(e => e.VitalSignTypeID_FK);

            entity.HasIndex(e => e.VitalSignTypeID_FK, "IX_VitalSignTypeThreshold").IsUnique();

            entity.Property(e => e.VitalSignTypeID_FK).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ews_max_1).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_2).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_3).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_4).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_5).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_6).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_7).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_1).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_2).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_3).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_4).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_5).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_6).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_7).HasPrecision(18, 2);

            entity.HasOne(d => d.VitalSignTypeID_FKNavigation).WithOne(p => p.VitalSignTypeThreshold)
                .HasForeignKey<VitalSignTypeThreshold>(d => d.VitalSignTypeID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VitalSignTypeThreshold_VitalSignTypes");
        });

        modelBuilder.Entity<VitalSignTypes>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__VitalSig__3213E83F6F00CA79");

            entity.HasIndex(e => e.name, "idx_VitalSignTypes1");

            entity.Property(e => e.createdDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.name).HasMaxLength(200);
            entity.Property(e => e.updatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<VitalSigns>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__VitalSig__3213E83F2E0950CF");

            entity.HasIndex(e => e.patientId, "IX_VitalSigns_patientId");

            entity.Property(e => e.createdDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.source).HasMaxLength(200);
            entity.Property(e => e.updatedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.patient).WithMany(p => p.VitalSigns)
                .HasForeignKey(d => d.patientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_VitalSigns_patientId");
        });

        modelBuilder.Entity<WoundConsolidatedEmail>(entity =>
        {
            entity.HasIndex(e => e.MailSettingsID_FK, "IX_WoundConsolidatedEmail_MailSettingsID_FK");

            entity.HasIndex(e => e.PatientWoundVisitID_FK, "IX_WoundConsolidatedEmail_PatientWoundVisitID_FK");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifiedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.MailSettingsID_FKNavigation).WithMany(p => p.WoundConsolidatedEmail)
                .HasForeignKey(d => d.MailSettingsID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WoundConsolidatedEmail_MailSettings");

            entity.HasOne(d => d.PatientWoundVisitID_FKNavigation).WithMany(p => p.WoundConsolidatedEmail)
                .HasForeignKey(d => d.PatientWoundVisitID_FK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WoundConsolidatedEmail_PatientWoundVisit");
        });

        modelBuilder.Entity<WoundUserCategoryParentChild>(entity =>
        {
            entity.HasKey(e => new { e.ParentUserCategoryID_FK, e.ChildUserCategoryID_FK });
        });

        modelBuilder.Entity<vw_AmtAssessmentDue>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_AmtAssessmentDue");

            entity.Property(e => e.AssessmentName).HasMaxLength(200);
            entity.Property(e => e.DueDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.createdDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.source).HasMaxLength(200);
            entity.Property(e => e.updatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<vw_AmtCarePlanSetup>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_AmtCarePlanSetup");

            entity.Property(e => e.DiseaseName).HasMaxLength(255);
            entity.Property(e => e.DiseaseSubInfo).HasMaxLength(50);
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.System).HasMaxLength(255);
        });

        modelBuilder.Entity<vw_AssessmentDue>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_AssessmentDue");

            entity.Property(e => e.AssessmentName).HasMaxLength(200);
            entity.Property(e => e.DueDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.createdDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.source).HasMaxLength(200);
            entity.Property(e => e.updatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<vw_BradenScaleAssessmentDue>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_BradenScaleAssessmentDue");

            entity.Property(e => e.AssessmentName).HasMaxLength(200);
            entity.Property(e => e.DueDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.createdDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.source).HasMaxLength(200);
            entity.Property(e => e.updatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<vw_BradenScaleCarePlanSetup>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_BradenScaleCarePlanSetup");

            entity.Property(e => e.DiseaseName).HasMaxLength(255);
            entity.Property(e => e.DiseaseSubInfo).HasMaxLength(50);
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.System).HasMaxLength(255);
        });

        modelBuilder.Entity<vw_CarePlanSetup>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CarePlanSetup");

            entity.Property(e => e.DiseaseName).HasMaxLength(255);
            entity.Property(e => e.DiseaseSubInfo).HasMaxLength(50);
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.System).HasMaxLength(255);
        });

        modelBuilder.Entity<vw_CarePlanSystemDisease>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CarePlanSystemDisease");
        });

        modelBuilder.Entity<vw_DiseaseCarePlanSetup>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_DiseaseCarePlanSetup");

            entity.Property(e => e.DiseaseName).HasMaxLength(255);
            entity.Property(e => e.DiseaseSubInfo).HasMaxLength(50);
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.System).HasMaxLength(255);
        });

        modelBuilder.Entity<vw_Doctors>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Doctors");
        });

        modelBuilder.Entity<vw_EbasDepAssessmentDue>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_EbasDepAssessmentDue");

            entity.Property(e => e.AssessmentName).HasMaxLength(200);
            entity.Property(e => e.DueDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.createdDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.source).HasMaxLength(200);
            entity.Property(e => e.updatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<vw_FalangaScores>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_FalangaScores");

            entity.Property(e => e.ExudateAmount).HasMaxLength(50);
            entity.Property(e => e.HealingEdges).HasMaxLength(50);
            entity.Property(e => e.PeriwoundCallousFibrosis).HasMaxLength(50);
            entity.Property(e => e.PeriwoundDermatitis).HasMaxLength(50);
        });

        modelBuilder.Entity<vw_FalangaScores_WoundDraft>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_FalangaScores_WoundDraft");

            entity.Property(e => e.ExudateAmount).HasMaxLength(50);
            entity.Property(e => e.HealingEdges).HasMaxLength(50);
            entity.Property(e => e.PeriwoundCallousFibrosis).HasMaxLength(50);
            entity.Property(e => e.PeriwoundDermatitis).HasMaxLength(50);
        });

        modelBuilder.Entity<vw_GcsAssessmentDue>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_GcsAssessmentDue");

            entity.Property(e => e.AssessmentName).HasMaxLength(200);
            entity.Property(e => e.DueDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.createdDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.source).HasMaxLength(200);
            entity.Property(e => e.updatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<vw_MbiAssessmentDue>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_MbiAssessmentDue");

            entity.Property(e => e.AssessmentName).HasMaxLength(200);
            entity.Property(e => e.DueDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.createdDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.source).HasMaxLength(200);
            entity.Property(e => e.updatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<vw_MedicalHistoryCarePlanSetup>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_MedicalHistoryCarePlanSetup");

            entity.Property(e => e.DiseaseName).HasMaxLength(255);
            entity.Property(e => e.DiseaseSubInfo).HasMaxLength(50);
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.System).HasMaxLength(255);
        });

        modelBuilder.Entity<vw_MfsAssessmentDue>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_MfsAssessmentDue");

            entity.Property(e => e.AssessmentName).HasMaxLength(200);
            entity.Property(e => e.DueDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.createdDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.source).HasMaxLength(200);
            entity.Property(e => e.updatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<vw_MmseAssessmentDue>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_MmseAssessmentDue");

            entity.Property(e => e.AssessmentName).HasMaxLength(200);
            entity.Property(e => e.DueDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.createdDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.source).HasMaxLength(200);
            entity.Property(e => e.updatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<vw_NursingDiagnosesCarePlanSetup>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_NursingDiagnosesCarePlanSetup");

            entity.Property(e => e.DiseaseName).HasMaxLength(255);
            entity.Property(e => e.DiseaseSubInfo).HasMaxLength(50);
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.System).HasMaxLength(255);
        });

        modelBuilder.Entity<vw_OralCarePlanSetup>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_OralCarePlanSetup");

            entity.Property(e => e.DiseaseName).HasMaxLength(255);
            entity.Property(e => e.DiseaseSubInfo).HasMaxLength(50);
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.System).HasMaxLength(255);
        });

        modelBuilder.Entity<vw_PatientAllLatestVitalSigns>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_PatientAllLatestVitalSigns");

            entity.Property(e => e.ThresholdMaxValue).HasPrecision(18, 2);
            entity.Property(e => e.ThresholdMinValue).HasPrecision(18, 2);
            entity.Property(e => e.Value).HasPrecision(18, 2);
            entity.Property(e => e.VitalSignDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.VitalSignTypeName).HasMaxLength(200);
            entity.Property(e => e.ews_max_1).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_2).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_3).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_4).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_5).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_6).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_7).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_1).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_2).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_3).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_4).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_5).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_6).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_7).HasPrecision(18, 2);
        });

        modelBuilder.Entity<vw_PatientBilling>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_PatientBilling");

            entity.Property(e => e.BillingAddress1).HasMaxLength(255);
            entity.Property(e => e.BillingAddress2).HasMaxLength(255);
            entity.Property(e => e.BillingAddress3).HasMaxLength(255);
            entity.Property(e => e.BillingPostalCode).HasMaxLength(10);
            entity.Property(e => e.Email).HasMaxLength(255);
        });

        modelBuilder.Entity<vw_PatientDisease>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_PatientDisease");

            entity.Property(e => e.DiseaseName).HasMaxLength(255);
            entity.Property(e => e.DiseaseSubInfo).HasMaxLength(50);
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.System).HasMaxLength(255);
        });

        modelBuilder.Entity<vw_PatientLatestVitalSigns>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_PatientLatestVitalSigns");

            entity.Property(e => e.ThresholdMaxValue).HasPrecision(18, 2);
            entity.Property(e => e.ThresholdMinValue).HasPrecision(18, 2);
            entity.Property(e => e.Value).HasPrecision(18, 2);
            entity.Property(e => e.VitalSignDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.VitalSignTypeName).HasMaxLength(200);
            entity.Property(e => e.ews_max_1).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_2).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_3).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_4).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_5).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_6).HasPrecision(18, 2);
            entity.Property(e => e.ews_max_7).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_1).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_2).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_3).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_4).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_5).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_6).HasPrecision(18, 2);
            entity.Property(e => e.ews_min_7).HasPrecision(18, 2);
        });

        modelBuilder.Entity<vw_PatientWound>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_PatientWound");

            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.NextReviewDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.NextTreatmentDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(15);
        });

        modelBuilder.Entity<vw_PatientWoundImageDownload>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_PatientWoundImageDownload");

            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.ImageUpload).HasMaxLength(50);
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.VisitDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<vw_PushScores>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_PushScores");
        });

        modelBuilder.Entity<vw_RafAssessmentDue>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_RafAssessmentDue");

            entity.Property(e => e.AssessmentName).HasMaxLength(200);
            entity.Property(e => e.DueDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.createdDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.source).HasMaxLength(200);
            entity.Property(e => e.updatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<vw_RafCarePlanSetup>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_RafCarePlanSetup");

            entity.Property(e => e.DiseaseName).HasMaxLength(255);
            entity.Property(e => e.DiseaseSubInfo).HasMaxLength(50);
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.System).HasMaxLength(255);
        });

        modelBuilder.Entity<vw_Teleconsultation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Teleconsultation");

            entity.Property(e => e.EndDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<vw_UserRoles>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_UserRoles");

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.RoleDescription).HasMaxLength(250);
            entity.Property(e => e.Status).HasMaxLength(15);
            entity.Property(e => e.UserCategory).HasMaxLength(50);
            entity.Property(e => e.UserType).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
