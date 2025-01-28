using C4WX1.Database.Models;
using FastEndpoints;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.SysConfig.Create
{
    public class CreateSysConfigDto
    {
        public string ConfigName { get; set; } = null!;
        public string? ConfigValue { get; set; }
        public bool? IsConfigurable { get; set; }
        public string? Description { get; set; }
    }

    public class CreateSysConfigSummary : EndpointSummary
    {
        public CreateSysConfigSummary()
        {
            Summary = $"Create {nameof(SysConfig)}";
            Description = $"Create a new {nameof(SysConfig)}";
            ExampleRequest = new CreateSysConfigDto
            {
                ConfigName = "Config Name",
                ConfigValue = "Config Value",
                IsConfigurable = false,
                Description = "Description"
            };
            Responses[204] = $"{nameof(SysConfig)} created successfully";
        }
    }

    public class Create(
        THCC_C4WDEVContext dbContext): Endpoint<CreateSysConfigDto>
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
            var entity = new Database.Models.SysConfig
            {
                ConfigName = req.ConfigName,
                ConfigValue = req.ConfigValue,
                IsConfigurable = req.IsConfigurable,
                Description = req.Description
            };
            dbContext.SysConfig.Add(entity);
            await dbContext.SaveChangesAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
