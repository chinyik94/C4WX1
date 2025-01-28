using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_PatientWoundDraft
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int PatientWoundDraftID { get; set; }

    public DateTime? VisitDate { get; set; }

    public DateTime? OccurDate { get; set; }

    public DateTime? SeenDate { get; set; }

    public string? LocationOfWound { get; set; }

    public string? Site { get; set; }

    public string? Category { get; set; }

    public string? Stage { get; set; }

    public int? WoundStatusID_FK { get; set; }

    public string? Comments { get; set; }

    public decimal? SizeLength { get; set; }

    public decimal? SizeDepth { get; set; }

    public decimal? SizeWidth { get; set; }

    public decimal? Size { get; set; }

    public decimal? SurfaceArea { get; set; }

    public decimal? Perimeter { get; set; }

    public decimal? AverageDepth { get; set; }

    public decimal? MaximumDepth { get; set; }

    public decimal? MinimumDepth { get; set; }

    public decimal? Volume { get; set; }

    public decimal? Granulation { get; set; }

    public decimal? Slough { get; set; }

    public decimal? Necrosis { get; set; }

    public decimal? Epithelizing { get; set; }

    public decimal? Others { get; set; }

    public string? Exudate { get; set; }

    public string? ExudateNature { get; set; }

    public string? ExudatedConsistency { get; set; }

    public string? Edges { get; set; }

    public string? PeriWound { get; set; }

    public int? Suffering { get; set; }

    public bool? IsRedness { get; set; }

    public bool? IsSwelling { get; set; }

    public bool? IsWarmToTouch { get; set; }

    public bool? IsSmell { get; set; }

    public bool? IsAccept { get; set; }

    public string? Reason { get; set; }

    public string? ImageUpload { get; set; }

    public string? OriginalImage { get; set; }

    public string? WoundBedImage { get; set; }

    public string? AnnotatedImage { get; set; }

    public int? PatientWoundID_FK { get; set; }

    public int? PatientWoundVisitID_FK { get; set; }

    public DateTime? AssignDate { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public string? DepthImage { get; set; }

    public decimal? DepthMax { get; set; }

    public decimal? DepthEighty { get; set; }

    public decimal? DepthSixty { get; set; }

    public decimal? DepthForty { get; set; }

    public decimal? DepthTwenty { get; set; }

    public decimal? DepthNegative { get; set; }

    public decimal? DepthNans { get; set; }

    public string? UnderMining { get; set; }

    public int? PatientID_FK { get; set; }

    public decimal? Rotation { get; set; }

    public string? OriginalImageMeasurement { get; set; }

    public string? WoundBedImageMeasurement { get; set; }

    public string? DepthImageMeasurement { get; set; }

    public string? AnnotatedImageMeasurement { get; set; }

    public decimal? SizeLength_Auto { get; set; }

    public decimal? SizeDepth_Auto { get; set; }

    public decimal? SizeWidth_Auto { get; set; }

    public string? MeasurementUpdateRemark { get; set; }

    public string? TCUpdateRemark { get; set; }

    public bool? isTCModified { get; set; }

    public bool? isWMModified { get; set; }

    public bool? isUploadImageModified { get; set; }

    public decimal? woundOverlaysImageDistance { get; set; }

    public string? woundOverlaysImage { get; set; }

    public string? TO_Comments { get; set; }

    public DateTime? NextReviewDate { get; set; }

    public DateTime? NextTreatmentDate { get; set; }

    public string? TreatmentRemarks { get; set; }

    public string? LocationRemark { get; set; }
}
