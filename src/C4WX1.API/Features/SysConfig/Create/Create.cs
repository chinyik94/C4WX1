using C4WX1.API.Features.SysConfig.Dtos;
using C4WX1.API.Features.SysConfig.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.SysConfig.Create
{
    public class CreateSysConfigSummary : EndpointSummary
    {
        public CreateSysConfigSummary()
        {
            Summary = "Create SysConfig";
            Description = "Create a new SysConfig";
            ExampleRequest = new CreateSysConfigDto
            {
                ConfigName = "Config Name",
                ConfigValue = "Config Value",
                IsConfigurable = false,
                Description = "Description"
            };
            Responses[204] = "SysConfig created successfully";
        }
    }

    public class Create(
        THCC_C4WDEVContext dbContext): EndpointWithMapper<CreateSysConfigDto, SysConfigCreateMapper>
    {
        public override void Configure()
        {
            Post("sysconfig");
            Description(b => b
                .Accepts<CreateSysConfigDto>("application/json")
                .Produces(204));
            Summary(new CreateSysConfigSummary());
        }

        public override async Task HandleAsync(CreateSysConfigDto req, CancellationToken ct)
        {
            var entity = Map.ToEntity(req);
            dbContext.SysConfig.Add(entity);
            await dbContext.SaveChangesAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
