using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class PatientMedicationConsume
{
    public int PatientMedicationConsumeID { get; set; }

    public int PatientMedicationID_FK { get; set; }

    public int? MedicationID_FK { get; set; }

    public int? RouteID_FK { get; set; }

    public int? DosageID_FK { get; set; }

    public int? FrequencyID_FK { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Indication { get; set; }

    public string? ReasonOfDiscontinue { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public int? ChronicDiseaseID_FK { get; set; }

    public int? ChronicDiseaseSubInfoID_FK { get; set; }

    public int? AcutePRNIndicationID_FK { get; set; }

    public int? ReferID_FK { get; set; }

    public int? InstructedByID_FK { get; set; }

    public string? DrName { get; set; }

    public string? DrContact { get; set; }

    public string? MCRNo { get; set; }

    public string? ClinicHosp { get; set; }

    public int? InstructedBy2ID_FK { get; set; }

    public string? DrNameED { get; set; }

    public string? DrContactED { get; set; }

    public string? MCRNoED { get; set; }

    public string? ClinicHospED { get; set; }

    public virtual Code? AcutePRNIndicationID_FKNavigation { get; set; }

    public virtual Disease? ChronicDiseaseID_FKNavigation { get; set; }

    public virtual DiseaseSubInfo? ChronicDiseaseSubInfoID_FKNavigation { get; set; }

    public virtual Code? DosageID_FKNavigation { get; set; }

    public virtual Code? FrequencyID_FKNavigation { get; set; }

    public virtual Code? InstructedBy2ID_FKNavigation { get; set; }

    public virtual Code? InstructedByID_FKNavigation { get; set; }

    public virtual ICollection<PatientMedicationConsume> InverseReferID_FKNavigation { get; set; } = new List<PatientMedicationConsume>();

    public virtual Code? MedicationID_FKNavigation { get; set; }

    public virtual ICollection<PatientMedicationConsumeAttachment> PatientMedicationConsumeAttachment { get; set; } = new List<PatientMedicationConsumeAttachment>();

    public virtual PatientMedication PatientMedicationID_FKNavigation { get; set; } = null!;

    public virtual PatientMedicationConsume? ReferID_FKNavigation { get; set; }

    public virtual Code? RouteID_FKNavigation { get; set; }
}
