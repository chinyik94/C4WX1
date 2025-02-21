using C4WX1.API.Features.BillingProposal.Dtos;
using FastEndpoints;

namespace C4WX1.API.Features.BillingProposal.Mappers
{
    public class BillingProposalCreateMapper : RequestMapper<CreateBillingProposalDto, Database.Models.BillingProposal>
    {
        public override Database.Models.BillingProposal ToEntity(CreateBillingProposalDto r) => new()
        {
            PatientID_FK = r.PatientID_FK,
            Title = r.Title,
            SendEmail = r.SendEmail,
            EmailPatient = r.EmailPatient,
            EmailTo = r.EmailTo,
            EmailCC = r.EmailCC,
            EmailBCC = r.EmailBCC,
            CurrencyID_FK = r.CurrencyID_FK,
            Status = r.Status,
            TotalCost = r.ServiceList.Sum(x => x.Session * x.UnitCost * ((100 - x.Discount) / 100)),
            ProposalType = r.ProposalType,
            CreatedBy_FK = r.UserId,
            CreatedDate = DateTime.Now,
            IsDeleted = false,
            BillingProposalService = r.ServiceList
                .Select(x => new Database.Models.BillingProposalService
                {
                    ServiceID_FK = x.ServiceID_FK,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Visit = x.Visit,
                    UnitCost = x.UnitCost,
                    Duration1 = x.Duration1,
                    Duration2 = x.Duration2,
                    Session = x.Session,
                    Discount = x.Discount,
                    ServiceDescription = x.ServiceDescription,
                    CreatedBy_FK = r.UserId,
                    CreatedDate = DateTime.Now
                })
                .ToList()
        };
    }
}
