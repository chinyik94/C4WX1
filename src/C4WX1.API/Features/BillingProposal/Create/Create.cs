using C4WX1.API.Features.BillingProposal.Dtos;
using C4WX1.API.Features.BillingProposal.Mappers;
using C4WX1.API.Features.Security;
using C4WX1.API.Features.SysConfig.Constants;
using C4WX1.API.Features.SysConfig.Repository;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.BillingProposal.Create
{
    public class CreateBillingProposalSummary : EndpointSummary
    {
        public CreateBillingProposalSummary()
        {
            Summary = "Create Billing Proposal";
            Description = "Create new Billing Proposal";
            ExampleRequest = new CreateBillingProposalDto
            {
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
            Responses[200] = "Billing Proposal created successfully";
        }
    }

    public class Create(
        THCC_C4WDEVContext dbContext,
        ISysConfigRepository sysConfigRepository)
        : EndpointWithMapper<CreateBillingProposalDto, BillingProposalCreateMapper>
    {
        public override void Configure()
        {
            Post("billing-proposal");
            Summary(new CreateBillingProposalSummary());
            Description(b => b
                .Accepts<CreateBillingProposalDto>()
                .Produces(204)
                .ProducesProblemFE<InternalErrorResponse>(500));
        }

        public override async Task HandleAsync(CreateBillingProposalDto req, CancellationToken ct)
        {
            var entity = Map.ToEntity(req);
            var groupNumber = req.GroupNumber;
            var version = 1;
            if (!string.IsNullOrWhiteSpace(groupNumber))
            {
                var latestVersion = await dbContext.BillingProposal
                    .Where(x => !x.IsDeleted && x.GroupNumber == groupNumber)
                    .MaxAsync(x => x.Version, ct);
                version = latestVersion + 1;
            }
            else
            {
                groupNumber = await sysConfigRepository
                    .GenerateNewBillingProposalNumberAsync(req.UserId, ct);
            }
            entity.GroupNumber = groupNumber;
            entity.Version = (short)version;
            var enterpriseAbbr = sysConfigRepository.GetEnterpriseAbbrAsync(ct);
            entity.ProposalNumber = $"{enterpriseAbbr}P{groupNumber}-{version}";

            dbContext.BillingProposal.Add(entity);
            await dbContext.SaveChangesAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
