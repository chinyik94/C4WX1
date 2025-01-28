﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Patient
{
    public int PatientID { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string NRIC { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public int? Age { get; set; }

    public string? PostalCode { get; set; }

    public string? Photo { get; set; }

    public int? CareManagerAssignedID { get; set; }

    public string? CaseID { get; set; }

    public string? DrugAllergy { get; set; }

    public string? Status { get; set; }

    public int? DischargeNoticePeriodInMonths { get; set; }

    public DateTime? AdmittedDate { get; set; }

    public string? ReasonOfAdmission { get; set; }

    public bool? AMD { get; set; }

    public bool? ACP { get; set; }

    public bool? PACEMAKER { get; set; }

    public bool? ACID { get; set; }

    public string? MobilePhone { get; set; }

    public string? HomePhone { get; set; }

    public string? Email { get; set; }

    public string? GenogramPicture { get; set; }

    public string? ReferringDiagnosis { get; set; }

    public string? MailForVitalAlert1 { get; set; }

    public string? MailForVitalAlert2 { get; set; }

    public string? MailForVitalAlert3 { get; set; }

    public string? MailForFamilyNotification1 { get; set; }

    public string? MailForFamilyNotification2 { get; set; }

    public string? VisitingFrequency { get; set; }

    public int? NumberOfChildren { get; set; }

    public string? Occupation { get; set; }

    public bool? UpfrontPayment { get; set; }

    public DateTime? CareReviewDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public int? PatientTypeID_FK { get; set; }

    public string? MailingAddress1 { get; set; }

    public string? MailingAddress2 { get; set; }

    public string? MailingAddress3 { get; set; }

    public int? GenderID_FK { get; set; }

    public int? BloodTypeID_FK { get; set; }

    public int? ResidentTypeID_FK { get; set; }

    public int? MaritalStatusID_FK { get; set; }

    public int? ReligionID_FK { get; set; }

    public int? PatientProfileID_FK { get; set; }

    public int? RaceID_FK { get; set; }

    public int? PatientAdditionalInfoID_FK { get; set; }

    public int? PatientReferralID_FK { get; set; }

    public string? MedicalHistoryRemarks { get; set; }

    public int? PatientMedicationID_FK { get; set; }

    public int? PatientReferralByID_FK { get; set; }

    public string? IdentificationNumber { get; set; }

    public string? IdentificationAttachmentFilename { get; set; }

    public string? IdentificationAttachmentPhysical { get; set; }

    public string? OtherRace { get; set; }

    public string? OtherLanguage { get; set; }

    public string? PaymentMode { get; set; }

    public int? InvoiceModeID_FK { get; set; }

    public string? DisplayName { get; set; }

    public string? OrderID { get; set; }

    public bool? Accepted { get; set; }

    public string? NursingStation { get; set; }

    public int? AccessHospitalID_FK { get; set; }

    public string? ActionDescription { get; set; }

    public string? IntegrationSourceID { get; set; }

    public virtual ICollection<BillingInvoice> BillingInvoice { get; set; } = new List<BillingInvoice>();

    public virtual ICollection<BillingProposal> BillingProposal { get; set; } = new List<BillingProposal>();

    public virtual Code? BloodTypeID_FKNavigation { get; set; }

    public virtual ICollection<CarePlan> CarePlan { get; set; } = new List<CarePlan>();

    public virtual ICollection<CareReport> CareReport { get; set; } = new List<CareReport>();

    public virtual ICollection<Chat> Chat { get; set; } = new List<Chat>();

    public virtual Code? GenderID_FKNavigation { get; set; }

    public virtual Code? InvoiceModeID_FKNavigation { get; set; }

    public virtual Code? MaritalStatusID_FKNavigation { get; set; }

    public virtual ICollection<MultiDisciplinaryMeeting> MultiDisciplinaryMeeting { get; set; } = new List<MultiDisciplinaryMeeting>();

    public virtual ICollection<NutritionTask> NutritionTask { get; set; } = new List<NutritionTask>();

    public virtual ICollection<PatientAMT> PatientAMT { get; set; } = new List<PatientAMT>();

    public virtual PatientAdditionalInfo? PatientAdditionalInfoID_FKNavigation { get; set; }

    public virtual ICollection<PatientAttachment> PatientAttachment { get; set; } = new List<PatientAttachment>();

    public virtual ICollection<PatientClinician> PatientClinician { get; set; } = new List<PatientClinician>();

    public virtual ICollection<PatientDrugAllergy> PatientDrugAllergy { get; set; } = new List<PatientDrugAllergy>();

    public virtual ICollection<PatientEBASDEP> PatientEBASDEP { get; set; } = new List<PatientEBASDEP>();

    public virtual ICollection<PatientFacility> PatientFacility { get; set; } = new List<PatientFacility>();

    public virtual ICollection<PatientFamilyHistory> PatientFamilyHistory { get; set; } = new List<PatientFamilyHistory>();

    public virtual ICollection<PatientImmunisation> PatientImmunisation { get; set; } = new List<PatientImmunisation>();

    public virtual ICollection<PatientLanguage> PatientLanguage { get; set; } = new List<PatientLanguage>();

    public virtual ICollection<PatientMedicalHistory> PatientMedicalHistory { get; set; } = new List<PatientMedicalHistory>();

    public virtual PatientMedication? PatientMedicationID_FKNavigation { get; set; }

    public virtual ICollection<PatientOtherAllergy> PatientOtherAllergy { get; set; } = new List<PatientOtherAllergy>();

    public virtual ICollection<PatientPackage> PatientPackage { get; set; } = new List<PatientPackage>();

    public virtual PatientProfile? PatientProfileID_FKNavigation { get; set; }

    public virtual Code? PatientReferralByID_FKNavigation { get; set; }

    public virtual PatientReferral? PatientReferralID_FKNavigation { get; set; }

    public virtual ICollection<PatientSocialSupport> PatientSocialSupport { get; set; } = new List<PatientSocialSupport>();

    public virtual ICollection<PatientSpecialIndicator> PatientSpecialIndicator { get; set; } = new List<PatientSpecialIndicator>();

    public virtual Code? PatientTypeID_FKNavigation { get; set; }

    public virtual ICollection<PatientWound> PatientWound { get; set; } = new List<PatientWound>();

    public virtual ICollection<PatientWoundDraft> PatientWoundDraft { get; set; } = new List<PatientWoundDraft>();

    public virtual Code? RaceID_FKNavigation { get; set; }

    public virtual ICollection<Receipt> Receipt { get; set; } = new List<Receipt>();

    public virtual ICollection<RecentView> RecentView { get; set; } = new List<RecentView>();

    public virtual Code? ReligionID_FKNavigation { get; set; }

    public virtual Code? ResidentTypeID_FKNavigation { get; set; }

    public virtual ICollection<Task> Task { get; set; } = new List<Task>();

    public virtual ICollection<TeleconsultationRecording> TeleconsultationRecording { get; set; } = new List<TeleconsultationRecording>();

    public virtual ICollection<Users> Users { get; set; } = new List<Users>();

    public virtual ICollection<VitalSignRelationships> VitalSignRelationships { get; set; } = new List<VitalSignRelationships>();

    public virtual ICollection<VitalSigns> VitalSigns { get; set; } = new List<VitalSigns>();
}
