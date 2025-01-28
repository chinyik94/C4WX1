﻿using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Task
{
    public int TaskID { get; set; }

    public int ActionTypeID_FK { get; set; }

    public int? PatientID_FK { get; set; }

    public int? InitialCareAssessmentID_FK { get; set; }

    public string? Description { get; set; }

    public string? Remarks { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Location { get; set; }

    public string? OtherLocation { get; set; }

    public int? FrequencyID_FK { get; set; }

    public int? DosageID_FK { get; set; }

    public decimal? MilkFeedVolumeMLS { get; set; }

    public string? Supplement { get; set; }

    public decimal? H2OFlushingMLS { get; set; }

    public string? ReferenceType { get; set; }

    public int? ReferenceID { get; set; }

    public bool? Pending { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool IsDeleted { get; set; }

    public int? MedicationID_FK { get; set; }

    public int? Recurrence_Frequency { get; set; }

    public int? Recurrence_Days { get; set; }

    public int? Recurrence_Interval { get; set; }

    public int? Recurrence_IntervalFlag { get; set; }

    public string? MedicationInstructions { get; set; }

    public int? recurrenceDailyHourly { get; set; }

    public int? UserCategory_FK { get; set; }

    public virtual Code ActionTypeID_FKNavigation { get; set; } = null!;

    public virtual Users? CreatedBy_FKNavigation { get; set; }

    public virtual Code? DosageID_FKNavigation { get; set; }

    public virtual Code? FrequencyID_FKNavigation { get; set; }

    public virtual InitialCareAssessment? InitialCareAssessmentID_FKNavigation { get; set; }

    public virtual Code? MedicationID_FKNavigation { get; set; }

    public virtual ICollection<NotificationTask> NotificationTask { get; set; } = new List<NotificationTask>();

    public virtual Patient? PatientID_FKNavigation { get; set; }

    public virtual ICollection<TaskFileAttachment> TaskFileAttachment { get; set; } = new List<TaskFileAttachment>();

    public virtual ICollection<TaskServicesRequired> TaskServicesRequired { get; set; } = new List<TaskServicesRequired>();

    public virtual ICollection<TaskSpecificDate> TaskSpecificDate { get; set; } = new List<TaskSpecificDate>();

    public virtual ICollection<TaskUser> TaskUser { get; set; } = new List<TaskUser>();

    public virtual ICollection<TaskUserLog> TaskUserLog { get; set; } = new List<TaskUserLog>();

    public virtual UserCategory? UserCategory_FKNavigation { get; set; }
}
