using C4WX1.API.Features.Activity.Dtos;
using C4WX1.API.Features.Activity.Mappers;
using C4WX1.API.Features.Activity.Sqls;
using C4WX1.API.Features.Shared;
using C4WX1.Database.Models;
using Dapper;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.Activity.Get
{
    public class GetActivityByIdSummary : EndpointSummary
    {
        public GetActivityByIdSummary()
        {
            Summary = "Get Activity";
            Description = "Get an Activity by its ID";
            Responses[200] = "Activity retrieved successfully";
            Responses[404] = "Activity not found";
        }
    }

    public class GetById(
        THCC_C4WDEVContext dbContext,
        IConfiguration configuration): Endpoint<GetByIdRequestDto, ActivityDto, ActivityMapper>
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

        public override async Task HandleAsync(GetByIdRequestDto req, CancellationToken ct)
        {
            var entity = await dbContext.Activity
                .FirstOrDefaultAsync(x => x.ActivityID == req.Id && !x.IsDeleted, ct);
            if (entity == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            var dto = Map.FromEntity(entity);
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            using var connection = new NpgsqlConnection(connectionString);
            dto.CanDelete = await connection.QuerySingleAsync<bool>(
                ActivitySqls.GetCanDeleteActivity, 
                new { ActivityID = req.Id });

            await SendAsync(dto, cancellation: ct);
        }
    }
}
