﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_Patient
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

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
}
