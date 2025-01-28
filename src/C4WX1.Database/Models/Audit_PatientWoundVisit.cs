using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_PatientWoundVisit
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int PatientWoundVisitID { get; set; }

    public int PatientWoundID_FK { get; set; }

    public DateTime? VisitDate { get; set; }

    public string WoundType { get; set; } = null!;

    public string? WoundSubType { get; set; }

    public string? WoundTypeOther { get; set; }

    public decimal? SizeLength { get; set; }

    public decimal? SizeDepth { get; set; }

    public decimal? SizeWidth { get; set; }

    public string? Edges { get; set; }

    public string? Appearance { get; set; }

    public string? Smell { get; set; }

    public string? UnderMining { get; set; }

    public string? Exudate { get; set; }

    public int? Suffering { get; set; }

    public string? ImageUpload { get; set; }

    public decimal? SurfaceArea { get; set; }

    public decimal? UnderMiningDepth { get; set; }

    public string? ExudateSubInfo { get; set; }

    public int? VitalSignID_FK { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public int? CareReportID_FK { get; set; }

    public int? InitialCareAssessmentID_FK { get; set; }

    public int? ReferID_FK { get; set; }

    public DateTime? NextReviewDate { get; set; }

    public string? TreatmentRemarks { get; set; }

    public int? AssignedToID_FK { get; set; }

    public string? DESIGN_R_Depth { get; set; }

    public int? DESIGN_R_Exudate { get; set; }

    public int? DESIGN_R_Size { get; set; }

    public int? DESIGN_R_Inflammation { get; set; }

    public int? DESIGN_R_Granulation { get; set; }

    public int? DESIGN_R_Necrotic { get; set; }

    public int? DESIGN_R_Pocket { get; set; }

    public int? DESIGN_R_Score { get; set; }

    public bool? IsDESIGN_R { get; set; }

    public string? ExudateSubInfo2 { get; set; }

    public string? PeriWound { get; set; }

    public string? Debridement { get; set; }

    public string? CleansingSolutionUsed { get; set; }

    public string? Model_jpg { get; set; }

    public string? Model_mtl { get; set; }

    public string? Model_obj { get; set; }

    public bool? IsDraft { get; set; }

    public decimal? Volume { get; set; }

    public bool? WoundInfection { get; set; }

    public bool? fever { get; set; }

    public decimal? temperature { get; set; }

    public bool? abscessPuss { get; set; }

    public bool? increasedPain { get; set; }

    public bool? erythema { get; set; }

    public bool? oedema { get; set; }

    public bool? localWarmth { get; set; }

    public bool? increasedExcudate { get; set; }

    public bool? delayedHealing { get; set; }

    public bool? maladour { get; set; }

    public bool? pocketing { get; set; }

    public bool? suspectedInfection { get; set; }

    public decimal? TC_Granulation { get; set; }

    public decimal? TC_Slough { get; set; }

    public decimal? TC_Necrosis { get; set; }

    public decimal? TC_Epithelizing { get; set; }

    public decimal? TC_Others { get; set; }

    public string? TC_OriginalImage { get; set; }

    public string? TC_WoundBedImage { get; set; }

    public string? TC_AnnotatedImage { get; set; }

    public bool? TC_IsAccept { get; set; }

    public string? TC_Reason { get; set; }

    public decimal? Perimeter { get; set; }

    public decimal? AverageDepth { get; set; }

    public decimal? MaximumDepth { get; set; }

    public decimal? MinimumDepth { get; set; }

    public bool? IsRedness { get; set; }

    public bool? IsSwelling { get; set; }

    public bool? IsWarmToTouch { get; set; }

    public bool? IsSmell { get; set; }

    public decimal? Size { get; set; }

    public decimal? TC_Auto_Granulation { get; set; }

    public decimal? TC_Auto_Slough { get; set; }

    public decimal? TC_Auto_Necrosis { get; set; }

    public decimal? TC_Auto_Epithelizing { get; set; }

    public decimal? TC_Auto_Others { get; set; }

    public DateTime? NextTreatmentDate { get; set; }

    public string? InfectionRemarks { get; set; }

    public string? TO_Comments { get; set; }

    public string? DepthImage { get; set; }

    public string? Status { get; set; }

    public string? StatusRemark { get; set; }

    public decimal? woundOverlaysImageDistance { get; set; }

    public string? woundOverlaysImage { get; set; }

    public string? otherTissueName { get; set; }

    public bool? isTCAndImageModified { get; set; }

    public bool? isTCModified { get; set; }

    public bool? isWMModified { get; set; }

    public bool? isUploadImageModified { get; set; }

    public string? ProgressiveWoundStage { get; set; }

    public string? OriginalImageMeasurement { get; set; }

    public string? WoundBedImageMeasurement { get; set; }

    public string? DepthImageMeasurement { get; set; }

    public string? AnnotatedImageMeasurement { get; set; }

    public decimal? SizeLength_Auto { get; set; }

    public decimal? SizeDepth_Auto { get; set; }

    public decimal? SizeWidth_Auto { get; set; }

    public string? MeasurementUpdateRemark { get; set; }

    public string? TCUpdateRemark { get; set; }

    public decimal? DepthMax { get; set; }

    public decimal? DepthEighty { get; set; }

    public decimal? DepthSixty { get; set; }

    public decimal? DepthForty { get; set; }

    public decimal? DepthTwenty { get; set; }

    public decimal? DepthNegative { get; set; }

    public decimal? DepthNans { get; set; }

    public decimal? Rotation { get; set; }

    public string? Comments { get; set; }

    public string? Title { get; set; }

    public string? ReasonForChangeMeasurement { get; set; }

    public string? ReasonForChangeClassification { get; set; }

    public int? OrigWoundId { get; set; }

    public bool? SmallWound { get; set; }

    public int? FrequencyOfVisit { get; set; }
}
