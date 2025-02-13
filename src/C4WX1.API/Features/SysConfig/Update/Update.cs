using C4WX1.API.Features.SysConfig.Dtos;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.SysConfig.Update
{
    public class UpdateSysConfigSummary : EndpointSummary
    {
        public UpdateSysConfigSummary()
        {
            Summary = "Update SysConfig";
            Description = "Update one or multiple existing SysConfigs";
            ExampleRequest = new List<UpdateSysConfigDto>
            {
                new() {
                    ConfigName = "Config1",
                    ConfigValue = "Value1",
                    UserID = 1
                },
                new() {
                    ConfigName = "Config2",
                    ConfigValue = "Value2",
                    UserID = 1
                },
            };
            Responses[204] = "SysConfig updated successfully";
            Responses[404] = "SysConfig not found";
        }
    }

    public class Update(
        THCC_C4WDEVContext dbContext): Endpoint<List<UpdateSysConfigDto>>
    {
        public override void Configure()
        {
            Put("sysconfig");
            Description(b => b
                .Accepts<IEnumerable<UpdateSysConfigDto>>("application/json")
                .Produces(204)
                .Produces(404)
                .ProducesProblemFE<InternalErrorResponse>(500));
            Summary(new UpdateSysConfigSummary());
        }

        public override async Task HandleAsync(List<UpdateSysConfigDto> req, CancellationToken ct)
        {
            var configNames = req.Select(r => r.ConfigName);
            var entityDict = await dbContext.SysConfig
                .Where(x => configNames.Contains(x.ConfigName))
                .ToDictionaryAsync(x => x.ConfigName, ct);

            if (entityDict == null || entityDict.Count == 0)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            foreach (var request in req)
            {
                if (entityDict.TryGetValue(request.ConfigName, out var entity))
                {
                    entity.ConfigValue = request.ConfigValue;
                    entity.ModifiedBy_FK = request.UserID;
                    entity.ModifiedDate = DateTime.Now;
                }
            }

            await dbContext.SaveChangesAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
