using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class vw_BradenScaleAssessmentDue
{
    public int? patientId { get; set; }

    public string? source { get; set; }

    public int? icaId { get; set; }

    public DateTime? createdDate { get; set; }

    public int? createdBy { get; set; }

    public DateTime? updatedDate { get; set; }

    public int? updatedBy { get; set; }

    public string? AssessmentName { get; set; }

    public DateTime? DueDate { get; set; }
}
