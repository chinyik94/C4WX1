using C4WX1.API.Features.BillingProposal.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.BillingProposal.Mappers
{
    public class BillingProposalMapper : ResponseMapper<BillingProposalDto, Database.Models.BillingProposal>
    {
        public override BillingProposalDto FromEntity(Database.Models.BillingProposal e) => new()
        {
            BillingProposalID = e.BillingProposalID,
            ProposalNumber = e.ProposalNumber,
            PatientID_FK = e.PatientID_FK,
            Title = e.Title,
            SendEmail = e.SendEmail,
            EmailPatient = e.EmailPatient,
            EmailTo = e.EmailTo,
            EmailCC = e.EmailCC,
            EmailBCC = e.EmailBCC,
            CurrencyID_FK = e.CurrencyID_FK,
            CurrencyCode = e.CurrencyID_FKNavigation.CodeName,
            TotalCost = e.TotalCost,
            GroupNumber = e.GroupNumber,
            Version = e.Version,
            Status = e.Status,
            CreatedDate = e.CreatedDate,
            CreatedBy_FK = e.CreatedBy_FK,
            ModifiedDate = e.ModifiedDate,
            ModifiedBy_FK = e.ModifiedBy_FK,
            ProposalType = e.ProposalType,
            PatientData = new BillingProposalPatientDto
            {
                PatientID = e.PatientID_FK,
                FirstName = e.PatientID_FKNavigation.Firstname,
                LastName = e.PatientID_FKNavigation.Lastname,
                Photo = e.PatientID_FKNavigation.Photo,
                MailingAddress1 = e.PatientID_FKNavigation.MailingAddress1,
                MailingAddress2 = e.PatientID_FKNavigation.MailingAddress2,
                MailingAddress3 = e.PatientID_FKNavigation.MailingAddress3,
                MailingPostalCode = e.PatientID_FKNavigation.PostalCode,
                Profile = e.PatientID_FKNavigation.PatientProfileID_FKNavigation == null
                    ? null
                    : new BillingProposalPatientProfileDto
                    {
                        Email = e.PatientID_FKNavigation.PatientProfileID_FKNavigation.Email
                    }
            },
            CreatedByData = new BillingProposalUserDto
            {
                UserId = e.CreatedBy_FK,
                FirstName = e.CreatedBy_FKNavigation.Firstname,
                LastName = e.CreatedBy_FKNavigation.Lastname,
                Photo = e.CreatedBy_FKNavigation.Photo,
                Email = e.CreatedBy_FKNavigation.Email
            },
            ModifiedByData = e.ModifiedBy_FKNavigation == null
                ? null
                : new BillingProposalUserDto
                {
                    UserId = e.ModifiedBy_FKNavigation.UserId,
                    FirstName = e.ModifiedBy_FKNavigation.Firstname,
                    LastName = e.ModifiedBy_FKNavigation.Lastname,
                    Photo = e.ModifiedBy_FKNavigation.Photo,
                    Email = e.ModifiedBy_FKNavigation.Email
                },
            ServiceList = e.BillingProposalService
                .Where(x => !x.IsDeleted)
                .Select(x => new BillingProposalServiceDto
                {
                    BillingInvoiceServiceID = x.BillingProposalServiceID,
                    BillingProposalID_FK = x.BillingProposalID_FK,
                    ServiceID_FK = x.ServiceID_FK,
                    CategoryId = x.ServiceID_FKNavigation.CategoryID_FK,
                    Title = x.ServiceID_FKNavigation.Title,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    UnitCost = x.UnitCost,
                    Duration1 = x.Duration1,
                    Duration2 = x.Duration2,
                    Visit = x.Visit,
                    Session = x.Session,
                    Discount = x.Discount,
                    ServiceDescription = x.ServiceDescription,
                    CategoryName = x.ServiceID_FKNavigation.CategoryID_FKNavigation.CodeName
                })
        };
    }
}
