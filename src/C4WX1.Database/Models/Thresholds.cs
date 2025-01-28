﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Thresholds
{
    public int id { get; set; }

    public string? name { get; set; }

    public decimal minValue { get; set; }

    public decimal maxValue { get; set; }

    public bool isDeleted { get; set; }

    public int? createdBy { get; set; }

    public DateTime createdDate { get; set; }

    public int? updatedBy { get; set; }

    public DateTime? updatedDate { get; set; }

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

    public virtual ICollection<VitalSignRelationships> VitalSignRelationships { get; set; } = new List<VitalSignRelationships>();
}
