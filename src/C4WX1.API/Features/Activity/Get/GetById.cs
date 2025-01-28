using C4WX1.API.Features.Activity.Shared;
using C4WX1.API.Features.Shared;
using C4WX1.Database.Models;
using Dapper;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace C4WX1.API.Features.Activity.Get
{
    public class GetActivityByIdSummary : EndpointSummary
    {
        public GetActivityByIdSummary()
        {
            Summary = $"Get {nameof(Activity)} by ID";
            Description = $"Get an {nameof(Activity)} by its ID";
            Responses[200] = $"{nameof(Activity)} retrieved successfully";
            Responses[404] = $"{nameof(Activity)} not found";
        }
    }

    public class GetById(
        THCC_C4WDEVContext dbContext,
        IConfiguration configuration): Endpoint<GetByIdRequestDto, ActivityDto>
    {
        public override void Configure()
        {
            Get("activity/{Id}");
            AllowAnonymous();
            Description(b => b
                .Accepts<GetByIdRequestDto>("application/json")
                .Produces<ActivityDto>()
                .Produces(200)
                .Produces(404)
                .ProducesProblemFE<InternalErrorResponse>(500));
            Summary(new GetActivityByIdSummary());
        }

        public override async System.Threading.Tasks.Task HandleAsync(GetByIdRequestDto req, CancellationToken ct)
        {
            var entity = await dbContext.Activity
                .FirstOrDefaultAsync(a => a.ActivityID == req.Id && !a.IsDeleted, ct);
            if (entity == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            var dto = new ActivityDto()
            {
                ActivityID = entity.ActivityID,
                ActivityDetail = entity.ActivityDetail ?? string.Empty,
                CreatedBy_FK = entity.CreatedBy_FK,
                CreatedDate = entity.CreatedDate,
                DiseaseID_FK = entity.DiseaseID_FK,
                DiseaseSubInfoID_FK = entity.DiseaseSubInfoID_FK,
                IsDeleted = entity.IsDeleted,
                ModifiedBy_FK = entity.ModifiedBy_FK,
                ModifiedDate = entity.ModifiedDate,
                ProblemListID_FK = entity.ProblemListID_FK
            };

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            using var connection = new NpgsqlConnection(connectionString);
            dto.CanDelete = await connection.QuerySingleAsync<bool>(
                ActivitySqls.GetCanDeleteActivity, 
                new { ActivityID = req.Id });

            await SendAsync(dto, cancellation: ct);
        }
    }
}
