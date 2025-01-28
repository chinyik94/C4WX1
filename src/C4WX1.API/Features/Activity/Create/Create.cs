using C4WX1.Database.Models;
using FastEndpoints;

namespace C4WX1.API.Features.Activity.Create
{
    public class CreateActivityDto
    {
        public int ProblemListID_FK { get; set; }
        public int DiseaseID_FK { get; set; }
        public string ActivityDetail { get; set; } = string.Empty;
        public int? DiseaseSubInfoID_FK { get; set; }
        public int UserId { get; set; }
    }

    public class CreateActivitySummary : EndpointSummary
    {
        public CreateActivitySummary()
        {
            Summary = $"Create {nameof(Activity)}";
            Description = $"Create a new {nameof(Activity)}";
            ExampleRequest = new CreateActivityDto
            {
                ProblemListID_FK = 1,
                DiseaseID_FK = 1,
                ActivityDetail = "Activity Detail",
                DiseaseSubInfoID_FK = 1,
                UserId = 1
            };
            Responses[204] = $"{nameof(Activity)} created successfully";
        }
    }

    public class Create(THCC_C4WDEVContext dbContext) : Endpoint<CreateActivityDto>
    {
        public override void Configure()
        {
            Post("activity");
            Description(b => b
                .Accepts<CreateActivityDto>("application/json")
                .Produces(204));
            Summary(new CreateActivitySummary());
        }

        public override async System.Threading.Tasks.Task HandleAsync(CreateActivityDto req, CancellationToken ct)
        {
            var entity = new Database.Models.Activity
            {
                ActivityDetail = req.ActivityDetail,
                CreatedBy_FK = req.UserId,
                CreatedDate = DateTime.Now,
                DiseaseID_FK = req.DiseaseID_FK,
                DiseaseSubInfoID_FK = req.DiseaseSubInfoID_FK,
                ProblemListID_FK = req.ProblemListID_FK,
                IsDeleted = false,
            };
            dbContext.Activity.Add(entity);
            await dbContext.SaveChangesAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
