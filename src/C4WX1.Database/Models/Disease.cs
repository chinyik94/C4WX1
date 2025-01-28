using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Disease
{
    public int DiseaseID { get; set; }

    public string DiseaseName { get; set; } = null!;

    public int SystemID_FK { get; set; }

    public bool IsAdditionalInfo { get; set; }

    public bool IsSuggestPalliativeCare { get; set; }

    public bool IsSystemUsed { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public string? AdditionalInfo { get; set; }

    public string? DiseaseCode { get; set; }

    public virtual ICollection<Activity> Activity { get; set; } = new List<Activity>();

    public virtual ICollection<CPGoals> CPGoals { get; set; } = new List<CPGoals>();

    public virtual ICollection<CarePlanDetail> CarePlanDetail { get; set; } = new List<CarePlanDetail>();

    public virtual ICollection<CarePlanSubGoal> CarePlanSubGoal { get; set; } = new List<CarePlanSubGoal>();

    public virtual ICollection<DiseaseInfo> DiseaseInfo { get; set; } = new List<DiseaseInfo>();

    public virtual ICollection<DiseaseSubInfo> DiseaseSubInfo { get; set; } = new List<DiseaseSubInfo>();

    public virtual ICollection<DiseaseVitalSignType> DiseaseVitalSignType { get; set; } = new List<DiseaseVitalSignType>();

    public virtual ICollection<Intervention> Intervention { get; set; } = new List<Intervention>();

    public virtual ICollection<PatientClinician> PatientClinician { get; set; } = new List<PatientClinician>();

    public virtual ICollection<PatientFamilyHistory> PatientFamilyHistory { get; set; } = new List<PatientFamilyHistory>();

    public virtual ICollection<PatientMedicationConsume> PatientMedicationConsume { get; set; } = new List<PatientMedicationConsume>();

    public virtual ICollection<ProblemList> ProblemList { get; set; } = new List<ProblemList>();

    public virtual SystemForDisease SystemID_FKNavigation { get; set; } = null!;
}
