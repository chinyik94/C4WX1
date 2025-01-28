﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Code
{
    public int CodeId { get; set; }

    public int CodeTypeId_FK { get; set; }

    public string CodeName { get; set; } = null!;

    public int? Ordering { get; set; }

    public bool IsSystemUsed { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool? Indication_Acute { get; set; }

    public bool? Indication_PRN { get; set; }

    public string? Referral_Code { get; set; }

    public bool? AllergyReaction_Drug { get; set; }

    public bool? AllergyReaction_Others { get; set; }

    public int? MedicationGroupID_FK { get; set; }

    public string? Status { get; set; }

    public string? CurrencyCodeA { get; set; }

    public string? CurrencyCodeN { get; set; }

    public string? CurrencyInvoiceFooter { get; set; }

    public bool? Critical { get; set; }

    public virtual ICollection<BillingInvoice> BillingInvoice { get; set; } = new List<BillingInvoice>();

    public virtual ICollection<BillingProposal> BillingProposal { get; set; } = new List<BillingProposal>();

    public virtual ICollection<BillingService> BillingService { get; set; } = new List<BillingService>();

    public virtual ICollection<Branch> Branch { get; set; } = new List<Branch>();

    public virtual ICollection<CarePlanSubProblemListGoal> CarePlanSubProblemListGoalOperator { get; set; } = new List<CarePlanSubProblemListGoal>();

    public virtual ICollection<CarePlanSubProblemListGoal> CarePlanSubProblemListGoalScoreType { get; set; } = new List<CarePlanSubProblemListGoal>();

    public virtual ICollection<CareReport> CareReportAirwayBreathingID_FKNavigation { get; set; } = new List<CareReport>();

    public virtual ICollection<CareReport> CareReportBladderCareID_FKNavigation { get; set; } = new List<CareReport>();

    public virtual ICollection<CareReport> CareReportBowelCareID_FKNavigation { get; set; } = new List<CareReport>();

    public virtual ICollection<CareReport> CareReportCapillaryRefillID_FKNavigation { get; set; } = new List<CareReport>();

    public virtual ICollection<CareReport> CareReportCirculationID_FKNavigation { get; set; } = new List<CareReport>();

    public virtual ICollection<CareReport> CareReportCoughID_FKNavigation { get; set; } = new List<CareReport>();

    public virtual ICollection<CareReport> CareReportDiapersID_FKNavigation { get; set; } = new List<CareReport>();

    public virtual ICollection<CareReport> CareReportLipsID_FKNavigation { get; set; } = new List<CareReport>();

    public virtual ICollection<CareReport> CareReportLowerEyelidsID_FKNavigation { get; set; } = new List<CareReport>();

    public virtual ICollection<CareReport> CareReportO2AidID_FKNavigation { get; set; } = new List<CareReport>();

    public virtual ICollection<CareReport> CareReportPainDescriptionID_FKNavigation { get; set; } = new List<CareReport>();

    public virtual ICollection<CareReport> CareReportPeripheralPulsesPedalID_FKNavigation { get; set; } = new List<CareReport>();

    public virtual ICollection<CareReport> CareReportPeripheralPulsesRadialID_FKNavigation { get; set; } = new List<CareReport>();

    public virtual ICollection<CareReport> CareReportSleepRestID_FKNavigation { get; set; } = new List<CareReport>();

    public virtual ICollection<CareReport> CareReportTemperatureID_FKNavigation { get; set; } = new List<CareReport>();

    public virtual CodeType CodeTypeId_FKNavigation { get; set; } = null!;

    public virtual ICollection<Enquiry> EnquiryCaregiverAtHomeID_FKNavigation { get; set; } = new List<Enquiry>();

    public virtual ICollection<Enquiry> EnquiryEnquirySourceID_FKNavigation { get; set; } = new List<Enquiry>();

    public virtual ICollection<Enquiry> EnquiryGenderID_FKNavigation { get; set; } = new List<Enquiry>();

    public virtual ICollection<EnquiryLanguage> EnquiryLanguage { get; set; } = new List<EnquiryLanguage>();

    public virtual ICollection<Enquiry> EnquiryPreferredLanguageID_FKNavigation { get; set; } = new List<Enquiry>();

    public virtual ICollection<Enquiry> EnquiryRaceID_FKNavigation { get; set; } = new List<Enquiry>();

    public virtual ICollection<EnquiryServicesRequired> EnquiryServicesRequired { get; set; } = new List<EnquiryServicesRequired>();

    public virtual ICollection<Enquiry> EnquiryServicesRequiredID_FKNavigation { get; set; } = new List<Enquiry>();

    public virtual ICollection<Enquiry> EnquiryUserOrganizationID_FKNavigation { get; set; } = new List<Enquiry>();

    public virtual ICollection<Event> EventEventTypeID_FKNavigation { get; set; } = new List<Event>();

    public virtual ICollection<Event> EventPeriodTypeID_FKNavigation { get; set; } = new List<Event>();

    public virtual ICollection<Facility> Facility { get; set; } = new List<Facility>();

    public virtual ICollection<ICAWoundCare> ICAWoundCare { get; set; } = new List<ICAWoundCare>();

    public virtual ICollection<Code> InverseMedicationGroupID_FKNavigation { get; set; } = new List<Code>();

    public virtual ICollection<Item> ItemCategoryID_FKNavigation { get; set; } = new List<Item>();

    public virtual ICollection<Item> ItemItemUnitID_FKNavigation { get; set; } = new List<Item>();

    public virtual Code? MedicationGroupID_FKNavigation { get; set; }

    public virtual ICollection<MedicationVitalSignType> MedicationVitalSignType { get; set; } = new List<MedicationVitalSignType>();

    public virtual ICollection<NutritionTask> NutritionTask { get; set; } = new List<NutritionTask>();

    public virtual ICollection<NutritionTaskReference> NutritionTaskReference { get; set; } = new List<NutritionTaskReference>();

    public virtual ICollection<Patient> PatientBloodTypeID_FKNavigation { get; set; } = new List<Patient>();

    public virtual ICollection<PatientDrugAllergy> PatientDrugAllergyMedicationID_FKNavigation { get; set; } = new List<PatientDrugAllergy>();

    public virtual ICollection<PatientDrugAllergy> PatientDrugAllergyReactionID_FKNavigation { get; set; } = new List<PatientDrugAllergy>();

    public virtual ICollection<Patient> PatientGenderID_FKNavigation { get; set; } = new List<Patient>();

    public virtual ICollection<Patient> PatientInvoiceModeID_FKNavigation { get; set; } = new List<Patient>();

    public virtual ICollection<PatientLanguage> PatientLanguage { get; set; } = new List<PatientLanguage>();

    public virtual ICollection<Patient> PatientMaritalStatusID_FKNavigation { get; set; } = new List<Patient>();

    public virtual ICollection<PatientMedicalHistory> PatientMedicalHistory { get; set; } = new List<PatientMedicalHistory>();

    public virtual ICollection<PatientMedicationConsume> PatientMedicationConsumeAcutePRNIndicationID_FKNavigation { get; set; } = new List<PatientMedicationConsume>();

    public virtual ICollection<PatientMedicationConsume> PatientMedicationConsumeDosageID_FKNavigation { get; set; } = new List<PatientMedicationConsume>();

    public virtual ICollection<PatientMedicationConsume> PatientMedicationConsumeFrequencyID_FKNavigation { get; set; } = new List<PatientMedicationConsume>();

    public virtual ICollection<PatientMedicationConsume> PatientMedicationConsumeInstructedBy2ID_FKNavigation { get; set; } = new List<PatientMedicationConsume>();

    public virtual ICollection<PatientMedicationConsume> PatientMedicationConsumeInstructedByID_FKNavigation { get; set; } = new List<PatientMedicationConsume>();

    public virtual ICollection<PatientMedicationConsume> PatientMedicationConsumeMedicationID_FKNavigation { get; set; } = new List<PatientMedicationConsume>();

    public virtual ICollection<PatientMedicationConsume> PatientMedicationConsumeRouteID_FKNavigation { get; set; } = new List<PatientMedicationConsume>();

    public virtual ICollection<PatientMedicationSupply> PatientMedicationSupply { get; set; } = new List<PatientMedicationSupply>();

    public virtual ICollection<PatientOtherAllergy> PatientOtherAllergyDescriptionID_FKNavigation { get; set; } = new List<PatientOtherAllergy>();

    public virtual ICollection<PatientOtherAllergy> PatientOtherAllergyReactionID_FKNavigation { get; set; } = new List<PatientOtherAllergy>();

    public virtual ICollection<Patient> PatientPatientReferralByID_FKNavigation { get; set; } = new List<Patient>();

    public virtual ICollection<Patient> PatientPatientTypeID_FKNavigation { get; set; } = new List<Patient>();

    public virtual ICollection<PatientProfile> PatientProfileBloodTypeID_FKNavigation { get; set; } = new List<PatientProfile>();

    public virtual ICollection<PatientProfile> PatientProfilePatientOrganizationID_FKNavigation { get; set; } = new List<PatientProfile>();

    public virtual ICollection<PatientProfile> PatientProfileReligionID_FKNavigation { get; set; } = new List<PatientProfile>();

    public virtual ICollection<Patient> PatientRaceID_FKNavigation { get; set; } = new List<Patient>();

    public virtual ICollection<PatientReferralService> PatientReferralService { get; set; } = new List<PatientReferralService>();

    public virtual ICollection<Patient> PatientReligionID_FKNavigation { get; set; } = new List<Patient>();

    public virtual ICollection<Patient> PatientResidentTypeID_FKNavigation { get; set; } = new List<Patient>();

    public virtual ICollection<PatientSocialSupport> PatientSocialSupportGenderID_FKNavigation { get; set; } = new List<PatientSocialSupport>();

    public virtual ICollection<PatientSocialSupport> PatientSocialSupportMaritalStatusID_FKNavigation { get; set; } = new List<PatientSocialSupport>();

    public virtual ICollection<PatientSocialSupport> PatientSocialSupportNationalityID_FKNavigation { get; set; } = new List<PatientSocialSupport>();

    public virtual ICollection<PatientSocialSupport> PatientSocialSupportRelationshipID_FKNavigation { get; set; } = new List<PatientSocialSupport>();

    public virtual ICollection<PatientSpecialIndicator> PatientSpecialIndicator { get; set; } = new List<PatientSpecialIndicator>();

    public virtual ICollection<PatientWound> PatientWound { get; set; } = new List<PatientWound>();

    public virtual ICollection<PatientWoundDraft> PatientWoundDraft { get; set; } = new List<PatientWoundDraft>();

    public virtual ICollection<PatientWoundDraftTreatmentObjectives> PatientWoundDraftTreatmentObjectives { get; set; } = new List<PatientWoundDraftTreatmentObjectives>();

    public virtual ICollection<PatientWoundVisitAppearance> PatientWoundVisitAppearance { get; set; } = new List<PatientWoundVisitAppearance>();

    public virtual ICollection<PatientWoundVisitCleansingItem> PatientWoundVisitCleansingItem { get; set; } = new List<PatientWoundVisitCleansingItem>();

    public virtual ICollection<PatientWoundVisitTreatmentObjectives> PatientWoundVisitTreatmentObjectives { get; set; } = new List<PatientWoundVisitTreatmentObjectives>();

    public virtual ICollection<ProblemListGoal> ProblemListGoalOperator { get; set; } = new List<ProblemListGoal>();

    public virtual ICollection<ProblemListGoal> ProblemListGoalScoreType { get; set; } = new List<ProblemListGoal>();

    public virtual ICollection<Receipt> ReceiptCurrencyID_FKNavigation { get; set; } = new List<Receipt>();

    public virtual ICollection<Receipt> ReceiptPaymentModeID_FKNavigation { get; set; } = new List<Receipt>();

    public virtual ICollection<Resource> Resource { get; set; } = new List<Resource>();

    public virtual ICollection<ServiceForBilling> ServiceForBilling { get; set; } = new List<ServiceForBilling>();

    public virtual ICollection<ServiceForBillingCost> ServiceForBillingCost { get; set; } = new List<ServiceForBillingCost>();

    public virtual ICollection<ServiceSkillset> ServiceSkillsetServiceID_FKNavigation { get; set; } = new List<ServiceSkillset>();

    public virtual ICollection<ServiceSkillset> ServiceSkillsetSkillsetID_FKNavigation { get; set; } = new List<ServiceSkillset>();

    public virtual ICollection<TD_WoundAssessmentFactor> TD_WoundAssessmentFactor { get; set; } = new List<TD_WoundAssessmentFactor>();

    public virtual ICollection<Task> TaskActionTypeID_FKNavigation { get; set; } = new List<Task>();

    public virtual ICollection<Task> TaskDosageID_FKNavigation { get; set; } = new List<Task>();

    public virtual ICollection<Task> TaskFrequencyID_FKNavigation { get; set; } = new List<Task>();

    public virtual ICollection<Task> TaskMedicationID_FKNavigation { get; set; } = new List<Task>();

    public virtual ICollection<TaskServicesRequired> TaskServicesRequired { get; set; } = new List<TaskServicesRequired>();

    public virtual ICollection<TeleconsultationRecording> TeleconsultationRecording { get; set; } = new List<TeleconsultationRecording>();

    public virtual ICollection<TreatmentListItem> TreatmentListItem { get; set; } = new List<TreatmentListItem>();

    public virtual ICollection<UserCategory> UserCategory { get; set; } = new List<UserCategory>();

    public virtual ICollection<UserLanguage> UserLanguage { get; set; } = new List<UserLanguage>();

    public virtual ICollection<UserOrganization> UserOrganization { get; set; } = new List<UserOrganization>();

    public virtual ICollection<UserSkillset> UserSkillset { get; set; } = new List<UserSkillset>();
}
