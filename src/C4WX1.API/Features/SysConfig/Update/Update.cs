using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace C4WX1.API.Features.SysConfig.Update
{
    public class UpdateSysConfigDto
    {
        public string ConfigName { get; set; } = null!;
        public string ConfigValue { get; set; } = null!;
        public int UserID { get; set; }
    }

    public class UpdateSysConfigSummary : EndpointSummary
    {
        public UpdateSysConfigSummary()
        {
            Summary = $"Update {nameof(SysConfig)}";
            Description = $"Update an existing {nameof(SysConfig)}";
            ExampleRequest = new UpdateSysConfigDto
            {
                ConfigName = nameof(UpdateSysConfigDto.ConfigName),
                ConfigValue = nameof(UpdateSysConfigDto.ConfigValue),
                UserID = 1
            };
            Responses[204] = $"{nameof(SysConfig)} updated successfully";
            Responses[404] = $"{nameof(SysConfig)} not found";
        }
    }

    public class Update(
        THCC_C4WDEVContext context): Endpoint<UpdateSysConfigDto>
    {
        public override void Configure()
        {
            Put("sysconfig");
            Description(b => b
                .Accepts<UpdateSysConfigDto>("application/json")
                .Produces(204)
                .Produces(404)
                .ProducesProblemFE<InternalErrorResponse>(500));
            Summary(new UpdateSysConfigSummary());
        }

        public override async System.Threading.Tasks.Task HandleAsync(UpdateSysConfigDto req, CancellationToken ct)
        {
            var entity = await context.SysConfig
                .FirstOrDefaultAsync(x => x.ConfigName == req.ConfigName, ct);
            if (entity == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            entity.ConfigValue = req.ConfigValue;
            entity.ModifiedBy_FK = req.UserID;
            entity.ModifiedDate = DateTime.Now;
            await context.SaveChangesAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
