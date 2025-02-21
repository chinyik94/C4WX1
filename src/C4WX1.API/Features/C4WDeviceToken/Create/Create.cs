﻿using C4WX1.API.Features.C4WDeviceToken.Dtos;
using C4WX1.API.Features.C4WDeviceToken.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.C4WDeviceToken.Create
{
    public class CreateC4WDeviceTokenSummary : EndpointSummary
    {
        public CreateC4WDeviceTokenSummary()
        {
            Summary = "Create C4W Device Token";
            Description = "Create a new C4W Device Token";
            ExampleRequest = new CreateC4WDeviceTokenDto
            {
                OldDeviceToken = "Old Token",
                NewDeviceToken = "New Token",
                ClientEnvironment = "test env",
                Device = "Iphone",
                UserId = 1
            };
            Responses[200] = "C4W Device Token created successfully";
        }
    }

    public class Create(THCC_C4WDEVContext dbContext)
        : EndpointWithMapper<CreateC4WDeviceTokenDto, CreateC4WDeviceTokenMapper>
    {
        public override void Configure()
        {
            Post("c4w-device-token");
            Summary(new CreateC4WDeviceTokenSummary());
            Description(b => b
                .Accepts<CreateC4WDeviceTokenDto>()
                .ProducesProblemFE<InternalErrorResponse>(500));
        }

        public override async Task HandleAsync(CreateC4WDeviceTokenDto req, CancellationToken ct)
        {
            var entity = Map.ToEntity(req);
            dbContext.C4WDeviceToken.Add(entity);
            await dbContext.SaveChangesAsync(ct);
            await SendNoContentAsync(ct);
        }
    }
}
