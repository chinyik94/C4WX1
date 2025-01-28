﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_CareReportRehabilitation
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int CareReportRehabilitationID { get; set; }

    public bool? IsADLAssistance { get; set; }

    public string? ADLAssistanceType { get; set; }

    public string? Bounded { get; set; }

    public int? NoOfTimesTurned { get; set; }

    public int? NoOfSatOutOfBed { get; set; }

    public bool? IsDVTPrevention { get; set; }

    public string? DVTType { get; set; }

    public bool? RequirePhysioTherapist { get; set; }

    public int? VisitForPhysioTherapist { get; set; }

    public bool? RequireOccupationTherapist { get; set; }

    public int? VisitForOccupationTherapist { get; set; }

    public bool? RequireSpeechTherapist { get; set; }

    public int? VisitForSpeechTherapist { get; set; }

    public bool? RequireWalkingAid { get; set; }

    public string? WalkingAidType { get; set; }

    public bool? IsUpperLimbStrengthLeft { get; set; }

    public bool? IsUpperLimbStrengthRight { get; set; }

    public int? UpperLimbStrengthLeft { get; set; }

    public int? UpperLimbStrengthRight { get; set; }

    public bool? IsLowerLimbStrengthLeft { get; set; }

    public bool? IsLowerLimbStrengthRight { get; set; }

    public int? LowerLimbStrengthLeft { get; set; }

    public int? LowerLimbStrengthRight { get; set; }

    public string? RehabilitationRemarks { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }
}
