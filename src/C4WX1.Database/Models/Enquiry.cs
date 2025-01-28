using System;
using System.Collections.Generic;

namespace C4WX1.Database.Models;

public partial class Enquiry
{
    public int EnquiryID { get; set; }

    public int? CareManagerAssignedID_FK { get; set; }

    public int? EnquirySourceID_FK { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? RaceID_FK { get; set; }

    public string? IdentificationNumber { get; set; }

    public int? PreferredLanguageID_FK { get; set; }

    public int? GenderID_FK { get; set; }

    public string? PatientAddress1 { get; set; }

    public string? PatientAddress2 { get; set; }

    public string? PatientAddress3 { get; set; }

    public string? PostalCode { get; set; }

    public string? NameOfCaller { get; set; }

    public string? ContactNumberOfCaller { get; set; }

    public string? EmailOfCaller { get; set; }

    public DateTime? PreferredAppointmentDateTime { get; set; }

    public string? MedicalHistory { get; set; }

    public int? CaregiverAtHomeID_FK { get; set; }

    public int? ServicesRequiredID_FK { get; set; }

    public string? Status { get; set; }

    public string? Remarks { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy_FK { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy_FK { get; set; }

    public bool? IsDeleted { get; set; }

    public string? OtherRace { get; set; }

    public string? OtherPreferredLanguage { get; set; }

    public int? UserOrganizationID_FK { get; set; }

    public string? CaseNumber { get; set; }

    public string? Note { get; set; }

    public string? OrderID { get; set; }

    public virtual Users? CareManagerAssignedID_FKNavigation { get; set; }

    public virtual Code? CaregiverAtHomeID_FKNavigation { get; set; }

    public virtual ICollection<EnquiryAttachment> EnquiryAttachment { get; set; } = new List<EnquiryAttachment>();

    public virtual ICollection<EnquiryLanguage> EnquiryLanguage { get; set; } = new List<EnquiryLanguage>();

    public virtual ICollection<EnquiryServicesRequired> EnquiryServicesRequired { get; set; } = new List<EnquiryServicesRequired>();

    public virtual Code? EnquirySourceID_FKNavigation { get; set; }

    public virtual Code? GenderID_FKNavigation { get; set; }

    public virtual Code? PreferredLanguageID_FKNavigation { get; set; }

    public virtual Code? RaceID_FKNavigation { get; set; }

    public virtual Code? ServicesRequiredID_FKNavigation { get; set; }

    public virtual Code? UserOrganizationID_FKNavigation { get; set; }
}
