using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Users
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string? Remarks { get; set; }

    public string? Photo { get; set; }

    public string? Contact { get; set; }

    public string? Designation { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public DateTime? LastLogoutDate { get; set; }

    public DateTime? LastActivityDate { get; set; }

    public DateTime? LastLockoutDate { get; set; }

    public DateTime? LastPasswordChangedDate { get; set; }

    public string? PreviousPasswords { get; set; }

    public string? SessionKey { get; set; }

    public bool? ResetPassword { get; set; }

    public bool IsDeleted { get; set; }

    public string? LocationNow1 { get; set; }

    public string? LocationNow2 { get; set; }

    public string? LocationNow3 { get; set; }

    public string? PostalCodeNow { get; set; }

    public DateTime? LocationNowModifiedDate { get; set; }

    public int? PatientID_FK { get; set; }

    public bool IsExternal { get; set; }

    public int? UserOrganizationID_FK { get; set; }

    public bool? IsTCAccepted { get; set; }

    public string? UserName { get; set; }

    public int? PreferredLanguage { get; set; }

    public int? AccessLevelID_FK { get; set; }

    public bool HasValidEmail { get; set; }

    public string? TokenID { get; set; }

    public string? PreviousPasswords2 { get; set; }

    public bool? SharePdf { get; set; }

    public virtual ICollection<AuditTrail> AuditTrail { get; set; } = new List<AuditTrail>();

    public virtual ICollection<BillingInvoice> BillingInvoiceCreatedBy_FKNavigation { get; set; } = new List<BillingInvoice>();

    public virtual ICollection<BillingInvoice> BillingInvoiceModifiedBy_FKNavigation { get; set; } = new List<BillingInvoice>();

    public virtual ICollection<BillingProposal> BillingProposalCreatedBy_FKNavigation { get; set; } = new List<BillingProposal>();

    public virtual ICollection<BillingProposal> BillingProposalModifiedBy_FKNavigation { get; set; } = new List<BillingProposal>();

    public virtual ICollection<CareReport> CareReport { get; set; } = new List<CareReport>();

    public virtual ICollection<CareReportSystemInfo> CareReportSystemInfoKeyPerson1UserID_FKNavigation { get; set; } = new List<CareReportSystemInfo>();

    public virtual ICollection<CareReportSystemInfo> CareReportSystemInfoKeyPerson2UserID_FKNavigation { get; set; } = new List<CareReportSystemInfo>();

    public virtual ICollection<Chat> Chat { get; set; } = new List<Chat>();

    public virtual ICollection<Enquiry> Enquiry { get; set; } = new List<Enquiry>();

    public virtual ICollection<EnquiryConfig> EnquiryConfigEscalatingPersonID_FKNavigation { get; set; } = new List<EnquiryConfig>();

    public virtual ICollection<EnquiryConfig> EnquiryConfigSCMID_FKNavigation { get; set; } = new List<EnquiryConfig>();

    public virtual ICollection<EnquiryEscPerson> EnquiryEscPerson { get; set; } = new List<EnquiryEscPerson>();

    public virtual ICollection<EnquirySCM> EnquirySCM { get; set; } = new List<EnquirySCM>();

    public virtual ICollection<Event> Event { get; set; } = new List<Event>();

    public virtual ICollection<EventUser> EventUser { get; set; } = new List<EventUser>();

    public virtual ICollection<EventUserLog> EventUserLog { get; set; } = new List<EventUserLog>();

    public virtual ICollection<MobileAppVersioning> MobileAppVersioningCreatedBy_FKNavigation { get; set; } = new List<MobileAppVersioning>();

    public virtual ICollection<MobileAppVersioning> MobileAppVersioningModifiedBy_FKNavigation { get; set; } = new List<MobileAppVersioning>();

    public virtual ICollection<Notifications> Notifications { get; set; } = new List<Notifications>();

    public virtual ICollection<PatientClinician> PatientClinician { get; set; } = new List<PatientClinician>();

    public virtual Patient? PatientID_FKNavigation { get; set; }

    public virtual ICollection<PatientWoundReviewBy> PatientWoundReviewBy { get; set; } = new List<PatientWoundReviewBy>();

    public virtual ICollection<PatientWoundVisit> PatientWoundVisit { get; set; } = new List<PatientWoundVisit>();

    public virtual ICollection<PatientWoundVisitClinician> PatientWoundVisitClinician { get; set; } = new List<PatientWoundVisitClinician>();

    public virtual ICollection<Receipt> ReceiptCreatedBy_FKNavigation { get; set; } = new List<Receipt>();

    public virtual ICollection<Receipt> ReceiptModifiedBy_FKNavigation { get; set; } = new List<Receipt>();

    public virtual ICollection<RecentView> RecentView { get; set; } = new List<RecentView>();

    public virtual ICollection<Task> Task { get; set; } = new List<Task>();

    public virtual ICollection<TaskUser> TaskUser { get; set; } = new List<TaskUser>();

    public virtual ICollection<TaskUserLog> TaskUserLog { get; set; } = new List<TaskUserLog>();

    public virtual ICollection<UserAddress> UserAddress { get; set; } = new List<UserAddress>();

    public virtual ICollection<UserBranch> UserBranch { get; set; } = new List<UserBranch>();

    public virtual ICollection<UserLanguage> UserLanguage { get; set; } = new List<UserLanguage>();

    public virtual ICollection<UserOrganization> UserOrganization { get; set; } = new List<UserOrganization>();

    public virtual ICollection<UserRole> UserRole { get; set; } = new List<UserRole>();

    public virtual ICollection<UserSkillset> UserSkillset { get; set; } = new List<UserSkillset>();

    public virtual ICollection<UserUserType> UserUserType { get; set; } = new List<UserUserType>();
}
