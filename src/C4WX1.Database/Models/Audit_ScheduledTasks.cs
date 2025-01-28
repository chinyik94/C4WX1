using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Audit_ScheduledTasks
{
    public string AuditAction { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public int ScheduleId { get; set; }

    public string ScheduleDescription { get; set; } = null!;

    public string PerformTask { get; set; } = null!;

    public bool Everyday { get; set; }

    public bool Weekday { get; set; }

    public int NDays { get; set; }

    public string WeekDays { get; set; } = null!;

    public DateTime? TimeStart { get; set; }

    public DateTime? TimeEnd { get; set; }

    public int Interval { get; set; }

    public string IntervalType { get; set; } = null!;

    public DateTime? StartDate { get; set; }

    public DateTime? NextRun { get; set; }

    public DateTime? LastRun { get; set; }

    public string Status { get; set; } = null!;
}
