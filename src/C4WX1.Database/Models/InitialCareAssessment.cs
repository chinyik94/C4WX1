using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class InitialCareAssessment
{
    public int InitialCareAssessmentID { get; set; }

    public int? PatientID_FK { get; set; }

    public string? GeneralCondition { get; set; }

    public string? Physique { get; set; }

    public string? ConsciousLevel { get; set; }

    public string? EmotionalState { get; set; }

    public string? OtherEmotionalState { get; set; }

    public string? Breathing { get; set; }

    public string? OtherBreathing { get; set; }

    public decimal? O2Litres { get; set; }

    public string? O2LitresVia { get; set; }

    public DateTime? TracheostomyDateInserted { get; set; }

    public string? TracheostomySize { get; set; }

    public string? TracheostomyType { get; set; }

    public bool? IsTracheostomyInnerCannula { get; set; }

    public DateTime? TracheostomyNextReviewDate { get; set; }

    public string? Cough { get; set; }

    public string? Vision { get; set; }

    public bool? VisionImpairedLeft { get; set; }

    public bool? VisionImpairedRight { get; set; }

    public string? VisionImpairedRemarks { get; set; }

    public bool? VisionImpairedGlaucoma { get; set; }

    public bool? VisionImpairedCataract { get; set; }

    public bool? VisionImpairedGlaucomaLeft { get; set; }

    public bool? VisionImpairedGlaucomaRight { get; set; }

    public string? VisionImpairedGlaucomaRemarks { get; set; }

    public bool? VisionImpairedCataractLeft { get; set; }

    public bool? VisionImpairedCataractRight { get; set; }

    public string? VisionImpairedCataractRemarks { get; set; }

    public string? Hearing { get; set; }

    public bool? HearingImpairedLeft { get; set; }

    public bool? HearingImpairedRight { get; set; }

    public string? HearingImpairedRemarks { get; set; }

    public bool? HearingImpairedWithHearingAidLeft { get; set; }

    public bool? HearingImpairedWithHearingAidRight { get; set; }

    public string? HearingImpairedWithHearingAidRemarks { get; set; }

    public string? BowelHabitsTimes { get; set; }

    public string? BowelHabitsDays { get; set; }

    public string? BowelType { get; set; }

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

    public string? UrinaryFrequencyTimes { get; set; }

    public string? UrinaryFrequencyDay { get; set; }

    public string? UrinaryTypes { get; set; }

    public string? Catheter { get; set; }

    public DateTime? CatheterDateInserted { get; set; }

    public string? CatheterType { get; set; }

    public string? CatheterSize { get; set; }

    public DateTime? CatheterNextReviewDate { get; set; }

    public DateTime? LMP { get; set; }

    public bool? UseOfDrug { get; set; }

    public string? UseOfDrugExplain { get; set; }

    public string? MedicalHistory { get; set; }

    public int? OralCavityAssessmentScore1 { get; set; }

    public int? OralCavityAssessmentScore2 { get; set; }

    public int? OralCavityAssessmentScore3 { get; set; }

    public int? OralCavityAssessmentScore4 { get; set; }

    public int? OralCavityAssessmentScore5 { get; set; }

    public int? OralCavityAssessmentScore6 { get; set; }

    public string? MilkFeedRx { get; set; }

    public bool? EmotionalYesNo { get; set; }

    public string? EmotionalYes { get; set; }

    public string? HowCanIHelp { get; set; }

    public bool? LostInterest { get; set; }

    public string? LostInterestYes { get; set; }

    public string? HowDoYouScope { get; set; }

    public bool? DifficultyCoping { get; set; }

    public string? DifficultyCopingYes { get; set; }

    public bool? Depressed { get; set; }

    public string? GetSupport { get; set; }

    public bool? ReferCounsellor { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public string Status { get; set; } = null!;

    public int? PatientProfileID_FK { get; set; }

    public int? PatientReferralID_FK { get; set; }

    public string? SectionStatus { get; set; }

    public int? PatientAdditionalInfoID_FK { get; set; }

    public int? VitalSignID_FK { get; set; }

    public int? WoundAssessmentScore1 { get; set; }

    public int? WoundAssessmentScore2 { get; set; }

    public int? WoundAssessmentScore3 { get; set; }

    public int? WoundAssessmentScore4 { get; set; }

    public int? WoundAssessmentScore5 { get; set; }

    public int? WoundAssessmentScore6 { get; set; }

    public int? PatientMedicationID_FK { get; set; }

    public bool? HomeFacilityVentilation { get; set; }

    public bool? HomeFacilityCooking { get; set; }

    public bool? HomeFacilityRefrigeration { get; set; }

    public bool? HomeFacilityToileting { get; set; }

    public bool? HomeFacilityStairs { get; set; }

    public bool? HomeFacilityCommunication { get; set; }

    public bool? HomeFacilityAffectCaregiver { get; set; }

    public bool? HomeFacilityAffectCareManager { get; set; }

    public string? HomeFacilityRemarks { get; set; }

    public bool? IsRequirePalliativeCare { get; set; }

    public int? PainLevel { get; set; }

    public int? TirednessLevel { get; set; }

    public int? DrowsinessLevel { get; set; }

    public int? NauseaLevel { get; set; }

    public int? LackOfAppetiteLevel { get; set; }

    public int? ShortnessOfBreath { get; set; }

    public int? DepressionLevel { get; set; }

    public int? AnxietyLevel { get; set; }

    public int? BestWellbeing { get; set; }

    public string? Faith { get; set; }

    public bool? IsReligious { get; set; }

    public string? GiveMeaningToLife { get; set; }

    public string? MakeSense { get; set; }

    public bool? IsBeliefImportant { get; set; }

    public string? InfluenceTakeCare { get; set; }

    public string? BeliefInfluenced { get; set; }

    public string? RoleOfBeliefForInfluence { get; set; }

    public bool? IsPartOfCommunity { get; set; }

    public string? SupportTo { get; set; }

    public string? RoleOfBeliefForCommunity { get; set; }

    public string? PersonalConcern { get; set; }

    public string? AddressIssue { get; set; }

    public string? Concern { get; set; }

    public string? TalkToSomeone { get; set; }

    public int? OralCavityAssessmentScore7 { get; set; }

    public int? OralCavityAssessmentScore8 { get; set; }

    public int? PatientNutritionID_FK { get; set; }

    public int? PatientRAFID_FK { get; set; }

    public int? PatientMBIID_FK { get; set; }

    public int? PatientMFSID_FK { get; set; }

    public DateTime? VisitDateTime { get; set; }

    public DateTime? VSOnSetDate { get; set; }

    public DateTime? painOnSetDate { get; set; }

    public string? VSQuality { get; set; }

    public string? VSPainFrequency { get; set; }

    public string? VSIntermittent { get; set; }

    public string? VSLocation { get; set; }

    public string? VSPrecipitatingFactors { get; set; }

    public string? VSRelievingFactors { get; set; }

    public int? VSPainFrequencyIntermittentNumber { get; set; }

    public string? CAAlertness { get; set; }

    public string? CACommunication { get; set; }

    public bool? CADementia { get; set; }

    public bool? CAdateAndTime { get; set; }

    public bool? CAPerson { get; set; }

    public bool? CAPlace { get; set; }

    public bool? CASituation { get; set; }

    public bool? HearingAid { get; set; }

    public bool? ChestSymmetry { get; set; }

    public bool? AbdomenSymmetry { get; set; }

    public bool? AnySkinIssue { get; set; }

    public bool? PressureInjuries { get; set; }

    public int? ApicalPulse { get; set; }

    public string? SkinType { get; set; }

    public string? SkinIssue { get; set; }

    public string? SkinTurgor { get; set; }

    public string? BreathSounds { get; set; }

    public string? BowelSounds { get; set; }

    public string? Percussion { get; set; }

    public string? Palpation { get; set; }

    public string? TenderNGuarding { get; set; }

    public string? Remark { get; set; }

    public int? LeftUpperLimbStrength { get; set; }

    public int? RightUpperLimbStrength { get; set; }

    public int? LeftLowerLimbStrength { get; set; }

    public int? RightLowerLimbStrength { get; set; }

    public string? MobilityStatus { get; set; }

    public string? AssistiveAids { get; set; }

    public bool? Incontinence { get; set; }

    public string? IncontinenceType { get; set; }

    public string? UrineConsistency { get; set; }

    public string? UrineColour { get; set; }

    public string? StoolsType { get; set; }

    public bool? VisionSpectacles { get; set; }

    public bool? OxygenRequired { get; set; }

    public bool? Sputum { get; set; }

    public bool? SuctioningRequired { get; set; }

    public decimal? OxygenLMin { get; set; }

    public string? OxygenType { get; set; }

    public string? OxygenRemark { get; set; }

    public string? Oralhealth { get; set; }

    public string? Teeth { get; set; }

    public bool? AblePassUrine { get; set; }

    public bool? NutritionalImbalance { get; set; }

    public virtual ICollection<ICAWoundCare> ICAWoundCare { get; set; } = new List<ICAWoundCare>();

    public virtual ICollection<InitialCareAssessmentAttachment> InitialCareAssessmentAttachment { get; set; } = new List<InitialCareAssessmentAttachment>();

    public virtual ICollection<InitialCareAssessmentSpecialInstruction> InitialCareAssessmentSpecialInstruction { get; set; } = new List<InitialCareAssessmentSpecialInstruction>();

    public virtual ICollection<PatientAMT> PatientAMT { get; set; } = new List<PatientAMT>();

    public virtual PatientAdditionalInfo? PatientAdditionalInfoID_FKNavigation { get; set; }

    public virtual ICollection<PatientClinician> PatientClinician { get; set; } = new List<PatientClinician>();

    public virtual ICollection<PatientDrugAllergy> PatientDrugAllergy { get; set; } = new List<PatientDrugAllergy>();

    public virtual ICollection<PatientEBASDEP> PatientEBASDEP { get; set; } = new List<PatientEBASDEP>();

    public virtual ICollection<PatientFamilyHistory> PatientFamilyHistory { get; set; } = new List<PatientFamilyHistory>();

    public virtual PatientMBI? PatientMBIID_FKNavigation { get; set; }

    public virtual PatientMFS? PatientMFSID_FKNavigation { get; set; }

    public virtual PatientMedication? PatientMedicationID_FKNavigation { get; set; }

    public virtual PatientNutrition? PatientNutritionID_FKNavigation { get; set; }

    public virtual ICollection<PatientOtherAllergy> PatientOtherAllergy { get; set; } = new List<PatientOtherAllergy>();

    public virtual PatientProfile? PatientProfileID_FKNavigation { get; set; }

    public virtual PatientRAF? PatientRAFID_FKNavigation { get; set; }

    public virtual PatientReferral? PatientReferralID_FKNavigation { get; set; }

    public virtual ICollection<PatientSocialSupport> PatientSocialSupport { get; set; } = new List<PatientSocialSupport>();

    public virtual ICollection<PatientWound> PatientWound { get; set; } = new List<PatientWound>();

    public virtual ICollection<PatientWoundVisit> PatientWoundVisit { get; set; } = new List<PatientWoundVisit>();

    public virtual ICollection<Task> Task { get; set; } = new List<Task>();

    public virtual VitalSigns? VitalSignID_FKNavigation { get; set; }
}
