using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class vw_PatientAllLatestVitalSigns
{
    public int? patientId { get; set; }

    public DateTime? VitalSignDate { get; set; }

    public int? VitalSignDetailId { get; set; }

    public int? vitalSignTypeId { get; set; }

    public string? VitalSignTypeName { get; set; }

    public decimal? Value { get; set; }

    public decimal? ThresholdMinValue { get; set; }

    public decimal? ThresholdMaxValue { get; set; }

    public decimal? ews_min_1 { get; set; }

    public decimal? ews_max_1 { get; set; }

    public decimal? ews_min_2 { get; set; }

    public decimal? ews_max_2 { get; set; }

    public decimal? ews_min_3 { get; set; }

    public decimal? ews_max_3 { get; set; }

    public decimal? ews_min_4 { get; set; }

    public decimal? ews_max_4 { get; set; }

    public decimal? ews_min_5 { get; set; }

    public decimal? ews_max_5 { get; set; }

    public decimal? ews_min_6 { get; set; }

    public decimal? ews_max_6 { get; set; }

    public decimal? ews_min_7 { get; set; }

    public decimal? ews_max_7 { get; set; }

    public long? Index { get; set; }
}
