using C4WX1.API.Features.BillingProposal.Dtos;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.BillingProposal.Update
{
    public class UpdateBillingProposalSummary : EndpointSummary
    {
        public UpdateBillingProposalSummary()
        {
            Summary = "Update Billing Proposal";
            Description = "Update Billing Proposal by its ID";
            ExampleRequest = new UpdateBillingProposalDto
            {
                Id = 1,
                PatientID_FK = 1,
                Title = "Title",
                SendEmail = true,
                EmailPatient = true,
                EmailTo = "test-to@gmail.com",
                EmailCC = "test-cc@gmail.com",
                EmailBCC = "test-bcc@gmail.com",
                CurrencyID_FK = 1,
                Status = "Active",
                GroupNumber = "1",
                Version = 1,
                ProposalType = "ProposalType",
                UserId = 1,
                ServiceList = [
                    new BillingProposalServiceDto{
                        ServiceID_FK = 1,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        UnitCost = 0M,
                        Duration1 = "Duration1",
                        Duration2 = "Duration2",
                        Visit = 1,
                        Discount = 0M,
                        ServiceDescription = "ServiceDescription"
                    }
                    ]
            };
            Responses[204] = "Billing Proposal updated successfully";
            Responses[404] = "Billing Proposal not found";
        }
    }

    public class Update(THCC_C4WDEVContext dbContext)
        : Endpoint<UpdateBillingProposalDto>
    {
        public override void Configure()
        {
            Put("billing-proposal/{id}");
            Summary(new UpdateBillingProposalSummary());
            Description(b => b
                .Accepts<UpdateBillingProposalDto>()
                .Produces(404)
                .ProducesProblemFE<InternalErrorResponse>(500));
        }

        public override async Task HandleAsync(UpdateBillingProposalDto req, CancellationToken ct)
        {
            var entity = await dbContext.BillingProposal
                .Where(x => !x.IsDeleted && x.BillingProposalID == req.Id)
                .FirstOrDefaultAsync(ct);

            if (entity == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            if ((req.Status == Statuses.Draft && entity.Status == Statuses.Sent)
                || req.Status == Statuses.Sent)
            {
                req.Id = 0;
                entity.Status = string.Empty;
                entity = new Database.Models.BillingProposal();
            }

            entity.PatientID_FK = req.PatientID_FK;
            entity.Title = req.Title;
            entity.SendEmail = req.SendEmail;
            entity.EmailPatient = req.EmailPatient;
            entity.EmailTo = req.EmailTo;
            entity.EmailCC = req.EmailCC;
            entity.EmailBCC = req.EmailBCC;
            entity.CurrencyID_FK = req.CurrencyID_FK;
            entity.Status = req.Status;
            entity.TotalCost = req.ServiceList
                .Sum(x => x.Session * x.UnitCost * ((100 - x.Discount) / 100));
            entity.ProposalType = req.ProposalType;
            entity.ModifiedBy_FK = req.UserId;
            entity.ModifiedDate = DateTime.Now;

            var servicesLookup = req.ServiceList
                .ToDictionary(x => x.BillingInvoiceServiceID);

            foreach (var item in entity.BillingProposalService
                .Where(x => !x.IsDeleted && !servicesLookup.ContainsKey(x.BillingProposalServiceID)))
            {
                item.IsDeleted = true;
                item.ModifiedBy_FK = req.UserId;
                item.ModifiedDate = DateTime.Now;
            }

            foreach (var item in entity.BillingProposalService
                .Where(x => !x.IsDeleted && servicesLookup.ContainsKey(x.BillingProposalServiceID)))
            {
                var service = servicesLookup[item.BillingProposalServiceID];
                item.ServiceID_FK = service.ServiceID_FK;
                item.StartDate = service.StartDate;
                item.EndDate = service.EndDate;
                item.Visit = service.Visit;
                item.UnitCost = service.UnitCost;
                item.Duration1 = service.Duration1;
                item.Duration2 = service.Duration2;
                item.Session = service.Session;
                item.Discount = service.Discount;
                item.ServiceDescription = service.ServiceDescription;
                item.ModifiedBy_FK = req.UserId;
                item.ModifiedDate = DateTime.Now;
            }

            foreach (var item in req.ServiceList
                .Where(x => x.BillingInvoiceServiceID == 0))
            {
                entity.BillingProposalService.Add(new BillingProposalService
                {
                    ServiceID_FK = item.ServiceID_FK,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    Visit = item.Visit,
                    UnitCost = item.UnitCost,
                    Duration1 = item.Duration1,
                    Duration2 = item.Duration2,
                    Session = item.Session,
                    Discount = item.Discount,
                    ServiceDescription = item.ServiceDescription,
                    CreatedBy_FK = req.UserId,
                    CreatedDate = DateTime.Now
                });
            }

            await dbContext.SaveChangesAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
