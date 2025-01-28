﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_PatientNutrition
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int PatientNutritionID { get; set; }

    public string? EatingAndSwallowing { get; set; }

    public string? EatingAndSwallowingTypeOfTubeFeeding { get; set; }

    public string? EatingAndSwallowingTypeOfTube { get; set; }

    public string? EatingAndSwallowingSize { get; set; }

    public DateTime? EatingAndSwallowingDateInserted { get; set; }

    public DateTime? EatingAndSwallowingDateDue { get; set; }

    public string? Diet { get; set; }

    public string? Appetite { get; set; }

    public string? FluidConsistency { get; set; }

    public decimal? FluidRestrictionMLSPerDay { get; set; }

    public bool? ReviewedBySpeechTherapist { get; set; }

    public bool? ReferralToSpeechTherapist { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public string? Enteralfeeding { get; set; }

    public string? SizeofPEGJtube { get; set; }

    public string? IVtherapyStateType { get; set; }

    public bool? SwallowingIssues { get; set; }

    public bool? DiagnosedDysphasia { get; set; }

    public bool? IsFIsluidRestriction { get; set; }

    public bool? IVtherapy { get; set; }

    public decimal? IVtherapyMLSPerDay { get; set; }

    public decimal? MilkFeedAmt { get; set; }

    public decimal? WaterPerDay { get; set; }

    public DateTime? DiagnosedDysphasiaLastReviewDate { get; set; }
}
