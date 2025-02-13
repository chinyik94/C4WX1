﻿using C4WX1.API.Features.SysConfig.Dtos;
using C4WX1.API.Features.SysConfig.Mappers;
using C4WX1.Database.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.API.Features.SysConfig.Get
{
    public class GetAllSysConfigListSummary : EndpointSummary
    {
        public GetAllSysConfigListSummary()
        {
            Summary = "Get All SysConfig";
            Description = "Get all SysConfigs";
            Responses[200] = "SysConfig List retrieved successfully";
        }
    }

    public class GetAllList(
        THCC_C4WDEVContext dbContext) : EndpointWithoutRequest<IEnumerable<SysConfigDto>, SysConfigGetMapper>
    {
        public override void Configure()
        {
            Get("sysconfig/list/all");
            AllowAnonymous();
            Description(b => b
                .Produces<IEnumerable<SysConfigDto>>()
                .ProducesProblemFE<InternalErrorResponse>(500));
            Summary(new GetAllSysConfigListSummary());
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var dtos = await dbContext.SysConfig
                .Select(x => Map.FromEntity(x))
                .ToListAsync(ct);

            await SendAsync(dtos, cancellation: ct);
        }
    }
}
