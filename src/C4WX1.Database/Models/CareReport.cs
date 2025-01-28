﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class CareReport
{
    public int CareReportID { get; set; }

    public int PatientID_FK { get; set; }

    public string? CareReportType { get; set; }

    public string Status { get; set; } = null!;

    public string? SectionStatus { get; set; }

    public string? Memo1 { get; set; }

    public string? Memo2 { get; set; }

    public string? Memo3 { get; set; }

    public string? Memo4 { get; set; }

    public string? Memo5 { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public int? CarePlanID_FK { get; set; }

    public int? CareReportID_FK { get; set; }

    public DateTime? VisitStartDate { get; set; }

    public DateTime? VisitEndDate { get; set; }

    public int? VisitedBy_FK { get; set; }

    public string? Subject { get; set; }

    public int? VitalSignID_FK { get; set; }

    public string? Pain { get; set; }

    public string? PainScaleType { get; set; }

    public int? PainLevel { get; set; }

    public int? PainDescriptionID_FK { get; set; }

    public string? SiteOfPain { get; set; }

    public string? TypeOfPain { get; set; }

    public string? AggravatingFactor { get; set; }

    public string? RelievingFactor { get; set; }

    public string? Frequency { get; set; }

    public string? PainRemarks { get; set; }

    public int? NeuroOrMental { get; set; }

    public int? Eyes { get; set; }

    public int? VerbalResponse { get; set; }

    public int? MotorResponse { get; set; }

    public int? LeftEyeSize { get; set; }

    public string? LeftEyeReaction { get; set; }

    public int? RightEyeSize { get; set; }

    public string? RightEyeReaction { get; set; }

    public string? NeuroRemarks { get; set; }

    public string? SectionRequired { get; set; }

    public string? PsychoEmotionalSpiritual { get; set; }

    public string? PsychoRemarks { get; set; }

    public int? AirwayBreathingID_FK { get; set; }

    public int? CoughID_FK { get; set; }

    public int? O2AidID_FK { get; set; }

    public decimal? O2LitresPercent { get; set; }

    public decimal? O2Litres { get; set; }

    public string? Sunction { get; set; }

    public string? CoughAmount { get; set; }

    public string? Color { get; set; }

    public string? ColorOthers { get; set; }

    public string? Consistency { get; set; }

    public string? Nebuliser { get; set; }

    public string? AirwayBreathingRemarks { get; set; }

    public int? CirculationID_FK { get; set; }

    public int? LowerEyelidsID_FK { get; set; }

    public int? LipsID_FK { get; set; }

    public int? CapillaryRefillID_FK { get; set; }

    public int? PeripheralPulsesRadialID_FK { get; set; }

    public int? PeripheralPulsesPedalID_FK { get; set; }

    public string? CirculationRemarks { get; set; }

    public int? SleepRestID_FK { get; set; }

    public string? DayNightReversal { get; set; }

    public string? SleepRestRemarks { get; set; }

    public int? TemperatureID_FK { get; set; }

    public string? TemperatureInterventions { get; set; }

    public string? TemperatureRemarks { get; set; }

    public int? BowelCareID_FK { get; set; }

    public int? NoOfBowelTimes { get; set; }

    public int? BowelType { get; set; }

    public int? HowManyDaysBNO { get; set; }

    public string? BowelInterventions { get; set; }

    public string? Stoma { get; set; }

    public DateTime? StomaCreatedDate { get; set; }

    public decimal? StomaSizeLength { get; set; }

    public decimal? StomaSizeBreath { get; set; }

    public string? StomaColour { get; set; }

    public string? StomaAppearance { get; set; }

    public string? StomaProtrusion { get; set; }

    public string? StomaPeristomalSkin { get; set; }

    public string? StomaEffluent { get; set; }

    public string? StomaAmountOfOutput { get; set; }

    public string? StomaOstomyProductUsed { get; set; }

    public DateTime? StomaReviewDate { get; set; }

    public string? BowelRemarks { get; set; }

    public int? BladderCareID_FK { get; set; }

    public int? BladderCareTimes { get; set; }

    public int? BladderCareNPU { get; set; }

    public int? DiapersID_FK { get; set; }

    public string? TypeOfUrine { get; set; }

    public string? CharacteristicOfUrine { get; set; }

    public string? Dysuria { get; set; }

    public string? BladderCareRemarks { get; set; }

    public string? PersonalHygieneRemarks { get; set; }

    public int? CareReportRehabilitationID_FK { get; set; }

    public string? EnvironmentRemarks { get; set; }

    public bool? ACP { get; set; }

    public DateTime? ACP_DoneDate { get; set; }

    public DateTime? ACP_ReviewDate { get; set; }

    public string? OtherTreatment { get; set; }

    public string? OtherTreatmentOther { get; set; }

    public string? OtherTreatmentRemarks { get; set; }

    public int? CareReportSystemInfoID_FK { get; set; }

    public string? SectionRequireInput { get; set; }

    public int? PatientNutritionID_FK { get; set; }

    public string? SkinAndWoundCare { get; set; }

    public string? PersonalHygiene { get; set; }

    public string? Environment { get; set; }

    public string? BreathSounds { get; set; }

    public string? BowelSounds { get; set; }

    public string? HeartSounds { get; set; }

    public virtual Code? AirwayBreathingID_FKNavigation { get; set; }

    public virtual ICollection<BillingInvoice> BillingInvoice { get; set; } = new List<BillingInvoice>();

    public virtual Code? BladderCareID_FKNavigation { get; set; }

    public virtual Code? BowelCareID_FKNavigation { get; set; }

    public virtual Code? CapillaryRefillID_FKNavigation { get; set; }

    public virtual CarePlan? CarePlanID_FKNavigation { get; set; }

    public virtual CareReport? CareReportID_FKNavigation { get; set; }

    public virtual CareReportRehabilitation? CareReportRehabilitationID_FKNavigation { get; set; }

    public virtual ICollection<CareReportSocialSupport> CareReportSocialSupport { get; set; } = new List<CareReportSocialSupport>();

    public virtual CareReportSystemInfo? CareReportSystemInfoID_FKNavigation { get; set; }

    public virtual Code? CirculationID_FKNavigation { get; set; }

    public virtual Code? CoughID_FKNavigation { get; set; }

    public virtual Code? DiapersID_FKNavigation { get; set; }

    public virtual ICollection<CareReport> InverseCareReportID_FKNavigation { get; set; } = new List<CareReport>();

    public virtual Code? LipsID_FKNavigation { get; set; }

    public virtual Code? LowerEyelidsID_FKNavigation { get; set; }

    public virtual Code? O2AidID_FKNavigation { get; set; }

    public virtual Code? PainDescriptionID_FKNavigation { get; set; }

    public virtual ICollection<PatientAMT> PatientAMT { get; set; } = new List<PatientAMT>();

    public virtual ICollection<PatientAccessLine> PatientAccessLine { get; set; } = new List<PatientAccessLine>();

    public virtual ICollection<PatientEBASDEP> PatientEBASDEP { get; set; } = new List<PatientEBASDEP>();

    public virtual Patient PatientID_FKNavigation { get; set; } = null!;

    public virtual PatientNutrition? PatientNutritionID_FKNavigation { get; set; }

    public virtual ICollection<PatientWound> PatientWound { get; set; } = new List<PatientWound>();

    public virtual ICollection<PatientWoundVisit> PatientWoundVisit { get; set; } = new List<PatientWoundVisit>();

    public virtual Code? PeripheralPulsesPedalID_FKNavigation { get; set; }

    public virtual Code? PeripheralPulsesRadialID_FKNavigation { get; set; }

    public virtual Code? SleepRestID_FKNavigation { get; set; }

    public virtual Code? TemperatureID_FKNavigation { get; set; }

    public virtual Users? VisitedBy_FKNavigation { get; set; }

    public virtual VitalSigns? VitalSignID_FKNavigation { get; set; }
}
