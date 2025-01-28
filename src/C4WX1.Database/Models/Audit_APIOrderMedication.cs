using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_APIOrderMedication
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int APIOrderMedicationID { get; set; }

    public int APIOrderID_FK { get; set; }

    public int? MedicationID { get; set; }

    public string? MedicationName { get; set; }

    public string? MedicationStatus { get; set; }

    public int? MedicationQuantity { get; set; }

    public string? MedicationQuantityUnit { get; set; }

    public int? MedicationFrequencyID { get; set; }

    public int? MedicationFrequency { get; set; }

    public int? MedicationPeriod { get; set; }

    public string? MedicationPeriodUnit { get; set; }

    public bool? MedicationAsNeeded { get; set; }

    public string? MedicationDisplay { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public int? DosageID_FK { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}
